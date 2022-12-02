    using Dapper;
    using Npgsql;
    using Domain.Dto;

    namespace Infrastructure.Services;

        public class AutorService
        {
            private string _connectionString = "Server=127.0.0.1;Port=5432;Database=autor_books;User Id=postgres;Password=shohrukh;";

            public List<Autor> GetAutors()
            {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM author";
                var result = connection.Query<Autor>(sql).ToList();
                return result;
            }
            }
            public int InsertAutors(Autor autor)
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var sql =
                        $"Insert into author ( FirstName, LastName) VALUES ('{autor.FirstName}','{autor.LastName}')";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int UpdateAutors(Autor autor)
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var sql =
                        $"UPDATE author SET FirstName = '{autor.FirstName}' , LastName = {autor.LastName} WHERE Id = {autor.Id} ";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int DeleteAutors(int id)
            {
                using (var conn = new NpgsqlConnection(_connectionString))
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