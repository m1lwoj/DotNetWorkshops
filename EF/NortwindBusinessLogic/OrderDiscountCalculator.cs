
public class OrderDiscountCalculator
{
    private readonly int _quantity;

    public OrderDiscountCalculator(int quantity = 100)
    {
        _quantity = quantity;
    }

    public float SetDiscount(int quantity)
    {
        if (quantity > _quantity)
        {
            return 0.1f;
        }

        return 0;
    }
}
