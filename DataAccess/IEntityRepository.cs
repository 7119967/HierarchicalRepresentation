using HierarchicalRepresentation.Models;

namespace HierarchicalRepresentation.DataAccess
{
    public interface IEntityRepository
    {
        List<Entity> FilteredByParentId(int parentId);
        List<Entity> ListAllEntities();
        List<Entity> ListParentEntities();
        Entity GetEntityById(int id);
        Entity GetRootParent();
        int GetNewId();
        void CreateNewEntity(Entity entity);
        void RemoveEntityById(int id);
        void RemoveEntity(Entity entity);
    }
}
