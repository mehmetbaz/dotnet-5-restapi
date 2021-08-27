using System;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems(string name = null)
        {
          var items = repository.GetItems().Select(item =>item.AsDto());

          return items;
        }

        // GET /items
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

    }
}