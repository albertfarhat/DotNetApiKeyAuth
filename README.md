# DotNetApiKeyAuth
Api Key Authorization for Web API


## Installing

```powershell
Install-Package ApiKeyAuth
```
## Usage

```cs
        Statrup.cs 
        using ApiKeyAuth;
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddApiKeyAuth("ApiKeyPolicy", new[] { "secretkey" }, "API-KEY");
            services.AddMvc()              
                .AddApplicationPart(typeof(ApiKeyAuth.ServicesConfiguration).Assembly);               
        }
```

```cs
        Controller:

        [HttpGet]
        [Authorize(Policy = "ApiKeyPolicy")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

```

## Contributing

There are many ways you can contribute to ApiKeyAuth. Like most open-source software projects, contributing code is just one of many outlets where you can help improve. Some of the things that you could help out with in ApiKeyAuth are:

- Documentation
- Bug reports
- Bug fixes
- Feature requests
- Feature implementations
- Test coverage
- Code quality

## Copyright

Copyright © 2020 Albert Farhat and contributors

## License

ApiKeyAuth is licensed under MIT. Refer to [LICENSE](LICENSE) for more information.