    using Dapper;
    using Npgsql;
    using Domain.Dto;

    namespace Infrastructure.Services;

        public class AutorService
        {
            private DapperContext _context;
            public AutorService(DapperContext context)
            {
                _context = context;
            }
            public async Task<Response<List<Autor>>>  GetAutors()
            {
                using (var connection = _context.CreateConnection())
                {
                    try
                    {
                        string sql = "SELECT * FROM author";
                        var response = await connection.QueryAsync<Autor>(sql).ToList();
                        return new Response<List<Autor>>(response.ToList());   
                    }
                    catch (Exception ex)
                    {
                        return new Response<List<Autor>>(HttpStatusCode.BadRequest, "eror 404")
                    }
                }
            }
            public int InsertAutors(Autor autor)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql =
                        $"Insert into author ( FirstName, LastName) VALUES ('{autor.FirstName}','{autor.LastName}')";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int UpdateAutors(Autor autor)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql =
                        $"UPDATE author SET FirstName = '{autor.FirstName}' , LastName = {autor.LastName} WHERE Id = {autor.Id} ";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int DeleteAutors(int id)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql = $"DELETE FROM author WHERE id = {id}";

                    var result = conn.Execute(sql);

                    return result;
                }
            }
            // public int ByIdOrders(int id)
            // {
            //     using (var conn = new NpgsqlConnection(_connectionString))
            //     {
            //         var sql = $"select * from Products where id = {id}";
            //         var result = conn.Execute(sql);
            //         return result;
            //     }
            // }
            //   public int CountProducts()
            // {
            //     using (var conn = new NpgsqlConnection(_connectionString))
            //     {
            //         var sql = $"Select count(*) FROM Products";

            //         var result = conn.Execute(sql);

            //         return  result;
            //     }
            // }   
        }