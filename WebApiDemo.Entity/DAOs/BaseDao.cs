namespace WebApiDemo.Entity.DAOs
{
    public class BaseDao
    {
        public BaseDao() 
        {
            CreatedDatetime = DateTime.UtcNow;
            ModifiedDatetime = DateTime.UtcNow;
        }

        public long Id { get; set; }

        public DateTime CreatedDatetime { get; set; }

        public DateTime ModifiedDatetime { get; set; }
    }
}
