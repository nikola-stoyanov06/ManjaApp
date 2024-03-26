using ManjaApp.Data.Entities.Abstractions;

namespace ManjaApp.Data.Entities
{
    public class Manja : BaseEntity
    {
        public AppUser User { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public ICollection<ManjaIngredient>? Ingredients { get; set; }
        public string Instructions { get; set; }
        public List<string>? Pictures { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public Category Category { get; set; }
        public virtual double Rating { get; set; }
    }
}