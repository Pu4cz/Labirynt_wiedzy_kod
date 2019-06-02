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
    /// Klasa zawierające wszystkie funkcjie związane z ciekawostką poziomu trzeciego
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ciekawostka3 : UserControl
    {
        private static ciekawostka3 _zmiana;

        public static ciekawostka3 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new ciekawostka3();
                return _zmiana;
            }
        }

        //************************************************************************

        string WysCiekawostke;

        /// <summary>
        ///  Zawartość ciekawostki 3
        /// </summary>
        string Ciekawostka3 = "Sztuczni nauczyciele w internecie coraz bliżej. System sztucznej inteligencji," +
                              " który zastąpi osobisty kontakt z nauczycielem podczas uczestnictwa w masowych kursach internetowych," +
                              " opracowali badacze z Uniwersytetu Stanforda w Kalifornii. Może już niedługo nie będziemy świadomi, że po drugiej stronie" +
                              " wcale nie ma człowieka. :) ";

        /// <summary>
        ///  Funkcja określająca czy ilość zebranych książek jest wystarczająca do wyświetlenia ciekawostki
        /// </summary>
        public void WyswietlanieCiekawostki()
        {
            if (Lab3.Ksiazki3 == 3)
            {
                WysCiekawostke = Ciekawostka3;
            }
            else
            {
                WysCiekawostke = "Nie udało Ci się zebrać wszystkich książek.Następnym razem postaraj się bardziej!";
            }
        }

        //************************************************************************

        public ciekawostka3()
        {
            InitializeComponent();
            WyswietlanieCiekawostki();
            TCiekawostka.Text = WysCiekawostke;
        }

        //************************************************************************

        /// <summary>
        /// Przejście do kolejnego poziomu
        /// </summary>
        public void Next3(object sender, EventArgs e)
        {
            if (!PCiekawostka3.Controls.Contains(Lab4.Zmiana))
            {
                PCiekawostka3.Controls.Add(Lab4.Zmiana);
                Lab4.Zmiana.Dock = DockStyle.Fill;
                Lab4.Zmiana.BringToFront();
            }
            else
                Lab4.Zmiana.BringToFront();
        }

        //************************************************************************

        /// <summary>
        /// Powtórzenie poziomu
        /// </summary>
        public void Back3(object sender, EventArgs e)
        {
            ciekawostka3.Zmiana.Hide();
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 30);
            TCiekawostka.Text = Ciekawostka3;
        }
    }
}
