using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using WebApplication2.Input;
using WebApplication2.Tabel;
using static Output.MsCategoryAllOutput;

namespace WebApplication2.Sevices.MsCategoryService
{
    public class MsCategoryService
    {
        // add category
        public static bool addCategory(MsCategoryAddDTO item)
        {   

            try
            {
                using var db = new SEContext();

                // Buat id baru
                var id = Guid.NewGuid();

                db.MsCategory.Add(new MsCategory()
                {
                    CategoryId = id,
                    CategoryName = item.categoryName
                });


                var result = db.SaveChanges();



                return true;
            } catch (Exception ex) { 
                return false;
            }
            
        }

        // nampilin kategory
        // list<Cateory> return yang diinginkan
        public static List<Category> getAllCategory()
        {   

            try
            {
                using var db = new SEContext();

                var result = new List<Category>();

                var msCategories = db.MsCategory.ToList();

                    foreach ( var msCategory in msCategories)
                {
                    result.Add(new Category()
                    {
                        CategoryId = msCategory.CategoryId,
                        CategoryName = msCategory.CategoryName
                    });
                }

                return result;
                   
            } 
            catch (Exception ex)
            {
                throw (ex);
               //return null;

            }


        }
        // update data
        public static bool UpdateCategoryItem(MsCategoryUpdateDTO input) {
            try
            {
                using var db = new SEContext();

                // mencari dari MsCategories dimana x = variabel bebas dan dicari dari category id
                var dataUpdate = db.MsCategory.Where(x => x.CategoryId == Guid.Parse(input.categoryID )).FirstOrDefaultAsync().Result;

                // ganti category name
                dataUpdate.CategoryName = input.categoryName;

                var result = db.Update(dataUpdate);

                db.SaveChanges();

                return true;
                
            } catch (Exception ex)
            {
                return false;
            }          
        }

        public static bool DeletCategoryItem(MsCategoryDeleteDTO delet)
        {

            try
            {
                using var db = new SEContext();

                var dataDelet = db.MsCategory.Where(x => x.CategoryId == Guid.Parse(delet.categoryID)).FirstOrDefault();


                var result = db.Remove(dataDelet);

                db.SaveChanges();

                return true;

            }catch (Exception ex)
            {

                return false;

            }
            

            
        }

    }
}
