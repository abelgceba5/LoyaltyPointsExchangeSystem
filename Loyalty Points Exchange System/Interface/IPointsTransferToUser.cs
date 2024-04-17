namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface IPointsTransferToUser
    {

        Task<bool> TransferPointsToUserAsync(int fromUserId, int toUserId, int pointsToTransfer);
    }
}
