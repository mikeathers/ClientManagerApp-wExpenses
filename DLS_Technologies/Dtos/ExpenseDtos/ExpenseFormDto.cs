using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Dtos.ExpenseDtos
{
    public class ExpenseFormDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}