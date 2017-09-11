using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc517.DAL.Validator
{
    public class YearValidator :ValidationAttribute
    {

        public YearValidator()
        {
            ErrorMessage = "The year is not right!";
        }

        public override bool IsValid(object value)
        {
            bool isValid = false;
            try
            {
                int year = (int)value;

                if (year < 1598)
                {
                    isValid = false;
                }
                else
                    isValid = true;


                return isValid;

            }
            catch (Exception)
            {
                return false;

            }
        }


    }
}