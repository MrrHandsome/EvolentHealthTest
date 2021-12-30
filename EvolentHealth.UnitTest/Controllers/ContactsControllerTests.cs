using AutoMapper;
using EvolentHealthTest.Controllers;
using EvolentHealthTest.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace EvolentHealth.Test.Controllers
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ContactsControllerTests
    {
        #region Private Members

        private ContactsController _target;
        private IContactRepository _contactRepository;
        private ILogger<ContactsController> _fakeLogger;
        private IMapper _mapper;
        private EvolentHealthTest.Entities.Contact _item;
        private EvolentHealthTest.Models.Contact _newItem;

        #endregion

        #region Public Constructor

        [TestInitialize]
        public void TestInitialize()
        {
            _contactRepository = Substitute.For<IContactRepository>();
            _fakeLogger = Substitute.For<ILogger<ContactsController>>();
            var httpContext = new DefaultHttpContext();
            _mapper = MapperInitialize();
            _target = new ContactsController(_fakeLogger, _mapper, _contactRepository);
            _target.ControllerContext = new ControllerContext() { HttpContext = httpContext };

            _item = MockItemObject();
            _newItem = ItemInput();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Test for add
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestAdd()
        {
            var result = await _contactRepository.AddItemAsync(Input());

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for get
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestGet()
        {
            var result = await _contactRepository.GetItemAsync(Input().Email);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for get all
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestGetAll()
        {
            var result = await _contactRepository.GetAllItemAsync();

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for item exist
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestExists()
        {
            var result = await _contactRepository.IsItemExistsAsync(Input().Email);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for update
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestUpdate()
        {
            var result = await _contactRepository.UpdateItemAsync(UpdatedItemInput());

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for delete
        /// </summary>
        /// <returns>nothing</returns>
        [TestMethod, TestCategory("Unit")]
        public async Task TestDelete()
        {
            var result = await _contactRepository.DeleteItemAsync(Input().PhoneNumber);

            Assert.IsNotNull(result);
        }

        #endregion

        #region Private Methods

        private EvolentHealthTest.Entities.Contact MockItemObject() => new EvolentHealthTest.Entities.Contact
        {
            Id = 1,
            FirstName = "User1",
            LastName = "User1",
            Email = "abc@gmail.com",
            PhoneNumber = "9173079065",
            Status = true,
        };

        private IMapper MapperInitialize()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<EvolentHealthTest.Entities.Contact, EvolentHealthTest.Models.Contact>();
                opts.CreateMap<EvolentHealthTest.Models.Contact, EvolentHealthTest.Entities.Contact>();
            });
            return config.CreateMapper();
        }

        private EvolentHealthTest.Models.Contact ItemInput() => new EvolentHealthTest.Models.Contact
        {
            FirstName = "Jason",
            LastName = "Roy",
            Email = "test@gmail.com",
            PhoneNumber = "9999999991",
            Status = true,
        };

        private EvolentHealthTest.Entities.Contact Input() => new EvolentHealthTest.Entities.Contact
        {
            FirstName = "Jason",
            LastName = "Roy",
            Email = "test@gmail.com",
            PhoneNumber = "9999999991",
            Status = true,
        };

        private EvolentHealthTest.Entities.Contact UpdatedItemInput() => new EvolentHealthTest.Entities.Contact
        {
            FirstName = "Jolly",
            LastName = "Roy",
            Email = "test@gmail.com",
            PhoneNumber = "9999999991",
            Status = true,
        };

        #endregion
    }
}
