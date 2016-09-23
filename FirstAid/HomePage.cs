using System;
using Xamarin.Forms;
using FirstAid.Database;

namespace FirstAid
{
	public class HomePage : ContentPage
	{
        ListView listView;

		public HomePage()
		{
            // Create an object that can access the database table Category.
            CategoryDatabase cDatabase = new CategoryDatabase();

            var searchBar = new SearchBar
            {
                Placeholder = "Enter Search Term"
            };

            searchBar.TextChanged += onSearchBarTextChanged;

            // Create the listview that will hold the categories of all the injuries.
            listView = new ListView
            {
                RowHeight = 40,
                // Define where to pull the data from, in this case it is the rows from the Category table.
                ItemsSource = cDatabase.GetAllCategories(),
                // Define the ItemTemplate, this will contain a single TextCell.
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };

            // Bind the CategoryName attribute to the TextCell in the ItemTemplate.
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "CategoryName");

            // Add a handler for when a ListItem is selected.
            listView.ItemSelected += onCategorySelected;

            var Logo = new Image { Aspect = Aspect.AspectFit };
            Logo.Source = ImageSource.FromFile("FirstAid.png");

            Button Home = new Button
            {
                Text = "Home",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Button Emergency = new Button
            {
                Text = "Emergency",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Button RecoveryLog = new Button
			{
				Text = "RecoveryLog",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			// Assign delegates to the buttons that will change to different pages.
			Home.Clicked += onHomeButtonClicked;
			Emergency.Clicked += onEmergencyButtonClicked;
			RecoveryLog.Clicked += onRecoveryLogButtonClicked;

            StackLayout list = new StackLayout
            {
                Children = {
                    listView
                },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout buttons = new StackLayout
            {
                Children = {
                    Home,
                    Emergency,
					RecoveryLog
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

        private void onSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            // Create an object that can access the database table Category.
            CategoryDatabase cDatabase = new CategoryDatabase();

            // If the search text is not empty, then update the list view with possible injuries.
            if (String.IsNullOrEmpty(e.NewTextValue))
            {
                listView.ItemsSource = cDatabase.GetAllCategories();
            }
            else
            {
                // Update the list view to search for injuries.
                listView.ItemsSource = cDatabase.GetCategoriesByTitle("%" + e.NewTextValue + "%");
            }
        }

        private void onEmergencyButtonClicked(object sender, EventArgs e)
        {
            // Switch to the Emergency view.
            Navigation.PushAsync(new EmergencyContact());
        }

        private void onHomeButtonClicked(object sender, EventArgs e)
        {
            // Switch to the HomePage view.
            Navigation.PushAsync(new HomePage());
        }

		private void onRecoveryLogButtonClicked(object sender, EventArgs e)
		{
			// Switch to the HomePage view.
			Navigation.PushAsync(new LogPage());
		}

        private void onCategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Ensure SelectedItem is not null. This is to make sure no action is taken when it is deselected.
            if (e.SelectedItem == null)
            {
                return;
            }

            // Get the selected item and cast it to category so we can pull the id.
            Category category = (Category)e.SelectedItem;

            // Switch to the Injuries view and pass the current category id.
            Navigation.PushAsync(new Injuries(category.CategoryId));
        }
    }
}


