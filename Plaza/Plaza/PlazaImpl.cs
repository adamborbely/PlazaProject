using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    class PlazaImpl : IPlaza
    {
        private List<IShop> _shops;
        private bool _isopen = false;
        private string _name;
        public PlazaImpl(string name)
        {
            this._name = name;
            _shops = new List<IShop>();
        }
        public List<IShop> GetShops()
        {
            return _shops;
            //throw PlazaIsClosedException();
        }
        public string GetName()
        {
            return _name;
        }
        public void AddShop(IShop shop)
        {
            _shops.Add(shop);
            //throw ShopAlreadyExistsException();
            //throw PlazaIsClosedException();
        }
        public void RemoveShop(IShop shop)
        {
            _shops.Remove(shop);
            //throw NoSuchShopException();
            //throw PlazaIsClosedException();
        }

        public IShop FindShopByName(string name)
        {
            foreach (var shop in _shops)
            {
                if (name == shop.GetName())
                {
                    return shop;
                }
            }
            throw new Exception();
            //throw NoSuchShopException();
            //throw PlazaIsClosedException();
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
