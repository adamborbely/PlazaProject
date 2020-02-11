using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    public interface IShop
    {
        //+String getName()
        //+String getOwner()
        //+boolean isOpen()
        //+void open()
        //+void close()
        //+List<Product> getProducts() throws ShopIsClosedException
        //+Product findByName(String name) throws NoSuchProductException, ShopIsClosedException
        //+float getPrice(long barcode) throws NoSuchProductException, ShopIsClosedException
        //+boolean hasProduct(long barcode) throws ShopIsClosedException
        //+void addNewProduct(Product product, int quantity, float price) throws ProductAlreadyExistsException, ShopIsClosedException
        //+void addProduct(long barcode, int quantity) throws NoSuchProductException, ShopIsClosedException
        //+Product buyProduct(long barcode) throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        //+List<Product> buyProducts(long barcode, int quantity) throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        //+String toString()
        public string GetName();
        public string GetOwner();
        public bool IsOpen();
        public void Open();
        public void Close();
        public List<Product> GetProducts();
        public Product FindByName(string name);
        public float GetPrice(long barcode);
        public bool HasProduct(long barcode);
        public void AddNewProduct(Product product, int quantity, float price);
        public void AddProduct(long barcode, int quantity);
        public Product BuyProduct(long barcode);
        public List<Product> BuyProducts(long barcode, int quantity);
        public Product GetProductName(long barcode);
        public string ToString();
        public int GetQuantityOf(long barcode);
    }
}
