# Installation

https://www.nuget.org/packages/Epiphany.Core

`Install-Package Epiphany.Core`


# Usage

Adding it as namespace in the `web.config` file inside the `View` folder helps with intellisense and shortening the import list when using this library in razor
```
<configuration>
  <system.web.webPages.razor>
      <namespaces>  
        <add namespace="Epiphany.Core" />
      </namespaces>
    </pages>
  </system.web.webPages.razor>
</configuration>
```
