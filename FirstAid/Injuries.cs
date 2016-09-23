using System;
using Xamarin.Forms;
using FirstAid.Database;

namespace FirstAid
{
    class Injuries : ContentPage
    {
        public Injuries(int categoryId)
        {
            // Create an object that can access the database table Injury.
            InjuryDatabase iDatabase = new InjuryDatabase();

            // Create the listview that will hold the injuries.
            var listView = new ListView
            {
                RowHeight = 40,
                // Define where to pull the data from, in this case it is the rows from the Injury table.
                ItemsSource = iDatabase.GetInjuriesByCategory(categoryId),
                // Define the ItemTemplate, this will contain a single TextCell.
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };

            // Bind the InjuryName attribute to the TextCell in the ItemTemplate.
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "InjuryName");

            //Add a handler for when the ListItem is selected.
            listView.ItemSelected += onInjurySelected;

            Button Home = new Button
            {
                Text = "Home",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Home.Clicked += onHomeButtonClicked;

            Content = new StackLayout
            {

                Children = {
                    listView,
                    Home
                }
            };
        }

        private void onInjurySelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Ensure SelectedItem is not null. This is to make sure no action is taken when it is deselected.
            if (e.SelectedItem == null)
            {
                return;
            }

            // Get the selected item and cast it to injury so we can pull the id.
            Injury injury = (Injury)e.SelectedItem;

            // Switch to the Display view and pass the current injury id.
            Navigation.PushAsync(new Display(injury.TreatmentId));
        }

        private void onHomeButtonClicked(object sender, EventArgs e)
        {
            // Switch to the HomePage view.
            Navigation.PushAsync(new HomePage());
        }
    }
}
