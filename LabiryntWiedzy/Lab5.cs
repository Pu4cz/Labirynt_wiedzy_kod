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
    /// Klasa zawierająca wszystkie metody związane z piątym poziomem
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Lab5 : UserControl
    {
        private static Lab5 _zmiana;

        public static Lab5 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Lab5();
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


        public Lab5()
        {
            InitializeComponent();
            PrzejscieDoStartu();
            Lab5timer5.Enabled = true;
            Lab5timer5.Start();
            LicznikKsiazek.Text = "[|] " + Ksiazki5.ToString() + "/3";
        }

        // *********************************************************
        // Funkcje zwiazane z ksiazkami

        /// <summary>
        /// Ilość zebranych ksiązek 
        /// </summary>
        public static int Ksiazki5 = 0;

        /// <summary>
        /// Funkcja dodająca 1 do puli zebranych ksiązek i wyświetlająca aktualną ilość
        /// </summary>
        public void ZbierzKsiazki()
        {
            Ksiazki5 = Ksiazki5 + 1;
            LicznikKsiazek.Text = "[|] " + Ksiazki5.ToString() + "/3";
        }

        /// <summary>
        /// Zebranie pierwszej książki
        /// </summary>
        private void Ks1(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka1.Hide();
            WynikPoz5 = WynikPoz5 + 5;
        }

        /// <summary>
        /// Zebranie drugiej ksiązki
        /// </summary>
        private void Ks2(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka2.Hide();
            WynikPoz5 = WynikPoz5 + 5;
        }

        /// <summary>
        /// Zebranie trzeciej ksiązki
        /// </summary>
        private void Ks3(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka3.Hide();
            WynikPoz5 = WynikPoz5 + 5;
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
            Ksiazki5 = 0;
            LicznikKsiazek.Text = "[|] " + Ksiazki5.ToString() + "/3";
        }

        // *********************************************************
        // Timer

        /// <summary>
        /// Aktualny czas, a zarazem wynik poziomu 5
        /// </summary>
        public static int WynikPoz5 = 60;

        /// <summary>
        /// Funkcja związana z działaniem licznika czasu
        /// </summary>
        private void Timer5(object sender, EventArgs e)
        {
            WynikPoz5--;
            OdczytTimer.Text = WynikPoz5.ToString();

            if (WynikPoz5 == 0)
            {
                Lab5timer5.Stop();
                MenuGlowne.KoniecCzasu.Play();
                MessageBox.Show("Czas minął, zaczynasz od nowa!");
                WynikPoz5 = 60;
                ResetKsiazek();
                PowrotDoStartu();
                Lab5timer5.Start();
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zakończenia poziomu i przejścia do panelu ciekawostki (dynamiczna zmiana zawartości)
        /// </summary>
        private void Meta5(object sender, EventArgs e)
        {
            Lab5timer5.Stop();
            MenuGlowne.Wygrana.Play();

            if (!Labirynt5.Controls.Contains(ciekawostka5.Zmiana))
            {
                Labirynt5.Controls.Add(ciekawostka5.Zmiana);
                ciekawostka5.Zmiana.Dock = DockStyle.Fill;
                ciekawostka5.Zmiana.BringToFront();
            }
            else
                ciekawostka5.Zmiana.Show();
                Ksiazka1.Hide();
                Ksiazka2.Hide();
                Ksiazka3.Hide();
                LicznikKsiazek.Text = "( ͡° ͜ʖ ͡°)";
                WysCzasu.Text = "Uzyskany wynik";
        }

        //*******************************************
    }
}
