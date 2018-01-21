using CashRegister.Library.Models;

namespace CashRegister.Library.Interfaces
{
    public interface IBasketManager
    {
        BasketDetails BasketDetails { get; }

        void AddHistory(string operation, string itemName = "", double price = 0, double finalPrice = 0, bool applyDiscount = false);
        bool AddNewItem(string itemname, int quantity);
        bool CalculateBasketItem(string itemname, int quantity);
        double GetTotalBasket();
    }
}