using System;
using System.Collections.Generic;
using System.Text;
using WebHelpers.OAuth2;
using Xamarin.Forms;

namespace SIITEC2App
{
    public class AppSettings
    {
        private static AppSettings _instance;

        private AppSettings()
        {
            ;
        }

        public static AppSettings Instance
        {
            get
            {
                return _instance ?? (_instance = new AppSettings());
            }
        }

        private T GetProperty<T>(string key) where T : IConvertible
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (T)Application.Current.Properties[key];
            }
            return default;
        }

        private void SetProperty<T>(string key, T value) where T : IConvertible
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        private void ClearProperty(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                Application.Current.Properties.Remove(key);
            }
        }

        private void ClearProperties(params string[] keys)
        {
            foreach(var key in keys)
            {
                ClearProperty(key);
            }
        }

        public TokenSuccess AuthToken
        {
            get
            {
                return TokenSuccess.FromPrimitives(
                    GetProperty<string>("auth_accessToken"),
                    GetProperty<string>("auth_tokenType"),
                    GetProperty<int>("auth_expiresIn"),
                    GetProperty<string>("auth_refreshToken"),
                    GetProperty<long>("auth_creationTicks")
                );
            }
            set
            {
                if (value is null)
                {
                    ClearProperties(
                        "auth_creationTicks",
                        "auth_accessToken",
                        "auth_tokenType",
                        "auth_expiresIn",
                        "auth_refreshToken"
                    );
                }
                else
                {
                    SetProperty("auth_creationTicks", value.CreateTime.Ticks);
                    SetProperty("auth_accessToken", value.AccessToken);
                    SetProperty("auth_tokenType", value.Type);
                    SetProperty("auth_expiresIn", value.Lifetime);
                    SetProperty("auth_refreshToken", value.RefreshToken);
                }
            }
        }
    }
}
