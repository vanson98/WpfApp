using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class ExpressionModel
    {
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public required string Operator { get; set; }
        public double Result { get; set; }
    }
}
