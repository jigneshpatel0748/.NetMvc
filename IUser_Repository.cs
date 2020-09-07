using JigneshPractical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JigneshPractical.Repository
{
    public interface IUser_Repository : IDisposable
    {
        List<MST_City_List_Get_Result> GetCityList();
        int GetUserCode();
        List<MST_User_Register_Result> MST_User_Register(string UserName, string EmailId, string Passwod, int CityId, out int ReturnValue, out string RetuenMsg);
        List<User_Login_Result> User_Login(string UserName, string Passwod, out int ReturnValue, out string RetuenMsg);
    }
}
