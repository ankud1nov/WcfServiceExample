using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceExample
{
    public class ContractsInfoContext : DbContext
    {
        public DbSet<ContractInfo> ContractsInfo { get; set; }
    }
}
