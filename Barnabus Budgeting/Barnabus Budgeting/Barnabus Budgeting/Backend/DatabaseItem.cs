using SQLite;

namespace Barnabus_Budgeting.Backend
{
    public class DatabaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }
    }
}
