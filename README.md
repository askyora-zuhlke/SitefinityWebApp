## Sitefinity Dev Environment Setup in MAC OS.
-- Environment
``` js
.Net SDK 6 (6.0.104)
Mono JIT compiler version 6.12.0.174
Nuget
MacOS 12.3 (21E230) ,Apple M1 Pro.
```
-- Setup

-- Create Empty Project and change directory to it.
``` console
mkdir SitefinityWebApp
cd SitefinityWebApp
```
-- Create a new dotnet project
``` console
dotnet new web
```
-- add Sitefinity NuGet Repository
Add a new source, name it Sitefinity NuGet Repository.
``` console
sudo dotnet nuget add source https://nuget.sitefinity.com/nuget -n sitefinity
```

-- Fix the NuGet.Config as below.(Sitefinity as first package source) /Users/<username>/.nuget/NuGet
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="sitefinity" value="https://nuget.sitefinity.com/nuget" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
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
