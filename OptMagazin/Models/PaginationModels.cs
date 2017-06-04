﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptMagazin.Models
{
    public class PaginationModels
    {
    }


    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
   // public class IndexViewModel
   // {
    //    public IEnumerable<Phone> Phones { get; set; }
     //   public PageInfo PageInfo { get; set; }
   // }



}