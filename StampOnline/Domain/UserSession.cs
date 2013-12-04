using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StampOnline.Models;

namespace StampOnline.Domain
{
    public class UserSession: IUserSession
    {
        public UserSession()
        {

        }

        public void SetValue(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public T GetValue<T>(string key)
        {
            var session = HttpContext.Current.Session;
            if (session == null)
                return default(T);

            object value = session[key];
            if (value == null)
                return default(T);

            return (T)value;
        }
    }
}