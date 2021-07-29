# ML Fundamentals Checklist

This checklist helps ensure that our ML projects meet our ML Fundamentals. The items below are not sequential, but rather organized by different parts of an ML project.

## Data Quality and Governance

- [ ] There is access to data.
- [ ] Labels exist for dataset of interest.
- [ ] Data quality evaluation.
- [ ] Able to track data lineage.
- [ ] Understanding of where the data is coming from and any policies related to data access.
- [ ] Gather Security and Compliance requirements.

## Feasibility Study

- [ ] A feasibility study was performed to assess if the data supports the proposed tasks.
- [ ] Rigorous Exploratory data analysis was performed (including analysis of data distribution).
- [ ] Hypotheses were tested producing sufficient evidence to either support or reject that an ML approach is feasible to solve the problem.
- [ ] ROI estimation and risk analysis was performed for the project.
- [ ] ML outputs/assets can be integrated within the production system.
- [ ] Recommendations on how to proceed have been documented.

## Evaluation and Metrics

- [ ] Clear definition of how performance will be measured.
- [ ] The evaluation metrics are somewhat connected to the success criteria.
- [ ] The metrics can be calculated with the datasets available.
- [ ] Evaluation flow can be applied to all versions of the model.
- [ ] Evaluation code is unit-tested and reviewed by all team members.
- [ ] Evaluation flow facilitates further results and error analysis.

## Model Baseline

- [ ] Well-defined baseline model exists and its performance is calculated. ([More details on well defined baselines](ml-model-checklist.md#is-there-a-well-defined-baseline-is-the-model-performing-better-than-the-baseline))
- [ ] The performance of other ML models can be compared with the model baseline.

## Experimentation setup

- [ ] Well-defined train/test dataset with labels.
- [ ] Reproducible and logged experiments in an environment accessible by all data scientists to quickly iterate.
- [ ] Defined experiments/hypothesis to test.
- [ ] Results of experiments are documented.
- [ ] Model hyper parameters are tuned systematically.
- [ ] Same performance evaluation metrics and consistent datasets are used when comparing candidate models.

## Production

- [ ] [Model readiness checklist](ml-model-checklist.md) reviewed.
- [ ] Model reviews were performed (covering model debugging, reviews of training and evaluation approaches, model performance).
- [ ] Data pipeline for inferencing, including an end-to-end tests.
- [ ] SLAs requirements for models are gathered and documented.
- [ ] Monitoring of data feeds and model output.
- [ ] Ensure consistent schema is used across the system with expected input/output defined for each component of the pipelines (data processing as well as models).
- [ ] [Responsible AI](responsible-ai.md) reviewed.
