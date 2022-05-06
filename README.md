## Sitefinity Dev Environment Setup in MAC OS.
### Environment
``` js
.Net SDK 6 (6.0.104)
Mono JIT compiler version 6.12.0.174
Nuget
MacOS 12.3 (21E230) ,Apple M1 Pro.
```
### Setup

# Create Empty Project and change directory to it.
``` console
mkdir SitefinityWebApp
cd SitefinityWebApp
```
-- Create a new dotnet project
``` console
dotnet new web
```
-- Add Dependancies.
``` console
dotnet add package Progress.Sitefinity.AspNetCore
dotnet add package Progress.Sitefinity.AspNetCore.Widgets
dotnet add package Progress.Sitefinity.Renderer
dotnet add package Progress.Sitefinity.AspNetCore.FormWidgets
dotnet add package Telerik.Sitefinity.Mvc
```
-- Open VS code 
```
code .
```

-- Change Program.cs to below.
``` csharp
using  Microsoft.AspNetCore.Builder;
using  Microsoft.Extensions.Hosting;
using  Progress.Sitefinity.AspNetCore;
using  Progress.Sitefinity.AspNetCore.FormWidgets;

var builder =  WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSitefinity();
builder.Services.AddViewComponentModels();
builder.Services.AddFormViewComponentModels();
var app =  builder.Build();

// Configure the HTTP request pipeline.
if  (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
}
else
{
app.UseExceptionHandler("/Error");
app.UseHosts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseSitefinity();

app.UseEndpoints(endpoints  =>
{
endpoints.MapSitefinityEndpoints();
});
app.Run();
```

###  Change appsettings.json

``` xml
{  
  "Logging": {  
  "LogLevel": {  
  "Default": "Information",  
  "Microsoft": "Warning",  
  "Microsoft.Hosting.Lifetime": "Information"  
  }  
 },  "AllowedHosts": "*",  
  "Sitefinity" :{  
  "Url":"http://quantum-sandbox.azurewebsites.net/",  
  "WebServicePath":"api/default"  
  }  
}
``` 
