using System;
using System.Collections.Generic;

namespace Output
{
    public class MsCategoryAllOutput : OutputBase
    {
        public MsCategoryAllOutput()
        {

        }

        public List<Category> Data {  get; set; }

        public class  Category
        {
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
        
    }
}