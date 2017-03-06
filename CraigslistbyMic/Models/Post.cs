using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace CraigslistbyMic.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public virtual ImageUpload Image { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int SubCatagoryId { get; set; }
        [ForeignKey("SubCatagoryId")]
        public virtual SubCatagory SubCatagory { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual ApplicationUser User { get; set; }

    }
}