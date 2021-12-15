using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Services;
using Blinkay.API.DTOs;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Blinkay.Infrastructure.Entities;
using System.Collections.Generic;

namespace Blinkay.UnitTests
{
    public class Tests
    {
        /// <summary>
        /// The MySql service for unit testing.
        /// </summary>
        private IMySqlService _mySqlService;

        /// <summary>
        /// The Postgres service for unit testing.
        /// </summary>
        private IPosgreeService _postgresService;

        /// <summary>
        /// The NHibernate repository mock.
        /// </summary>
        private Mock<IMapperSession> _session;

        /// <summary>
        /// The EF repository mock.
        /// </summary>
        private Mock<ApplicationContext> _context;

        [SetUp]
        public void Setup()
        {
            this._session = new Mock<IMapperSession>();
            this._context = new Mock<ApplicationContext>();

            this._mySqlService = new MySqlService(this._session.Object);
            this._postgresService = new PosgreeService(this._context.Object);
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
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            var userAdded = this._mySqlService.MySQLInsertion(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.NotNull(userAdded);
            Assert.AreEqual(userAdded.Id, 1);
            Assert.True(this._session.Object.Users.Count() > 0);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test select plus update with empty list MySql use case.")]
        public void mysql_select_plus_update_with_empty_list_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => this._mySqlService.MySQLSelectPlusUpdate(request.NumRegistres));

        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test select plus update MySql use case.")]
        public void mysql_select_plus_update_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            this._mySqlService.MySQLSelectPlusUpdate(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.True(this._session.Object.Users.Count() > 0);

        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the select plus update plus insertion use case.")]
        public void mysql_select_plus_update_plus_insertion_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            this._mySqlService.MySQLSelectPlusUpdatePlusInsertion(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.True(this._session.Object.Users.Count() > 0);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the Postgre DB engine insertion.")]
        public void postgres_insertion_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            var userAdded = this._postgresService.PGInsertion(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.NotNull(userAdded);
            Assert.AreEqual(userAdded.Id, 2);
            Assert.True(this._session.Object.Users.Count() > 0);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test select plus update Postgre use case.")]
        public void postgre_select_plus_update_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            this._postgresService.PGSelectPlusUpdate(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.True(this._session.Object.Users.Count() > 0);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to test the Postgre select plus update plus insertion use case.")]
        public void postgre_select_plus_update_plus_insertion_test()
        {
            // Arrange
            this._session.Setup(x => x.Users).Returns(new List<User>() { new User() { Id = 0, Info = "blablabla" }, new User() { Id = 1, Info = "testtesttest" } }.AsQueryable());
            AddEntityRequest request = new AddEntityRequest()
            {
                NumThreads = 60,
                NumRegistres = 30
            };

            // Act
            this._mySqlService.MySQLSelectPlusUpdatePlusInsertion(request.NumRegistres);

            // Assert
            Assert.NotNull(this._session.Object.Users);
            Assert.True(this._session.Object.Users.Count() > 0);
        }
    }
}