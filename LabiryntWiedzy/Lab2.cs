using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LabiryntWiedzy
{
    /// <summary>
    /// Klasa zawierająca wszystkie metody związane z drugim poziomem
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Lab2 : UserControl
    {
        private static Lab2 _zmiana;

        public static Lab2 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Lab2();
                return _zmiana;
            }
        }

        // *********************************************************

        /// <summary>
        /// Przejscie kursora na start z menu
        /// </summary>
        public void PrzejscieDoStartu()
        {
            Point Startp = Start.Location;
            Startp.Offset(550, 90);
            Cursor.Position = PointToScreen(Startp);
        }

        /// <summary>
        /// Powrot na start labiryntu
        /// </summary>
        public void PowrotDoStartu()
        {
            Point Startp = Start.Location;
            Startp.Offset(50, 30);
            Cursor.Position = PointToScreen(Startp);
        }

        public void PowrotDoStartu(object sender, EventArgs e)
        {
            PowrotDoStartu();
            MenuGlowne.Sciana.Play();
        }


        public Lab2()
        {
            InitializeComponent();
            PrzejscieDoStartu();
            Lab2timer2.Enabled = true;
            Lab2timer2.Start();
            LicznikKsiazek.Text = "[|] " + Ksiazki2.ToString() + "/3";
        }

        // *********************************************************
        // Funkcje zwiazane z ksiazkami

        /// <summary>
        /// Ilość zebranych ksiązek 
        /// </summary>
        public static int Ksiazki2 = 0;

        /// <summary>
        /// Funkcja dodająca 1 do puli zebranych ksiązek i wyświetlająca aktualną ilość
        /// </summary>
        public void ZbierzKsiazki()
        {
            Ksiazki2 = Ksiazki2 + 1;
            LicznikKsiazek.Text = "[|] " + Ksiazki2.ToString() + "/3";
        }

        /// <summary>
        /// Zebranie pierwszej książki
        /// </summary>     
        private void Ks1(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka1.Hide();
            WynikPoz2 = WynikPoz2 + 5;
        }

        /// <summary>
        /// Zebranie drugiej ksiązki
        /// </summary>
        private void Ks2(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka2.Hide();
            WynikPoz2 = WynikPoz2 + 5;
        }

        /// <summary>
        /// Zebranie trzeciej ksiązki
        /// </summary>
        private void Ks3(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka3.Hide();
            WynikPoz2 = WynikPoz2 + 5;
        }

        // *********************************************************

        /// <summary>
        /// Funkcja przywracania książek (reset poziomu)
        /// </summary>
        private void ResetKsiazek()
        {
            Ksiazka1.Show();
            Ksiazka2.Show();
            Ksiazka3.Show();
            Ksiazki2 = 0;
            LicznikKsiazek.Text = "[|] " + Ksiazki2.ToString() + "/3";
        }

        // *********************************************************
        // Timer

        /// <summary>
        /// Aktualny czas, a zarazem wynik poziomu 2
        /// </summary>
        public static int WynikPoz2 = 30;

        /// <summary>
        /// Funkcja związana z działaniem licznika czasu
        /// </summary>
        private void Timer2(object sender, EventArgs e)
        {
            WynikPoz2--;
            OdczytTimer.Text = WynikPoz2.ToString();

            if (WynikPoz2 == 0)
            {
                Lab2timer2.Stop();
                MenuGlowne.KoniecCzasu.Play();
                MessageBox.Show("Czas minął, zaczynasz od nowa!");
                WynikPoz2 = 30;
                ResetKsiazek();
                PowrotDoStartu();
                Lab2timer2.Start();
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zakończenia poziomu i przejścia do panelu ciekawostki (dynamiczna zmiana zawartości)
        /// </summary>
        private void Meta2(object sender, EventArgs e)
        {
            Lab2timer2.Stop();
            MenuGlowne.Wygrana.Play();

            if (!Labirynt2.Controls.Contains(ciekawostka2.Zmiana))
            {
                Labirynt2.Controls.Add(ciekawostka2.Zmiana);
                ciekawostka2.Zmiana.Dock = DockStyle.Fill;
                ciekawostka2.Zmiana.BringToFront();
            }
            else
                ciekawostka2.Zmiana.Show();
                Ksiazka1.Hide();
                Ksiazka2.Hide();
                Ksiazka3.Hide();
                LicznikKsiazek.Text = "( ͡° ͜ʖ ͡°)";
                WysCzasu.Text = "Uzyskany wynik";
        }

        //*******************************************
    }
}
