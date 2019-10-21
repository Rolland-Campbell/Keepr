using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;

    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }

    public Vault Get(int id)
    {
      Vault exists = _vr.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }
    public IEnumerable<Vault> GetVaultsByUser(string userId)
    {
      Vault vault = _vr.GetVaultsByUser(userId);
      if (vault == null) { throw new Exception("Invalid Id"); }
      return _vr.GetVaultsByUser(userId);
    }

    public Vault Create(Vault newVault)
    {
      int id = _vr.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    // public Vault Edit(Vault editVault)
    // {
    //   Vault vault = _vr.GetVaultsByUser(editVault.UserId);
    //   if (vault == null) { throw new Exception("Invalid Id"); }
    //   vault.Name = editVault.Name;
    //   vault.Description = editVault.Description;
    //   vault.UserId = editVault.UserId;
    //   _vr.Edit(vault);
    //   return vault;
    // }

    public string Delete(int id)
    {
      Vault exists = _vr.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _vr.Delete(id);
      return " unkept man";
    }
  }
}