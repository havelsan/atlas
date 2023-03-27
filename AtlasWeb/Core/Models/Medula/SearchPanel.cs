using System;
using System.Collections.Generic;

namespace Core.Models.Medula
{
    public class SearchPanel : BaseModel
    {
        public int Type
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public DateTime? firstDate
        {
            get;
            set;
        }

        public DateTime? lastDate
        {
            get;
            set;
        }

        public List<int> provisionState
        {
            get;
            set;
        }

        public bool switchButton
        {
            get;
            set;
        }

        public int IlId
        {
            get;
            set;
        }

        public int IlceId
        {
            get;
            set;
        }
    }
}