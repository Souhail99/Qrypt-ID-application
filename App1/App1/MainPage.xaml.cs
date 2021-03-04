using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }

        private void OnPressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Pressed";
            button.BackgroundColor = Color.White;
            Content = new View1();
        }

        private void OnReleased(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Realeased";
            button.BackgroundColor = Color.Salmon;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Pressed";
            button.BackgroundColor = Color.White;
            Content = new View1();
        }

        public void Alpha()
        {
            Random rd = new Random();
            bool passe = false;
            System.Threading.Thread.Sleep(50);
            Task.Delay(rd.Next(10000, 20000)).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "En préparation")
                {
                    commande.EtatCommande = "En livraison";
                    passe = true;
                }
                int index = 0;
                if (passe)
                {
                    for (int i = 0; i < livreurs.Count; i++)
                    {
                        if (livreurs[i].Commandedulivreur.NumeroDeCommande == commande.NumeroDeCommande)
                        {
                            index = i;
                        }
                        else { }
                    }
                    livreurs[index].EtatLivraison();
                    tb.Text = "En livraison";
                }
                passe = false;
                System.Threading.Thread.Sleep(50);
                Task.Delay(rd.Next(20000, 30000)).ContinueWith(x =>
                {
                    if (commande.EtatCommande == "En livraison")
                    {
                        commande.EtatCommande = "Arrivée";
                        passe = true;
                    }
                    if (passe)
                    {
                        livreurs[index].Etat = "Sur place";
                        tb.Text = "Arrivée";
                    }
                }
                );
            }
            );



            Task.Delay(50000).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "Arrivée")
                {
                    this.com.Remove(commande);
                    ltb.Remove(tb);
                    ltb2.Remove(tb2);
                    ltb3.Remove(tb3);
                    ltb4.Remove(tb4);
                    ltb5.Remove(tb5);
                }
            }
           );


        }
    }
}
