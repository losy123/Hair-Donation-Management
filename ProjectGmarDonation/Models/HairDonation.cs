using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectGmarDonation.Models
{
    public class HairDonation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Hair Type")]
        [Required(ErrorMessage = "hairtype is Required.")]
        public string HairType { get; set; }

        [Required(ErrorMessage = "hair length is Required.")]
        [Display(Name = "Hair Length")]

        public string HairLength { get; set; }

        [Display(Name = "Upload Picture")]
        public byte[] imgurl { get; set; }

        [Required(ErrorMessage = "hair Color is Required.")]
        [Display(Name = "Hair Color")]
        public string HairColor { get; set; }

        [Display(Name = "Second Hair Color")]
        public string HairColor2 { get; set; }

        [Display(Name = "Third Hair Color")]
        public string HairColor3 { get; set; }

        public Boolean IsAvailable { get; set; }

        public string Requester_Id { get; set; }

        public string Donor_Id { get; set; }


        public string Donor_Email { get; set; }

        public Boolean Approved { get; set; }

        public Boolean isColor { get; set; }

    }
}