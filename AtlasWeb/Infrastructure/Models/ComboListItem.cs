using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ComboListItem
    {
        private object _dataValue;
        public object DataValue
        {
            get
            {
                return _dataValue;
            }
        }

        private string _displayText;
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
        }

        public ComboListItem(object dataValue, string displayText)
        {
            _displayText = displayText;
            _dataValue = dataValue;
        }
    }
}