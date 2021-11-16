namespace userinterface
{
    public enum MenuType
    {
        StartMenu,
        MainMenu,
        AddCustomer,
        ShowCustomer,
        SearchForCustomer,
        SearchByCategory,
        ViewStoreFronts,
        PlaceOrder,
        ViewOrderHistory,
        ReplenishInventory,
        ShowLineItems,
        ShowColumbia,
        ShowCharleston,


        

        Exit
       

    }
    public interface IMenu
    {
        /// <summary>
        /// Display menu of current class, choices user is allowed to make
        /// 
        /// </summary>
        void Menu();
        /// <summary>
        /// Record what User Inputs, will change menu upon choice
        /// </summary>
        /// <returns>Returns a menu enum that user will go to next</returns> 
        MenuType UserChoice();
        
    }
}