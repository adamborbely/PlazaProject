using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    public interface IPlaza
    {
        //+List<Shop> getShops() throws PlazaIsClosedException
        //+void addShop(Shop shop) throws ShopAlreadyExistsException, PlazaIsClosedException
        //+void removeShop(Shop shop) throws NoSuchShopException, PlazaIsClosedException
        //+Shop findShopByName(String name) throws NoSuchShopException, PlazaIsClosedException
        //+boolean isOpen()
        //+void open()
        //+void close()
        //+String toString()
        public List<IShop> GetShops();
        public void AddShop(IShop shop);
        public void RemoveShop(IShop shop);
        public IShop FindShopByName(string name);
        public bool IsOpen();
        public void Open();
        public void Close();
        public string ToString();
    }
}
