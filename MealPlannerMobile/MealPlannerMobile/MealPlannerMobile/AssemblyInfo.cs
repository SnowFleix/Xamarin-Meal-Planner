using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#region Fonts
[assembly: ExportFont("Assets/Fonts/Heebo-Regular.ttf", Alias = "Heebo")]
#endregion

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)] // for me this caused more issues as a value was null at the start of every XAML page and I couldn't find a fix for it