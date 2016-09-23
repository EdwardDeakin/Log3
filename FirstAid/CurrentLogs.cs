using System;
using Xamarin.Forms;
using FirstAid.Database;
using Plugin.Messaging;
using SQLite.Net;


namespace FirstAid
{

	class CurrentLogs : ContentPage
	{
		private SQLiteConnection _Database;

		public CurrentLogs(int LogTypeId)
		{


			System.Diagnostics.Debug.WriteLine("LogType ID is " + LogTypeId);
			_Database = DependencyService.Get<IDatabaseConnection>().GetConnection();

			//this.SetBinding(TitleProperty, "Name");



			var subject = _Database.Get<LogType>(LogTypeId).LogInjuryName;
			var stoc = _Database.Get<LogType>(LogTypeId).EmailName;




			var filler = new Label { };




			var Resipient = new Label { Text = "Please Enter" };
			var RecoveryUpdate = new Label { Text = "Please Enter Recovery Update" };

			var EmailName = new Editor
			{
				Text = stoc.ToString(),
				VerticalOptions = LayoutOptions.FillAndExpand,
			};


			var Email2 = new Editor
			{
				Text = "",
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			//Lab.SetBinding(Editor.TextProperty, "Name");



			var emailTask2 = MessagingPlugin.EmailMessenger;




			var delButton = new Button { Text = "Delete" };
			delButton.Clicked += (sender, e) =>
			{


				_Database.Delete<LogType>(LogTypeId);
				Navigation.PushAsync(new LogPage());
			};
			Button Home1 = new Button
			{
				Text = "Log Home",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			//DateTime today = new DateTime();
			var EmailButton = new Button
			{
				Text = "Email Update",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			EmailButton.Clicked += (sender, e) =>
			{

				var email2 = new EmailMessageBuilder()

		.To(EmailName.Text)
		.Subject(subject)
				.BodyAsHtml(Email2.Text)

		.Build();


				emailTask2.SendEmail(email2);

			};

			Home1.Clicked += onHomeButtonClicked;

			StackLayout edit = new StackLayout
			{
				Children = {
					 Resipient,
					EmailName,
					RecoveryUpdate,
					Email2
				},
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center
			};

			StackLayout buttons = new StackLayout
			{
				Children = {
					Home1,
					EmailButton,
				delButton},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Children = {

					edit,
					buttons
					}
			};

		}
			private void onHomeButtonClicked(object sender, EventArgs e)
		{
			// Switch to the HomePage view.
			Navigation.PushAsync(new LogPage());
		}


		}



	}



