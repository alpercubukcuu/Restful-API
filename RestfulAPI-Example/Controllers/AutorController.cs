using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI_Example.DBOperation;
using RestfulAPI_Example.Entities;
using RestfulAPI_Example.Features.Queries.GetAutors;
using RestfulAPI_Example.Features.Queries.GetCustomer;

namespace RestfulAPI_Example.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AutorController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllAutor")]
        public IActionResult GetAllAutor()
        {
            GetAutorQuery getAutorQuery = new GetAutorQuery(_context, _mapper);
            List<AutorViewModel> autors = new();
            try
            {
                autors = getAutorQuery.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(autors);
        }
    }
}
