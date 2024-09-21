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
using WebApplication2.Sevices.MsCategoryService;
using Microsoft.AspNetCore.Routing;

namespace WebApplication2.Helper
{
    [ApiController]
    [Route("category")]
    public class CategoryHelper
    {
        public CategoryHelper()
        {
        }

        [HttpPost]
        [Route("addcategory")]
        [Produces("application/json")]
        public IActionResult AddCategory([FromBody] MsCategoryAddDTO item)
        {
            var obJson = new OutputBase();
            
            var result = MsCategoryService.addCategory(item);

            if (result == true)
            {
                obJson.ResultCode = 200;
                obJson.ErrorMessage = "Success";
                return new OkObjectResult(obJson);
            } else
            {
                obJson.ResultCode = 404;
                obJson.ErrorMessage = "Failed";
                return new BadRequestObjectResult(obJson);
            }
           
        }

        [HttpGet]
        [Route("getCategory")]
        [Produces("application/json")]
        public IActionResult GetCategory()
        {
            var obJson = new MsCategoryAllOutput();
          
            var result = MsCategoryService.getAllCategory();

            if (result == null)
            {   
                obJson.Data = new List<MsCategoryAllOutput.Category> { new MsCategoryAllOutput.Category() };
                obJson.ErrorMessage = "Failed";
                obJson.ResultCode = 404;
                return new BadRequestObjectResult(obJson);
            }
            else
            {
                obJson.Data = result;
                obJson.ErrorMessage = "Success";
                obJson.ResultCode = 200;
                return new OkObjectResult(obJson);
            }

            
        }

        [HttpPatch]
        [Route("UpdateCategory")]
        [Produces("application/json")]
        public IActionResult UpdateCategory(MsCategoryUpdateDTO input)
        
        {
            var obJson = new OutputBase();

            var result = MsCategoryService.UpdateCategoryItem(input);

            if (result == false)
            {
 
                obJson.ResultCode = 404;
                obJson.ErrorMessage = "Failed";
                return new BadRequestObjectResult(obJson);
            }

            else
            {
                obJson.ResultCode = 200;
                obJson.ErrorMessage = "Success";

                return new OkObjectResult(obJson);
            }
        }

        [HttpDelete]
        [Route("DeletCategory")]
        [Produces("application/json")]
        public IActionResult DeletCategory(MsCategoryDeleteDTO delet)

        {
            var obJson = new OutputBase();

            var result = MsCategoryService.DeletCategoryItem(delet);

            if (result == false)
            {

                obJson.ResultCode = 404;
                obJson.ErrorMessage = "Failed";
                return new BadRequestObjectResult(obJson);
            }

            else
            {
                obJson.ResultCode = 200;
                obJson.ErrorMessage = "Success";

                return new OkObjectResult(obJson);
            }
        }
    }
}
