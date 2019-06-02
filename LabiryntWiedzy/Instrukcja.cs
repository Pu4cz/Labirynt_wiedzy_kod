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
    /// Klasa, która zawiera wszystkie funkcje związane z instrukcją
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Instrukcja : UserControl
    {
        private static Instrukcja _zmiana;

        public static Instrukcja Zmiana
        {
            get
            {
                if (_zmiana == null)
                    _zmiana = new Instrukcja();
                return _zmiana;
            }
        }

        public Instrukcja()
        {
            InitializeComponent();

            InstrukacjaTekst.Text =
              "1. Przejdź przez labirynt od START do META " +
              "\n\n 2. Zbieraj [|] w celu odkrycia \n ,,ciekawostki naukowej''" +
              "\n\n 3. Nie najeżdzaj na ściany (zetknięcie ze ścianą spowoduje powrót na START)" +
              "\n\n 4. Staraj się uzyskać jak najlepszy czas" +
              "\n\n 5. Nagrodą za powtórzony poziom jest ciekawostka (wynik pozostaje)" +
              "\n\n 6. Baw się dobrze :) ";
        }
    }
}