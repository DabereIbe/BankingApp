using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Identification
    {
        [Key]
        public int Id { get; set; }

        public string IdentificationType { get; set; }
    }
}
