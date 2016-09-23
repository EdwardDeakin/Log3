using System;
using Xamarin.Forms;
using Plugin.Messaging;
namespace FirstAid
{
	public class EmergencyContact : ContentPage
	{
		public EmergencyContact()
		{
			Button emergencyCall = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			Button Call = new Button
			{
				Text = "Call",
        HorizontalOptions = LayoutOptions.StartAndExpand 
			};

			Button Call2 = new Button
			{
				Text = "Call",
HorizontalOptions = LayoutOptions.StartAndExpand

			};

			Button Call3 = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.StartAndExpand

			};
			Button Call4 = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.StartAndExpand

			};
			Button Call5 = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.StartAndExpand

			};
			Button Home = new Button
			{
				Text = "Home",
				HorizontalOptions = LayoutOptions.StartAndExpand


			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Children = {
					new Label { Text = "Emergency Services: 000",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
	FontAttributes = FontAttributes.Bold},
					emergencyCall,
					new Label { Text = "Emergency Contact 1: Poison Control ",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
	FontAttributes = FontAttributes.Bold},
					Call,
					new Label { Text = "Emergency Contact 2: SES ",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
	FontAttributes = FontAttributes.Bold,},
					Call2,
					new Label { Text = "Emergency Contact 3: HealthCare Direct ",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
	    FontAttributes = FontAttributes.Bold},
					Call3,
					new Label { Text = "Emergency Contact 4: Animal Control ",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
		FontAttributes = FontAttributes.Bold},
					Call4,
					new Label { Text = "Emergency Contact 3: Disney Trivia Hotline ",
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
		FontAttributes = FontAttributes.Bold},
					Call5,

					Home


				}
			};
			Home.Clicked += onHomeClicked;
			emergencyCall.Clicked += onemergClicked;
			Call.Clicked += onCallButtonClicked;
			Call2.Clicked += onCallButtonClicked;
			Call3.Clicked += onCallButtonClicked;

		}

		private void onHomeClicked(object sender, EventArgs e)
		{
			// Switch to the HomePage view.
			Navigation.PushAsync(new HomePage());
		}
		private void onemergClicked(object sender, EventArgs e)
		{

			var phoneCallTask = MessagingPlugin.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
				phoneCallTask.MakePhoneCall("+272193343499");
		}
			private void onCallButtonClicked(object sender, EventArgs e)
		{

			var phoneCallTask = MessagingPlugin.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
				phoneCallTask.MakePhoneCall("+272193343499");
		}

		private void onCall2ButtonClicked(object sender, EventArgs e)
		{

			var phoneCallTask = MessagingPlugin.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
				phoneCallTask.MakePhoneCall("+272193343499");
		}
		private void onCall3ButtonClicked(object sender, EventArgs e)
		{

			var phoneCallTask = MessagingPlugin.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
				phoneCallTask.MakePhoneCall("+272193343499");
		}


		}
	}
