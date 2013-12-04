using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampOnline.Domain
{
    public interface IUserSession
    {
        void SetValue(string key, object value);
        T GetValue<T>(string key);
    }
}
