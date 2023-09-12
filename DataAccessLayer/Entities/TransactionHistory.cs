using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string SenderAccountName { get; set; }
        public string RecipientAccountName { get; set; }
        public string Description { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int Balance { get; set; }
    }
}
