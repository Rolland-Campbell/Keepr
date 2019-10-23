using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {

    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeeps> Get()
    {
      string sql = "SELECT * FROM vaultKeeps";
      return _db.Query<VaultKeeps>(sql);
    }

    public IEnumerable<Keep> Get(int id, string userId)
    {
      string sql = @"
        SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId
            WHERE (vaultId = @id AND vk.userId = @userId);
            ";
      return _db.Query<Keep>(sql, new { id, userId });
    }

    public int Create(VaultKeeps newVaultKeeps)
    {
      string sql = @"
            INSERT INTO vaultKeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newVaultKeeps); //get the new id back from line 36 and return to service

    }

    // public void Delete(VaultKeeps vk)
    // {
    //   string sql = "DELETE from vaultkeeps WHERE vaultId = @vaultid AND keepId = @keepId";
    //   _db.Execute(sql, vk);
    // }
  }
}