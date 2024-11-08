using Domain.Enums;

namespace ITI_Staff_Task.Views
{
    public static class Home
    {
        public static void Menue()
        {
            Console.WriteLine("\n PRESS" +
                $" \n\t {Utility.Green}A{Utility.Reset} =>> To Add New Product" +
                $" \n\t {Utility.Green}S{Utility.Reset} =>> To Show All Products with {Utility.Bold}Total Inventory{Utility.Reset}" +
                $" \n\t {Utility.Green}Q{Utility.Reset} =>> To Change Quantity of Product" +
                $" \n\t {Utility.Green}B{Utility.Reset} =>> To Back to Menue" +
                //$" \n\t {Utility.Green}T{Utility.Reset} =>> To Back to Menue" +
                $" \n\t {Utility.Green}E{Utility.Reset} =>> To Exist Application" + Utility.BreakLine);
            
            
        }

        public static string ShowCategories()
        {
            //Console.WriteLine("\t\t\t\t\t\t  Our Categories |" +
            //    "\n \t\t\t\t\t\t \t\t V" +
            //   $" \n \t {Category.Phone} | {(int)Category.Phone} - {Category.Labtop} | {(int)Category.Labtop} - {Category.PC} | {(int)Category.PC} " +
            //   $"\n ______________________________________________________________________________________________ \n\n");

            return $" \n{Category.Phone} | {(int)Category.Phone} - {Category.Labtop} | {(int)Category.Labtop} - {Category.PC} | {(int)Category.PC} ";
        }

        public static void HandleException(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(exception.Message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
