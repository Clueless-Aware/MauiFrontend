
# Maui FrontEnd


## Roadmap

- [Tree structure] (https://github.com/ProjectWorkITS2022/MauiFrontend#tree-structure)



## Tree structure 

```python
ProjectWork
    ├───bin
    ├───Components #create here your shared components
    ├───Data
    │   ├───Services #create here your services for viewmodels
    │   │      └─── YourService.cs # inheritance from Service<YourModel>
    │   └───ViewModels #create here your model management
    │          └─── YourViewModels.cs # inheritance from ObservableRecipient , IViewModel<YourModel>
    ├───Models #create here your models
    │      └─── YourModel.cs # Uses [JsonPropertyName("field")]
    ├───obj
    ├───Pages #create here your pages (routing)
    ├───Properties
    ├───Resources
    ├───Shared #shared between the pages
    ├───Utilities # Utilities for the entire project
    └───wwwroot
```