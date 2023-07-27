# Guidelines on Structuring the Terraform Configuration

## Context
When creating an infrastructure configuration, it is important to follow a consistent and organized structure to ensure maintainability, scalability and reusability of the code. The goal of this section is to briefly describe how to structure your Terraform configuration in order to achieve this.

## Structuring the Terraform configuration

The recommended structure is as follows:

1. Place each component you want to configure in its own module folder. Analyze your infrastructure code and identify the logical components that can be separated into reusable modules. This will give you a clear separation of concerns and will make it straight forward to include new resources, update existing ones or reuse them in the future. For more details on modules and when to use them, see the [Terraform guidance](https://developer.hashicorp.com/terraform/language/modules/develop#when-to-write-a-module).

2. Place the `.tf` module files at the root of each folder and make sure to include a [`README`](#generating-the-documentation) file in a markdown format which can be automatically generated based on the module code. It's recommended to follow this approach as this file structure will be automatically picked up by the [Terraform Registry](https://registry.terraform.io/browse/modules).
3. Use a consistent set of files to structure your modules. While this can vary depending on the specific needs of the project, one good example can be the following:
   - **provider.tf**: defines the list of providers according to the plugins used
   - **data.tf**: defines information read from different data sources
   - **main.tf**: defines the infrastructure objects needed for your configuration (e.g. resource group, role assignment, container registry)
   - **backend.tf**: backend configuration file
   - **outputs.tf**: defines structured data that is exported
   - **variables.tf**: defines static, reusable values
4. Include in each module sub folders for documentation, examples and tests.
The documentation includes basic information about the module: what is it installing, what are the options, an example use case and so on. You can also add here any other relevant details you might have.
The example folder can include one or more examples of how to use the module, each example having the same set of configuration files decided on the previous step. It's recommended to also include a README providing a clear understanding of how it can be used in practice.
The tests folder includes one or more files to test the example module together with a documentation file with instructions on how these tests can be [executed](https://www.hashicorp.com/blog/testing-hashicorp-terraform).
5. Place the root module in a separate folder called `main`: this is the primary entry point for the configuration. Like for the other modules, it will contain its corresponding configuration files.

An example configuration structure obtained using the guidelines above is:

```console
modules
├── mlops
│   ├── doc
│   ├── example
│   ├── test
│   ├── backend.tf
│   ├── data.tf
│   ├── main.tf
│   ├── outputs.tf
│   ├── provider.tf
│   ├── variables.tf
│   ├── README.md
├── common
├── main
```


## Naming convention

When naming Terraform variables, it's essential to use clear and consistent naming conventions that are easy to understand and follow. The general convention is to use lowercase letters and numbers, with underscores instead of dashes, for example: "azurerm_resource_group".
When naming resources, start with the provider's name, followed by the target resource, separated by underscores. For instance, "azurerm_postgresql_server" is an appropriate name for an Azure provider resource. When it comes to data sources, use a similar naming convention, but make sure to use plural names for lists of items. For example, "azurerm_resource_groups" is a good name for a data source that represents a list of resource groups.
Variable and output names should be descriptive and reflect the purpose or use of the variable. It's also helpful to group related items together using a common prefix. For example, all variables related to storage accounts could start with "storage_". Keep in mind that outputs should be understandable outside of their scope. A useful naming pattern to follow is "{name}_{attribute}", where "name" represents a resource or data source name, and "attribute" is the attribute returned by the output. For example, "storage_primary_connection_string" could be a valid output name.

Make sure you include a description for outputs and variables, as well as marking the values as 'default' or 'sensitive' when the case. This information will be captured in the generated documentation.

## Generating the documentation

The documentation can be automatically generated based on the configuration code in your modules with the help of [terraform-docs](https://terraform-docs.io/). To generate the Terraform module documentation, go to the module folder and enter this command:

```sh
terraform-docs markdown table --output-file README.md --output-mode inject .
```

Then, the documentation will be generated inside the component root directory.

## Conclusion

The approach presented in this section is designed to be flexible and easy to use, making it straight forward to add new resources or update existing ones. The separation of concerns also makes it easy to reuse existing components in other projects, with all the information (modules, examples, documentation and tests) located in one place.

## References and Further Reading

- [Terraform-docs](https://github.com/terraform-docs/terraform-docs)
- [Terraform Registry](https://registry.terraform.io/browse/modules)
- [Terraform Module Guidance](https://developer.hashicorp.com/terraform/language/modules/develop#when-to-write-a-module)
- [Terratest](https://terratest.gruntwork.io/)
- [Testing HashiCorp Terraform](https://www.hashicorp.com/blog/testing-hashicorp-terraform)
- [Build Infrastructure - Terraform Azure Example](https://developer.hashicorp.com/terraform/tutorials/azure-get-started/azure-build)