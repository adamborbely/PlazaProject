using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class PlazaImpl : IPlaza
    {
        private List<IShop> _shops;
        private bool _isopen = true;
        private string _name;
        public PlazaImpl(string name)
        {
            this._name = name;
            _shops = new List<IShop>();
        }
        public List<IShop> GetShops()
        {
            if (_isopen)
            {
                return _shops;
            }
            throw new PlazaIsClosedException();
        }
        public string GetName()
        {
            return _name;
        }
        public void AddShop(IShop shop)
        {
            if (_isopen)
            {
                foreach (var bolt in _shops)
                {
                    if (bolt.GetName().Equals(shop.GetName()))
                    {
                        throw new ShopAlreadyExistsException();
                    }
                }
                _shops.Add(shop);
            }
            else
            {
                throw new PlazaIsClosedException();
            }

        }
        public void RemoveShop(IShop shop)
        {
            if (_isopen)
            {
                var removed = false;
                foreach (var bolt in _shops)
                {
                    if (bolt.GetName().Equals(shop.GetName()))
                    {
                        _shops.Remove(shop);
                        removed = true;
                        break;
                    }
                }
                if (!removed)
                {
                    throw new NoSuchShopException();
                }
            }
            else
            {
                throw new PlazaIsClosedException();
            }
        }

        public IShop FindShopByName(string name)
        {
            if (_isopen)
            {
                foreach (var shop in _shops)
                {
                    if (name == shop.GetName())
                    {
                        return shop;
                    }
                }
                throw new NoSuchShopException();
            }
            else
            {
                throw new PlazaIsClosedException();
            }
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
        public override string ToString()
        {
            return "fcku";
        }
    }
}
