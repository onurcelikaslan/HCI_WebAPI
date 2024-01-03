using HCI_WebAPI.Data;
using HCI_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HCI_WebAPI.Services
{
    internal sealed class PatientService : IPatientService
    {
        private readonly DataContext dataContext;

        public PatientService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<string> AddPatient(Patient patient)
        {
            dataContext.Patients.Add(patient);
            await dataContext.SaveChangesAsync();
            return patient.FirstName + " " + patient.LastName;
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await dataContext.Patients.ToListAsync();
        }
    }
}
