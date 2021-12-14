using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Services;
using Blinkay.API.DTOs;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Blinkay.UnitTests
{
    public class Tests
    {
        /// <summary>
        /// The MySql service for unit testing.
        /// </summary>
        private IMySqlService _mySqlService;

        /// <summary>
        /// The NHibernate repository mock.
        /// </summary>
        private Mock<IMapperSession> _session;

        [SetUp]
        public void Setup()
        {
            this._session = new Mock<IMapperSession>();
            this._mySqlService = new MySqlService(this._session.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the MySql DB engine insertion.")]
        public void mysql_insertion_test()
        {
            // Arrange
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            this._mySqlService.MySQLInsertion(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.True(this._session.Object.Users.Any());
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test select plus update MySql use case.")]
        public void mysql_select_plus_update_test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the select plus update plus insertion use case.")]
        public void mysql_select_plus_update_plus_insertion_test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the Postgre DB engine insertion.")]
        public void postgre_insertion_test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test select plus update Postgre use case.")]
        public void postgre_select_plus_update_test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the Postgre select plus update plus insertion use case.")]
        public void postgre_select_plus_update_plus_insertion_test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }
    }
}