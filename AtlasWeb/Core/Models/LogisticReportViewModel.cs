using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class LogisticReportViewModel
    {
        public List<Report> Reports
        {
            get;
            set;
        }
    }

    public class Report
    {
        public Guid id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string caption
        {
            get;
            set;
        }

        public List<Report> items
        {
            get;
            set;
        }
    }

    public class SubStoreModel
    {
        public List<SubStoreItem> Stores
        {
            get;
            set;
        }
    }

    public class SubStoreItem
    {
        public string id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }
}
