using HierarchicalRepresentation.Models;

namespace HierarchicalRepresentation.DataAccess
{
    public interface IEntityRepository
    {
        IEnumerable<Entity> FilteredByParentId(int parentId);
        IEnumerable<Entity> ListAllEntities();
        IEnumerable<Entity> ListParentEntities();
        Entity GetEntityById(int id);
        Entity GetRootParent();
        int GetNewId();
        void CreateNewEntity(Entity entity);
        void RemoveEntityById(int id);
        void RemoveEntity(Entity entity);
    }
}
