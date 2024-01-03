using HCI_WebAPI.Data;
using HCI_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HCI_WebAPI.Services
{
    internal sealed class HospitalService : IHospitalService
    {
        private readonly DataContext dataContext;

        public HospitalService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<string> AddHospital(Hospital hospital)
        {
            dataContext.Hospitals.Add(hospital);
            await dataContext.SaveChangesAsync();
            return hospital.Name;
        }

        public Task<List<Hospital>> GetHospitals()
        {
            return dataContext.Hospitals.ToListAsync();
        }
    }
}
