using HCI_WebAPI.Models;

namespace HCI_WebAPI.Services
{
    public interface IPatientService
    {
        Task<string> AddPatient(Patient patient);
        Task<List<Patient>> GetPatients();
    }
}
