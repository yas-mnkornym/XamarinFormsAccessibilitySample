using System.ComponentModel;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinFormsNarratorSample.Views.Effects;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(XamarinFormsNarratorSample.UWP.Effects.UwpAccessibilityEffect), "AddAccessibilityEffect")]

namespace XamarinFormsNarratorSample.UWP.Effects
{
	public class UwpAccessibilityEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			UpdateName();
			UpdateAccessibilityView();
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			if (args.PropertyName == AccessibilityEffect.AccessibilityLabelProperty.PropertyName) {
				UpdateName();
			}
			else if (args.PropertyName == AccessibilityEffect.InAccessibleTreeProperty.PropertyName) {
				UpdateAccessibilityView();
			}
		}

		void UpdateName()
		{
			AutomationProperties.SetName(Control, AccessibilityEffect.GetAccessibilityLabel(Element) as string ?? string.Empty);
		}

		void UpdateAccessibilityView()
		{
			AutomationProperties.SetAccessibilityView(Control, AccessibilityEffect.GetInAccessibleTree(Element) ? AccessibilityView.Control : AccessibilityView.Raw);
		}
	}
}
