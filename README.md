# Aark.SecurityHeaders.Extension

This is an extension (middleware) to add HTTP security headers in a WebAPI in .NET Core 3.1.

# How to use

Install the [nuget package](https://www.nuget.org/packages/Aark.SecurityHeaders.Extension/).

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

## Create a report server

In order to easily debug your headers, especially for Content-Security-Policy, you must set up a server that will receive rule violations detected by browsers.

To do this, you need a web server and a URI pointing to a script that recovers errors.

Here is an example of a PHP script that logs errors and forwards them by email:
```php
<?php
  // Send `204 No Content` status code.
  http_response_code(204);
  // collect data from post request
  $data = file_get_contents('php://input');
  if ($data = json_decode($data)) {
    // Remove slashes from the JSON-formatted data.
    $data = json_encode(
      $data, JSON_UNESCAPED_SLASHES
    );
    // set options for syslog daemon
    openlog('report-uri', LOG_NDELAY, LOG_USER);

    // send warning about csp report
    syslog(LOG_WARNING, $data);

    mail('report@example.com', 'Report CSP rule violations', $data);
  }
?>
```
Then, declare the complete URI in your headers, for example:
```csharp
            app.UseSecurityHeadersMiddleware(new SecurityHeadersBuilder()
                .AddDefaultSecurePolicy()
                .AddReportUri(new Uri("https://report.example.com/report-uri.php"))
                .AddContentSecurityPolicy(...);
```
**It is very important that this URI is different from that of your WebAPI because you may not receive the reports or send them back to a domain whose security may have been compromised.**

## Authors

* **Édouard Biton** - *Initial work* - [AArklendoïa](https://www.aarklendoia.com)

## License

This project is licensed under the MIT licence.
