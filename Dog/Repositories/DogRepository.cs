using Dapper;
using Dogs.API.DataBase;
using Dogs.API.DTO;
using Dogs.Models;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

public class DogRepository
{
    private readonly SqlConnection _connection;

    public DogRepository(ConnectionDB connection)
    {
        _connection = connection.GetConnection();
    }

    public async Task<List<DogResponseDTO>> GetAllDogsAsync()

    {

        var sql = "SELECT Id, Name, BirthDate, ImageUrl, Adopted FROM Dogs";
        return (await _connection.QueryAsync<DogResponseDTO>(sql)).ToList();

    }

    public async Task<DogResponseDTO?> GetDogByIdAsync(int id)
    {
        var sql = "SELECT Id, Name, BirthDate, ImageUrl, Adopted FROM Dogs WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<DogResponseDTO>(sql, new { Id = id });
    }

    public async Task AddDogAsync(Dog dog)
    {
        var sql = @"INSERT INTO Dogs (Name, BirthDate, ImageUrl, Adopted)
                    VALUES (@Name, @BirthDate, @ImageUrl, @Adopted)";

        await _connection.ExecuteAsync(sql, new
        {
            dog.Name,
            dog.BirthDate,
            ImageUrl = dog.ImageUrl?.Message,
            dog.Adopted
        });
    }

    public async Task DeleteDogAsync(int id)
    {
        var sql = @"DELETE FROM Dogs WHERE Id = @Id";
        await _connection.QueryAsync(sql, new { Id = id });
    }

    public async Task UpdateDogAsync(int id, DogUpdateDTO dog)
    {
        try
        {
            var sql = @"UPDATE Dogs
                    SET Name = @Name,
                        BirthDate = @BirthDate
                        WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new
            {
                Name = dog.Name,
                BirthDate = dog.BirthDate,
                Id = id

            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error" + ex.Message);

        }
    }

    public async Task UpdateAdoptedAsync(int id, bool adopted)
    {
        try
        {
            var sql = @"UPDATE Dogs SET Adopted = @Adopted WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new
            {
                Adopted = adopted,
                Id = id
            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error" + ex.Message);
        }
    }

    public async Task AddTutorAsync(Tutor tutor)
    {
        var sql = @"INSERT INTO Tutor (Name, Phone, Email, DogId)
                    VALUES (@Name, @Phone, @Email, @DogId)";

        //mudar dog para adotado
        var sqlDog = @"UPDATE Dogs SET Adopted = 1 WHERE Id = @DogId";
        await _connection.ExecuteAsync(sqlDog, new
        {
            tutor.DogId
        });

        await _connection.ExecuteAsync(sql, new
        {
            tutor.Name,
            tutor.Phone,
            tutor.Email,
            tutor.DogId
        });
    }

    public async Task<List<TutorRequestDTO>> GetAllTutorsAsync()
    {
        var sql = "SELECT Name, Phone, Email, DogId FROM Tutor";
        return (await _connection.QueryAsync<TutorRequestDTO>(sql)).ToList();
    }
   

}