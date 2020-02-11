using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class ProductException : System.Exception
    {
        public ProductException() : base() { }
    }
    class NoSuchProductException : ProductException
    {
        public NoSuchProductException() : base() { }
    }
    class ProductAlreadyExistsException : ProductException
    {
        public ProductAlreadyExistsException() : base() { }
    }
    class OutOfStockException : ProductException
    {
        public OutOfStockException() : base() { }
    }
}
