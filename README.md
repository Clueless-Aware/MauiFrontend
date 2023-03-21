
# Maui FrontEnd

## Project tree structure
```
ProjectWork
    ├───Properties
    ├───wwwroot # Here is were static files reside (css, backrounds...)
    ├───Models # Classes that represent a DB entity
    │      └─── YourModel.cs # Use [JsonPropertyName("field")]
    ├───Pages # Blazor pages
    ├───Platforms # Maui code for specific platforms
    ├───Resources # Static files for icons
    ├───Services # Services that handle the HTPP request to our apis
    ├───Shared # Blazor components that we reuse multipel times
    ├───Utilities # Utilities for the entire project
    └───ViewModels # Classes for mofiying/gathering data for/from views
```
## Running with local backend

For running locally check out the backend repo at:
- [Backend Docker](https://github.com/Clueless-Aware/BackendAPI)

Then you will have do modify a couple of files:
- in wwwroot/index.html

```html
<!--set the local ip of your host, to avoid the https conversion-->
<meta http-equiv="Content-Security-Policy" content="img-src https: http://192.168.1.1:80/" />
```

- in Utilities/Endpoints.cs
```csharp
//Set the ip of your local host
private static readonly string _url = "http://192.168.1.1:80";
```

## Running without local backend

If you are lucky then our server might still be 
running but most likely it's down...

Anyhow the url of the backend is already present so you
don't need to change anything
