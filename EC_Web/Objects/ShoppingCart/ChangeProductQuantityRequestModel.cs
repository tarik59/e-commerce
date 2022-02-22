namespace EC_Web.Objects.ShoppingCart
{
    public class ChangeProductQuantityRequestModel
    {
        public int ProductId { get; set; }
        public bool Increasing { get; set; }
    }
}
