using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabiryntWiedzy
{
    /// <summary>
    /// Klasa zawierające wszystkie funkcjie związane z ciekawostką poziomu drugiego
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ciekawostka2 : UserControl
    {
        private static ciekawostka2 _zmiana;

        public static ciekawostka2 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new ciekawostka2();
                return _zmiana;
            }
        }

        //************************************************************************
  
        string WysCiekawostke;

        /// <summary>
        /// Zawartość ciekawostki 2
        /// </summary>
        string Ciekawostka2 = " Języka uczymy się nie tylko poprzez tłumaczenie słów, ale poprzez dźwięk, ton, czyjeś intencje," +
                              " dlatego wszędzie gdzie jesteś możesz czasem zamiast muzyki posłuchać rozmów w języku obcym. Niezależnie" +
                              " na jakim jesteś poziomie i ile rozumiesz z wypowiedzi cały czas się uczysz." +
                              " W czasie słuchania angażujesz swój mózg bardziej niż tłumacząc ze słownika, bo uruchamiasz kojarzenie i wnioskowanie.";

        /// <summary>
        /// Funkcja określająca czy ilość zebranych książek jest wystarczająca do wyświetlenia ciekawostki
        /// </summary>
        public void WyswietlanieCiekawostki()
        {
            if (Lab2.Ksiazki2 == 3)
            {
                WysCiekawostke = Ciekawostka2;
            }
            else
            {
                WysCiekawostke = "Nie udało Ci się zebrać wszystkich książek.Następnym razem postaraj się bardziej!";
            }
        }

        //************************************************************************

        public ciekawostka2()
        {
            InitializeComponent();
            WyswietlanieCiekawostki();
            TCiekawostka.Text = WysCiekawostke;
        }

        //************************************************************************

        /// <summary>
        /// Przejście do kolejnego poziomu
        /// </summary>
        public void Next2(object sender, EventArgs e)
        {
            if (!PCiekawostka2.Controls.Contains(Lab3.Zmiana))
            {
                PCiekawostka2.Controls.Add(Lab3.Zmiana);
                Lab3.Zmiana.Dock = DockStyle.Fill;
                Lab3.Zmiana.BringToFront();
            }
            else
                Lab3.Zmiana.BringToFront();
        }

        //************************************************************************

        /// <summary>
        /// Powtórzenie poziomu
        /// </summary>
        public void Back2(object sender, EventArgs e)
        {
            ciekawostka2.Zmiana.Hide();
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 30);
            TCiekawostka.Text = Ciekawostka2;
        }
    }
}

