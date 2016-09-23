using System;
using Xamarin.Forms;
using FirstAid.Database;

namespace FirstAid
{
	

	public class LogPage : ContentPage
	{
		
		public LogPage()
		{
			
			LogTypeDB dDatabase = new LogTypeDB();


			var searchBar = new SearchBar
			{
				Placeholder = "Enter Search Term"
			};



			var listView2 = new ListView
			{
				RowHeight = 40,

				ItemsSource = dDatabase.GetAllLogTypes(),

				ItemTemplate = new DataTemplate(typeof(TextCell))
			};



			// Bind the CategoryName attribute to the TextCell in the ItemTemplate.
			listView2.ItemTemplate.SetBinding(TextCell.TextProperty, "LogInjuryName");

			// Add a handler for when a ListItem is selected.
			listView2.ItemSelected += onLogSelected;

			var Logo = new Image { Aspect = Aspect.AspectFit };
			Logo.Source = ImageSource.FromFile("LogAid.png");

			Button Home1 = new Button
			{
				Text = "Home",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};


			Button Add1 = new Button
			{
				Text = "Add Injury",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			Button Emergency1 = new Button
			{
				Text = "Emergency",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			// Assign delegates to the buttons that will change to different pages.
			Home1.Clicked += onHomeButtonClicked;
			Emergency1.Clicked += onEmergencyButtonClicked;
			Add1.Clicked += onAddButtonClicked;

			StackLayout list = new StackLayout
			{
				Children = {
					listView2
				},
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center
			};

			StackLayout buttons = new StackLayout
			{
				Children = {
					Home1,
					Emergency1,
					Add1
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Children = {
					searchBar,

					Logo,
					list,
					buttons
					}
			};
		}

		private void onEmergencyButtonClicked(object sender, EventArgs e)
		{
			
			Navigation.PushAsync(new EmergencyContact());
		}

		void onAddButtonClicked(object sender, EventArgs e)
		{
			

			Navigation.PushAsync(new NewLog()); 
		}

		private void onHomeButtonClicked(object sender, EventArgs e)
		{
			// Switch to the HomePage view.
			Navigation.PushAsync(new HomePage());
		}

		private void onLogSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// Ensure SelectedItem is not null. This is to make sure no action is taken when it is deselected.
			if (e.SelectedItem == null)
			{
				return;
			}

			// Get the selected item and cast it to category so we can pull the id.
			LogType edward = (LogType)e.SelectedItem;

			// Switch to the Injuries view and pass the current category id.
			Navigation.PushAsync(new CurrentLogs(edward.LogTypeId));
		}
	}
}

