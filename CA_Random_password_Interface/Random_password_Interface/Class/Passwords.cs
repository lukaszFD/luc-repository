using Random_password_Interface.Interface;

namespace Random_password_Interface.Class
{
    class Passwords
    {
        public string Pass(IGenerator generator)
        {
            return generator.Generator();
        }
    }
}
