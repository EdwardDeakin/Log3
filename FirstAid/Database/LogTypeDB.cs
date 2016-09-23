using System;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FirstAid.Database
{
	class LogTypeDB
	{
		private SQLiteConnection _Database;

		public LogTypeDB()
		{
			System.Diagnostics.Debug.WriteLine("I'm in the LogType database");
			_Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

			// Create the table if it doesn't not exist.
			_Database.CreateTable<LogType>();

			// Check how many rows are in the table, if it's empty. Add the initial data.
			if (_Database.Table<LogType>().Count() == 0)
			{
				// Add data here.
				//_Database.Insert(new LogType { LogInjuryName = "Burnt arm" });
				_Database.Insert(new LogType { LogInjuryName = "Test", EmailName = "Test email" });
			}
		}


		//_Database.DeleteAll<LogType>();
		public IEnumerable<LogType> GetAllLogTypes()
		{
			// Get all of the categories from the database table.
			return _Database.Table<LogType>();
		}
	}
}


