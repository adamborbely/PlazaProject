using System.Collections.Generic;

namespace packagecom.codecool.plaza.api
{
    public class ShopImpl : IShop
    {
        private string _name;
        private string _owner;
        private Dictionary<long, ShopEntryImpl> products;
        private bool _isopen = false;

        public ShopImpl(string name, string owner)
        {
            _name = name;
            _owner = owner;
            products = new Dictionary<long, ShopEntryImpl>();
        }
        public string GetName()
        {
            return _name;
        }

        public string GetOwner()
        {
            return _owner;
        }
        public bool IsOpen()
        {
            return _isopen;
        }

        public void Open()
        {
            _isopen = true;
        }
        public void Close()
        {
            _isopen = false;
        }
        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            foreach (KeyValuePair<long, ShopEntryImpl> entry in products)
            {
                result.Add(entry.Value.GetProduct());
            }
            return result;
        }
        public Product FindByName(string name)
        {
            foreach (KeyValuePair<long, ShopEntryImpl> entry in products)
            {
                if (entry.Value.GetProduct().GetName().Equals(name))
                {
                    return entry.Value.GetProduct();
                }
            }
            throw new System.NotImplementedException();

            //throw NoSuchProductException();
        }

        public float GetPrice(long barcode)
        {
            if (products.ContainsKey(barcode))
            {
                return products[barcode].GetPrice();
            }
            throw new System.NotImplementedException();
            //throw NoSuchProductException();
        }
        public bool HasProduct(long barcode)
        {
            if (products.ContainsKey(barcode))
            {
                return true;
            }
            return false;
        }
        public void AddNewProduct(Product product, int quantity, float price)
        {
            if (products.ContainsKey(product.GetBarcode()))
            {
                //throw ProductAlreadyExistsException();
            }
            else
            {
                products.Add(product.GetBarcode(), new ShopEntryImpl(product, quantity, price));
            }
        }

        public void AddProduct(long barcode, int quantity)
        {
            if (products.ContainsKey(barcode))
            {
                products[barcode].IncreaseQuantity(quantity);
            }
            else
            {
                //throw NoSuchProductException();
            }
        }

        public Product BuyProduct(long barcode)
        {
            if (products.ContainsKey(barcode) && products[barcode].GetQuantity() > 0)
            {
                products[barcode].SetQuantity(products[barcode].GetQuantity() - 1);
                return products[barcode].GetProduct();
            }
            throw new System.NotImplementedException();
            //throw NoSuchProductException();
            //OutOfStockException
        }

        public List<Product> BuyProducts(long barcode, int quantity)
        {
            var result = new List<Product>();
            if (products.ContainsKey(barcode) && products[barcode].GetQuantity() > quantity)
            {
                products[barcode].DecreaseQuantity(quantity);
                if (products[barcode].GetProduct() is FoodProduct)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        result.Add(new FoodProduct(products[barcode].GetProduct() as FoodProduct));
                    }
                }
                else if (products[barcode].GetProduct() is ClothingProduct)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        result.Add(new ClothingProduct(products[barcode].GetProduct() as ClothingProduct));
                    }
                }
                return result;
            }
            throw new System.NotImplementedException();
        }

        internal class ShopEntryImpl
        {
            private Product _product;
            private int _quantity;
            private float _price;
            public ShopEntryImpl(Product product, int quantity, float price)
            {
                _product = product;
                _quantity = quantity;
                _price = price;
            }
            public Product GetProduct()
            {
                return _product;
            }
            public void SetProduct(Product product)
            {
                _product = product;
            }
            public int GetQuantity()
            {
                return this._quantity;
            }
            public void SetQuantity(int quantity)
            {
                _quantity = quantity;
            }
            public void IncreaseQuantity(int quantity)
            {
                _quantity += quantity;
            }
            public void DecreaseQuantity(int quantity)
            {
                _quantity -= quantity;
            }

            public float GetPrice()
            {
                return _price;
            }
            public void SetPrice(int price)
            {
                _price = price;
            }
            public override string ToString()
            {
                return "Don't sure yet";
            }

        }
    }
}