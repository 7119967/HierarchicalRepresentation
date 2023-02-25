using HierarchicalRepresentation.Models;

namespace HierarchicalRepresentation.DataAccess
{
    public class EntityRepository : IEntityRepository
    {
        private List<Entity> entities = new List<Entity>
        {
          new Entity() { Id = 1, Name = "Layout", Icon = "<i class=\"ri-menu-line\"></i>", ParentId = null },
          new Entity() { Id = 2, Name = "Navigator", Icon = "<i class=\"ri-organization-chart\"></i>", ParentId = 1 },
          new Entity() { Id = 3, Name = "TopBar", Icon = "<i class=\"ri-menu-line\"></i>", ParentId = 1 },
          new Entity() { Id = 4, Name = "Exit", ParentId = 3 },
          new Entity() { Id = 5, Name = "Language", ParentId = 3 },
          new Entity() { Id = 6, Name = "Currency", ParentId = 3 },
          new Entity() { Id = 7, Name = "Settings", Icon = "<i class=\"ri-settings-2-line\"></i>",ParentId = 1 },
          new Entity() { Id = 8, Name = "Footer", Icon = "<i class=\"ri-menu-line\"></i>", ParentId = 1 }
        };
        public List<Entity> FilteredByParentId(int parentId)
        {
            return entities.FindAll(e => e.ParentId == parentId);
        }
        public Entity GetEntityById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }
        public int GetNewId()
        {
            return entities.Max(e => e.Id);
        }
        public List<Entity> ListAllEntities()
        {
            return entities.ToList();
        }
        public List<Entity> ListParentEntities()
        {
            return entities.FindAll(e => e.ParentId == null);
        }
        public void CreateNewEntity(Entity entity)
        {
            entities.Add(entity);
        }
        public void RemoveEntityById(int id)
        {
            entities.RemoveAt(id);
        }
        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }
        public Entity GetRootParent()
        {
            return entities.FirstOrDefault(e => e.ParentId == null);
        }
    }
}
