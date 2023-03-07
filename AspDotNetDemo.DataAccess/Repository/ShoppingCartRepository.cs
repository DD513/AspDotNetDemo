using AspDotNetDemo.DataAccess.Repository.IRepository;
using AspDotNetDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetDemo.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }

        public void UpdateIceAndSweetness(ShoppingCart obj)
        {
            var cartFromDb = _db.ShoppingCarts.FirstOrDefault(
                u => u.ApplicationUserId == obj.ApplicationUserId && u.ProductId == obj.ProductId);

            if (cartFromDb != null)
            {
                cartFromDb.Ice = obj.Ice;
                cartFromDb.sweetness = obj.sweetness;
            }
        }
    }
}
