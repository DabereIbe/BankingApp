using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public int AccountBalance { get; set; }
        public string BVN { get; set; }
        public int IdentificationId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Level { get; set; }

        [ForeignKey("IdentificationId")]
        public virtual Identification Identification { get; set; }
    }
}
