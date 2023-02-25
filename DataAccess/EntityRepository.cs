using HierarchicalRepresentation.Models;

namespace HierarchicalRepresentation.DataAccess
{
    public class EntityRepository : IEntityRepository
    {
        public static List<Entity> entities = new List<Entity>
        {
          new Entity() { Id = 1, Name = "Layout", ParentId = null, Icon = "<i class=\"ri-menu-line\"></i>" },
          new Entity() { Id = 2, Name = "Navigator", ParentId = 1, Icon = "<i class=\"ri-organization-chart\"></i>" },
          new Entity() { Id = 3, Name = "TopBar", ParentId = 1, Icon = "<i class=\"ri-menu-line\"></i>" },
          new Entity() { Id = 4, Name = "Exit", ParentId = 3, Icon = "" },
          new Entity() { Id = 5, Name = "Language", ParentId = 3, Icon = "" },
          new Entity() { Id = 6, Name = "Currency", ParentId = 3, Icon = "" },
          new Entity() { Id = 7, Name = "Settings", ParentId = 1, Icon = "<i class=\"ri-settings-2-line\"></i>" },
          new Entity() { Id = 8, Name = "Footer", ParentId = 1, Icon = "<i class=\"ri-menu-line\"></i>" }
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
