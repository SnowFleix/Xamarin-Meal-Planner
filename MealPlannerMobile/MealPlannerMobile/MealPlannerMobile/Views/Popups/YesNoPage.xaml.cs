using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesNoPage : PopupPage
    {
        public string Title { get; set; }
        public YesNoPage(string text)
        {
            InitializeComponent();
            Title = text;
        }

        /// <summary>
        /// 
        /// </summary>
        private async void ReturnBoolAndClose(bool condition)
        {
            MessagingCenter.Send<YesNoPage, bool>(this, "YesNoPageReply", condition); // 
            await PopupNavigation.PopAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void YesButtonClicked(object source, EventArgs args)
        {
            ReturnBoolAndClose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void NoButtonClicked(object source, EventArgs args)
        {
            ReturnBoolAndClose(false);
        }
    }
}