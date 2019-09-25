using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res365.BusinessLogic
{
    public interface IStringParser
    {
        List<int> Numbers { get; set; }
        List<int> NegativeNumbers { get; set; }
        List<int> IgnoredNumbers { get; set; }
        bool AllowNegative { get; set; }
        int UpBound { get; set; }
        void ParseString(string input);       
    }
}
