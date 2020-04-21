using RestWithASPNETUdemy.Data.Converter;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
                return new Book();
            return new Book()
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return new BookVO();
            return new BookVO()
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public IList<Book> ParseList(IList<BookVO> origin)
        {
            if (origin == null)
                return new List<Book>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public IList<BookVO> ParseList(IList<Book> origin)
        {
            if (origin == null)
                return new List<BookVO>();

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
