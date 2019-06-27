using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace NumbersToWords.Models
{
    public class FormModel
    {
        [Range(0, 100000000000000000,ErrorMessage = "Number too Large! ")]
        [DataType(DataType.Currency)]
        public decimal Number { get; set; }
        public string Word { get; set; }
    }
}