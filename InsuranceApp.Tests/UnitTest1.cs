using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using Moq;
using NUnit.Framework;
using System;

namespace InsuranceApp.Tests
{
    public class Tests
    {
        private Mock<IClaimService> _claimService;
        private Mock<IPolicyHolderService> _policyHolderService;

        [SetUp]
        public void Setup()
        {
            _claimService = new Mock<IClaimService>();
            _policyHolderService = new Mock<IPolicyHolderService>();
        }

        [Test]
        public void AddClaimAsync_ClaimCreated()
        {
            //Arrange
            var request = new Claim() 
            { 
                ClaimId = Guid.NewGuid(), 
                PolicyHolderNationalId = "TEST12166", 
                CreatedDate = DateTime.Now, 
                Status = ClaimStatus.Submitted, 
            };

            //Act
            var response = _claimService.Setup(O => O.AddClaimAsync(request).Result);

            //Assert
            //Assert.Pass(response);
        }
    }
}