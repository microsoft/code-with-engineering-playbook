# Guidelines on Structuring the Terraform Configuration

## Context
When creating an infrastructure configuration, it is important to follow a consistent and organized structure to ensure maintainability, scalability and reusability of the code. The goal of this section is to briefly describe how to structure your Terraform configuration in order to achieve this.

## Structuring the Terraform configuration

The recommended structure is as follows:

1. Place each component you want to configure in it's own module folder. This will give you a clear separation of concerns and will make it straight forward to include new resources, update existing ones or reuse them in the future.  
2. Place the `.tf` module files at the root of each folder and make sure to include a [`README`](#generating-the-documentation) file in a markdown format which can be automatically generated based on the module code. It's recommended to follow this approach as this file structure will be automatically picked up by the [Terraform Registry](https://registry.terraform.io/browse/modules).
3. Use the same set of files to structure your modules. While this can vary depending on the specific needs of the project, one good example can be the following:
   - **provider.tf**: defines the list of providers according to the plugins used
   - **data.tf**: defines information read from different data sources
   - **main.tf**: defines the infrastructure objects needed for your configuration (e.g. resource group, role assignment, container registry)
   - **backend.tf**: configuration file filled in by Terragrunt
   - **outputs.tf**: defines structured data that is exported
   - **variables.tf**: defines static, reusable values
4. Include in each module subfolders for documentation, examples and tests.  
The documentation includes basic information about the module: what is it installing, what are the options, an example use case and so on. You can also add here any other relevant details you might have.  
The example folder can include one or more examples of how to use the module, each example having the same set of configuration files decided on the previous step. It's recommended to also include README providing a clear understanding of how it can be used in practice.  
The tests folder includes one or more files to test the example module together with a documentation file with instructions on how these tests can be [executed](https://www.hashicorp.com/blog/testing-hashicorp-terraform).  
5. Place the root module in a separate folder called `main`: this is the primary entry point for the configuration. Like for the other modules, it will contain its corresponding configuration files.


Make sure you include a description for outputs and variables, as well as marking the values as 'default' or 'sensitive' when the case. This information will be captured in the generated documentation.

You should also establish a naming convention for your resource names, variables, outputs and data source names. In Terraform the general convention is that you use '_' (underscore) instead of '-' (dash) in combination with lowercase letters and numbers, for example: azurerm_resource_group.

An example configuration structure obtained using the guidelines above is:

```console
modules
├── computer_vision
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
├── container_registry
├── main
```

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
- [Terratest](https://terratest.gruntwork.io/)
- [Testing HashiCorp Terraform](https://www.hashicorp.com/blog/testing-hashicorp-terraform)
- [Build Infrastructure - Terraform Azure Example](https://developer.hashicorp.com/terraform/tutorials/azure-get-started/azure-build)