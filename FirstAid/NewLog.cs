using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite.Net;
using FirstAid.Database; 

namespace FirstAid
{
	public class NewLog : ContentPage
	{
		public SQLiteConnection _Database;

		public NewLog()
		{
			_Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

			this.SetBinding(TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar(this, true);
			var nameLabel = new Label { Text = "Enter Injury" };
			var nameEntry = new Editor();
			var emailLabel = new Label { Text = "Enter Repicient" };
			var emailEntry = new Editor();

			nameEntry.SetBinding(Entry.TextProperty, "Name");
			emailEntry.SetBinding(Entry.TextProperty, "Name");




			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) =>
			{
				

				_Database.Insert(new LogType { LogInjuryName = nameEntry.Text, EmailName = emailEntry.Text });
				Navigation.PushAsync(new LogPage());
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) =>
			{



				Navigation.PushAsync(new LogPage());
			};


			StackLayout buttons = new StackLayout
			{
				Children = {
					saveButton,
					cancelButton
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};


			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, 
					nameEntry,
					emailLabel,
					emailEntry,
					buttons

				}
			};
		}
	}
}
