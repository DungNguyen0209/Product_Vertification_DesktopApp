using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Communication
{
    public class QueryResult<T>
    {
        public IList<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
    }
}
