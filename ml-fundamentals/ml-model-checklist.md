# ML model production checklist

The purpose of this checklist is to make sure that:

- The team assessed if the model is ready for production before moving to the scoring process
- The team has prepared a production plan for the model

The checklist provides guidelines for creating this production plan. It should be used by teams/organizations that already built/trained a ML model and are now consdering putting it into production.

## Checklist

Before putting an individual ML model into production, the following aspects should be considered:

- [ ] [Is there a well defined baseline? Is the model performing better than the baseline?](#is-there-a-well-defined-baseline-is-the-model-performing-better-than-the-baseline)
- [ ] [Are machine learning performance metrics defined for both training and scoring?](#are-machine-learning-performance-metrics-defined-for-both-training-and-scoring)
- [ ] [Is the model benchmarked?](#is-the-model-benchmarked)
- [ ] [Can ground truth be obtained or inferred in production?](#can-ground-truth-be-obtained-or-inferred-in-production)
- [ ] [Has the data distribution of training, testing and validation sets been analysed? Can data distribution be obtained for new data?](#has-the-data-distribution-of-training-testing-and-validation-sets-been-analysed-can-data-distribution-be-obtained-for-new-data)
- [ ] [Have goals and hard limits for performance, speed of prediction and costs been established so they can be considered if trade-offs need to be made?](#have-goals-and-hard-limits-for-performance-speed-of-prediction-and-costs-been-established-so-they-can-be-considered-if-trade-offs-need-to-be-made)
- [ ] [How will the model be integrated into other systems, and what impact will it have?](#how-will-the-model-be-integrated-into-other-systems-and-what-impact-will-it-have)
- [ ] [How will performance be monitored?](#how-will-performance-be-monitored)
- [ ] [Have any ethical concerns been taken into account in accordance with the Microsofts AI principles on responsible AI?](#have-any-ethical-concerns-been-taken-into-account-in-accordance-with-the-microsofts-ai-principles-on-responsible-ai)

Please note that there might be scenarios where it is not possible to check all the items on this checklist. However, it is advised to go through all items and make informed decisions based on your specific use case.

## Will your model performance be different in production than during training phase

Once deployed into production, the model might be performing much worse than expected. This poor performance could be a result of:

- The data to be scored in production is significantly different from the train and test datasets
- The feature engineering steps are different or inconsistent in production compared to the training process
- The performance measure is not consistent (for example your test set covers several months of data where the performance metric for production has been calculated for one month of data)

### Is there a well defined baseline? Is the model performing better than the baseline?

A good way to think of a model baseline is the simplest model one can come up with: either a simple threshold, a random guess or a very basic linear model. This baseline is the reference point your model needs to outperform. A well defined baseline is different for each problem type and there is no one size fits all approach.

As an example, let's consider some common types of machine learning problems:

- **Classification**: Predicting between a positive and a negative class. Either the class with the most observations or a simple logistic regression model can be the baseline.
- **Regression**: Predicting the house prices in a city. The average house price for the last year or last month, a simple linear regression model or the previous median house price in a neighbourhood could be the baseline.
- **Image classification**: Building an image classifier to distinguish between cats and no cats in an image. If your classes are unbalanced: 70% cats and 30% no cats and if you always predict cats, your naive classifier has 70% accuracy and this can be your baseline. If your classes are balanced: 52% cats and 48% no cats, then a simple convolutional architecture can be the baseline (1 conv layer + 1 max pooling + 1 dense). Additionally, human accuracy at labelling can also be the baseline in an image classification scenario.

Some questions to ask when comparing to a baseline:

- How does your model compare to a random guess?
- How does your model performance compare to applying a simple threshold?
- How does your model compare with always predicting the most common value?

**Note**: In some cases, human parity might be too ambitious as a baseline, but this should be decided on a case by case basis. Human accuracy is one of the available options, but not the only one.

Resources:

- ["How To Get Baseline Results And Why They Matter" article](https://machinelearningmastery.com/how-to-get-baseline-results-and-why-they-matter/)
- ["Always start with a stupid model, no exceptions." article](https://blog.insightdatascience.com/always-start-with-a-stupid-model-no-exceptions-3a22314b9aaa)

### Are machine learning performance metrics defined for both training and scoring?

The methodology of translating the training metrics to scoring metrics should be well defined and understood. Depending on the data type and model, the model metrics calculation might differ in production and in training. For example, the training procedure calculated metrics for a long period of time (a year, a decade) with different seasonal characteristics while the scoring procedure will calculate the metrics per a restricted time interval (for example a week, a month, a quarter). Well defined ML performance metrics are essential in production so that a decrease or increase in model performance can be accurately detected.

Things to consider:

- In forecasting, if you change the period of assesing the performance, from one month to a year for example, then you might get a different result. For example, if your model is predicting sales of a product per day and the RMSE (Root Mean Squared Error) is very low for the first month the model is in production. As the model is live for longer, the RMSE is increasing, becoming 10x the RMSE for the first year compared to the first month.
- In a classification scenario, the overall accuracy is good, but the model is performing poorly for some subgroups. For example, a classifier has an accuracy of 80% overall, but only 55% for the 20-30 age group. If this is a signigicant age group for the production data, then your accuracy might suffer greatly when in production.
- In scene classification scenario, the model is trying to identify a specific scene in a video and the model has been trained and tested (80-20 split) on 50000 segments where half are segments containing the scene and half of the segments do not contain the scene. The accuracy on the training set is 85% and 84% on the test set. However, when an entire video is scored, scores are obtained on all segments and we expect few segments to contain the scene. The accuracy for an entire video is not comparable with the training/test set procedure in this case, hence different metrics should be considered.
- If sampling techniques (over-sampling, under-sampling) are used to train model when classes are imbalanced, ensure the metrics used during training are comparable with the ones used in scoring.
- If the number of samples used for training and testing is small, the performance metrics might change significantly as new data is scored.

### Is the model benchmarked?

The trained model to be put into production is well benchmarked if machine learning performance metrics (such as accuracy, recall, RMSE or whatever is appropriate) are measured on the train and test set. Furthermore, the train and test set split should be well documented and reproducible.

### Can ground truth be obtained or inferred in production?

Without a reliable ground truth, the machine learning metrics cannot be calculated. It is important to identify if the ground truth can be obtained as the model is scoring new data by either manual or automatic means. If the ground truth cannot be obtained systematically, other proxies and methodology should be investigated in order to obtain some measure of model performance.

One option is to use humans to manually label samples. One important aspect of human labelling is to take into account the human accuracy. If there are two different individuals labelling an image, the labels will likely be different for some samples. It is important to understand how the labels were obtained to assess the reliability of the ground truth (that is why we talk about human accuracy).

For clarity, let's consider the following examples (by no means an exhaustive list):

- **Forecasting**: Forecasting scenarios are an example of machine learning problems where the ground truth could be obtained in most cases even though a delay might occur. For example, for a model predicting the sales of ice cream in a local shop, the ground truth will be obtained as the sales are happening, but it might appear in the system at a later time than as the model prediction.
- **Recommender systems**: For recommender system, obtaining the ground truth is a complex problem in most cases as there is no way of identifying the ideal recommendation. For a retail website for example, click/not click, buy/not buy or other user interaction with recommendation can be used as ground truth proxies.
- **Object detection in images**: For an object detection model, as new images are scored, there are no new labels being generated automatically. One option to obtain the ground truth for the new images is to use people to manually label the images. Human labelling is costly, time consuming and not 100% accurate, so in most cases, only a subset of images can be labelled. These samples can be chosen at random or by using active learning techniques of selecting the most informative unlabeled samples.

### Has the data distribution of training, testing and validation sets been analysed? Can data distribution be obtained for new data?

The data distribution of your training, test and validation (if applicable) dataset (including labels) should be analysed to ensure they all come from the same distribution. If this is not the case, some options to consider are: re-shuffling,  re-sampling, modifying the data, more samples need to be gathered or features removed from the dataset.

Furthermore, it is imperative to understand if the new data in production will be significantly different from the data in the training phase. It is also important to check that the data distribution information can be obtained for any of the new data coming in.

Significant differences in the data distributions of the different datasets can greatly impact the performance of the model. Some potential questions to ask:

- How much does the training and test data represent the end result?
- Is the distribution of each invididual feature consistent across all your datasets? (i.e. same representation of age groups, gender, race etc.)
- Is there any data lineage information? Where did the data come from? How was the data collected? Can collection and labelling be automated?

Resources:

- ["Splitting into train, dev and test" tutorial](http://cs230.stanford.edu/blog/split/)
- [Covariate shift in Machine Learning](https://dkopczyk.quantee.co.uk/covariate_shift/)
- [Understanding dataset shift](https://towardsdatascience.com/understanding-dataset-shift-f2a5a262a766)

### Have goals and hard limits for performance, speed of prediction and costs been established so they can be considered if trade-offs need to be made?

Some machine learning models achieve high ML performance, but they are costly and time consuming to run. In those cases, a less performant and cheaper model could be preferred. Hence, it is important to calculate the model performance metrics (accuracy, precision, recall, RMSE etc), but also to gather data on how expensive it will be to run the model and how long it will take to run. Once this data is gathered, an informed decision should be made on what model to productionise.

System metrics to consider:

- CPU/GPU/memory usage
- Cost per prediction
- Time taken to make a prediction

### How will the model be integrated into other systems, and what impact will it have?

Machine Learning models do not exist in isolation, but rather they are part of a much larger system. These systems could be old, prorietary systems or new systems being developed as a results of the creation a new machine learning model. In both of those cases, it is important to understand where the actual model is going to fit in, what output is expected from the model and how that output is going to be used by the larger system. Additionally, it is essential to decide if the model will be used for batch and/or real-time inference as production paths might differ.

Possible questions to assess model impact:

- Is there a human in the loop?
- How is feedback collected through the system? (for example how do we know if a prediction is wrong)
- Is there a fallback mechanism when things go wrong?
- Is the system transparent that there is a model making a prediction and what data is used to make this prediction?
- What is the cost of a wrong prediction?

### How will performance be monitored?

It is important to define how the model will be monitored when it is in production and how that data is going to be used to make decisions. For example, when will a model need retraining as the performance has degraded and how to identify what are the underlying causes of this degradation could be part of this monitoring methodology.

Ideally, model monitoring should be done automatically. However, if this is not possible, then there should be a manual periodical check of the model performance.

Model monitoring should lead to:

- Ability to identify abrupt changes in data characteristics
- Ability to identify abrupt changes in model performance
- Warnings when anomalies in model output or input data are occurring
- Retraining decisions

### Have any ethical concerns been taken into account in accordance with the Microsofts AI principles on responsible AI?

[Check the Microsoft AI Principles for responsible AI](https://www.microsoft.com/en-us/ai/responsible-ai)

- Fairness
- Inclusiveness
- Reliability & Safety
- Privacy & Security
- Transparency
- Accountability

Potential areas to explore:

- Has the team analysed the input data properly to make sure that the training data is suitable for machine learning?
- Is the training data an accurate representation of data that will be used as input in production?
- Is there a good representation of all users?
- Is there a fall back mechanism (a human in the loop or a way to revert decisions based on the model)?
- Does data used by the model for training or scoring contain PII? What measures have been taken to remove sensitive data?
- Does the model impact consequential decisions, like blocking people from getting jobs, loans, health care etc. or in the cases where it may, have appropriate ethical considerations been discussed?
- Have measures for re-training been considered?
