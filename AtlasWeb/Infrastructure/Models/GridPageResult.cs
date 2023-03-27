using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class GridPageResult<T>
    {
        public List<T> data
        {
            get;
            set;
        }

        public int totalCount
        {
            get;
            set;
        }
    }
}