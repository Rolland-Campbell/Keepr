using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kr;

    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
    }
    public IEnumerable<Keep> Get()
    {
      return _kr.Get();
    }

    public Keep Get(int id)
    {
      Keep exists = _kr.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public IEnumerable<Keep> GetKeepsByUser(string userId)
    {
      return _kr.GetKeepsByUser(userId);
    }

    public Keep Create(Keep newKeep)
    {
      int id = _kr.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep Edit(Keep editKeep)
    {
      Keep keep = _kr.Get(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Name = editKeep.Name;
      keep.Description = editKeep.Description;
      keep.Img = editKeep.Img;
      keep.Views = editKeep.Views;
      keep.Keeps = editKeep.Keeps;
      keep.IsPrivate = editKeep.IsPrivate;
      _kr.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep exists = _kr.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _kr.Delete(id);
      return " unkept man";
    }
  }
}