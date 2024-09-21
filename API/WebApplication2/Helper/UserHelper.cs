using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Output;
using WebApplication2.Input;
using WebApplication2.Sevices.MsItemService;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Helper
{
    [ApiController]
    [Route("user")]
    public class UserHelper
    {
        public UserHelper()
        {
        }

        [HttpPost]
        [Route("signup")]
        [Produces("text/char")]        
        public IActionResult SignUp([FromBody] SignUpDTO item)
        {
            var obJson = new OutputBase();
            var result = UserService.SignUp(item);
            if (result)
            {
                obJson.ResultCode = 200;
                obJson.ErrorMessage = "Success";
            } else
            {
                obJson.ResultCode = 400;
                obJson.ErrorMessage = "Fail";
            }
            return new OkObjectResult(obJson);
        }

        [HttpPost]
        [Route("login")]
        [Produces("application/json")]
        public IActionResult Login([FromBody] LoginDTO item)
        {
            var obJson = new LoginOutput();
            obJson.result = UserService.Login(item);
            if (!string.IsNullOrEmpty(obJson.EmailAddress))
            {
                obJson.ResultCode = 200;
                obJson.ErrorMessage = "Success";
            } else
            {
                obJson.ResultCode = 400;    
                obJson.ErrorMessage = "Fail";
            }
            return new OkObjectResult(obJson);
        }
    }
}
