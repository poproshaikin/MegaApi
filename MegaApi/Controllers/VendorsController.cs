using MegaApi.DAL.DataRepositories;
using MegaApi.DAL.DataRepositories.Vendors;
using MegaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MegaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController : ControllerBase
{
    private IRepository<Vendor> _repo { get; init; }

    public VendorsController(IRepository<Vendor> repo)
    {
        _repo = repo;
    }

    [HttpGet("byId")]
    public IActionResult GetById([FromQuery] int id)
    {
        return Ok(_repo.GetById(id));
    }
}