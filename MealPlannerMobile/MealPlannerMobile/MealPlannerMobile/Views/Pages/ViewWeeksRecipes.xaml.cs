using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWeeksRecipes : ContentPage
    {
        // BindableProperty implementation
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ViewWeeksRecipes), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Helper method for invoking commands safely
        public static void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }

        public ViewWeeksRecipes()
        {
            InitializeComponent();

            this.BindingContext = Repository.result; // TODO: Change to use persistent data
        }

        // this is the command that gets bound by the control in the view
        // (ie. a Button, TapRecognizer, or MR.Gestures)
        public Command OnTap => new Command(() => { 
            Execute(Command); 
            Console.WriteLine("Got to the executing part"); 
        } );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnCardTapped(object sender, EventArgs e)
        {
            // TODO: Find out how to get the data from the tapped card
            await Navigation.PushModalAsync(new ViewRecipe(  new Recipe()  ));
        }
    }
}