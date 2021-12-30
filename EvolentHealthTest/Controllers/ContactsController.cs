using AutoMapper;
using EvolentHealthTest.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace EvolentHealthTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ContactsController : ControllerBase
    {
        #region Private Member

        private ILogger<ContactsController> _logger;
        private readonly IMapper _mapper;
        private IContactRepository _contactRepository;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Initialize requied object
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="contactRepository">Contact repository</param>
        public ContactsController(ILogger<ContactsController> logger, IMapper mapper, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion

        #region Action Methods

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var contactDetails = await _contactRepository.GetAllItemAsync();
                return new OkObjectResult(contactDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while geting all contact information: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while  geting all contact information");
            }
        }
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> PostAsync([FromBody] EvolentHealthTest.Models.Contact contact)
        {
            try
            {
                var exists = await _contactRepository.IsItemExistsAsync(contact.Email);

                if (exists)
                {
                    var err = $"Email already exists.";
                    _logger.LogWarning(err);
                    return new ConflictResult();
                }

                var newItem = _mapper.Map<Entities.Contact>(contact);
                await _contactRepository.AddItemAsync(newItem);
                await _contactRepository.SaveAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating contact: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error while creating contact");
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateAsync([FromBody] EvolentHealthTest.Models.Contact contactDetails)
        {
            try
            {
                var name = contactDetails.Email;
                var existingItem = await _contactRepository.GetItemAsync(name);

                if (existingItem == null)
                {
                    _logger.LogWarning($" Item name :{name} doesn't exists in the store.");
                    return NotFound();
                }

                var entityToUpdate = _mapper.Map(contactDetails, existingItem);
                await _contactRepository.UpdateItemAsync(entityToUpdate);
                return Ok(new { message = "contact Update successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while deleting contact : {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while delting contact");
            }
        }

        [HttpDelete("{contact}")]
        public async Task<IActionResult> DeleteAsync(string contact)
        {
            try
            {
                var user = await _contactRepository.GetContactAsync(contact);

                if (user == null)
                {
                    _logger.LogWarning($" {contact} doesn't exists in the contact details.");
                    return NotFound();
                }
                // contact can delete their own account and admins can delete any account
                var deleted = await _contactRepository.DeleteItemAsync(contact);
                if (!deleted)
                {
                    var error = $"Failed to delete contact with email : {contact}";
                    _logger.LogError(error);
                    return new BadRequestObjectResult(error);
                }
                await _contactRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while deleting contact : {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while delting contact");
            }
        }

        #endregion
    }
}
