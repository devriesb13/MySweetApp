using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetApp.Core.Attributes
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DataTemplateAttribute: Attribute
    {
        public DataTemplateAttribute(string resourcefilename)
        {
            ResourceFileName = resourcefilename;
        }

        public string ResourceFileName { get; }
    }
}
