using ClassLibrary1;
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
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            foreach(Predmet p in db.GetPredmety())
            {
                Label label = new Label();
                label.Text = p.Nazev;
                label.FontSize = 18;
                layout.Children.Add(label);
                foreach (Znamka z in db.GetZnamky(p.Id))
                {
                    Label label2 = new Label();
                    label2.Text = z.znamka.ToString() + " - Váha: " + z.Vaha.ToString();
                    layout.Children.Add(label2);                  
                }
                Label label3 = new Label();
                label3.Text = "Průměr:"  +db.prumerPredmetu(p.Id).ToString();
                BoxView boxview = new BoxView();
                boxview.Color = Color.Black;
                boxview.WidthRequest = 100;
                boxview.HeightRequest = 1;            
                layout.Children.Add(boxview);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PridatPredmet());
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PridatZnamku());
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OdebratPredmet());
        }
        private void Button_Clicked4(object sender, EventArgs e)
        {
            
        }
    }
}