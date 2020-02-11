using packagecom.codecool.plaza.api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace packagecom.codecool.plaza.cmdprog
{
    class CmdProgram
    {
        private List<Product> cart;
        private List<float> prices;


        public CmdProgram(string[] args)
        {
        }

        public void Run()
        {
            Console.WriteLine("There are no plaza created yet! Press \n1) to create a new plaza.\n2) to exit");
            var ans = Console.ReadLine();
            if (ans == "1")
            {
                Console.WriteLine("Give a name of your Plaza");
                var plazaName = Console.ReadLine();
                Console.Clear();
                var plaza = new PlazaImpl(plazaName);
                while (true)
                {
                    PlazaMenuLogic(plaza, PlazaMenu(plaza));
                }
            }
            else if (ans == "2")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Thread.Sleep(600);
                Console.Clear();
                Run();
            }
        }
        public string PlazaMenu(IPlaza plaza)
        {

            Console.WriteLine($"Welcome to the {plaza.GetName()} plaza! Press\n" +
                $"1) to list all shops\n" +
                $"2) to add a new shop\n" +
                $"3) to remove an existing shop\n" +
                $"4) enter a shop by name\n" +
                $"5) to open the plaza\n" +
                $"6) to close the plaza\n" +
                $"7) to check if the plaza is open or not\n" +
                $"8) leave plaza");
            return Console.ReadLine();
        }
        public void PlazaMenuLogic(IPlaza plaza, string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var shop in plaza.GetShops())
                    {
                        Console.WriteLine(shop.GetName());
                    }
                    break;
                case "2":
                    Console.WriteLine("What is the name of the shop");
                    var shopName = Console.ReadLine();
                    Console.WriteLine("Who is the owner of the shop");
                    var shopOwner = Console.ReadLine();
                    plaza.AddShop(new ShopImpl(shopName, shopOwner));
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Which shop you want to remove?");
                    var shopToRemove = Console.ReadLine();
                    plaza.RemoveShop(plaza.FindShopByName(shopToRemove));
                    Console.WriteLine($"{shopToRemove} is not in our plaza anymore.");
                    break;
                case "4":
                    Console.WriteLine("Which shop you looking for?");
                    var shopToEnter = Console.ReadLine();
                    ShopMenuLogic(plaza.FindShopByName(shopToEnter), ShopMenu(plaza.FindShopByName(shopToEnter)));
                    break;
                case "5":
                    Console.Clear();
                    plaza.Open();
                    break;
                case "6":
                    Console.Clear();
                    plaza.Close();
                    break;
                case "7":
                    Console.Clear();
                    if (plaza.IsOpen())
                    {
                        Console.WriteLine($"{plaza.GetName()} is open.");
                    }
                    else
                    {
                        Console.WriteLine($"{plaza.GetName()} is closed.");
                    }
                    break;
                case "8":
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        public string ShopMenu(IShop shop)
        {
            Console.WriteLine($"Welcome to the {shop.GetName()} shop! Press\n" +
                $"1) to list avaible products\n" +
                $"2) to find products by name\n" +
                $"3) to display the shop's owner\n" +
                $"4) to open the shop\n" +
                $"5) to close the shop\n" +
                $"6) to add new product to the shop.\n" +
                $"7) to add existing products to the shop.\n" +
                $"8) to buy a product by barcode.\n" +
                $"9) check price by barcode.\n" +
                $"0) go back to plaza");
            return Console.ReadLine();
        }
        public void ShopMenuLogic(IShop shop, string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    foreach (var product in shop.GetProducts())
                    {
                        Console.WriteLine(product.GetName());
                    }
                    break;
                case "2":
                    Console.WriteLine("What product you are looking for?");
                    var productName = Console.ReadLine();
                    Console.WriteLine(shop.FindByName(productName));
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(shop.GetOwner());
                    break;
                case "4":
                    Console.Clear();
                    shop.Open();
                    break;
                case "5":
                    Console.Clear();
                    shop.Close();
                    break;
                case "6":
                    Console.WriteLine("Press 1 if you want to add food, 2 for adding clothes");
                    var foodOrCloth = Console.ReadLine();
                    switch (foodOrCloth)
                    {
                        case "1":
                            Console.WriteLine("Pls give the barcode of the product");
                            var barcode = Console.ReadLine();
                            Console.WriteLine("What's the name of the product?");
                            var name = Console.ReadLine();
                            Console.WriteLine("Who is the manufacturer?");
                            var manufact = Console.ReadLine();
                            Console.WriteLine("How many calories it have?");
                            var calories = Console.ReadLine();
                            Console.WriteLine("Best before?");
                            var bestBefore = Console.ReadLine();
                            var productToAdd = new FoodProduct(Convert.ToInt64(barcode), name, manufact, Convert.ToInt32(calories), Convert.ToDateTime(bestBefore));
                            Console.WriteLine("How many you want to add?");
                            var quant = Console.ReadLine();
                            Console.WriteLine("How much it costs?");
                            var price = Console.ReadLine();
                            shop.AddNewProduct(productToAdd, Convert.ToInt32(quant), Convert.ToSingle(price));
                            break;
                        case "2":
                            Console.WriteLine("Pls give the barcode of the product");
                            var barcodec = Console.ReadLine();
                            Console.WriteLine("What's the name of the product?");
                            var namec = Console.ReadLine();
                            Console.WriteLine("Who is the manufacturer?");
                            var manufactc = Console.ReadLine();
                            Console.WriteLine("What material it is");
                            var material = Console.ReadLine();
                            Console.WriteLine("What type is it?");
                            var type = Console.ReadLine();
                            var clothToAdd = new ClothingProduct(Convert.ToInt64(barcodec), namec, manufactc, material, type);
                            Console.WriteLine("How many you want to add?");
                            var quanty = Console.ReadLine();
                            Console.WriteLine("How much it costs?");
                            var priceCloth = Console.ReadLine();
                            shop.AddNewProduct(clothToAdd, Convert.ToInt32(quanty), Convert.ToSingle(priceCloth));
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Pls give the barcode of the product");
                    var barcodeToAdd = Console.ReadLine();
                    Console.WriteLine("Pls give quantity you want to add.");
                    var quantity = Console.ReadLine();
                    shop.AddProduct(Convert.ToInt64(barcodeToAdd), Convert.ToInt32(quantity));
                    break;
                case "8":
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
