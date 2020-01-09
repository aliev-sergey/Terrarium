using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrrariumModel
{
    public interface IManage
    {
        void Manage(IManagable imngbl);
    }

    public interface IManagable
    {
        void DoWork();
    }
}
