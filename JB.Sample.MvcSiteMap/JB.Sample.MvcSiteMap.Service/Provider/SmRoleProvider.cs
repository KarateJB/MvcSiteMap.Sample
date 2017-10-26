using JB.Production.Infra.Utility.Logger;
using JB.Sample.MvcSiteMap.DAL;
using JB.Sample.MvcSiteMap.DAL.Models.DAO;
using JB.Sample.MvcSiteMap.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace JB.Sample.MvcSiteMap.Service.Provider
{

    public class SmRoleProvider : RoleProvider, IDisposable
    {
        private String _applicationName = "Sm eFlow";
        private SmDbContext _dbContext = null;
        private SmUserService<SmUser> _userService = null;
        private SmRoleService<SmRole> _roleService = null;
        private SmUserRoleService<SmUserRole> _userRoleService = null;

        public SmRoleProvider()
        {
            this._dbContext = new SmDbContext();
            this._userService = new SmUserService<SmUser>(this._dbContext);
            this._roleService = new SmRoleService<SmRole>(this._dbContext);
            this._userRoleService = new SmUserRoleService<SmUserRole>(this._dbContext);

        }
        public override string ApplicationName
        {
            get
            {
                return this._applicationName;
            }

            set
            {
                this._applicationName = value;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                //Find the users
                var users = this._userService.Get(x => usernames.Contains(x.AdUserId)).ToList();
                //Find the roles
                var roles = this._roleService.Get(x => roleNames.Contains(x.Name)).ToList();

                if (users == null || roles == null)
                {
                    return;
                }

                foreach (var user in users)
                {
                    foreach (var role in roles)
                    {
                        this._userRoleService.Add(new SmUserRole() { SmUserId = user.SmUserId, SmRoleId = role.SmRoleId });
                    }
                }

                //GC
                users.Clear();
                roles.Clear();
                users = null;
                roles = null;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "AddUsersToRoles error.");
                throw;
            }

        }

        public override void CreateRole(string roleName)
        {
            var role = new SmRole()
            {
                Name = roleName,
                Description = roleName,
                IsEnabled = true
            };
            try
            {
                this._roleService.Add(role);
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "CreateRole.");
                throw;
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var role = this._roleService.Get(x => x.Name == roleName).FirstOrDefault();

            try
            {
                if (role != null)
                {
                    this._roleService.Remove(role);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "DeleteRole.");
                throw;
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            //usernameToMatch = usernameToMatch.ToLower();

            try
            {
                var userNames = this._userRoleService.Get(
                    x => (x.SmRole.Name == roleName && x.SmUser.AdUserId == usernameToMatch)).ToList().Select(x => x.SmUser.AdUserId);
                if (userNames != null)
                    return userNames.ToArray();
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "FindUsersInRole.");
                throw;
            }
        }

        public override string[] GetAllRoles()
        {
            try
            {
                var roleNames = this._roleService.GetAll().ToList().Select(x => x.Name);
                if (roleNames != null)
                    return roleNames.ToArray();
                else
                    return null;

            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "GetAllRoles.");
                throw;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var roleNames = this._userRoleService.Get(x => x.SmUser.AdUserId == username).ToList().Select(x => x.SmRole.Name);

                if (roleNames != null)
                    return roleNames.ToArray();
                else
                    return null;

            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "GetRolesForUser.");
                throw;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            try
            {
                var userNames = this._userRoleService.Get(x => x.SmRole.Name == roleName).ToList().Select(x => x.SmUser.AdUserId);
                if (userNames != null)
                    return userNames.ToArray();
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "GetUsersInRole.");
                throw;
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                var role = this._userRoleService.Get(x => (x.SmUser.AdUserId == username && x.SmRole.Name == roleName)).ToList().FirstOrDefault();

                if (role == null)
                {
                    return false;
                }
                else
                    return true;

            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "IsUserInRole.");
                throw;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            //for (int i = 0; i < usernames.Length; i++)
            //    usernames[i] = usernames[i].ToLower();

            try
            {
                foreach (var userName in usernames)
                {
                    foreach (var roleName in roleNames)
                    {
                        var userRole = this._userRoleService.Get(x => (x.SmRole.Name == roleName && x.SmUser.AdUserId == userName)).ToList().FirstOrDefault();
                        if (userRole != null)
                        {
                            this._userRoleService.Remove(userRole);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "RemoveUsersFromRoles.");
                throw;
            }

        }

        public override bool RoleExists(string roleName)
        {
            try
            {
                var role = this._roleService.Get(x => x.Name == roleName).FirstOrDefault();
                if (role == null)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "RoleExists.");
                throw;
            }

        }

        public void Dispose()
        {
            //this._dbContext = null;
            //this._userService = null;
            //this._roleService = null;
            //this._userRoleService = null;
        }
    }
}
