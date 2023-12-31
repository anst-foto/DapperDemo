﻿using Dapper;
using Microsoft.Data.Sqlite;

namespace DapperDemo.DataAccess.Tables;

public abstract class BaseTable<T>
{
    private readonly SqliteConnection _db;

    protected BaseTable(string connectionString)
    {
        _db = new SqliteConnection(connectionString);
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    protected IEnumerable<T>? FindAll(string sql)
    {
        _db.Open();

        var result = _db.Query<T>(sql);
        
        _db.Close();

        return result;
    }

    protected bool Execute(string sql)
    {
        _db.Open();

        var result = _db.Execute(sql);
        
        _db.Close();

        return result != 0;
    }

    protected T? FindSingle(string sql)
    {
        _db.Open();

        var result = _db.QuerySingleOrDefault<T>(sql);
        
        _db.Close();

        return result;
    }
}