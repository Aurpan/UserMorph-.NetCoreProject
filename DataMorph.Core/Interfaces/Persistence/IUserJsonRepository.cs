namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IUserJsonRepository
    {
        string ReadUsersJson();
        string SaveUsersJson();
    }
}
