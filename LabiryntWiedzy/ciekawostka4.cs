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
    /// Klasa zawierające wszystkie funkcjie związane z ciekawostką poziomu czwartego
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ciekawostka4 : UserControl
    {
        private static ciekawostka4 _zmiana;

        public static ciekawostka4 Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new ciekawostka4();
                return _zmiana;
            }
        }

        //************************************************************************

        string WysCiekawostke;

        /// <summary>
        ///  Zawartość ciekawostki 4
        /// </summary>
        string Ciekawostka4 = " Istnieją trzy typy budowy ciała:  ektomorfik, mezomorfik i endomorfik." +
                              " Określenie, do której grupy przynależysz, może w dużym stopniu pomóc Ci w prawidłowym" +
                              " doborze diety i treningu. Określenie typu można dokonać poprzez ocenę wizualną, np. w lustrze." +
                              " Jeśli zależy ci na zdrowiu i dobrej sylwetce znajdź więcej informacji na ten temat. :)";

        /// <summary>
        /// Funkcja określająca czy ilość zebranych książek jest wystarczająca do wyświetlenia ciekawostki
        /// </summary>
        public void WyswietlanieCiekawostki()
        {
            if (Lab4.Ksiazki4 == 3)
            {
                WysCiekawostke = Ciekawostka4;
            }
            else
            {
                WysCiekawostke = "Nie udało Ci się zebrać wszystkich książek.Następnym razem postaraj się bardziej!";
            }
        }

        //************************************************************************

        public ciekawostka4()
        {
            InitializeComponent();
            WyswietlanieCiekawostki();
            TCiekawostka.Text = WysCiekawostke;
        }

        //************************************************************************

        /// <summary>
        /// Przejście do kolejnego poziomu
        /// </summary>
        public void Next4(object sender, EventArgs e)
        {
            if (!PCiekawostka4.Controls.Contains(Lab5.Zmiana))
            {
                PCiekawostka4.Controls.Add(Lab5.Zmiana);
                Lab5.Zmiana.Dock = DockStyle.Fill;
                Lab5.Zmiana.BringToFront();
            }
            else
                Lab5.Zmiana.BringToFront();
        }

        //************************************************************************

        /// <summary>
        /// Powtórzenie poziomu
        /// </summary>
        public void Back4(object sender, EventArgs e)
        {
            ciekawostka4.Zmiana.Hide();
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 30);
            TCiekawostka.Text = Ciekawostka4;
        }
    }
}