using HierarchicalRepresentation.Models;

namespace HierarchicalRepresentation.ViewModels
{
    public class CreateEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
    }
}
