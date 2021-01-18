using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturation.Shared
{
    public class BusinessData : IBusinessData
    {
        public List<Facture> Factures { get; set; }

        public IEnumerable<Facture> AllFactures => testFactures;

        public decimal SalesRevenue => testFactures.Sum(Facture => Facture.Montant);

        public decimal Outstanding => testFactures.Sum(Facture => Facture.Montant - Facture.Payé);

        private Facture[] testFactures =
        {
            new Facture ("F9649", "test1", 9146.5m , DateTime.Now),
            new Facture("G9874", "test2", 6479.6m , DateTime.Now),
            new Facture("A9194", "test3", 3167.8m , DateTime.Now),
            new Facture("T3164", "test4", 5246.2m , DateTime.Now)

        };

        public BusinessData()
        {
            testFactures[1].RegisterPayment(DateTime.Now, 6479.6m);
            testFactures[2].RegisterPayment(DateTime.Now, 3167.8m);
            testFactures[2].DateAttendue = DateTime.Now;
        }




    }
}
