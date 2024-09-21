using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Input;
using WebApplication2.Tabel;

namespace WebApplication2.Sevices.MsItemService
{
    public class UserService
    {

        public static bool SignUp(SignUpDTO item)
        {
            try
            {
                using var db = new SEContext();

                var SignUpUser = Guid.NewGuid();

                db.MsLogin.Add(new MsLogin{
                    UserID = SignUpUser,
                    UserName = item.UserName,
                    EmailAdderss = item.EmailAddress,
                    Password = item.Password

                });

                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
            
        }

        public static bool Login(LoginDTO item)
        {
            try
            {
                using var db = new SEContext();

                var LoginUser = db.MsLogin.Where(x => x.EmailAdderss == item.EmailAddress  && x.Password == item.Password).FirstOrDefaultAsync().Result;

                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

     



        }
}
