using HCI_WebAPI.Controllers;
using HCI_WebAPI.Models;
using HCI_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HCI_WebAPI.UnitTests.Controllers
{
    [TestClass]
    public class VisitsControllerTests
    {
        // Constants
        private readonly Guid PatientId = new Guid("4c92c35f-0062-409d-8cd7-e8e1d3333c46");
        private readonly Guid HospitalId = new Guid("e225b73a-7b85-4650-983d-18829a7335ca");
        private readonly Guid VisitId0 = new Guid("985e2445-32b3-4744-886e-2445b6ba6b58");
        private readonly Guid VisitId1 = new Guid("2f8771ca-d216-443f-97de-dcb2000673d5");

        private const string FirstName0 = "Luke";
        private const string LastName0 = "Skywalker";
        private const string HospitalName = "Beacon";

        // Objects
        private List<Visit>? visits;
        private VisitsController? visitsController;
        private Patient? patient;
        private Hospital? hospital;

        // Mocks
        private Mock<IVisitService>? visitServiceMock;

        [TestInitialize]
        public void TestInitilaze()
        {
            this.patient = new Patient()
            {
                Id = this.PatientId,
                FirstName = FirstName0,
                LastName = LastName0,
            };

            this.hospital = new Hospital()
            {
                Id = this.HospitalId,
                Name = HospitalName
            };

            this.visits = new List<Visit>()
            {
                new Visit()
                {
                    Id = this.VisitId0,
                    CreatedDate = DateTime.Now,
                    HospitalId = this.HospitalId,
                    PatientId = this.PatientId,
                    Patient = this.patient,
                    Hospital = this.hospital                    
                },
                new Visit()
                {
                    Id = this.VisitId1,
                    CreatedDate = DateTime.Now,
                    HospitalId = this.HospitalId,
                    PatientId = this.PatientId,
                    Patient = this.patient,
                    Hospital = this.hospital
                }
            };

            this.visitServiceMock = new Mock<IVisitService>();
            this.visitServiceMock
                .Setup(s=>s.GetVisitsByPatientIdAndHospitalId(It.Is<Guid>(c=>c.Equals(this.PatientId)), It.Is<Guid>(c => c.Equals(this.HospitalId))))
                .ReturnsAsync(this.visits);

            this.visitsController = new VisitsController(visitServiceMock.Object);
        }


        [TestMethod, TestCategory("UnitTest")]
        public async Task GeVisitsAsyncTest_Given_ExistingParentIdAndHospitalId_When_TryingToGetVisit_Result_Ok()
        {
            // Act
            var result = await this.visitsController.GetVisits(PatientId, HospitalId);

            // Assert
            var response = (List<Visit>)((OkObjectResult)result).Value;

            Assert.IsNotNull(result);
            Assert.IsTrue(response[0].Id.ToString().Equals(this.VisitId0.ToString(), StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response[0].Hospital?.Name.Equals(HospitalName, StringComparison.OrdinalIgnoreCase));
        }
    }
}