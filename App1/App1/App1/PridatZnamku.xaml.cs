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
	public partial class PridatZnamku : ContentPage
	{
		public PridatZnamku()
		{
			InitializeComponent();         
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            foreach (Predmet p in db.GetAllPredmety())
            {
                predmetinput.Items.Add(p.Nazev);
            }
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            int value;
            int value2;
            if(int.TryParse(znamkainput.Text, out value) & int.TryParse(vahainput.Text, out value2))
            {
                foreach (Predmet p in db.GetAllPredmety())
                {
                    if(p.Nazev == (string)predmetinput.SelectedItem){
                        Znamka znamka = new Znamka();
                        znamka.znamka = value;
                        znamka.Vaha = value2;
                        znamka.PredmetID = p.Id;
                        p.Znamky = new List<Znamka> { znamka };
                        db.SaveItemZnamka(znamka);
                        Navigation.PushAsync(new MainPage());
                    }
                }
            }
        }

    }
}