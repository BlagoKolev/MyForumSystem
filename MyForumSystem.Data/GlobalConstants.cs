using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForumSystem.Data
{
    public class GlobalConstants
    {
        public const int ContentsMaxLength = 5000;
        public const int ContentMinLength = 2;
        public const int TitleMaxLength = 100;
        public const int TitleMinLength = 3;
        public const int DescriptionMaxLength = 100;
        public const int DescriptionMinLength = 3;

        public const string RequiredFieldWarning = "The '{0}' field is reqired.";
        public const string FieldLengthWarning = "Field {0} must be between {2} and {1} sumbols.";
        public const string ValueInRangeWarning = "'{0}' must be between {1} and {2}";

    }
}
