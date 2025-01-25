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
                    FROM Users
                    WHERE 
                        Active = @active",
                    new { active = true }
                ).ToList();
    }

    public User? GetById(long id)
    {
        using var conection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
     
        return  conection.QueryFirstOrDefault<User?>(@"
                    SELECT 
                        Id
                        ,FullName
                        ,Email
                        ,Active
                        ,CreatedAt
                        ,UpdatedAt
                    FROM Users
                    WHERE 
                            Id = @id
                        AND Active = @active", 
            
                    new { id });
    }

    public bool CreateUser(CreateUserRequestDTO request)
    {
        using var conection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        
        var result = conection.Execute(@"
                        INSERT INTO Users (
                              FullName
                            , Email
                            , Active
                            , CreatedAt
                            , UpdatedAt)
                        VALUES (
                              @FullName
                            , @Email
                            , @Active
                            , @CreatedAt
                            , @UpdatedAt)
                        ",
                        request
                    );

        return result > 0;
    }

    public bool UpdateUser(UpdateUserRequestDTO request) 
    {
        using var conection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var result = conection.Execute(@"
                        UPDATE Users 
                        SET
                              FullName = @FullName
                            , Email = @Email
                            , Active = @Active
                            , UpdatedAt = @UpdatedAt

                        WHERE Id = @Id
                        ",
                       request
                   );

        return result > 0;
    }
}
