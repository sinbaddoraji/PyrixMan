using PyrixMan.Helpers.Interface;
using PyrixMan.Model;

namespace PyrixMan.Helpers.Implementation;

public class UserCreator(UserDataMongoWriter userDataMongoWriter) : IUserCreator
{
    public bool UserExists(string emailAddress)
    {
        return userDataMongoWriter.Read()
            .Any(x => x.Email.Equals(emailAddress, StringComparison.InvariantCulture));
    }

    public bool CreateUser(User user)
    {
        if (UserExists(user.Email))
        {
            return false;
        }

        userDataMongoWriter.Write(user);
        return true;
    }
}