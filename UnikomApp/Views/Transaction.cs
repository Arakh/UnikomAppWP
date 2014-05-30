using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikomApp.Views
{
    class Transaction
    {
        public string MenuJudul { get; set; }
        public string MenuGambar { get; set; }
        public Transaction(string menujudul, string menugambar)
        {
            this.MenuJudul = menujudul;
            this.MenuGambar = menugambar;
        }
    }
}
