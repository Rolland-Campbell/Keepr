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
  }
}