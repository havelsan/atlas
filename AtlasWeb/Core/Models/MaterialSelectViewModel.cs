using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class MaterialSelectViewModel
    {
        public List<MaterialTreeItem> Materials
        {
            get;
            set;
        }
    }

    public class MaterialTreeItem
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public Guid? ParentID
        {
            get;
            set;
        }

        public bool? expanded
        {
            get;
            set;
        }

        public List<MaterialTreeItem> items
        {
            get;
            set;
        }

        public List<MaterialItem> Materials
        {
            get;
            set;
        }
    }

    public class MaterialItem
    {
        public string ObjectID { get; set; }
        public string MaterialName { get; set; }
        public int? Amount { get; set; }
        public string DistributionType { get; set; }
        public string Barcode { get; set; }
        public string MaterialTreeName { get; set; }
        public double Inheld { get; set; }
        public string drugSpecification { get; set; }
        public bool IsDivide { get; set; }
        public double DivideUnitAmount { get; set; }
        public double DivideTotalAmount { get; set; }
    }
}