namespace HierarchicalRepresentation.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public virtual Entity Parent { get; set; }
        public int? ParentId { get; set; }
        public bool HasParent()
        {
            return Parent != null;
        }
        public ICollection<Entity> Children { get; set; }   // дочерние пункты меню
        public Entity()
        {
            Children = new List<Entity>();
        }
    }
}
