namespace HPlusSportTDD.Core.Tests
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private List<AddToCartItem> _shoppingCartList;
        public ShoppingCartManager()
        {
            _shoppingCartList = new List<AddToCartItem>();
        }

        public IEnumerable<AddToCartItem> GetCart()
        {
            return _shoppingCartList.ToArray();
        }

        public AddToCartResponse AddToCart(AddToCartRequest request)
        {
            var item = _shoppingCartList.Find(item => item.ArticleId == request.Item.ArticleId);
            if(item == null)
            {
                _shoppingCartList.Add(request.Item);
            }
            else
            {
                item.Quantity += request.Item.Quantity;
            }

            return new AddToCartResponse()
            {
                Items = _shoppingCartList.ToArray()
            };
        }

    }
}