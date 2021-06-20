using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            //validate wheter a property has the attribute or not
            //if the object is null -> no attribute

            string str = (string)obj;

            return !string.IsNullOrEmpty(str);

        }
    }
}
