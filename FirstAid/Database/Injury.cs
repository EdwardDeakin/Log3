using SQLite.Net.Attributes;

namespace FirstAid.Database
{
    // Class describes the database table Injury.
    class Injury
    {
        // SQLite class attribute, defines the primary key.
        [PrimaryKey, AutoIncrement]
        public int InjuryId { get; set; }
        public string InjuryName { get; set; }
        public int CategoryId { get; set; }
        public int TreatmentId { get; set; }
    }
}
