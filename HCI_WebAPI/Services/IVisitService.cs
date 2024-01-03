using HCI_WebAPI.Models;

namespace HCI_WebAPI.Services
{
    public interface IVisitService
    {
        Task<string> AddVisit(Visit visit);
        Task<List<Visit>> GetAllVisit();
        Task<List<Visit>?> GetVisitsByPatientId(Guid patientId);
        Task<List<Visit>?> GetVisitsByHospitalId(Guid hospitalId);
        Task<List<Visit>?> GetVisitsByPatientIdAndHospitalId(Guid patientId, Guid hospitalId);
        Task<List<Visit>?> UpdateVisit(int id, Visit visitRequest);
        Task<List<Visit>?> DeleteVisit(int visitId);
    }
}
