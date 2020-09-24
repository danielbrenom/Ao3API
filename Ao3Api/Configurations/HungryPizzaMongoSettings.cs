namespace HungryPizzaAPI.Domain.Configurations
{
    public class HungryPizzaMongoSettings : IHungryPizzaMongoSettings
    {
        public string OrdersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHungryPizzaMongoSettings
    {
        string OrdersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}