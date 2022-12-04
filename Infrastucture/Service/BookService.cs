    using Dapper;
    using Npgsql;
    using Domain.Dto;

    namespace Infrastructure.Services;

        public class BookService
        {
            private DapperContext _context;
            public AutorService(DapperContext context)
            {
                _context = context;
            }
            public List<GetBooks> GetBooks()
            {
            using (var connection = _context.CreateConnection())
            {
                string sql = "select a.id, a.FirstName, a.LastName , b.BookName from author as a join book as b  on a.id = b.author_id";
                var result = connection.Query<GetBooks>(sql).ToList();
                return result;
            }
            }
            public int InsertBooks(Book book)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql =
                        $"Insert into Book ( BookName, author_id) VALUES ('{book.BookName}',{(int)book.Author_id})";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int UpdateBooks(Book book)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql =
                        $"UPDATE Book SET BookName = '{book.BookName}' , author_id = {book.Author_id} WHERE Id = {book.Id} ";
                    var result = conn.Execute(sql);
                    return result;
                }
            }
            public int DeleteBook(int id)
            {
                using (var connection = _context.CreateConnection())
                {
                    var sql = $"DELETE FROM Book WHERE id = {id}";

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