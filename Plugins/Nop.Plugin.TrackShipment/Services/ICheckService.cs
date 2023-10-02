using Nop.Plugin.RasteBazar.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Services
{
    public interface ICheckService
    {
        void Log(Check check);
    }
}
