using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Helpers
{

    public interface IJwtAuthenticationManager
    {
        string Authentication(string name, string password);

    }
}
