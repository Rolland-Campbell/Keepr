using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<VaultKeeps> Get()
    {
      return _repo.Get();
    }

    public VaultKeeps Get(int id)
    {
      VaultKeeps exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public VaultKeeps Create(Keep newVaultKeeps)
    {
      int id = _repo.Create(newVaultKeeps);
      newVaultKeeps.Id = id;
      return newVaultKeeps;
    }

    public VaultKeeps Edit(Keep editVaultKeeps)
    {
      VaultKeeps vaultKeeps = _repo.Get(editVaultKeeps.Id);
      if (vaultKeeps == null) { throw new Exception("Invalid Id"); }
      vaultKeeps.VaultId = editVaultKeeps.VaultId;
      vaultKeeps.KeepId = editVaultKeeps.KeepId;
      vaultKeeps.UserId = editVaultKeeps.UserId;
      _repo.Edit(vaultKeeps);
      return vaultKeeps;
    }

    public string Delete(int id)
    {
      VaultKeeps exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return " unkept man";
    }
  }
}