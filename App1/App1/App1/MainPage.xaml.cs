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
            foreach (Predmet p in db.GetAllPredmety())
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
                    if (deleteZnamka)
                    {
                        Button button = new Button();
                        button.Clicked += Button_Clicked5;
                        button.ClassId = z.ID.ToString();
                        layout.Children.Add(button);
                    }
                }
                Label label3 = new Label();
                label3.Text = "Průměr: " + db.prumerPredmetu(p.Id).ToString();
                layout.Children.Add(label3);
                BoxView boxview = new BoxView();
                boxview.Color = Color.Black;
                boxview.WidthRequest = 100;
                boxview.HeightRequest = 1;
                layout.Children.Add(boxview);
            }
        }

        private void Page_Reload()
        {
            layout.Children.Clear();
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            foreach (Predmet p in db.GetAllPredmety())
            {
                Label label = new Label();
                label.Text = p.Nazev;
                label.FontSize = 18;
                layout.Children.Add(label);
                foreach (Znamka z in db.GetZnamky(p.Id))
                {
                    Label label2 = new Label();
                    label2.Text = "Známka - " + z.znamka.ToString() + " - Váha: " + z.Vaha.ToString();
                    layout.Children.Add(label2);
                    if (deleteZnamka)
                    {
                        Button button = new Button();
                        button.Text = "Smazat";
                        button.HeightRequest = 50;
                        button.WidthRequest = 1;
                        button.Clicked += Button_Clicked5;
                        button.ClassId = z.ID.ToString();
                        layout.Children.Add(button);
                    }
                }
                Label label3 = new Label();
                label3.Text = "Průměr: " + db.prumerPredmetu(p.Id).ToString();
                layout.Children.Add(label3);
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
        bool deleteZnamka = false;
        private void Button_Clicked4(object sender, EventArgs e)
        {
            deleteZnamka = true;
            Page_Reload();
        }
        private void Button_Clicked5(object sender, EventArgs e)
        {
            PristupTabulka pristup = new PristupTabulka();
            Databaze db = new Databaze(pristup.DataAccess());
            var button = (Button)sender;
            var classId = button.ClassId;
            db.DeleteItemZnamka(db.GetItemZnamka(int.Parse(classId)));
            deleteZnamka = false;
            Page_Reload();
        }
    }
}