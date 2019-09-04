using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.EF;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.ViewModels;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable All

namespace BusinessLogicLayer.Controllers
{
    [Route("api/[controller]")] 
    public class AccountsController : Controller
    {
        // GET
        private readonly DatabaseContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, DatabaseContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            using (IUnitOfWork uow = new UnitOfWork(_context))
            {
                uow.GetRepository<Customer>().AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await uow.SaveASync();
            }
//            await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
//            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}