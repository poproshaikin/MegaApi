using MegaApi.DAL.DataRepositories;
using MegaApi.DAL.DataRepositories.Products;
using MegaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MegaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private IRepository<Product> _repo { get; init; }

    public ProductsController(IRepository<Product> repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repo.Get());
    }

    [HttpGet("byCategory")]
    public IActionResult GetByCategory([FromQuery] int id)
    {
        return Ok((_repo as ProductsRepository)!.GetByCategory(id));
    }

    [HttpGet("byId")]
    public IActionResult GetById([FromQuery] int id)
    {
        return Ok(_repo.GetById(id));
    }

    [HttpGet("bySlug")]
    public IActionResult GetBySlug([FromQuery] string slug)
    {
        return Ok((_repo as ProductsRepository)!.GetBySlug(slug));
    }
}