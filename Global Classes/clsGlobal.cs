using GymnasiumLogicLayer;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Gymnasium.Global_Classes
{
    public class clsGlobal
    {

        public static clsUsers _CurrentUser;

        // Specify the Registry key and path
        // static variabels for Registry Methods
        private static string keyPath = "HKEY_CURRENT_USER\\SOFTWARE\\Gymnasium";
        private static string MiniKeyPath = "SOFTWARE\\Gymnasium";
        private static string valueName = "UserName";
        private static string valueName2 = "Password";

        // Registry Methods =========================================================

        /// <summary>
        /// Saves the provided username and password to the Windows registry if they are not empty.
        /// If the username and password are empty, deletes the current user from the registry.
        /// Returns true if the username and password are successfully saved or deleted, false otherwise.
        /// </summary>
        /// <param name="Username">The username to be saved or deleted.</param>
        /// <param name="Password">The password to be saved or deleted.</param>
        /// <returns>True if the username and password are successfully saved or deleted, false otherwise.</returns>
        public static bool RememberUsernameAndPasswordUsingRegistry(string Username, string Password)
        {
            bool IsRemembred = false;


            string KeyValue = Username;

            string KeyValue2 = Password;

            try
            {
                if (KeyValue != "" && KeyValue2 != "")
                {
                    Registry.SetValue(keyPath, valueName, KeyValue, RegistryValueKind.String);
                    Registry.SetValue(keyPath, valueName2, KeyValue2, RegistryValueKind.String);

                    // MessageBox.Show($"Success, UserName {KeyName} And Password Are Successfully Saved In the Registry ✅");


                    IsRemembred = true;
                }
                else
                {
                    // deleting The Current User From Registry If chkRememberMe Is False
                    try
                    {

                        // Open the registry key in read/write mode with explicit registry view
                        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                        {
                            // deleting User Name From The Registry
                            using (RegistryKey key = baseKey.OpenSubKey(MiniKeyPath, true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueName);


                                    // Console.WriteLine($"Successfully deleted value '{KeyName}' from registry key '{MiniKeyPath}'");
                                }
                                else
                                {
                                    // Console.WriteLine($"Registry key '{MiniKeyPath}' not found");
                                }
                            }

                            // deleting User Name From The Registry
                            using (RegistryKey key = baseKey.OpenSubKey(MiniKeyPath, true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueName2);


                                    //  Console.WriteLine($"Successfully deleted value '{KeyName2}' from registry key '{MiniKeyPath}'");
                                }
                                else
                                {
                                    //  Console.WriteLine($"Registry key '{MiniKeyPath}' not found");
                                }
                            }

                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
            }


            return IsRemembred;
        }

        /// <summary>
        /// Retrieves the stored credential from the registry.
        /// </summary>
        /// <param name="UserName">The username stored in the registry.</param>
        /// <param name="Password">The password stored in the registry.</param>
        /// <returns>True if the credential is found, false otherwise.</returns>
        public static bool GetStoredCredentialFromRegistry(ref string UserName, ref string Password)
        {
            bool IsFind = false;

            try
            {
                // Read the value from the Registry
                UserName = Registry.GetValue(keyPath, valueName, null) as string;
                Password = Registry.GetValue(keyPath, valueName2, null) as string;

                if (UserName != null && Password != null)
                {
                    IsFind = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }


            return IsFind;
        }
    }
}
