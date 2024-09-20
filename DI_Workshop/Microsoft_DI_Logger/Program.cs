using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollection = new ServiceCollection();

//serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
serviceCollection.AddSingleton<ILogger, TextLogger>();
serviceCollection.AddSingleton<Company, Company>();
serviceCollection.AddSingleton<Employee, Employee>();

IServiceProvider provider = serviceCollection.BuildServiceProvider();   




//ILogger logger =provider.GetRequiredService<ILogger>();
Company company = provider.GetRequiredService<Company>();
company.RaiseSalary();

Employee employee  = provider.GetRequiredService<Employee>();
employee.TakeVacation(5);