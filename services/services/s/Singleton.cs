namespace services.s
{
    public class Singleton:ISingleton
    {
        public readonly Guid id;
        public Singleton()
        {
            id=Guid.NewGuid();
        }
        public string GetGuid()
        {
            return id.ToString();
        }
    }
} 
