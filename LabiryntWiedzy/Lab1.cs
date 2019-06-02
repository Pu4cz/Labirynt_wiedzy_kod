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
    /// Klasa zawierająca wszystkie metody związane z pierwszym poziomem
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Lab1 : UserControl
    {
        private static Lab1 _zmiana;

        public static Lab1 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Lab1();
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


        public Lab1()
        {
            InitializeComponent();
            PrzejscieDoStartu();
            Lab1timer1.Enabled = true;
            Lab1timer1.Start();
            LicznikKsiazek.Text = "[|] " + Ksiazki1.ToString() + "/3";
        }

        // *********************************************************
        // Funkcje zwiazane z ksiazkami

        /// <summary>
        /// Ilość zebranych ksiązek 
        /// </summary>
        public static int Ksiazki1 = 0;

        /// <summary>
        /// Funkcja dodająca 1 do puli zebranych ksiązek i wyświetlająca aktualną ilość
        /// </summary>
        public void ZbierzKsiazki()
        {
            Ksiazki1 = Ksiazki1 + 1;
            LicznikKsiazek.Text = "[|] " + Ksiazki1.ToString() + "/3";
        }

        /// <summary>
        /// Zebranie pierwszej książki
        /// </summary>
        private void Ks1(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka1.Hide();
            WynikPoz1 = WynikPoz1 + 5;
        }

        /// <summary>
        /// Zebranie drugiej ksiązki
        /// </summary>
        private void Ks2(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka2.Hide();
            WynikPoz1 = WynikPoz1 + 5;
        }

        /// <summary>
        /// Zebranie trzeciej ksiązki
        /// </summary>
        private void Ks3(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka3.Hide();
            WynikPoz1 = WynikPoz1 + 5;
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
            Ksiazki1 = 0;
            LicznikKsiazek.Text = "[|] " + Ksiazki1.ToString() + "/3";
        }

        // *********************************************************
        // Timer

        /// <summary>
        /// Aktualny czas, a zarazem wynik poziomu 1
        /// </summary>
        public static int WynikPoz1 = 20;

        /// <summary>
        /// Funkcja związana z działaniem licznika czasu
        /// </summary>
        private void Timer1(object sender, EventArgs e)
        {
            WynikPoz1--;
            OdczytTimer.Text = WynikPoz1.ToString();

            if (WynikPoz1 == 0)
            {
                Lab1timer1.Stop();
                MenuGlowne.KoniecCzasu.Play();
                MessageBox.Show("Czas minął, zaczynasz od nowa!");
                WynikPoz1 = 20;
                ResetKsiazek();
                PowrotDoStartu();
                Lab1timer1.Start();
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zakończenia poziomu i przejścia do panelu ciekawostki (dynamiczna zmiana zawartości)
        /// </summary>
        private void Meta1(object sender, EventArgs e)
        {
            Lab1timer1.Stop();
            MenuGlowne.Wygrana.Play();

            if (!Labirynt1.Controls.Contains(ciekawostka1.Zmiana))
            {
                Labirynt1.Controls.Add(ciekawostka1.Zmiana);
                ciekawostka1.Zmiana.Dock = DockStyle.Fill;
                ciekawostka1.Zmiana.BringToFront();
            }
            else
                ciekawostka1.Zmiana.Show();
                Ksiazka1.Hide();
                Ksiazka2.Hide();
                Ksiazka3.Hide();
                LicznikKsiazek.Text = "( ͡° ͜ʖ ͡°)";
                WysCzasu.Text = "Uzyskany wynik";
        }

        //*******************************************
    }
}

