using System;

namespace Output
{
    public class OutputBase
    {
        public OutputBase()
        {

        }
        public OutputBase(Exception ex)
        {

        }

        public int ResultCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}