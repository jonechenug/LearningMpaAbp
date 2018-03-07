namespace LearningMpaAbp
{
    public class RedisConfiguration
    {
        public int InstanceDbId { get; set; }
        public string InstanceRedisConnectionString { get; set; }
    }

    public class MongodbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatatabaseName { get; set; }
    }
}
