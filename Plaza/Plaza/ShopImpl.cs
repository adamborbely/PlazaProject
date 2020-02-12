using System.Collections.Generic;

namespace packagecom.codecool.plaza.api
{
    public class ShopImpl : IShop
    {
        private string _name;
        private string _owner;
        private Dictionary<long, ShopEntryImpl> products;
        private bool _isopen = true;

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
        public int GetQuantityOf(long barcode)
        {
            if (products.ContainsKey(barcode))
            {
                return products[barcode].GetQuantity();
            }
            else
            {
                throw new NoSuchProductException();
            }
        }
        public List<Product> GetProducts()
        {
            if (_isopen)
            {
                var result = new List<Product>();
                foreach (KeyValuePair<long, ShopEntryImpl> entry in products)
                {
                    result.Add(entry.Value.GetProduct());
                }
                return result;
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }
        public Product FindByName(string name)
        {
            if (_isopen)
            {
                foreach (KeyValuePair<long, ShopEntryImpl> entry in products)
                {
                    if (entry.Value.GetProduct().GetName().Equals(name))
                    {

                        return entry.Value.GetProduct();
                    }
                }
                throw new NoSuchProductException();
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }

        public float GetPrice(long barcode)
        {
            if (_isopen)
            {
                if (products.ContainsKey(barcode))
                {
                    return products[barcode].GetPrice();
                }
                throw new NoSuchProductException();
            }
            else
            {
                throw new ShopIsClosedException();

            }
        }
        public Product GetProductName(long barcode)
        {
            if (products.ContainsKey(barcode))
            {
                return products[barcode].GetProduct();
            }
            throw new NoSuchProductException();
        }
        public bool HasProduct(long barcode)
        {
            if (_isopen)
            {
                if (products.ContainsKey(barcode))
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }
        public void AddNewProduct(Product product, int quantity, float price)
        {
            if (_isopen)
            {
                if (products.ContainsKey(product.GetBarcode()))
                {
                    throw new ProductAlreadyExistsException();
                }
                else
                {
                    products.Add(product.GetBarcode(), new ShopEntryImpl(product, quantity, price));
                }
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }

        public void AddProduct(long barcode, int quantity)
        {
            if (_isopen)
            {
                if (products.ContainsKey(barcode))
                {
                    products[barcode].IncreaseQuantity(quantity);
                }
                else
                {
                    throw new NoSuchProductException();
                }
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }

        public Product BuyProduct(long barcode)
        {
            if (_isopen)
            {
                if (products.ContainsKey(barcode))
                {
                    if (products[barcode].GetQuantity() > 0)
                    {
                        products[barcode].SetQuantity(products[barcode].GetQuantity() - 1);
                        return products[barcode].GetProduct();
                    }
                    else
                    {
                        throw new OutOfStockException();
                    }
                }
                else
                {
                    throw new NoSuchProductException();
                }
            }
            else
            {
                throw new ShopIsClosedException();
            }
        }

        public List<Product> BuyProducts(long barcode, int quantity)
        {
            if (_isopen)
            {
                var result = new List<Product>();
                if (products.ContainsKey(barcode))
                {
                    System.Console.WriteLine(products[barcode].GetQuantity());
                    if (products[barcode].GetQuantity() >= quantity)
                    {

                        products[barcode].DecreaseQuantity(quantity);
                        for (int i = 0; i < quantity; i++)
                        {
                            result.Add(products[barcode].GetProduct());
                        }

                        return result;
                    }
                    else
                    {
                        throw new OutOfStockException();
                    }
                }
                else
                {
                    throw new NoSuchProductException();
                }
            }
            else
            {
                throw new ShopIsClosedException();
            }
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
                return $"We have {GetQuantity()} pieces left";
            }

        }
    }
}