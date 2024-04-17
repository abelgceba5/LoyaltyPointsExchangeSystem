namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface IRedeemPoints
    {
        Task<bool> RedeemPointsAsync(int userId, int pointsRedeemed, decimal amountRedeemed);
    }
}
