using Nop.Data;
using Nop.Plugin.RasteBazar.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Services
{
    public class CheckService : ICheckService
    {
        private readonly IRepository<Check> _checkRepository;
        public CheckService(IRepository<Check> repository)
        {
            _checkRepository = repository;
        }

        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        public void Log(Check check)
        {
            if (check == null)
                throw new ArgumentNullException(nameof(check));
            _checkRepository.Insert(check);
        }
    }
}
