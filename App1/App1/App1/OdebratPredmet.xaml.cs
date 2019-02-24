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
	public partial class OdebratPredmet : ContentPage
	{
        PristupTabulka pristup = new PristupTabulka();
        
        public OdebratPredmet ()
		{
			InitializeComponent ();
            Databaze db = new Databaze(pristup.DataAccess());
            foreach (Predmet p in db.GetAllPredmety())
            {
                predmetinput.Items.Add(p.Nazev);
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Databaze db = new Databaze(pristup.DataAccess());
            foreach (Predmet p in db.GetAllPredmety())
            {
                if (p.Nazev.Equals((string)predmetinput.SelectedItem))
                {
                    db.DeleteItemPredmet(p);
                    foreach(Znamka z in db.GetZnamky(p.Id)){
                        db.DeleteItemZnamka(z);
                    }
                    Navigation.PushAsync(new MainPage());
                }
            }
        }

    }
}