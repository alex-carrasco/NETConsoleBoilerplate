# .NET Console App Boilerplate

## Folder Structure

### Models

This folder should serve as your main directory for placing your data models. You may want to consider adding subdirectories to maintain project structure as the application grows.

```csharp
public class MyAPIClient
{
	public string OperatorUrl { get; set; }
	public string APIKey { get; set; }
}
```

### Contracts

This folder should contain your interfaces which are used to create contracts for your classes and later used when adding services using dependency injection.

```
public interface IAPIClient
{
	Task Get();
}
```

### Services

This folder should contain the implemetation of your services for various functionality, it inherits from an interface.

```csharp
public class APIClient : IAPIClient
{
	IConfiguration _config;

	public APIClient(IConfiguration config)
	{
		_config = config;	
	}

	public async Task Get()
	{
		// my GET implementation
		string baseUrl = _config.GetValue<string>("BaseUrl");
	}
}
```