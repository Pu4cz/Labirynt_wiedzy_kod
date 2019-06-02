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
    /// Klasa zawierająca wszystkie metody związane z czwartym poziomem
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Lab4 : UserControl
    {
        private static Lab4 _zmiana;

        public static Lab4 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Lab4();
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


        public Lab4()
        {
            InitializeComponent();
            PrzejscieDoStartu();
            Lab4timer4.Enabled = true;
            Lab4timer4.Start();
            LicznikKsiazek.Text = "[|] " + Ksiazki4.ToString() + "/3";
        }

        // *********************************************************
        // Funkcje zwiazane z ksiazkami

        /// <summary>
        /// Ilość zebranych ksiązek 
        /// </summary>
        public static int Ksiazki4 = 0;

        /// <summary>
        /// Funkcja dodająca 1 do puli zebranych ksiązek i wyświetlająca aktualną ilość
        /// </summary>
        public void ZbierzKsiazki()
        {
            Ksiazki4 = Ksiazki4 + 1;
            LicznikKsiazek.Text = "[|] " + Ksiazki4.ToString() + "/3";
        }

        /// <summary>
        /// Zebranie pierwszej książki
        /// </summary>
        private void Ks1(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka1.Hide();
            WynikPoz4 = WynikPoz4 + 5;
        }

        /// <summary>
        /// Zebranie drugiej ksiązki
        /// </summary>
        private void Ks2(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka2.Hide();
            WynikPoz4 = WynikPoz4 + 5;
        }

        /// <summary>
        /// Zebranie trzeciej ksiązki
        /// </summary>
        private void Ks3(object sender, EventArgs e)
        {
            ZbierzKsiazki();
            MenuGlowne.Ksiazka.Play();
            Ksiazka3.Hide();
            WynikPoz4 = WynikPoz4 + 5;
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
            Ksiazki4 = 0;
            LicznikKsiazek.Text = "[|] " + Ksiazki4.ToString() + "/3";
        }

        // *********************************************************
        // Timer

        /// <summary>
        /// Aktualny czas, a zarazem wynik poziomu 4
        /// </summary>
        public static int WynikPoz4 = 50;

        /// <summary>
        /// Funkcja związana z działaniem licznika czasu
        /// </summary>
        private void Timer4(object sender, EventArgs e)
        {
            WynikPoz4--;
            OdczytTimer.Text = WynikPoz4.ToString();

            if (WynikPoz4 == 0)
            {
                Lab4timer4.Stop();
                MenuGlowne.KoniecCzasu.Play();
                MessageBox.Show("Czas minął, zaczynasz od nowa!");
                WynikPoz4 = 50;
                ResetKsiazek();
                PowrotDoStartu();
                Lab4timer4.Start();
            }
        }

        // *********************************************************

        /// <summary>
        /// Funkcja zakończenia poziomu i przejścia do panelu ciekawostki (dynamiczna zmiana zawartości)
        /// </summary>
        private void Meta4(object sender, EventArgs e)
        {
            Lab4timer4.Stop();
            MenuGlowne.Wygrana.Play();

            if (!Labirynt4.Controls.Contains(ciekawostka4.Zmiana))
            {
                Labirynt4.Controls.Add(ciekawostka4.Zmiana);
                ciekawostka4.Zmiana.Dock = DockStyle.Fill;
                ciekawostka4.Zmiana.BringToFront();
            }
            else
                ciekawostka4.Zmiana.Show();
                Ksiazka1.Hide();
                Ksiazka2.Hide();
                Ksiazka3.Hide();
                LicznikKsiazek.Text = "( ͡° ͜ʖ ͡°)";
                WysCzasu.Text = "Uzyskany wynik";
        }

        //*******************************************
    }
}
