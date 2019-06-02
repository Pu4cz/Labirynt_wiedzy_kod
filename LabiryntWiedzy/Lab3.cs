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
    /// Klasa zawierająca wszystkie metody związane z trzecim poziomem
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Lab3 : UserControl
    {
        private static Lab3 _zmiana;

        public static Lab3 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Lab3();
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


        public Lab3()
        {
            InitializeComponent();
            PrzejscieDoStartu();
            Lab3timer3.Enabled = true;
            Lab3timer3.Start();
            LicznikKsiazek.Text = "[|] " + Ksiazki3.ToString() + "/3";
        }

        // *********************************************************
        // Funkcje zwiazane z ksiazkami

        /// <summary>
        /// Ilość zebranych ksiązek 
        /// </summary>
        public static int Ksiazki3 = 0;

        /// <summary>
        /// Funkcja dodająca 1 do puli zebranych ksiązek i wyświetlająca aktualną ilość
        /// </summary>
        public void ZbierzKsiazki()
        {
            Ksiazki3 = Ksiazki3 + 1;
            LicznikKsiazek.Text = "[|] " + Ksiazki3.ToString() + "/3";
        }

        /// <summary>
        /// Zebranie pierwszej książki
        /// </summary>
        private void Ks1(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka1.Hide();
            WynikPoz3 = WynikPoz3 + 5;
        }

        /// <summary>
        /// Zebranie drugiej ksiązki
        /// </summary>
        private void Ks2(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka2.Hide();
            WynikPoz3 = WynikPoz3 + 5;
        }

        /// <summary>
        /// Zebranie trzeciej ksiązki
        /// </summary>
        private void Ks3(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka3.Hide();
            WynikPoz3 = WynikPoz3 + 5;
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
            Ksiazki3 = 0;
            LicznikKsiazek.Text = "[|] " + Ksiazki3.ToString() + "/3";
        }

        // *********************************************************
        // Timer

        /// <summary>
        /// Aktualny czas, a zarazem wynik poziomu 3
        /// </summary>
        public static int WynikPoz3 = 40;

        /// <summary>
        /// Funkcja związana z działaniem licznika czasu
        /// </summary>
        private void Timer3(object sender, EventArgs e)
        {
            WynikPoz3--;
            OdczytTimer.Text = WynikPoz3.ToString();

            if (WynikPoz3 == 0)
            {
                Lab3timer3.Stop();
                MenuGlowne.KoniecCzasu.Play();
                MessageBox.Show("Czas minął, zaczynasz od nowa!");
                WynikPoz3 = 40;
                ResetKsiazek();
                PowrotDoStartu();
                Lab3timer3.Start();
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zakończenia poziomu i przejścia do panelu ciekawostki (dynamiczna zmiana zawartości)
        /// </summary>
        private void Meta3(object sender, EventArgs e)
        {
            Lab3timer3.Stop();
            MenuGlowne.Wygrana.Play();

            if (!Labirynt3.Controls.Contains(ciekawostka3.Zmiana))
            {
                Labirynt3.Controls.Add(ciekawostka3.Zmiana);
                ciekawostka3.Zmiana.Dock = DockStyle.Fill;
                ciekawostka3.Zmiana.BringToFront();
            }
            else
                ciekawostka3.Zmiana.Show();
                Ksiazka1.Hide();
                Ksiazka2.Hide();
                Ksiazka3.Hide();
                LicznikKsiazek.Text = "( ͡° ͜ʖ ͡°)";
                WysCzasu.Text = "Uzyskany wynik";
        }

        //*******************************************
    }
}
