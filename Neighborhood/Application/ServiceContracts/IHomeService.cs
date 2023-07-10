namespace Application.ServiceContracts
{
    public interface IHomeService
    {
        Task<decimal> GetHomePrice(int id);
    }
}
