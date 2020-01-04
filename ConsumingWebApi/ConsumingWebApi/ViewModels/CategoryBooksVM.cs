﻿using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.ViewModels
{
    public class CategoryBooksVM
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
}
