using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinFormsNarratorSample.Views.Effects;
using static XamarinFormsNarratorSample.Views.Effects.AccessibilityEffect;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(AddAccessibilityEffect), "AddAccessibilityEffect")]

namespace XamarinFormsNarratorSample.Droid.Effects
{
	/// <summary>Add accessibility properties to Xamarin.Forms controls in Android</summary>
	public class AddAccessibilityEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try {
				Control.ContentDescription = AccessibilityEffect.GetAccessibilityLabel(Element);
				Control.Focusable = AccessibilityEffect.GetInAccessibleTree(Element);
			}
			catch (Exception ex) {
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			if (args.PropertyName == AccessibilityEffect.AccessibilityLabelProperty.PropertyName) {
				Control.ContentDescription = AccessibilityEffect.GetAccessibilityLabel(Element);
			}
			else if (args.PropertyName == AccessibilityEffect.InAccessibleTreeProperty.PropertyName) {
				Control.Focusable = AccessibilityEffect.GetInAccessibleTree(Element);
			}
		}
	}
}