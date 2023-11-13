using AutoFixture;
using InsuranceApp.API.Controllers;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Tests
{
    public class ClaimControllerTests
    {
        private Fixture _fixture;
        private Mock<IClaimService> _claimService;
        private ClaimController _controller;
        private const string _policyHolderNationalId = "TEST12166";

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _claimService = new Mock<IClaimService>();
        }

        [Test]
        public async Task GetClaims_ReturnsOk()
        {
            //Arrange
            var claims = _fixture.CreateMany<Claim>(5).ToList();

            //Act
            _claimService.Setup(O => O.GetClaimsAsync(_policyHolderNationalId)).Returns(claims);
            _controller = new ClaimController(_claimService.Object);
            var result = await _controller.GetClaims(_policyHolderNationalId);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);
        }

        [Test]
        public async Task GetClaims_ThrowsException()
        {
            //Arrange

            //Act
            _claimService.Setup(O => O.GetClaimsAsync(_policyHolderNationalId)).Throws(new Exception());
            _controller = new ClaimController(_claimService.Object);
            var result = await _controller.GetClaims(_policyHolderNationalId);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        [Test]
        public async Task AddClaim_ReturnsOk()
        {
            //Arrange
            var claim = _fixture.Create<Claim>();

            //Act
            _claimService.Setup(O => O.AddClaimAsync(It.IsAny<Claim>())).Returns(claim);

            _controller = new ClaimController(_claimService.Object);
            var result = await _controller.AddClaim(claim);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);
        }

        [Test]
        public async Task AddClaim_ThrowsException()
        {
            //Arrange
            var claim = _fixture.Create<Claim>();

            //Act
            _claimService.Setup(O => O.AddClaimAsync(It.IsAny<Claim>())).Throws(new Exception());
            _controller = new ClaimController(_claimService.Object);
            var result = await _controller.AddClaim(claim);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        //[Test]
        //public async void GGetClaimById_ReturnsOk()
        //{
        //    //Arrange
        //    var claims = _fixture.CreateMany<Claim>(1).ToList();

        //    //Act
        //    _claimService.Setup(O => O.GetClaimsAsync(_policyHolderNationalId)).Returns(claims);
        //    _controller = new ClaimController(_claimService.Object);
        //    var result = await _controller.GetClaims(_policyHolderNationalId);
        //    var obj = result as ObjectResult;

        //    //Assert
        //    Assert.AreEqual(200, obj.StatusCode);
        //}
    }
}