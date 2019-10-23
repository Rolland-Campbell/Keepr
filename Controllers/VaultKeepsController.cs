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
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VaultKeeps>> Get()
    {
      try
      {
        return Ok(_vks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("id");
        return Ok(_vks.Get(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //[Authorize]
    [HttpPost]
    public ActionResult<VaultKeeps> Create([FromBody]VaultKeeps newVaultKeep)
    {
      try
      {
        newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    // [HttpPut]
    // public ActionResult<VaultKeeps> Delete([FromBody] VaultKeeps vaultKeep)
    // {
    //   try
    //   {
    //     vaultKeep.UserId = HttpContext.User.FindFirstValue("id");
    //     return Ok(_vks.Delete(vaultKeep, vaultKeep.UserId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}