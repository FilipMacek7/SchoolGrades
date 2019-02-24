using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PridatPredmet : ContentPage
	{
		public PridatPredmet()
		{
			InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            Predmet predmet = new Predmet();
            if(db.GetPredmety().Count() == 0 & !string.IsNullOrWhiteSpace(nazevinput.Text))
            {
                predmet.Nazev = nazevinput.Text;
                db.SaveItemPredmet(predmet);
                Navigation.PushAsync(new MainPage());
            }
            else if(db.GetPredmety().Count() > 0 & !string.IsNullOrWhiteSpace(nazevinput.Text))
            {
                foreach (Predmet p in db.GetPredmety())
                {
                    if (p.Nazev != nazevinput.Text)
                    {
                        predmet.Nazev = nazevinput.Text;
                        db.SaveItemPredmet(predmet);
                        Navigation.PushAsync(new MainPage());
                    }
                    else if (p.Nazev == nazevinput.Text)
                    {
                        DisplayAlert("Chyba", "Tento předmět již existuje", "OK");
                    }
                }
            }
            else if (string.IsNullOrWhiteSpace(nazevinput.Text))
            {
                DisplayAlert("Chyba", "Název nesmí být prázdný", "OK");
            }
        }

    }
}