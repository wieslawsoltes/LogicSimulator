
namespace Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Solution : Element
    {
        public Solution()
            : base()
        {
            this.Children = new List<Element>();
        }

        public Context CurrentContext { get; set; }
        public Project CurrentProject { get; set; }
    }
}
