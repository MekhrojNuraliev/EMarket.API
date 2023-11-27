using Emarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Domain.Models
{
    public class GetUserModel
    {
        public Token tokens { get; set; }
        public User user { get; set; }
    }
}
