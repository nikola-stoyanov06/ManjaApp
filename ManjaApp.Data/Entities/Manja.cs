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
        public virtual AppUser? User { get; set; }
        public string? UserId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual Category? Category { get; set; }
    }
}