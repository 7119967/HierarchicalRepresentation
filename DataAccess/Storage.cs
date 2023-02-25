namespace HierarchicalRepresentation.DataAccess
{
    public class Storage : IStorage
    {
        public IEntityRepository EntityRepository { get; set; }
        public Storage()
        {
            EntityRepository = new EntityRepository();
        }
    }
}
