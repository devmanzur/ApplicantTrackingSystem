using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Xunit;

namespace UnitTests.Domain.Services
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task Should_successfully_add_applicant_when_all_data_is_valid()
        {
            //arrange
            ApplicantDto requestModel = new ApplicantDto();
            Applicant newApplicant = ValidApplicant();

            Given_name(requestModel, ValidName());
            Given_family_name(requestModel, ValidFamilyName());
            Given_address(requestModel, ValidAddress());
            Given_country_of_origin(requestModel, ValidCountry());
            Given_email(requestModel, ValidEmail());
            Given_age(requestModel, ValidAge());
            Given_hired(requestModel, ValidHiredStatus());

            Given_country_data_is_found(requestModel);
            Given_applicant_is_added_to_repo(newApplicant);

            //act
            var applicantCreation = await _applicantService.RegisterApplicant(requestModel);

            //assert
            applicantCreation.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Should_fail_to_add_applicant_when_country_is_not_found()
        {
            //arrange
            ApplicantDto requestModel = new ApplicantDto();
            Applicant newApplicant = ValidApplicant();

            Given_name(requestModel, ValidName());
            Given_family_name(requestModel, ValidFamilyName());
            Given_address(requestModel, ValidAddress());
            Given_country_of_origin(requestModel, ValidCountry());
            Given_email(requestModel, ValidEmail());
            Given_age(requestModel, ValidAge());
            Given_hired(requestModel, ValidHiredStatus());

            Given_country_data_is_not_found(requestModel);
            Given_applicant_is_added_to_repo(newApplicant);

            //act
            Func<Task> action = async () => { await _applicantService.RegisterApplicant(requestModel); };
            //assert
            action.Should().ThrowExactly<ApplicantPropertyValidationException>();
        }

        [Fact]
        public async Task Should_successfully_retrieve_applicant_by_id_when_applicant_exists()
        {
            //arrange
            Applicant existingApplicant = ValidApplicant();
            int applicantId = existingApplicant.Id;

            Given_repo_returns_applicant_by_id(applicantId, existingApplicant);

            //act
            var applicantRetrieval = await _applicantService.RetrieveApplicantById(applicantId);

            //arrange
            applicantRetrieval.IsSuccess.Should().Be(true);
            applicantRetrieval.Should().BeEquivalentTo(Result.Success(existingApplicant));
        }

        [Fact]
        public async Task Should_fail_to_retrieve_applicant_by_id_when_applicant_does_not_exist()
        {
            //arrange
            Applicant nonExistingApplicant = null;
            int applicantId = 0;

            Given_repo_returns_applicant_by_id(applicantId, nonExistingApplicant);

            //act
            var applicantRetrieval = await _applicantService.RetrieveApplicantById(applicantId);

            //arrange
            applicantRetrieval.IsSuccess.Should().Be(false);
            applicantRetrieval.Should()
                .BeEquivalentTo(Result.Failure<Applicant>($"applicant {applicantId} not found!"));
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Should_fail_to_add_applicant_when_any_required_data_is_Invalid(string name, string familyName,
            string address, string country, string email,int age,bool isHired
        )
        {
            ApplicantDto requestModel = new ApplicantDto();

            Given_name(requestModel, name);
            Given_family_name(requestModel, familyName);
            Given_address(requestModel, address);
            Given_country_of_origin(requestModel, country);
            Given_email(requestModel, email);
            Given_age(requestModel, age);
            Given_hired(requestModel, isHired);
            
            //act
            Func<Task> action = async () => { await _applicantService.RegisterApplicant(requestModel); };
            //assert
            action.Should().ThrowExactly<ApplicantPropertyValidationException>();
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Should_fail_to_modify_applicant_when_any_update_data_is_Invalid(string name, string familyName,
            string address, string country, string email,int age,bool isHired
        )
        {
            int applicantId = 1;
            ApplicantDto updateModel = new ApplicantDto();

            Given_name(updateModel, name);
            Given_family_name(updateModel, familyName);
            Given_address(updateModel, address);
            Given_country_of_origin(updateModel, country);
            Given_email(updateModel, email);
            Given_age(updateModel, age);
            Given_hired(updateModel, isHired);
            
            //act
            Func<Task> action = async () => { await _applicantService.ModifyApplicant(applicantId,updateModel); };
            //assert
            action.Should().ThrowExactly<ApplicantPropertyValidationException>();
        }
        
        
        public static IEnumerable<object[]> GetData =>
            new List<object[]>
            {
                new object[]
                    {null, ValidFamilyName(), ValidAddress(), ValidCountry(), ValidEmail(), ValidAge(), false},
                new object[]
                    {ValidName(), null, ValidAddress(), ValidCountry(), ValidEmail(), ValidAge(), true},
                new object[]
                    {ValidName(), ValidFamilyName(), null, ValidCountry(), ValidEmail(), ValidAge(), false},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), null, ValidEmail(), ValidAge(), true},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), ValidCountry(), null, ValidAge(), false},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), ValidCountry(), ValidEmail(), null, true},
                new object[]
                    {null, null, null, null, null, null, true},
            };
    }
}