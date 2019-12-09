# Aark.SecurityHeaders.Extension

This is an extension (middleware) to add HTTP security headers in a WebAPI in .NET Core 3.1.

# How to use

Install the [nuget package](https://www.nuget.org/packages/Aark.Netatmo.Extension/).

Add the extention namespaces in your startup.cs file :

```csharp
using Aark.SecurityHeaders.Extension;
using Aark.SecurityHeaders.Extension.Constants;
```

In the configure method, call the extension :
```csharp
List<Uri> hostSources = new List<Uri>
{
    new Uri("https://analytics.example.com"),
    new Uri("https://*.gstatics.com")
};

app.UseSecurityHeadersMiddleware(new SecurityHeadersBuilder()
    .AddDefaultSecurePolicy()
    .AddReportUri(new Uri("https://report.example.com/report-uri.php"))
    .AddFeaturePolicy(CommonPolicyDirective.Directive.AllowSelf, FeaturePolicyConstants.HttpFeatures.Geolocation, hostSources)
    .AddContentSecurityPolicy(CommonPolicyDirective.Directive.AllowSelf, ContentSecurityPolicyConstants.FetchDirectives.DefaultSrc, CommonPolicySchemeSource.SchemeSources.None, hostSources)
    .AddContentSecurityPolicy(CommonPolicyDirective.Directive.AllowSelf, ContentSecurityPolicyConstants.FetchDirectives.ImgSrc, CommonPolicySchemeSource.SchemeSources.Data)
    .AddExpectCT(86400));
```

You can call AddDefaultSecurePolicy() to set default value for Frame-Options, Xss-Protection, Content-Type-Options, Strict-Transport-Security and Referrer-Policy. After this call, all Feature-Policy and Content-Security-Policy are cleared.

Call AddReportUri to add for each policy supported an uri to report rule violations to.

You can add manually a header by calling AddCustomHeader :
```csharp
app.UseSecurityHeadersMiddleware(new SecurityHeadersBuilder()
    .AddCustomHeader("My header", "Hello !"));
```

## Authors

* **Édouard Biton** - *Initial work* - [AArklendoïa](https://www.aarklendoia.com)

## License

This project is licensed under the MIT licence.
