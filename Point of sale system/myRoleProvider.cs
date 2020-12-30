using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Point_of_sale_system.Models;
namespace Point_of_sale_system
{
    public class myRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using(var context=new DbModelEntities())
            {
                var res1 = (from user in context.Users
                            join role in context.User_Role on user.RoleID equals role.RoleId
                            where user.email == username
                            select role.Name).ToArray();

                var res = (from roles in context.User_Role
                          join user in context.Users on roles.RoleId equals user.RoleID
                          where user.email == username
                          select user.User_Role.Name).ToArray();
                return res;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}