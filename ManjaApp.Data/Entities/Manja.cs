using ManjaApp.Data.Entities.Abstractions;

namespace ManjaApp.Data.Entities
{
    public class Manja : BaseEntity
    {
        public Manja()
        {
            Ingredients = new HashSet<Ingredient>();
            Comments = new HashSet<Comment>();
        }
        public AppUser? User { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public Category? Category { get; set; }
    }
}