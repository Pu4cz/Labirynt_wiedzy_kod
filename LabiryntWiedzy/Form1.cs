using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LabiryntWiedzy
{
    /// <summary>
    /// Klasa główna definiująca zawartość multimedialną i pełniąca funkcję sterowania zawartością
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MenuGlowne : Form
    {
        public MenuGlowne()
        {
            InitializeComponent();
            ZmienKursor();
        }

        //*********************************************************
        // Dźwięki

        public static SoundPlayer Wygrana = new SoundPlayer(LabiryntWiedzy.Properties.Resources.meta_klaskanie);
        public static SoundPlayer KoniecCzasu = new SoundPlayer(LabiryntWiedzy.Properties.Resources.czas_klask);
        public static SoundPlayer Sciana = new SoundPlayer(LabiryntWiedzy.Properties.Resources.sciana_CantTouchThis);
        public static SoundPlayer Ksiazka = new SoundPlayer(LabiryntWiedzy.Properties.Resources.ksiazka_pstryk);

        // ********************************************************
        /// <summary>
        /// Funkcja zmieniająca kursor na własną grafikę
        /// </summary>
        public void ZmienKursor()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.kursorLW);
            Cursor c = new Cursor(bmp.GetHicon());
            this.Cursor = c;
        }

        // ********************************************************
        /// <summary>
        /// Funkcja, która wywołuje pierwszy poziom gry na panel główny (poprzez dynamiczą zmianę zawartości panelu)
        /// </summary>       
        private void startgry_Click(object sender, EventArgs e)
        {
            if (!PanelG.Controls.Contains(Lab1.Zmiana))
            {
                PanelG.Controls.Add(Lab1.Zmiana);
                Lab1.Zmiana.Dock = DockStyle.Fill;
                Lab1.Zmiana.BringToFront();
            }
            else
                Lab1.Zmiana.BringToFront();
        }

        /// <summary>
        /// Funkcja, która wywołuje instrikcję na panel główny (poprzez dynamiczą zmianę zawartości panelu)
        /// </summary>
        private void instrukcja_Click(object sender, EventArgs e)
        {
            if (!PanelG.Controls.Contains(Instrukcja.Zmiana))
            {
                PanelG.Controls.Add(Instrukcja.Zmiana);
                Instrukcja.Zmiana.Dock = DockStyle.Fill;
                Instrukcja.Zmiana.BringToFront();
            }
            else
                Instrukcja.Zmiana.BringToFront();
        }

        /// <summary>
        /// Funkcją wyłączania gry
        /// </summary>
        private void wyjscie_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
