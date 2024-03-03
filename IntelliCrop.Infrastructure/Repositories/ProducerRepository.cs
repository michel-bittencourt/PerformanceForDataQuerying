using Dapper;
using IntelliCrop.Domain;
using IntelliCrop.Domain.Interfaces;
using IntelliCrop.Infrastructure.Context;
using Microsoft.Data.SqlClient;

namespace IntelliCrop.Infrastructure.Repositories;

public class ProducerRepository : IProducerRepository
{
    #region Properties
    private readonly ApplicationDbContext _context;
    #endregion

    #region Constructor
    public ProducerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region CUD
    public async Task Create<T>(T entity) where T : class
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update<T>(T entity) where T : class
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Reads
    public async Task<Producer> GetProducerByIdAsyncEF(Guid? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), "ID cannot be null.");
        }

        return await _context.producers.FindAsync(id.Value) ?? throw new InvalidOperationException($"Producer with ID {id} not found.");
    }
    public async Task<Producer> GetProducerByIdAsyncSQL(Guid? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), "ID cannot be null.");
        }

        string connectionString = "Server=localhost;Database=IntelliCropDb;User Id=sa;Password=KtG85@KK;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";
        string sql = "SELECT * FROM producers WHERE Id = @Id";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Mapear os resultados para um objeto Producer
                        Producer producer = new Producer(
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            reader.GetString(reader.GetOrdinal("Address"))
                        );

                        return producer;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Producer with ID {id} not found.");
                    }
                }
            }
        }
    }

    public async Task<Producer> GetProducerByIdAsyncDAPPER(Guid? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), "ID cannot be null.");
        }

        string connectionString = "Server=localhost;Database=IntelliCropDb;User Id=sa;Password=KtG85@KK;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";
        string sql = "SELECT FirstName, LastName, Description, PhoneNumber, Address FROM producers WHERE Id = @Id";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            Producer producer = await connection.QueryFirstOrDefaultAsync<Producer>(sql, new { Id = id });

            return producer;
        }
    }
    #endregion
}
