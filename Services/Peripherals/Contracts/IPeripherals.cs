using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ApplicationUser;

namespace Services.Peripherals.Contracts
{
    public interface IPeripherals
    {
        public Task<List<PrimaryUser>> GetUsers();
    }
}
