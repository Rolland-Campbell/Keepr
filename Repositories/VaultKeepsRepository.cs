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
      throw new NotImplementedException();
    }

    public IEnumerable<Keep> Get(int id)
    {
      string sql = @"
        SELECT * FROM keeps p
                JOIN vaultkeeps g
                    ON p.keepid = g.vaultid
                WHERE g.id = @id";
      return _db.Query<Keep>(sql, new { id });
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

    public string Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}