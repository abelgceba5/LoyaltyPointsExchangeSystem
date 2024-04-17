namespace Loyalty_Points_Exchange_System.Interface
{
    public interface IEarnPoints
    {
        Task<bool> EarnPointsAsync(int userId, int pointsEarned);
        Task EarnPointsAsync(int userId, int itemId, int pointsEarned);
    }
}
