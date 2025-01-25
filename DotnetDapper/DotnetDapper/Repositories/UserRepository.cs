using Dapper;
using DotnetDapper.Models;
using Microsoft.Data.SqlClient;

namespace DotnetDapper.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;
    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<User> GetAll()
    {
        using var conection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        return conection.Query<User>(@"
            SELECT 
                Id
                ,FullName
                ,Email
                ,Active
                ,CreatedAt
                ,UpdatedAt
            FROM Users"
        ).ToList();
    }
}
