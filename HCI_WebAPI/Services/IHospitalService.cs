using HCI_WebAPI.Models;

namespace HCI_WebAPI.Services
{
    public interface IHospitalService
    {
        Task<string> AddHospital(Hospital hospital);
        Task<List<Hospital>> GetHospitals();
    }
}
