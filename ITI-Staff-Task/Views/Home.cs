using Domain.Enums;

namespace ITI_Staff_Task.Views
{
    /// <summary>
    /// Represent the main Views in Console APP
    /// </summary>
    public static class Home
    {
        /// <summary>
        /// Display Menu Section
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("\n PRESS" +
                $" \n\t {Utility.Green}A{Utility.Reset} =>> To Add New Product" +
                $" \n\t {Utility.Green}S{Utility.Reset} =>> To Show All Products with {Utility.Bold}Total Inventory{Utility.Reset}" +
                $" \n\t {Utility.Green}Q{Utility.Reset} =>> To Change Quantity of Product" +
                $" \n\t {Utility.Green}B{Utility.Reset} =>> To Back to Menu" +
                //$" \n\t {Utility.Green}T{Utility.Reset} =>> To Back to Menu" +
                $" \n\t {Utility.Green}E{Utility.Reset} =>> To Exist Application" + Utility.BreakLine);
            
            
        }

        /// <summary>
        /// Display the Categories
        /// </summary>
        /// <returns>string that will be show in Console</returns>
        public static string ShowCategories()
        {
            //Console.WriteLine("\t\t\t\t\t\t  Our Categories |" +
            //    "\n \t\t\t\t\t\t \t\t V" +
            //   $" \n \t {Category.Phone} | {(int)Category.Phone} - {Category.LabTop} | {(int)Category.LabTop} - {Category.PC} | {(int)Category.PC} " +
            //   $"\n ______________________________________________________________________________________________ \n\n");

            return $" \n{Category.Phone} | {(int)Category.Phone} - {Category.LabTop} | {(int)Category.LabTop} - {Category.PC} | {(int)Category.PC} ";
        }

        /// <summary>
        /// Display the Exception Scenario
        /// </summary>
        /// <param name="exception"><see cref="Exception"/></param>
        public static void HandleException(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(exception.Message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
