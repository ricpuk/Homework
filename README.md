# Notes about the implementation
* Configuration reading is done going up the layers rather than down. All of the read configuration values are being stored in memory, this allows configuring multiple sttings models from memory.
* The order of configuration file inclusion matters: Most general files are included first while the more specific ones are included after.
* The configurator was made with modularity in mind. ConfigurationReader is a modular part which means that the DefaultConfigurationReader can be overridden to a specific reader which can implement a customized file parsing logic.
* Value appears as "Error" if it is not configured and is read as string
* Value throws an exception if it is not configured and is read as a specified type
* Issue: When configuring a specific model, not configured values do not display "Error" instead the default value is presented. Ex.: Not configured integers appear as 0
## Model validation ideas
Initial implementation for model validation would probably be something like "OnConfigured" method which would be called after model configuration. The validation model would be overrideable and the developer responsible for the settings model would be able to write specific rules for the model and throw 
exceptions if the rules get violated.
