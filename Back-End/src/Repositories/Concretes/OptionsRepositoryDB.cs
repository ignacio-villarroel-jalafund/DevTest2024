
using Dapper;

public class OptionsRepositoryDB : IOptionsRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public OptionsRepositoryDB(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Options?> Create(Options item)
    {
        const string query = @"
        INSERT INTO Options 
        VALUES (@PollId @Name @Votes) 
        RETURNING (@PollId @Name @Votes)";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QueryFirstOrDefaultAsync<Options>(query, item);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        const string query = "DELETE FROM Options WHERE Id = @Id";

        using var connection = await _dbConnection.InitializeConnection();
        var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<List<Options>> GetAll()
    {
        const string query = "SELECT * FROM Options";

        using var connection = await _dbConnection.InitializeConnection();
        var array = await connection.QueryAsync<Options>(query);
        var response = array.ToList();
        return response;
    }

    public async Task<Options?> GetById(int id)
    {
        const string query = "SELECT * FROM Options WHERE Id = @Id";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QuerySingleOrDefaultAsync<Options>(query, new { Id = id });
        return response;
    }

    public async Task<Options?> Update(int id, Options item)
    {
        const string query = @"UPDATE Options 
        SET Name = @Name, Options = @Options 
        WHERE Id = @Id 
        RETURNING (@Id, @Name, @Options)
        ";

        using var connection = await _dbConnection.InitializeConnection();
        var response = await connection.QuerySingleOrDefaultAsync<Options>(query, item);
        return response;
    }
}
