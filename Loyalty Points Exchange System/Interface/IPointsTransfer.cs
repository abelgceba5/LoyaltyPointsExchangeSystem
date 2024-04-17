namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface IPointsTransfer
    {

        Task<bool> TransferPointsToBankAsync(int userId, int pointsToTransfer);
    }
}
