using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore
{
    public interface IAuthorRepository
    {
        Author getAuthorById(int id);
        List<Author> getAuthorList();
        void Add(Author newAuthor);
        void Delete(Author deleteAuthor);
        void Edit(Author updateAuthor);     
       
    }
}