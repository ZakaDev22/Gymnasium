using System.Text.RegularExpressions;

namespace Gymnasium
{
    public class clsValidation
    {
        /// <summary>
        /// Checks if the given user has the specified permission.
        /// </summary>
        /// <param name="User">The user object to check.</param>
        /// <param name="Perm">The permission to check for.</param>
        /// <returns>True if the user has the permission, false otherwise.</returns>
        public static bool IsUserHaveThisPermission(int UserPermissions, int Perm)
        {
            return (UserPermissions & Perm) == Perm;
        }


        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }



    }
}
