using Entities.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;
using Services.Peripherals.Contracts;

namespace Services.Peripherals.Services
{
    public class Peripheral:IPeripherals
    {
        private readonly IRepo _repo;
        public Peripheral(IRepo _repo)
        {
            this._repo = _repo;
        }

        public async Task<List<PrimaryUser>> GetUsers()
        {
            return await _repo.GetAllUsers();
        }

       
    }
}
