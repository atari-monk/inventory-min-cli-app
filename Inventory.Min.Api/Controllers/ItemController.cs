using AutoMapper;
using Inventory.Min.Api.Dto;
using Inventory.Min.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Min.Api.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController
    : ControllerBase
{
    private readonly IInventoryUnitOfWork uow;
    private readonly IMapper mapper;

    public ItemController(
        IInventoryUnitOfWork uow
        , IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ItemReadDto>> Get()
    {
        var items = uow.Item.Get();
		return Ok(mapper.Map<IEnumerable<ItemReadDto>>(items));
    }
}