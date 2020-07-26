using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AGL.Application.Dto;
using AGL.Application.Interfaces;
using AGL.Application.Services;
using AGL.Application.Validators;
using AGL.Application.ViewModel;
using AGL.Domain.Model;
using AGL.Infrastructure.Repositories;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Agl.UnitTests
{
    [TestClass]
    public class PersonServiceTests
    {
        private Mock<IContext> context;
        private IQueryable<PersonDto> GetNormalTestPersons()
        {
            var persons = new List<PersonDto>
            {
                new PersonDto
                {
                    Name = "Angie",
                    Gender = "Female",
                    Age = 17,
                    Pets =
                    {
                        new Pet
                        {
                            Name = "Tom",
                            Type = "Cat"
                        },
                        new Pet
                        {
                            Name = "Sam",
                            Type = "Dog"
                        },
                        new Pet
                        {
                            Name ="Omran",
                            Type = "Parrot"
                        }
                    }
                },
                new PersonDto
                {
                    Name = "Vasili",
                    Gender = "Male",
                    Age = 56,
                    Pets =
                    {
                        new Pet
                        {
                            Name = "Tabby",
                            Type = "cAt"
                        },
                        new Pet
                        {
                            Name = "Jim",
                            Type = "CAT"
                        }
                    }
                },
                new PersonDto
                {
                    Name = "Jessie",
                    Gender = "Female",
                    Age = 26,
                    Pets =
                    {
                        new Pet
                        {
                            Name = "Sherly",
                            Type = "Dog"
                        },
                        new Pet
                        {
                            Name = "Monfi",
                            Type = "cat"
                        }
                    }
                }
                };
            return persons.AsQueryable();
        }

        private GroupedPetResult PrepareTestData(IQueryable<PersonDto> personDtos)
        {

            context = new Mock<IContext>();
            context.Setup(d => d.GetPersonsFromWebService()).Returns(Task.FromResult(personDtos));

            var personService = new PersonService(new PersonRepository(context.Object));


            // Act
            return personService.GetAsync("cat").Result;
        }

        [TestMethod]
        public void TestData_NullCheck()
        {
            // Arrange
            var vm = PrepareTestData(GetNormalTestPersons());

            // Assert
            Assert.IsNotNull(vm);
        }

        [TestMethod]
        public void TestData_GroupedResult_Not_Null()
        {
            // Arrange
            var vm = PrepareTestData(GetNormalTestPersons());
            // Assert
            Assert.IsTrue(vm.GroupedPetVms.Any());

        }

        [TestMethod]
        public void LengthyName()
        {

            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Name = "Alighghfghfghfghgfhfghfdhfhfdhfhfghfhdfhfgh";

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);

        }

        [TestMethod]
        public void NullName()
        {

            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Name = null;

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void NonAlphaNumericName()
        {
            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Name = "Ali1";

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void NullEmptyGender()
        {
            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Gender = string.Empty;

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void LengthyPetName()
        {
            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Pets.FirstOrDefault().Name = "Abcdefghijlmnopq123456";

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void LengthyPetType()
        {
            var data = GetNormalTestPersons().ToList();
            data.FirstOrDefault().Pets.FirstOrDefault().Type = "ChrocodlieDinasourEagle";

            var validator = new PersonListValidator();
            var validationResult = validator.Validate(data);

            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }

    }
}
