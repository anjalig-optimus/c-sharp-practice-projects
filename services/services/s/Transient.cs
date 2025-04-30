namespace services.s
{
    public class Transient:ITransient
    {
        public readonly Guid id;
        public Transient()
        {
            id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return id.ToString();
        }
    }
}
