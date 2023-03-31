using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.DataAccess
{
    public class UsersData : IUsersData
    {
        private readonly DBContextSys dBContext;
        public UsersData(DBContextSys context)
        {
            dBContext= context;
        }

    }
}
