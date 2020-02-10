using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class ClothingProduct : Product
    {
        private string material;
        private string type;
        private ClothingProduct(long barcode, string name, string manufacturer, string material, string type) : base(barcode, name, manufacturer)
        {
            this.material = material;
            this.type = type;
        }
        public ClothingProduct(ClothingProduct cloths) : base(cloths.GetBarcode(), cloths.GetName(), cloths.GetManufacturer())
        {
            this.material = cloths.GetMaterial();
            this.type = cloths.GetClothesType();
        }
        public string GetMaterial()
        {
            return material;
        }
        public string GetClothesType()
        {
            return type;
        }
        public override string ToString()
        {
            return "ruha";
        }
    }
}
