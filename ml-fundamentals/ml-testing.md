# Testing Data Science and MLOps code

The purpose of this document is to provide samples of tests for the most common operations in MLOps/Data Science projects. Testing the code used for MLOps or data science projects follows the same principles of any other software project.

Some scenarios might seem different or more difficult to test. The best way to approach this is to always have a test design session, where the focus is on the input/outputs, exceptions and testing the behavior of data transformations. Designing the tests first makes it easier to test as it forces a more modular style, where each function has one purpose, and extracting common functionality functions and modules.

Below are some common operations in MLOps or Data Science projects, along with suggestions on how to test them.

* [Saving and loading data](#saving-and-loading-data)
* [Transforming data](#transforming-data)
* [Model load or predict](#model-load-or-predict)
* [Data validation](#data-validation)
* [Model testing](#model-testing)

## Saving and loading data

Reading and writing to csv, reading images or loading audio files are common scenarios encountered in MLOps projects.

### Example: Verify that a load function calls read_csv if the file exists

`utils.py`

```python
def load_data(filename: str) -> pd.DataFrame:
    if os.path.isfile(filename):
        df = pd.read_csv(filename, index_col='ID')
        return df
    return None
```

There's no need to test the `read_csv` function, or the `isfile` functions, we can leave testing them to the **pandas** and **os** developers.

The only thing we need to test here is the logic in this function, i.e. that `load_data` loads the file if the file exists with the right index column, and doesn't load the file if it doesn't exist, and that it returns the expected results.

One way to do this would be to provide a sample file and call the function, and verify that the output is **None** or a **DataFrame**. This requires separate files to be present, or not present, for the tests to run. This can cause the same test to run on one machine and then fail on a build server which is not a desired behavior.

A much better way is to **mock** calls to `isfile`, and `read_csv`. Instead of calling the real function, we will return a predefined return value, or call a stub that doesn't have any side effects. This way no files are needed in the repository to execute the test, and the test will always work the same, independent of what machine it runs on.

> Note: Below we mock the specific os and pd functions referenced in the utils file, any others are left unaffected and would run as normal.

`test_utils.py`

```python
import utils
from mock import patch


@patch('utils.os.path.isfile')
@patch('utils.pd.read_csv')
def test_load_data_calls_read_csv_if_exists(mock_isfile, mock_read_csv):
    # arrange
    # always return true for isfile
    utils.os.path.isfile.return_value = True
    filename = 'file.csv'

    # act
    _ = utils.load_data(filename)

    # assert
    # check that read_csv is called with the correct parameters
    utils.pd.read_csv.assert_called_once_with(filename, index_col='ID')
```

Similarly, we can verify that it's called 0 or multiple times. In the example below where we verify that it's not called if the file doesn't exist

```python
@patch('utils.os.path.isfile')
@patch('utils.pd.read_csv')
def test_load_data_doesnt_call_read_csv_if_not_exists(mock_isfile, mock_read_csv):
    # arrange
    # file doesnt exist
    utils.os.path.isfile.return_value = False
    filename = 'file.csv'

    # act
    _ = utils.load_data(filename)

    # assert
    # check that read_csv is not called
    assert utils.pd.read_csv.call_count == 0
```

### Example: Using the same sample data for multiple tests

If more than one test will use the same sample data, fixtures are a good way to reuse this sample data. The sample data can be the contents of a json file, or a csv, or a DataFrame, or even an image.

> Note: The sample data is still hard coded if possible, and does not need to be large. Only add as much sample data as required for the tests to make the tests readable.

Use the fixture to return the sample data, and add this as a parameter to the tests where you want to use the sample data.

```python
import pytest


@pytest.fixture
def house_features_json():
  return {'area': 25, 'price': 2500, 'rooms': np.nan}

def test_clean_features_cleans_nan_values(house_features_json):
  cleaned_features = clean_features(house_features_json)
  assert cleaned_features['rooms'] == 0

def test_extract_features_extracts_price_per_area(house_features_json):
  extracted_features = extract_features(house_features_json)
  assert extracted_features['price_per_area'] = 100
```

## Transforming data

For cleaning and transforming data, test fixed input and output, but try to limit each test to one verification.

For example, create one test to verify the output shape of the data.

```python
def test_resize_image_generates_the_correct_size():
  # Arrange
  original_image = np.ones((10, 5, 2, 3))

  # act
  resized_image = utils.resize_image(original_image, 100, 100)

  # assert
  resized_image.shape[:2] = (100, 100)
```

and one to verify that any padding is made appropriately

```python
def test_resize_image_pads_correctly():
  # Arrange
  original_image = np.ones((10, 5, 2, 3))

  # Act
  resized_image = utils.resize_image(original_image, 100, 100)

  # Assert
  assert resized_image[0][0][0][0] == 0
  assert resized_image[0][0][2][0] == 1
```

To test different inputs and expected outputs automatically, use parametrize

```python
@pytest.mark.parametrize('orig_height, orig_width, expected_height, expected_width',
                         [
                             # smaller than target
                             (10, 10, 20, 20),
                             # larger than target
                             (20, 20, 10, 10),
                             # wider than target
                             (10, 20, 10, 10)
                         ])
def test_resize_image_generates_the_correct_size(orig_height, orig_width, expected_height, expected_width):
  # Arrange
  original_image = np.ones((orig_height, orig_width, 2, 3))

  # act
  resized_image = utils.resize_image(original_image, expected_height, expected_width)

  # assert
  resized_image.shape[:2] = (expected_height, expected_width)
```

## Model load or predict

When **unit** testing we should mock model load and model predictions similarly to mocking file access.

There may be cases when you want to load your model to do smoke tests, or integration tests.

Since these will often take a bit longer to run it's important to be able to separate them from unit tests so that the developers on the team can still run unit tests as part of their test driven development.

One way to do this is using marks

```python
@pytest.mark.longrunning
def test_integration_between_two_systems():
  # this might take a while
```

Run all tests that are not marked longrunning

```bash
pytest -v -m "not longrunning"
```

### Basic Unit Tests for ML Models

ML unit tests are not intended to check the accuracy or performance of a model. Unit tests for an ML model is for code quality checks - for example:

* Does the model accept the correct inputs and produce the correctly shaped outputs?
* Do the weights of the model update when running `fit`?

To do this, the ML model tests do not strictly follow all of the best practices of standard Unit tests - not all outside calls are mocked. These tests are much closer to a [narrow integration test](https://martinfowler.com/bliki/IntegrationTest.html).
However, the benefits of having simple tests for the ML model help to stop a poorly configured model from spending hours in training, while still producing poor results.

Examples of how to implement these tests (for Deep Learning models) include:

* Build a model and compare the shape of input layers to that of an example source of data. Then, compare the output layer shape to the expected output.
* Initialize the model and record the weights of each layer. Then, run a single epoch of training on a dummy data set, and compare the weights of the "trained model" - only check if the values have changed.
* Train the model on a dummy dataset for a single epoch, and then validate with dummy data - only validate that the prediction is formatted correctly, this model will not be accurate.

## Data Validation

An important part of the unit testing is to include test cases for data validation. For example, no data supplied, images that are not in the expected format, data containing null values or outliers to make sure that the data processing pipeline is robust.

## Model Testing

Apart from unit testing code, we can also test, debug and validate our models in different ways during the training process

Some options to consider at this stage:

* [Adversarial and Boundary tests to increase robustness](https://medium.com/@deepmindsafetyresearch/towards-robust-and-verified-ai-specification-testing-robust-training-and-formal-verification-69bd1bc48bda)
* Verifying accuracy for under-represented classes
