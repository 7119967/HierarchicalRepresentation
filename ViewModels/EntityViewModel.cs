﻿namespace HierarchicalRepresentation.ViewModels
{
    public class EntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
    }
}
