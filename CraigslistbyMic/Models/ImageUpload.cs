﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CraigslistbyMic.Models
{

    public class ImageUpload
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string PostTitle { get; set; }
        public virtual string FilePath
        {
            get
            {
                return $"/Uploads/{File}";
            }
        }
    }
    public class ImageUploadViewModel
    {
        [Required]
        public HttpPostedFile File { get; set; }
    }

}