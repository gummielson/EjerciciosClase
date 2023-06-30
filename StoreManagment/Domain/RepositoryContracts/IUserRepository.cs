namespace Data.Repositories
{
    public interface IUserRepository
    {
        //Task<IEnumerable<UserEntity>> GetAllUsers();
        Task SaveDataInFile();
    }
}