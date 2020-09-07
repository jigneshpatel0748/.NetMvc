using JigneshPractical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JigneshPractical.Repository
{
    public class User_Repository : IUser_Repository
    {
        #region :: Defult Constructor ::
        private JigneshPracticalEntities context;

        public User_Repository(JigneshPracticalEntities _context)
        {
            this.context = _context;
        }
        #endregion

        public List<MST_City_List_Get_Result> GetCityList()
        {
            return context.MST_City_List_Get().ToList();
        }
        public int GetUserCode()
        {
            int MessageOutput = 0;
            var outParam = new ObjectParameter("UserCode", typeof(int));
            context.MST_User_Code_Get(outParam);
            MessageOutput = Convert.ToInt32(outParam.Value);
            return MessageOutput;
        }
        public List<MST_User_Register_Result> MST_User_Register(string UserName, string EmailId, string Passwod, int CityId, out int ReturnValue, out string RetuenMsg)
        {
            ReturnValue = 0;
            RetuenMsg = "";
            List<MST_User_Register_Result> _List = new List<MST_User_Register_Result>();

            var outRetunrValue = new ObjectParameter("ReturnValue", typeof(int));
            var outReturnMsg = new ObjectParameter("RetuenMsg", typeof(string));
            _List = context.MST_User_Register(UserName, EmailId, Passwod, CityId, outRetunrValue, outReturnMsg).ToList();

            ReturnValue = Convert.ToInt32(outRetunrValue.Value);
            RetuenMsg = Convert.ToString(outReturnMsg.Value);

            return _List;
        }

        public List<User_Login_Result> User_Login(string UserName, string Passwod, out int ReturnValue, out string RetuenMsg)
        {
            ReturnValue = 0;
            RetuenMsg = "";
            List<User_Login_Result> _List = new List<User_Login_Result>();

            var outRetunrValue = new ObjectParameter("ReturnValue", typeof(int));
            var outReturnMsg = new ObjectParameter("RetuenMsg", typeof(string));
            _List = context.User_Login(UserName, Passwod, outRetunrValue, outReturnMsg).ToList();

            ReturnValue = Convert.ToInt32(outRetunrValue.Value);
            RetuenMsg = Convert.ToString(outReturnMsg.Value);

            return _List;
        }



        #region :: Disposed Event ::
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
