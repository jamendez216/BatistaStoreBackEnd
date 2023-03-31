using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSBusiness.Access
{
    public class UsersService : IUsersInterface
    {
        private readonly IUsersData data; 
        public UsersService(IUsersData data) 
        {
            this.data = data;
        }


    }
}
