namespace SportsStore.DAL.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Base64 { get; set; }
    }
}
