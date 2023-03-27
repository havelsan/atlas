using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public interface IQueryParam
    {
        object paramValue { get; }
    }

    public class ArrayParam : IQueryParam
    {
        public IQueryParam[] paramValue { get; set; }

        object IQueryParam.paramValue
        {
            get
            {
                return this.GetValueArray();
            }
        }

        public object GetValueArray()
        {
            var valueList = new List<string>();
            if ( paramValue != null)
            {
                foreach(var arrayItemValue in paramValue)
                {
                    valueList.Add(Convert.ToString(arrayItemValue.paramValue));
                }
            }
            return valueList;
        }
    }

    public class BooleanParam : IQueryParam
    {
        public bool paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class DateParam : IQueryParam
    {
        public DateTime paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class DecimalParam : IQueryParam
    {
        public decimal paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class GuidParam : IQueryParam
    {
        public Guid paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class IntegerParam : IQueryParam
    {
        public int paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class StringParam : IQueryParam
    {
        public string paramValue { get; set; }
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

    public class NullValueParam : IQueryParam
    {
        public object paramValue { get; set; } = null;
        object IQueryParam.paramValue
        {
            get
            {
                return this.paramValue;
            }
        }
    }

}