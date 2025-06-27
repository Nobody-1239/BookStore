using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace MyEshop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void addItem(CartItem item)
        {
            if (CartItems.Exists(i => i.Item.OrderId == item.Item.OrderId))
            {
                CartItems.Find(i => i.Item.OrderId == item.Item.OrderId)
                    .Quantity += 1;
            }
            else
            {
                CartItems.Add(item);
            }
        }

        public void removeItem(int itemId)
        {
            var item = CartItems
                .SingleOrDefault(c => c.Item.OrderId == itemId);
            if (item?.Quantity <= 1)
            {
                CartItems.Remove(item);
            }
            else if (item != null)
            {
                item.Quantity -= 1;
            }
        }
    }
}
