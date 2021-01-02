using System.Threading;
using Bogus;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Services;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Moq;

namespace UnitTests.Domain.Services
{
    public partial class ApplicantServiceTests
    {
        private Mock<IApplicantRepository> _applicantRepoMock;
        private Mock<ICountryDataProvider> _countryDataMock;
        private Mock<ILoggingBroker> _loggingMock;
        private IApplicantService _applicantService;

        private static Faker _faker = new Faker();
        

        public ApplicantServiceTests()
        {
            _applicantRepoMock = new Mock<IApplicantRepository>();
            _countryDataMock = new Mock<ICountryDataProvider>();
            _loggingMock = new Mock<ILoggingBroker>();
            _applicantService =
                new ApplicantService(_applicantRepoMock.Object, _loggingMock.Object, _countryDataMock.Object);
        }


        private string InvalidEmailAddress()
        {
            return _faker.Random.String(10, 30);
        }

        private static string ValidEmail()
        {
            return _faker.Internet.Email();
        }

        private static int ValidAge()
        {
            return _faker.Random.Int(20, 60);
        }

        private int InvalidAge()
        {
            return _faker.Random.Int(61, 300);
        }

        private string InvalidAddress()
        {
            return _faker.Random.String(1, 9);
        }

        private static string ValidAddress()
        {
            return _faker.Random.String(10);
        }

        private string InvalidName()
        {
            return _faker.Random.String(1, 4);
        }

        private static string ValidName()
        {
            return _faker.Random.String(5);
        }


        private string InvalidFamilyName()
        {
            return _faker.Random.String(1, 4);
        }

        private static string ValidFamilyName()
        {
            return _faker.Random.String(5);
        }

        private bool ValidHiredStatus()
        {
            return true;
        }

        private static string ValidCountry()
        {
            return _faker.Random.String(3, 50);
        }

        private void Given_name(ApplicantDto requestModel, string name)
        {
            requestModel.Name = name;
        }

        private void Given_family_name(ApplicantDto requestModel, string familyName)
        {
            requestModel.FamilyName = familyName;
        }

        private void Given_address(ApplicantDto requestModel, string address)
        {
            requestModel.Address = address;
        }

        private void Given_country_of_origin(ApplicantDto requestModel, string country)
        {
            requestModel.CountryOfOrigin = country;
        }

        private void Given_email(ApplicantDto requestModel, string email)
        {
            requestModel.EmailAddress = email;
        }

        private void Given_age(ApplicantDto requestModel, int age)
        {
            requestModel.Age = age;
        }

        private void Given_hired(ApplicantDto requestModel, bool isHired)
        {
            requestModel.Hired = isHired;
        }

        private Applicant ValidApplicant()
        {
            return new Applicant(new Name(ValidName()), new FamilyName(ValidFamilyName()),
                new Address(ValidAddress()), ValidCountry(), new EmailAddress(ValidEmail()),
                new Age(ValidAge()), ValidHiredStatus());
        }

        private void Given_country_data_is_found(ApplicantDto requestModel)
        {
            _countryDataMock.Setup(x =>
                    x.ValidateCountry(requestModel.CountryOfOrigin))
                .ReturnsAsync(Result.Success(requestModel.CountryOfOrigin));
        }

        private void Given_country_data_is_not_found(ApplicantDto requestModel)
        {
            _countryDataMock.Setup(x =>
                    x.ValidateCountry(requestModel.CountryOfOrigin))
                .ReturnsAsync(Result.Failure<string>("not found"));
        }

        private void Given_applicant_is_added_to_repo(Applicant applicant)
        {
            _applicantRepoMock.Setup(x =>
                    x.Create(applicant, new CancellationToken()))
                .ReturnsAsync(applicant);
        }

        private void Given_repo_returns_applicant_by_id(int applicantId, Applicant applicant)
        {
            _applicantRepoMock.Setup(x =>
                    x.FindById(applicantId, new CancellationToken()))
                .ReturnsAsync(applicant);
        }
    }
}