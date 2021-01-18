using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Facture> AllFactures { get; }

        decimal SalesRevenue { get; }

        decimal Outstanding { get; }



    }
}
