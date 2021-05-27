using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.JWT
{

    public interface IJwtAuthenticationManager
    {
        string Authentication(string name, string password);

    }
}
