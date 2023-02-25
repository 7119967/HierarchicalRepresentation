namespace HierarchicalRepresentation.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public virtual Entity Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
