using System;

using Xamarin.Forms;

namespace XamarinFormsNarratorSample.Views
{
	public partial class MainPage : ContentPage
	{
		static Color[] Colors { get; } = new[]
		{
			Color.White,
			Color.Red,
			Color.Blue,
			Color.Green,
			Color.Black,
		};

		private static int currentIndex_ = 0;

		public MainPage()
		{
			InitializeComponent();
			BackgroundColor = Colors[currentIndex_];
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			currentIndex_ = (currentIndex_ + 1) % Colors.Length;
			BackgroundColor = Colors[currentIndex_];
		}
	}
}
