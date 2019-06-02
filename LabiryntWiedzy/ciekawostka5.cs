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
    /// Klasa zawierające wszystkie funkcjie związane z ciekawostką poziomu piątego
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ciekawostka5 : UserControl
    {
        private static ciekawostka5 _zmiana;

        public static ciekawostka5 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new ciekawostka5();
                return _zmiana;
            }
        }

        //************************************************************************

        string WysCiekawostke;

        /// <summary>
        ///  Zawartość ciekawostki 5
        /// </summary>
        string Ciekawostka5 = " „Kryptowaluty” - ciężko nie usłyszeć o coraz bardziej popularnych walutach wirtualnych." +
                              " Do najnowszych tego typu walut należy Riecoin, zaprojektowana tak, by „kopiący” wirtualne pieniądze" +
                              " znajdywali przy okazji skupiska kolejnych liczb pierwszych.";

        /// <summary>
        /// Funkcja określająca czy ilość zebranych książek jest wystarczająca do wyświetlenia ciekawostki
        /// </summary>
        public void WyswietlanieCiekawostki()
        {
            if (Lab5.Ksiazki5 == 3)
            {
                WysCiekawostke = Ciekawostka5;
            }
            else
            {
                WysCiekawostke = "Nie udało Ci się zebrać wszystkich książek.Następnym razem postaraj się bardziej!";
            }
        }

        //************************************************************************

        public ciekawostka5()
        {
            InitializeComponent();
            WyswietlanieCiekawostki();
            TCiekawostka.Text = WysCiekawostke;
        }

        //************************************************************************

        /// <summary>
        /// Przejście do podsumowania rozgrywki
        /// </summary>
        public void Suma(object sender, EventArgs e)
        {
            if (!PCiekawostka5.Controls.Contains(Podsumowanie.Zmiana))
            {
                PCiekawostka5.Controls.Add(Podsumowanie.Zmiana);
                Podsumowanie.Zmiana.Dock = DockStyle.Fill;
                Podsumowanie.Zmiana.BringToFront();
            }
            else
                Podsumowanie.Zmiana.BringToFront();
        }

        //************************************************************************

        /// <summary>
        /// Powtórzenie poziomu
        /// </summary>
        public void Back5(object sender, EventArgs e)
        {
            ciekawostka5.Zmiana.Hide();
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 30);
            TCiekawostka.Text = Ciekawostka5;
        }
    }
}
