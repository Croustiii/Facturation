using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class Facture
    {
        public Double MontantTotal { get; set; }

        public Double MontantDu { get; set; }

        public string  Client { get; set; }

        public DateTime Emission { get; set; }

        public DateTime ReglementAttendu { get; set; }


        public Facture()
        {

        }

        public Facture(double total, double du, string client )
        {
            this.MontantTotal = total;
            this.MontantDu = du;
            this.Client = client;
        }
    }
}
