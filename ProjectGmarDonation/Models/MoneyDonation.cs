using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectGmarDonation.Models
{
    public class MoneyDonation
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        public string User_Id { get; set; }

    }
}