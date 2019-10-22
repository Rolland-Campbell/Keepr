using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    public IEnumerable<VaultKeeps> Get()
    {
      return _vkr.Get();
    }

    public IEnumerable<Keep> Get(int id)
    {
      return _vkr.Get(id);
    }

    public VaultKeeps Create(VaultKeeps newVaultKeeps)
    {
      int id = _vkr.Create(newVaultKeeps);
      newVaultKeeps.Id = id;
      return newVaultKeeps;
    }

    // public string Delete(int id)
    // {
    //   VaultKeeps exists = _repo.Get(id);
    //   if (exists == null) { throw new Exception("Invalid Id"); }
    //   _repo.Delete(id);
    //   return " unkept man";
    // }
  }
}