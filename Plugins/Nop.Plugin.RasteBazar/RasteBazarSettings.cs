using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.RasteBazar
{
    /// <summary>
    /// Represents a plugin settings
    /// </summary>
    public class RasteBazarSettings : ISettings
    {
        /// <summary>
        /// Get or Set the Active Plugin
        /// </summary>
        public bool IsActive { get; set; }     
    }
}
