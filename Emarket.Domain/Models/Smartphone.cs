using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Domain.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
