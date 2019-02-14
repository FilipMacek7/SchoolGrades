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
            ClassLibrary1.Databaze databaze = new ClassLibrary1.Databaze(pristup.DataAccess());

            ClassLibrary1.Predmet vah = new ClassLibrary1.Predmet
            {
                Nazev = "VAH"
            };

            ClassLibrary1.Znamka znamka = new ClassLibrary1.Znamka
            {
                znamka = 1,
                Vaha = 30
            };

            vah.Znamky.Add(znamka);

            layout.Children.Add(new Label { Text = vah.Nazev });
            foreach (ClassLibrary1.Znamka z in databaze.GetItemsFromSubject("VAH"))
            {
                layout.Children.Add(new Label { Text = z.znamka.ToString() });
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddMarks()));
        }

    }
}
