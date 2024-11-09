
using System.Data;
using Dapper;

public class PollRepositoryDB : IPollRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public PollRepositoryDB(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Poll?> Create(Poll item)
    {
        const string query = @"
        INSERT INTO Poll 
        VALUES (@Name) 
        RETURNING (@Name)";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QueryFirstOrDefaultAsync<Poll>(query, item);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        const string query = "DELETE FROM Poll WHERE Id = @Id";

        using var connection = await _dbConnection.InitializeConnection();
        var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<List<Poll>> GetAll()
    {
        const string query = "SELECT * FROM Poll";

        using var connection = await _dbConnection.InitializeConnection();
        var array = await connection.QueryAsync<Poll>(query);
        var response = array.ToList();
        return response;
    }

    public async Task<Poll?> GetById(int id)
    {
        const string query = "SELECT * FROM Poll WHERE Id = @Id";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QuerySingleOrDefaultAsync<Poll>(query, new { Id = id });
        return response;
    }

    public async Task<Poll?> Update(int id, Poll item)
    {
        const string query = @"UPDATE Poll 
        SET Name = @Name, Options = @Options 
        WHERE Id = @Id 
        RETURNING (@Id, @Name, @Options)
        ";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QuerySingleOrDefaultAsync<Poll>(query, item);
        return response;
    }
}
