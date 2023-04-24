using System.Reflection.Emit;

namespace API.HelperClasses
{
    public class TextProcessor
    {
        public static string CheckPassword(string pass)
        {
            Password password = new Password(pass);
            if (!password.iscorrect)
            {
                if (!password.hasDigits) { return "Your password should have at least one digit"; }
                if (!password.hasSymbols) { return "Your password should have at least one symbol"; }
                if (!password.isLong) { return "Your password should be at least 6 characters long"; }
            }
                return "ok";
        }
        public static string CheckUsername(string username)
        {
            if (!(username.Length >= 5)) { return "Your username should be at least 5 characters long";}
            return "ok";
        }
    }
}
