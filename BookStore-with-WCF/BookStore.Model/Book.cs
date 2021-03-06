﻿using System.Collections.Generic;
using Mita.DataAccess;

namespace BookStore.Model
{
    public class Book : TitledDomainObject
    {
        public string ISBN { get; set; }

        public int PublishYear { get; set; }

        public int CategoryId { get; set; }

        public BookCategory Category { get; set; }

        public decimal Price { get; set; }

        public ICollection<Writer> Writers { get; set; }

        public ICollection<BookAmount> Amounts { get; set; } 
    }
}
