using petnb.DTL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace petnb.DTL.Data.Models
{
    public class Review
    {
        //properties
        public ApplicationUser ReviewedApplicationUser { get; set; }
        public int UserId { get; set; }
        public int ReviewingdApplicationUserId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public DateTime DateGiven { get; set; }
    }
}
