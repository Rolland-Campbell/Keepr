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

    public IEnumerable<Keep> Get(int id, string userId)
    {
      return _vkr.Get(id, userId);
    }

    public VaultKeeps Create(VaultKeeps newVaultKeeps)
    {
      int id = _vkr.Create(newVaultKeeps);
      newVaultKeeps.Id = id;
      return newVaultKeeps;
    }

    // public string Delete(VaultKeeps vk, string userId)
    // {
    //   if (vk == null || vk.UserId != userId)
    //   {
    //     throw new Exception("invalid Id");
    //   }
    //   _vkr.Delete(vk);
    //   return "Success";
    // }
  }
}