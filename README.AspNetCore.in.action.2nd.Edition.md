## 01 Getting Started with Asp.net Core

## 02 Your First Application

## 03 Handling Requests with the Middleware Pipeline

## 04 Creating a Web Site with Razor Pages

## 05 Mapping Urls to Razor Pages using Routing

## 06 The Binding Model: Retrieving and Validating User Input

## 07 Rendering Html using Razor Views

## 08 Building Forms with Tag Helpers

## 09 Creating a Web API for mobile and client applications using MVC

## 10 Service configuration with dependency injection



## 11 Configuring an ASP.NET Core application

- The configuration keys are not case-sensitive, so bear that in mind when loading from providers in which the keys are case-sensitive
- You can create the same hierarchical sections that you typically see in JSON files by using a colon, :, or a double underscore, __, to demarcate a section, for example: `MapSettings:MaxNumberOfPoints` or `MapSettings__MaxNumberOfPoints`. Some environments, such as Linux, don’t allow `:` in environment variables, you must use the double underscore approach on these instead
- For development scenarios, you can use the User Secrets Manager. This effectively adds per-app environment variables, so you can have different settings for each app, but store them in a different location from the app itself
- The idea behind User Secrets is to simplify storing per-app secrets outside of your app’s project tree. This is similar to environment variables, but you use a unique key per-app to keep the secrets segregated.
> :warning: The secrets aren’t encrypted, so shouldn’t be considered secure
- You should only use the User Secrets provider in development, not in production, so you’re conditionally adding the provider to ConfigurationBuilder. In production, you should use environment variables or Azure Key Vault
- If you forget to call Configure<T> and inject IOptions<T> into your services, you won’t see any errors, but the T options class won’t be bound to anything and will only have default values in its properties
- ASPNETCORE_ENVIRONMENT

## 12 Saving data with Entity Framework Core

## 13  The MVC and Razor Pages filter pipeline

## 14 Authentication: adding users to your application with Identity

## 15 Authorization: securing your application

## 16 Publishing and deploying your application

## 17 Monitoring and troubleshooting errors with logging

- When you inject `ILogger<T>`, the DI container indirectly calls `ILoggerFactory.CreateLogger<T>()` to create the wrapped ILogger

## 18 Improving your application[’](https://livebook.manning.com/book/asp-net-core-in-action-second-edition/chapter-18/v-6/)s security

## 19 Building custom components

## 20 Building custom MVC and Razor Pages components

## 21 Calling remote APIs with IHttpClientFactory

## 22 Building background tasks and services

## 23 Testing your application

### Reference

- Safe storage of app secrets in development in ASP.NET Core [docs](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)
- Official site [manning](https://www.manning.com/books/asp-net-core-in-action-second-edition)