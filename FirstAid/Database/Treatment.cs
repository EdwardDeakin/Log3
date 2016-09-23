using SQLite.Net.Attributes;

namespace FirstAid.Database
{
    // Class describes the database table Treatment.
    class Treatment
    {
        // SQLite class attribute, defines the primary key.
        [PrimaryKey, AutoIncrement]
        public int TreatmentId { get; set; }
        public string TreatmentHeading { get; set; }
        public string TreatmentText { get; set; }
		public override string ToString()
		{
			return string.Format("[Treatment: TreatmentId={0}, TreatmentHeading={1}, TreatmentText={2}]", TreatmentId, TreatmentHeading, TreatmentText);
		}
    }
}
