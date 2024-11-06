using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Setting
{
    public interface ISettingService
    {
        Task ToogleMaintenence();
        bool GetMaintenanceState();
    }
}
