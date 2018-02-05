using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ApplicationCore;
using ApplicationCore.Entities;


namespace Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {

        private string connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-AuthorsManager-A9CAD047-1190-4FDF-8FBE-89A92067683B;Trusted_Connection=True;MultipleActiveResultSets=true";
        private string selectQuery = "SELECT Id, FirstName, LastName, Email\n" +
            "FROM Authors\n";
        private string selectByIdClause = "WHERE Id = @id\n";
        private string orderByName = "ORDER BY LastName desc, FirstName\n";
        private string insertAuthorQuery = "INSERT INTO Authors\n" +
            "(FirstName,LastName,Email)\n" +
            "values(@fname,@lname,@email)\n";
        private string updateAuthorQuery = "UPDATE Authors SET FirstName = @fname, LastName = @lname, Email = @email where Id = @id";
        private string deleteAuthorQuery = "DELETE Authors where Id = @id";




        public Author getAuthorById(int id)
        {
            Author retrievedAuthor = new Author();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(selectQuery + selectByIdClause, conn);
                cmd.Parameters.AddWithValue("@id", id); 

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        retrievedAuthor = new Author
                        {
                            Id = int.Parse(reader[0].ToString()),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            Email = reader[3].ToString()

                        };
                       
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

                return retrievedAuthor;
        }

        public List<Author> getAuthorList()
        {
            List<Author> authorList = new List<Author>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(selectQuery + orderByName, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Author retrievedAuthor = new Author
                        {
                            Id = int.Parse(reader[0].ToString()),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            Email = reader[3].ToString()

                        };

                        authorList.Add(retrievedAuthor);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return authorList;
           
        }

        public void Add(Author newAuthor)
        {
           using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(insertAuthorQuery, conn);
                cmd.Parameters.AddWithValue("@fname", newAuthor.FirstName);
                cmd.Parameters.AddWithValue("@lname", newAuthor.LastName);
                cmd.Parameters.AddWithValue("@email", newAuthor.Email);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }



        }


        public void Delete(Author deleteAuthor)

        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(deleteAuthorQuery, conn);
                cmd.Parameters.AddWithValue("@id", deleteAuthor.Id);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public void Edit(Author updateAuthor)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(updateAuthorQuery, conn);
                cmd.Parameters.AddWithValue("@fname", updateAuthor.FirstName);
                cmd.Parameters.AddWithValue("@lname", updateAuthor.LastName);
                cmd.Parameters.AddWithValue("@email", updateAuthor.Email);
                cmd.Parameters.AddWithValue("@id", updateAuthor.Id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }



    }
}
