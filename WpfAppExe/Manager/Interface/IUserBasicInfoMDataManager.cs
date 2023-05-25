using DataBase.DbDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Manager.Interface
{
    public interface IUserBasicInfoMDataManager:IBaseDataManager
    {
        UserBasicInfoMDto GetUserBasicInfoMDto(string loginId,string password);
    }
}
