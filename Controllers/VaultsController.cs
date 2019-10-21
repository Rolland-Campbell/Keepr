using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Authorize]
  [ApiController]
  [Route("/api/[controller]")]

  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
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

    [HttpGet("user")]
    public ActionResult<IEnumerable<Vault>> GetVaultsByUser(string userId)
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.GetVaultsByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody]Vault newVault)
    {
      try
      {
        newVault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    // [HttpPut("{userId}")]
    // public ActionResult<Vault> Edit([FromBody] Keep editVault, string userId)
    // {
    //   try
    //   {
    //     editVault.UserId = userId;
    //     return Ok(_vs.Edit(editVault));
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