using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Facturation.Shared
{
    public class Facture
    {

        public Facture(string reference, string client, decimal montant, DateTime creation)
        {
            Reference = reference;
            Client = client;
            Montant = montant;
            DateCreation = creation;
            DateAttendue = DateCreation + TimeSpan.FromDays(30);

        }

        [Required(ErrorMessage = "La référence de la facture est requise")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Le nom du client est requis")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Le nom du client est requis")]
        public decimal Montant { get; set; }

        public decimal Payé { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateAttendue { get; set; }

        public DateTime? DernierPaiement { get; set; } = null;

        public bool IsPaid => Payé == Montant;

        public bool IsLate => DateAttendue < DateTime.Now;

        public void RegisterPayment(DateTime quand, decimal combien)
        {
            if (quand<DateCreation)
            {
                throw new ArgumentOutOfRangeException("Cannot pay before the invoice creation date");
            }
            DernierPaiement = quand;
            if (Montant < combien)
            {
                throw new ArgumentOutOfRangeException("Cannot pay over the due amount");
            }

        }






    }
}
