using SQLite.Net.Attributes;

namespace FirstAid.Database
{
	// Class describes the database table Category.
	class LogType
	{
		// SQLite class attribute, defines the primary key.
		[PrimaryKey, AutoIncrement]

		public int LogTypeId { get; set; }
		public string LogInjuryName { get; set; }
		public string EmailName { get; set;}
		public override string ToString()
		{
			return string.Format("[LogType: LogTypeId={0},LogInjuryName={1}, EmailName={2}", LogTypeId, LogInjuryName, EmailName);
		}

	}
}


