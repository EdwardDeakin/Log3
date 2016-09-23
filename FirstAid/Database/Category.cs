using SQLite.Net.Attributes;

namespace FirstAid.Database
{
    // Class describes the database table Category.
    class Category
    {
        // SQLite class attribute, defines the primary key.
        [PrimaryKey, AutoIncrement]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
