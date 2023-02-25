namespace HierarchicalRepresentation.DataAccess
{
    public interface IStorage
    {
        IEntityRepository EntityRepository { get; set; }
    }
}
