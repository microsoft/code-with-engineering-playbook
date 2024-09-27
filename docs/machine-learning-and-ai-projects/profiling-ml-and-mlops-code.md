# Profiling Machine Learning and MLOps Code

Data Science projects, especially the ones that involve Deep Learning techniques, usually are resource intensive. One model training iteration might be multiple hours long. Although large data volumes processing genuinely takes time, minor bugs and suboptimal implementation of some functional pieces might cause extra resources consumption.

Profiling can be used to identify performance bottlenecks and see which functions are the costliest in the application code. Based on the outputs of the profiler, one can focus on largest and easiest-to-resolve inefficiencies and therefore achieve better code performance.
Although profiling follows the same principles of any other software project, the purpose of this document is to provide profiling samples for the most common scenarios in MLOps/Data Science projects.

Below are some common scenarios in MLOps/Data Science projects, along with suggestions on how to profile them.

- [Generic Python profiling](#generic-python-profiling)
- [PyTorch model training profiling](#pytorch-model-training-profiling)
- [Azure Machine Learning pipeline profiling](#azure-machine-learning-pipeline-profiling)

## Generic Python Profiling

Usually an MLOps/Data Science solution contains plain Python code serving different purposes (e.g. data processing) along
with specialized model training code. Although many Machine Learning frameworks provide their own profiler,
sometimes it is also useful to profile the whole solution.

There are two types of profilers: deterministic (all events are tracked, e.g. [cProfile](https://docs.python.org/3/library/profile.html)) and statistical (sampling with regular intervals, e.g., [py-spy](https://pypi.org/project/py-spy/)). The sample below shows an example of a deterministic profiler.

There are many options of generic deterministic Python code profiling. One of the default options for profiling used to be a built-in
[cProfile](https://docs.python.org/3/library/profile.html) profiler. Using *cProfile* one can easily profile
either a Python script or just a chunk of code. This profiling tool produces a file that can be either
visualized using open source tools or analyzed using `stats.Stats` class. The latter option requires setting up filtering
and sorting parameters for better analysis experience.

Below you can find an example of using *cProfile* to profile a chunk of code.

```python
import cProfile

# Start profiling
profiler = cProfile.Profile()
profiler.enable()

# -- YOUR CODE GOES HERE ---

# Stop profiling
profiler.disable()

# Write profiler results to an html file
profiler.dump_stats("profiler_results.prof")
```

You can also run *cProfile* outside of the Python script using the following command:

```bash
python -m cProfile [-o output_file] [-s sort_order] (-m module | myscript.py)
```

> Note: one epoch of model training is usually enough for profiling. There's no need to run more epochs and produce
additional cost.

Refer to [The Python Profilers](https://docs.python.org/3/library/profile.html) for further details.

## PyTorch Model Training Profiling

PyTorch 1.8 includes an updated PyTorch
[profiler](https://pytorch.org/blog/introducing-pytorch-profiler-the-new-and-improved-performance-tool/)
that is supplied together with the PyTorch distribution and doesn't require any additional installation.
Using *PyTorch profiler* one can record CPU side operations as well as CUDA kernel launches on GPU side.
The profiler can visualize analysis results using TensorBoard plugin as well as provide suggestions
on bottlenecks and potential code improvements.

```python
 with torch.profiler.profile(
    # Limit number of training steps included in profiling
    schedule=torch.profiler.schedule(wait=1, warmup=1, active=3, repeat=2),
    # Automatically saves profiling results to disk
    on_trace_ready=torch.profiler.tensorboard_trace_handler,
    with_stack=True
) as profiler:
    for step, data in enumerate(trainloader, 0):
        # -- TRAINING STEP CODE GOES HERE ---
        profiler.step()
```

The `tensorboard_trace_handler` can be used to generate result files for TensorBoard. Those can be visualized by installing TensorBoard.
plugin and running TensorBoard on your log directory.

```bash
pip install torch_tb_profiler
tensorboard --logdir=<LOG_DIR_PATH>
# Navigate to `http://localhost:6006/#pytorch_profiler`
```

> Note: make sure to provide the right parameters to the `torch.profiler.schedule`. Usually you would need several steps of training to be profiled rather than the whole epoch.

More information on *PyTorch profiler*:

- [PyTorch Profiler Recipe](https://pytorch.org/tutorials/recipes/recipes/profiler_recipe.html)
- [Introducing PyTorch Profiler - the new and improved performance tool](https://pytorch.org/blog/introducing-pytorch-profiler-the-new-and-improved-performance-tool/)

## Azure Machine Learning Pipeline Profiling

In our projects we often use [Azure Machine Learning](https://azure.microsoft.com/en-us/services/machine-learning/)
pipelines to train Machine Learning models. Most of the profilers can also be used in conjunction with Azure Machine Learning.
For a profiler to be used with Azure Machine Learning, it should meet the following criteria:

- Turning the profiler on/off can be achieved by passing a parameter to the script ran by Azure Machine Learning
- The profiler produces a file as an output

In general, a recipe for using profilers with Azure Machine Learning is the following:

1. (Optional) If you're using profiling with an Azure Machine Learning pipeline, you might want to add `--profile`
Boolean flag as a pipeline parameter
2. Use one of the profilers described above or any other profiler that can produce a file as an output
3. Inside of your Python script, create step output folder, e.g.:

    ```python
    output_dir = "./outputs/profiler_results"
    os.makedirs(output_dir, exist_ok=True)
    ```

4. Run your training pipeline
5. Once the pipeline is completed, navigate to Azure ML portal and open details of the step that contains training code.
The results can be found in the `Outputs+logs` tab, under `outputs/profiler_results` folder.
6. You might want to download the results and visualize it locally.

> **Note:** it's not recommended to run profilers simultaneously. Profiles also consume resources, therefore a simultaneous run
might significantly affect the results.
