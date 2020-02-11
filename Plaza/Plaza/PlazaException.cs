using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class PlazaException : System.Exception
    {
        public PlazaException() : base() { }
    }
    class PlazaIsClosedException : PlazaException
    {
        public PlazaIsClosedException() : base() { }
    }
}
