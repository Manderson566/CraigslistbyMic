using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CraigslistbyMic.Models
{
    public class SubCatagory
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CatagoryId { get; set; }
        [ForeignKey("CatagoryId")]
        public virtual Catagory Catagory {get; set;}
    }
}