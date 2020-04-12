using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Register
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CLI app
            Alright, so there's some menus. Main menu: 
                1) Ring item
                    If the user chooses one, they can add cost of an item, and the app should keep track of the total sum
                
                2) Cash out
                    If the user choose 2, it should give show them the total cost and another menu. 
                    1) Go back
                    2) Receive money
                        If the user hits 2 again, you display what the change is in the most efficient manner (how many 100s, 20s, 1, ..., quarters, nickels, ...)
             */

            decimal totalCost = 0.00m;
            decimal itemCostDec = 0.00m;

            Console.WriteLine("Enter the number to perform operation:");
            Console.WriteLine("1) Ring item");
            Console.WriteLine("2) Cash out");
            string choiceMenu = Console.ReadLine();
            Int32.TryParse(choiceMenu, out int mainMenu);

            while (mainMenu == 1 || mainMenu == 2)
            {
                //Ring Item
                if (mainMenu == 1)
                {
                    Console.Write("Enter the item's price: ");
                    string userInput = Console.ReadLine();

                    //Bool statement checks if input can be decimal and output' decimal object
                    if (decimal.TryParse(userInput, out itemCostDec))
                    {
                        //Precision set to only 2 decimal places
                        string itemCostStr = string.Format("{0:0.##}", itemCostDec);
                        decimal itemCost = decimal.Parse(itemCostStr);
                        totalCost += itemCost;
                    }
                    else
                        Environment.Exit(0);

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("\n1) Ring item \n2) Cash out");
                    string inputNew = Console.ReadLine();
                    Int32.TryParse(inputNew, out mainMenu);

                }

                //Cash Out
                //Use Switch Statements 
                else if (mainMenu == 2)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Enter the number to perform operation:");
                    Console.WriteLine("1) Go back");
                    Console.WriteLine("2) Pay and receive change");
                    string cashOut = Console.ReadLine();

                    Int32.TryParse(cashOut, out int cashOutMenu);
                    switch (cashOutMenu)
                    {
                        case 1:
                            while (cashOutMenu == 1)
                            {
                                Console.WriteLine($"Total: {totalCost}");
                                Console.WriteLine("Enter the number to perform operation:");
                                Console.WriteLine("1) Ring item");
                                Console.WriteLine("2) Cash out");
                                string cashoutOption = Console.ReadLine();
                                Int32.TryParse(cashoutOption, out int choice);

                                if (choice == 1)
                                {
                                    mainMenu = 1;
                                    break;
                                }
                                else if (choice == 2)
                                {
                                    cashOutMenu = 2;
                                }
                                else
                                {
                                    mainMenu = 1;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine($"Your Total: ${totalCost:n2}");
                            Console.Write("You pay: $");
                            string userPayment = Console.ReadLine();

//EXCEPTION, not sure how to prevent this if someone enters bunch empty spaecs  
                            while (userPayment == "" || userPayment == " ")
                            {
                                Console.WriteLine($"Your Total: ${totalCost:n2}");
                                Console.Write("You pay: $");
                                userPayment = Console.ReadLine();
                            }

                            string userPaymentStr = string.Format("{0:0.##}", userPayment);
                            decimal payment = decimal.Parse(userPaymentStr);
                            

                            while (payment < totalCost)
                            {
                                Console.Write("Your payment is not enough! Pay: $");
                                userPayment = Console.ReadLine();
                                userPaymentStr = string.Format("{0:0.##}", userPayment);
                                payment = decimal.Parse(userPaymentStr);
                            }

                            //Determine change efficient bills: 100s 50s 20s 10s 1s Quarters Dimes Nickels Pennies

                            decimal change = (payment - totalCost);
                            Console.WriteLine($"Your total change is ${change} and you will receive:");

                            if (change >= 100.00m)
                            {
                                int hundredBills = (int)(change / 100.00m);
                                Console.WriteLine($"{hundredBills} one-hundred dollar");
                                change = (change % 100.00m);

                            }
                            if (change < 100.00m && change >= 50.00m)
                            {
                                int fiftyBills = (int)(change / 50.00m);
                                Console.WriteLine($"{fiftyBills} fifty dollar(s)");
                                change = (change % 50.00m);
                            }
                            if (change < 50.00m && change >= 20.00m)
                            {
                                int twentyBills = (int)(change / 20.00m);
                                Console.WriteLine($"{twentyBills} twenty dollar(s)");
                                change = (change % 20.00m);
                            }
                            if (change < 20.00m && change >= 10.00m)
                            {
                                int tenBills = (int)(change / 10.00m);
                                Console.WriteLine($"{tenBills} ten dollar(s)");
                                change = (change % 10.00m);
                            }
                            if (change < 10.00m && change >= 5.00m)
                            {
                                int fiveBills = (int)(change / 5.00m);
                                Console.WriteLine($"{fiveBills} five dollar(s)");
                                change = (change % 5.00m);
                            }
                            if (change < 5.00m && change >= 1.00m)
                            {
                                int oneBills = (int)(change / 1.00m);
                                Console.WriteLine($"{oneBills} one dollar(s)");
                                change = (change % 1.00m);
                            }
                            if (change < 1.00m && change >= 0.25m)
                            {
                                int quarterChange = (int)(change / 0.25m);
                                Console.WriteLine($"{quarterChange} quarter(s)");
                                change = (change % 0.25m);
                            }
                            if (change < 0.25m && change >= 0.10m)
                            {
                                int dimeChnage = (int)(change / 0.10m);
                                Console.WriteLine($"{dimeChnage} dime(s)");
                                change = (change % 0.10m);
                            }
                            if (change < 0.10m && change >= 0.05m)
                            {
                                int nickelChange = (int)(change / 0.05m);
                                Console.WriteLine($"{nickelChange} nickel(s)");
                                change = (change % 0.05m);
                            }
                            if (change < 0.05m && change >= 0.01m)
                            {
                                int penneyChange = (int)(change / 0.01m);
                                Console.Write($"{penneyChange} ");
                                if (penneyChange > 1)
                                    Console.WriteLine("pennies");
                                else
                                    Console.WriteLine("penny");
                            }

                            Console.WriteLine("\nThank you! Come Again");
                            mainMenu = 0;
                            break;

                        default:

                            while ((cashOutMenu != 1) && (cashOutMenu != 2))
                            {
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Enter the number to perform operation:");
                                Console.WriteLine("1) Go back");
                                Console.WriteLine("2) Pay and receive change");
                                cashOut = Console.ReadLine();

                                Int32.TryParse(cashOut, out cashOutMenu);
                                
                             
                            }
                            break;


                    }
                    //Environment.Exit(0);
                    
                }

                else
                    Console.WriteLine("You entered a invalid #, press Enter to Exit");
            }

            Console.ReadLine();    
        }
    }
}
