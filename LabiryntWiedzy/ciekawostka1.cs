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
    /// Klasa zawierające wszystkie funkcjie związane z ciekawostką poziomu pierwszego
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ciekawostka1 : UserControl
    {
        private static ciekawostka1 _zmiana;

        public static ciekawostka1 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new ciekawostka1();
                return _zmiana;
            }
        }

        //************************************************************************

        string WysCiekawostke;

        /// <summary>
        /// Zawartość ciekawostki 1
        /// </summary>
        string Ciekawostka1 = " Mózg szczególnie pobudza wyszukiwanie różnego rodzaju informacji w sieci. " +
                              "Dlatego właśnie gimnastykuj szare komórki, szukając jak najtrafniejszych haseł wywoławczych. " +
                              "Badania naukowe dowiodły, że już kilka dni takich aktywnych poszukiwań sprawia, że partie mózgu odpowiedzialne za podejmowanie decyzji uaktywniają się. ";

        /// <summary>
        /// Funkcja określająca czy ilość zebranych książek jest wystarczająca do wyświetlenia ciekawostki
        /// </summary>
        public void WyswietlanieCiekawostki()
        {             
            if (Lab1.Ksiazki1 == 3)
            {
                WysCiekawostke = Ciekawostka1;
            }
            else
            {
                WysCiekawostke = "Nie udało Ci się zebrać wszystkich książek.Następnym razem postaraj się bardziej!";
            }
        }        

        //************************************************************************

        public ciekawostka1()
        {
            InitializeComponent();
            WyswietlanieCiekawostki();
            TCiekawostka.Text = WysCiekawostke;
        }

        //************************************************************************

        /// <summary>
        /// Przejście do kolejnego poziomu
        /// </summary>
        public void Next1(object sender, EventArgs e)
        {
            if (!PCiekawostka1.Controls.Contains(Lab2.Zmiana))
            {
                PCiekawostka1.Controls.Add(Lab2.Zmiana);
                Lab2.Zmiana.Dock = DockStyle.Fill;
                Lab2.Zmiana.BringToFront();
            }
            else
                Lab2.Zmiana.BringToFront();
        }

        //************************************************************************
 
        /// <summary>
        /// Powtórzenie poziomu
        /// </summary>
        public void Back1(object sender, EventArgs e)
        {
            ciekawostka1.Zmiana.Hide();
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 30);
            TCiekawostka.Text = Ciekawostka1;           
        }
    }
}
