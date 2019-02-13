using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ClassLibrary1.PristupTabulka pristup = new ClassLibrary1.PristupTabulka();
            ClassLibrary1.DatabazeZnamek databaze = new ClassLibrary1.DatabazeZnamek(pristup.DataAccess());
            databaze.Predmety.Add()
            ClassLibrary1.Predmet vah = new ClassLibrary1.Predmet();
            vah.Nazev = "VAH";
            layout.Children.Add(new Label { Text = vah.Nazev });
            foreach (ClassLibrary1.Znamka z in databaze.GetItemsFromSubject("VAH"))
            {
                layout.Children.Add(new Label { Text = z.znamka.ToString() });
            }
            layout.Children.Add(new Label { Text = "PCV" });
            foreach (ClassLibrary1.Znamka z in databaze.GetItemsFromSubject("PCV"))
            {
                layout.Children.Add(new Label { Text = z.znamka.ToString() });
            }
        }

        private async Button_Clicked(object sender, EventArgs e)
        {
            async Navigation.PushAsync(new NavigationPage(new AddMarks()));
        }

    }
}
