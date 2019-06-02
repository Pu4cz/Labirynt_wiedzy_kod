using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LabiryntWiedzy
{
    /// <summary>
    /// Klasa zawierająca wszystkie funkcje związane z zapisem rozgrywki.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Podsumowanie : UserControl
    {
        private static Podsumowanie _zmiana;

        public static Podsumowanie Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Podsumowanie();
                return _zmiana;
            }
        }


        public Podsumowanie()
        {
            InitializeComponent();
            Wynik();
            TekstPods();
        }

        // *********************************************************

        /// <summary>
        /// Suma wyników uzyskanych na wrzystkich poziomach
        /// </summary>
        int WynikKoncowy;

        /// <summary>
        /// Funkcja, która sumuje wyniki uzyskane z każdego poziomu.
        /// </summary>
        public void Wynik()
        {
            WynikKoncowy = (Lab1.WynikPoz1 + Lab2.WynikPoz2 + Lab3.WynikPoz3 + Lab4.WynikPoz4 + Lab5.WynikPoz5) / 2;
            Sumarum.Text = "Twój wynik: " + WynikKoncowy;
        }

        // *********************************************************
 
        /// <summary>
        /// Funkcja generująca komentarz dotyczący umiejętności koncentracji gracza zależny od uzyskanego wyniku.
        /// </summary>
        public void TekstPods()
        {
            if (WynikKoncowy > 80)
            {
                PodsTekst.Text = "Gratulacje twoja umiejętność koncentracji jest ponadprzeciętna!";
            }
            else if (WynikKoncowy <= 80 && WynikKoncowy > 50)
            {
                PodsTekst.Text = "Nie masz problemów z koncentracją!";
            }
            else if (WynikKoncowy <= 60 && WynikKoncowy > 40)
            {
                PodsTekst.Text = "Musisz trochę poćwiczyć nad koncentracją";
            }
            else if (WynikKoncowy <= 40 && WynikKoncowy >= 15)
            {
                PodsTekst.Text = "Musisz poćwiczyć nad koncentracją!";
            }
            else
            {
                PodsTekst.Text = "Zdecydowanie musisz poćwiczyć koncentrację!";
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja pobierająca i wyświetlająca zawartość pliku z wynikami
        /// </summary>      
        public void Wyniki(object sender, EventArgs e)
        {
            using (StreamReader read = new StreamReader("Wyniki.txt"))
            {
                String line = read.ReadToEnd();
                PodsTekst.Text = line;
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zapisująca do pliku wynik wraz z nazwą gracza i wyjście z gry
        /// </summary>     
        public void Koniec(object sender, EventArgs e)
        {

            using (StreamWriter writer = new StreamWriter(("Wyniki.txt"), true))
            {
                writer.WriteLine(NazwaGracza.Text + " ->  " + WynikKoncowy);
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}