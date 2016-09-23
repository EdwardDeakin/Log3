using System;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FirstAid.Database
{
    class InjuryDatabase
    {
        private SQLiteConnection _Database;

        public InjuryDatabase()
        {
            _Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

            // Create the table if it doesn't not exist.
            _Database.CreateTable<Injury>();
            
            // Check how many rows are in the table, if it's empty. Add the initial data.
            if (_Database.Table<Injury>().Count() == 0)
            {
                // Add data here.
                _Database.Insert(new Injury { InjuryName = "First Degree Burn", CategoryId = 1, TreatmentId = 1 });
                _Database.Insert(new Injury { InjuryName = "Second Degree Burn", CategoryId = 1, TreatmentId = 2 });
                _Database.Insert(new Injury { InjuryName = "Third Degree Burn", CategoryId = 1, TreatmentId = 3 });
                _Database.Insert(new Injury { InjuryName = "Broken Arm", CategoryId = 2, TreatmentId = 4 });
                _Database.Insert(new Injury { InjuryName = "Broken Rib", CategoryId = 2, TreatmentId = 5 });
            }
        }

        public IEnumerable<Injury> GetAllInjuries()
        {
            // Get all of the categories from the database table.
            return _Database.Table<Injury>();
        }

        public IEnumerable<Injury> GetInjuriesByCategory(int categoryId)
        {
            // Get all of the categories from the database table.
            return _Database.Query<Injury>("SELECT * FROM Injury WHERE CategoryId = ?", categoryId);
        }

        public IEnumerable<Injury> GetInjuriesByTitle(string title)
        {
            // Get all of the categories from the database table.
            return _Database.Query<Injury>("SELECT * FROM Injury WHERE InjuryName LIKE ?", title);
        }
    }
}
