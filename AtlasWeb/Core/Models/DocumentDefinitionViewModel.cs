using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace Core.Models
{
    public class DocumentDefinitionViewModel
    {
        public List<Tab> tabs { get; set; }
        public List<DocumentDefinitionItem> documentDefinitions { get; set; }
    }

    public class DocumentDefinitionItem
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

        public Guid? parentID
        {
            get;
            set;
        }

        public List<DocumentDefinitionItem> items
        {
            get;
            set;
        }
    }

    public class Tab
    {
        public Guid id
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }
    }
}