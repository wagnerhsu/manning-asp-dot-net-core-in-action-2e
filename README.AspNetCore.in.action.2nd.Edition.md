## 11 Configuring an ASP.NET Core application
- The configuration keys are not case-sensitive, so bear that in mind when loading from providers in which the keys are case-sensitive
- You can create the same hierarchical sections that you typically see in JSON files by using a colon, :, or a double underscore, __, to demarcate a section, for example: `MapSettings:MaxNumberOfPoints` or `MapSettings__MaxNumberOfPoints`. Some environments, such as Linux, don’t allow `:` in environment variables, you must use the double underscore approach on these instead
- For development scenarios, you can use the User Secrets Manager. This effectively adds per-app environment variables, so you can have different settings for each app, but store them in a different location from the app itself
- The idea behind User Secrets is to simplify storing per-app secrets outside of your app’s project tree. This is similar to environment variables, but you use a unique key per-app to keep the secrets segregated.
> :warning: The secrets aren’t encrypted, so shouldn’t be considered secure
- You should only use the User Secrets provider in development, not in production, so you’re conditionally adding the provider to ConfigurationBuilder. In production, you should use environment variables or Azure Key Vault
- If you forget to call Configure<T> and inject IOptions<T> into your services, you won’t see any errors, but the T options class won’t be bound to anything and will only have default values in its properties
- ASPNETCORE_ENVIRONMENT
### Reference
- Safe storage of app secrets in development in ASP.NET Core [docs](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)