﻿using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindbyId(long id);
        IList<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);

    }
}