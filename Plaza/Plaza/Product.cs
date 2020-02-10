using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    public abstract class Product
    {
        protected long barcode;
        protected string name;
        protected string manufacturer;
        protected Product(long barcode, string name, string manufacturer)
        {
            this.barcode = barcode;
            this.name = name;
            this.manufacturer = manufacturer;
        }
        public long GetBarcode()
        {
            return this.barcode;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetManufacturer()
        {
            return this.manufacturer;
        }
        public override string ToString()
        {
            return "Something";
        }
    }
}
