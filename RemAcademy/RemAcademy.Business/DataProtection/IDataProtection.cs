using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.DataProtection
{
    public interface IDataProtection
    {
        string Protect(string text);
        string UnProtected(string protectedText);
    }
}
