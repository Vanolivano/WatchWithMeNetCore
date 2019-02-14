namespace BusinessLogicLayer.Domains
{
    public class User: DataAccessLayer.Entities.User
    {
        public User(DataAccessLayer.Entities.User item)
        {
            Id = item.Id;
            Login = item.Login;
            Password = item.Password;
        }
        public User(){}
    }
}