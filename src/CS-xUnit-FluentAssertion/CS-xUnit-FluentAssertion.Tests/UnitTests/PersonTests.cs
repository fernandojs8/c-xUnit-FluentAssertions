using CS_xUnit_FluentAssertion.Model;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_xUnit_FluentAssertion.Tests.UnitTests
{
    public class PersonTests
    {
        [Theory]
        [InlineData("Fernando JS")]
        [InlineData("Tim Corey")]
        public void TestFullNameProperty(string fullName)
        {
            // Arrange
            var person = new Person(fullName);

            // Act
            var actual = person.FullName;

            // Assert
            Assert.Equal(fullName, actual);
        }

        [Theory]
        [InlineData("Fernando JS", "Fernando")]
        [InlineData("Tim Corey", "Tim")]
        public void TestFirstNameProperty(string fullName, string firstName)
        {
            // Arrange
            var person = new Person(fullName);

            // Act
            var actual = person.FirstName;

            // Assert
            Assert.Equal(firstName, actual);
        }

        [Theory]
        [InlineData("Fernando JS", "JS")]
        [InlineData("Tim Corey", "Corey")]
        public void TestLastNameProperty(string fullName, string lastName)
        {
            // Arrange
            var person = new Person(fullName);

            // Act
            var actual = person.LastName;

            // Assert
            Assert.Equal(lastName, actual);
        }

        [Theory]
        [InlineData("Fernando Jesus Santos", "Jesus Santos", "Fernando")]
        [InlineData("Eddie Van Halen", "Van Halen", "Eddie")]
        public void TestEdgeCasesNames(string fullName, string lastName, string firstName)
        {
            // Arrange
            // Act
            var person = new Person(fullName);

            using var _ = new AssertionScope();

            // Assert
            person.FirstName
                .Should()
                .Be(firstName);

            person.LastName
                .Should()
                .Be(lastName);

            person.LastName
                .Should()
                .StartWith(lastName.Substring(0, 3))
                .And.EndWith(lastName.Substring(lastName.Length - 3))
                .And.Contain("an");
        }
    }
}
