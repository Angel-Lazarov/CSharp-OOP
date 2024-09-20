


using Microsoft.Extensions.DependencyInjection;

ServiceCollection collection = new ServiceCollection();
//collection.AddSingleton<IDBConnection, DBConnection>();
collection.AddTransient<IDBConnection, DBConnection>();
collection.AddTransient<DataView, DataView>();

IServiceProvider provider = collection.BuildServiceProvider();


for (int i = 0; i < 5; i++)
{
    //var connection = provider.GetRequiredService<IDBConnection>();
    //Console.WriteLine(connection.Id);
    var dateview = provider.GetRequiredService<DataView>();

}


class DataView
{
    public DataView(IDBConnection db)
    {
        Console.WriteLine("DateView vreated");
        Console.WriteLine(db.Id);
    }
}

class DBConnection : IDBConnection
{
    public DBConnection()
    {
        Console.WriteLine("DB Connection created!");
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string Connected()
    {
        return "Connected";
    }
}

interface IDBConnection
{
    public Guid Id { get; set; }
    string Connected();
}