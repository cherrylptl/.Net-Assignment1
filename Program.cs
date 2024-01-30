namespace _Net_Assignment1;

class Program
{
    static string[] productsList = { "Mouse", "KeyBoard", "Leptop", "HardDrive", "SSD" };
    static double[] productsPrice = { 10.00, 15.00, 500.00, 20.00, 30.00 };

    static void Main(string[] args)
    {

        StudentInformation();

        StoreMenu();

        int[] quantities = CartItemList();

        bool loyaltyCard = HasLoyaltyCard();

        Receipt(quantities);

        double subTotal = SubTotal(quantities);
        Console.WriteLine("\nSubTotal : $ {0}", subTotal);

        double loyaltyCardDiscount = LoyaltyCardDiscount(subTotal, loyaltyCard);
        Console.WriteLine("Discount : $ {0}", loyaltyCardDiscount);

        double totalTax = TotalTax(subTotal, loyaltyCardDiscount);
        Console.WriteLine("Tax(13%) : $ {0}", totalTax);

        double totalCost = TotalCost(totalTax, subTotal, loyaltyCardDiscount);
        Console.WriteLine("TotalCost : $ {0}", totalCost);

        Console.WriteLine("\n\n");
    }

    static void StudentInformation()
    {
        Console.WriteLine("\nName : Patel Cherryl \nStudent Number : 8963305 \nEmai : cpatel3305@conestogac.on.ca\n");
    }


    static void StoreMenu()
    {
        Console.WriteLine("Available Electronics Items:");

        for (int i = 0; i < productsList.Length; i++)
        {
            string itemName = productsList[i];
            double itemPrice = productsPrice[i];

            Console.WriteLine("{0} : $ {1}", itemName, itemPrice);
        }
        Console.WriteLine("");
    }

    static int[] CartItemList()
    {
        int[] quantities = new int[productsList.Length];

        for (int i = 0; i < productsList.Length; i++)
        {
            Console.Write($"Enter the quantity of {productsList[i]} (0 for none): ");
            quantities[i] = int.Parse(Console.ReadLine());
        }

        return quantities;
    }

    static bool HasLoyaltyCard()
    {
        Console.Write("\nDo you have a loyalty card? (yes/no): ");
        string userInput = Console.ReadLine();
        return userInput == "yes";
    }

    static void Receipt(int[] quantities)
    {
        Console.Write("\nReceipt:\n");
        for (int i = 0; i < productsList.Length; i++)
        {
            if (quantities[i] > 0)
            {
                Console.WriteLine($"{productsList[i]} x {quantities[i]}");
            }
        }
    }

    static double SubTotal(int[] quantities)
    {
        double subTotal = 0;
        for (int i = 0; i < productsPrice.Length; i++)
        {
            subTotal += quantities[i] * productsPrice[i];
        }
        return subTotal;
    }

    static double LoyaltyCardDiscount(double subTotal, bool loyalty)
    {
        return loyalty ? 0.10 * subTotal : 0;
    }

    static double TotalTax(double subTotal, double discount)
    {
        return (subTotal - discount) * 0.13;
    }

    static double TotalCost(double totalTax, double subTotal, double discount)
    {
        return subTotal - discount + totalTax;
    }
}
