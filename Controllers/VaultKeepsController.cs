using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vs;

    public VaultKeepsController(VaultKeepsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VaultKeeps>> Get()
    {
      try
      {
        return Ok(_vs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_vs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    // [HttpPost]
    // public ActionResult<Keep> Create([FromBody]Keep newKeep)
    // {
    //   try
    //   {
    //     newKeep.UserId = HttpContext.User.FindFirstValue("Id");
    //     return Ok(_vs.Create(newKeep));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // [Authorize]
    // [HttpPut("{id}")]
    // public ActionResult<Keep> Edit([FromBody] Keep editKeep, int id)
    // {
    //   try
    //   {
    //     editKeep.Id = id;
    //     return Ok(_vs.Edit(editKeep));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_vs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}