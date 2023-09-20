using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Domains
{
    public class Check : BaseEntity
    {
        public string OwnerName { get; set; }
        public decimal Amount { get; set; }
    }
}
