using PyrixMan.Model;

namespace PyrixMan.Helpers.Interface
{
    public interface IUserCreator
    {
        bool UserExists(string emailAddress);
        
        bool CreateUser(User user);
    }
}
