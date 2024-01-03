using HCI_WebAPI.Data;
using HCI_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HCI_WebAPI.Services
{
    internal sealed class VisitService : IVisitService
    {
        private readonly DataContext dataContext;

        public VisitService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<string> AddVisit(Visit visit)
        {
            dataContext.Visits.Add(visit);
            await dataContext.SaveChangesAsync();
            return visit.PatientId + " added ";
        }

        public async Task<List<Visit>> GetAllVisit()
        {
            return await dataContext.Visits
                    .Include(r => r.Patient)
                    .Include(r => r.Hospital)
                    .ToListAsync();
        }

        public async Task<List<Visit>?> GetVisitsByPatientId(Guid patientId)
        {
            var visits = await dataContext.Visits.Where(c=>c.PatientId == patientId).ToListAsync();
            return visits;
        }

        public async Task<List<Visit>?> GetVisitsByHospitalId(Guid hospitalId)
        {
            var visits = await dataContext.Visits.Where(c => c.HospitalId == hospitalId).ToListAsync();
            return visits;
        }

        public async Task<List<Visit>?> GetVisitsByPatientIdAndHospitalId(Guid patientId, Guid hospitalId)
        {
            var visits = new List<Visit>();
            if (patientId.Equals(Guid.Empty) && !hospitalId.Equals(Guid.Empty))
            {
                visits = await dataContext.Visits
                    .Include(r => r.Patient)
                    .Include(r => r.Hospital)
                    .Where(c => c.HospitalId == hospitalId).ToListAsync();
            }
            if (hospitalId.Equals(Guid.Empty) && !patientId.Equals(Guid.Empty))
            {
                visits = await dataContext.Visits
                    .Include(r=>r.Patient)
                    .Include(r=>r.Hospital)
                    .Where(c => c.PatientId == patientId).ToListAsync();
            }
            if (!hospitalId.Equals(Guid.Empty) && !patientId.Equals(Guid.Empty))
            {
                visits = await dataContext.Visits
                    .Include(r => r.Patient)
                    .Include(r => r.Hospital)
                    .Where(c => c.PatientId == patientId && c.HospitalId == hospitalId).ToListAsync();
            }
            return visits;
        }

        public Task<List<Visit>?> DeleteVisit(int visitId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visit>?> UpdateVisit(int id, Visit visitRequest)
        {
            throw new NotImplementedException();
        }
    }
}
