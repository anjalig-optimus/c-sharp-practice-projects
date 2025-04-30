namespace services.s
{
    public class Scoped:IScoped
    {
        public readonly Guid id;
        public Scoped()
        {
            id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return id.ToString();
        }
    }
}
