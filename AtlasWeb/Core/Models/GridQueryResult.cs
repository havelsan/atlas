using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class GridColumnInfo
    {
        public string DataField
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public string Alignment
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public int VisibleIndex
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }
    }

    public class QueryParameterInfo
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool IsArray
        {
            get;
            set;
        }

        public string SqlTestValue
        {
            get;
            set;
        }

        public string CodeType
        {
            get;
            set;
        }

        public string DataTypeName
        {
            get;
            set;
        }
    }

    public class GridQueryResult
    {
        public IEnumerable<GridColumnInfo> QueryColumns
        {
            get;
            set;
        }

        public object QueryResult
        {
            get;
            set;
        }
    }
}