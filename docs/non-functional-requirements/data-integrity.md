# Data Integrity

Data Integrity is the maintenance and assurance of the quality of data over its entire lifecycle. This includes the many facets of data quality such as, but not limited to, consistency, accuracy, and reliability. The benefits of this NFR are significant, as it ensures that data is trustworthy and reliable for decision-making, analysis, and reporting.

## Characteristics

- Accuracy: Data should be correct and free from errors or inconsistencies.
  - Are the column data types correct?
  - Are numeric values rounded off correctly?
- Completeness: All required data should be present and not missing any essential components.
- Consistency: Data should be consistent across different databases, applications, or time periods.
- Validity: Data should conform to defined rules, constraints, or standards. Invalid data should be rejected or flagged for correction.
- Reliability: Data should be trustworthy and dependable for decision-making and analysis.
- Timeliness: Data should be up-to-date and reflect the most current information available.
- Security: Data should be protected from unauthorized access, alteration, or deletion to maintain its integrity.
- Auditability: Changes to data should be tracked and logged, allowing for accountability and traceability.
- Transparency: Processes for data collection, storage, and manipulation should be transparent and understandable.
- Redundancy: Data should have backups or redundancy measures in place to prevent loss or corruption.
- Compliance: Data handling practices should comply with relevant regulations, standards, and industry best practices.
- Uniqueness: Data should be unique and not duplicated within the same dataset.
- Referential integrity: Does every row that depends on a dimension in the fact table actually have its associated dimension? (i.e., foreign keys without a primary)
  - For example, let's say the dimension is "city"- then if we have a fact table referencing Seattle, and then delete the Seattle dimension, we need to go delete Seattle from the facts
- Orderliness: Data should be organized in a logical and consistent manner, making it easy to search, retrieve, and analyze.

## Implementations

Data validation: Implement validation rules at the data entry points to ensure that only accurate and valid data is accepted into the system. This includes checks for data type, format, range, and consistency.

Data logging and auditing: Implement logging mechanisms to record all data-related activities, including data modifications, access attempts, and system events. Regularly review audit logs to detect any unauthorized or suspicious activities.

Data quality monitoring: Establish data quality monitoring processes to continuously evaluate the accuracy, completeness, and consistency of data. Implement automated checks and alerts to identify and address data quality issues in real-time.

Database constraints: Utilize database constraints such as primary keys, foreign keys, unique constraints, and check constraints to enforce data integrity rules at the database level.

Regular data backups: Implement regular backups of data to prevent loss in case of system failures, errors, or security breaches. Ensure that backup procedures are automated, monitored, and regularly tested.

## Resources

- [Great Expectations](https://greatexpectations.io/): A framework to build data validations and test the quality of your data.
