using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementation
{
    public class BookBusiness : IBookBusiness
    {
        
        private IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;

        public BookBusiness(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity= _bookRepository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public IList<BookVO> FindAll()
        {
            return _converter.ParseList(_bookRepository.FindAll());
        }

        public BookVO FindbyId(long id)
        {
            return _converter.Parse( _bookRepository.FindbyId(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }      
    }
}
