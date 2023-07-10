namespace Application.ServiceContracts
{
    public interface IHomePriceByIdService
    {
        Task<decimal> GetHomePrice(int id);
    }
}
