using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class ShopException : System.Exception
    {
        public ShopException() : base() { }
    }
    class ShopIsClosedException : ShopException
    {
        public ShopIsClosedException() : base() { }
    }
    class NoSuchShopException : ShopException
    {
        public NoSuchShopException() : base() { }
    }
    class ShopAlreadyExistsException : ShopException
    {
        public ShopAlreadyExistsException() : base() { }
    }
}
