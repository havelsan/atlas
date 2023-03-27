
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionInspectionDetail")] 

    public  partial class StockActionInspectionDetail : TTObject
    {
        public class StockActionInspectionDetailList : TTObjectCollection<StockActionInspectionDetail> { }
                    
        public class ChildStockActionInspectionDetailCollection : TTObject.TTChildObjectCollection<StockActionInspectionDetail>
        {
            public ChildStockActionInspectionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionInspectionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sınıf Kısaltması
    /// </summary>
        public string ShortMilitaryClass
        {
            get { return (string)this["SHORTMILITARYCLASS"]; }
            set { this["SHORTMILITARYCLASS"] = value; }
        }

    /// <summary>
    /// Rütbe Kısaltması
    /// </summary>
        public string ShortRank
        {
            get { return (string)this["SHORTRANK"]; }
            set { this["SHORTRANK"] = value; }
        }

    /// <summary>
    /// Sicil No
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string NameString
        {
            get { return (string)this["NAMESTRING"]; }
            set { this["NAMESTRING"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public InspectionUserTypeEnum? InspectionUserType
        {
            get { return (InspectionUserTypeEnum?)(int?)this["INSPECTIONUSERTYPE"]; }
            set { this["INSPECTIONUSERTYPE"] = value; }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser InspectionUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("INSPECTIONUSER"); }
            set { this["INSPECTIONUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockActionInspection StockActionInspection
        {
            get { return (StockActionInspection)((ITTObject)this).GetParent("STOCKACTIONINSPECTION"); }
            set { this["STOCKACTIONINSPECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockActionInspectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionInspectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionInspectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionInspectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionInspectionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONINSPECTIONDETAIL", dataRow) { }
        protected StockActionInspectionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONINSPECTIONDETAIL", dataRow, isImported) { }
        public StockActionInspectionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionInspectionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionInspectionDetail() : base() { }

    }
}