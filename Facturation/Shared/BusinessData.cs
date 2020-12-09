using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class BusinessData : IBusinessData
    {
        public IEnumerable<Facture> Factures { get; set; }

        public BusinessData()
        {
            Facture factureA = new Facture(100, 50, "jean Dupont");
            Facture factureB = new Facture(100, 75, "Patrick Bruel");
            Facture factureC = new Facture(100, 20, "Jacques Chirac");

            List<Facture> Factures = new List<Facture>();
            Factures.Add(factureA);
            Factures.Add(factureB);
            Factures.Add(factureC);
        }
    }
}
