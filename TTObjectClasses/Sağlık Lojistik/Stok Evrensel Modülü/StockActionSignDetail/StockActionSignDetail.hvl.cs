
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionSignDetail")] 

    public  partial class StockActionSignDetail : TTObject
    {
        public class StockActionSignDetailList : TTObjectCollection<StockActionSignDetail> { }
                    
        public class ChildStockActionSignDetailCollection : TTObject.TTChildObjectCollection<StockActionSignDetail>
        {
            public ChildStockActionSignDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionSignDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İmza Tipi
    /// </summary>
        public SignUserTypeEnum? SignUserType
        {
            get { return (SignUserTypeEnum?)(int?)this["SIGNUSERTYPE"]; }
            set { this["SIGNUSERTYPE"] = value; }
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
    /// Vekil
    /// </summary>
        public bool? IsDeputy
        {
            get { return (bool?)this["ISDEPUTY"]; }
            set { this["ISDEPUTY"] = value; }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser SignUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SIGNUSER"); }
            set { this["SIGNUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CheckStockCensusAction CheckStockCensusAction
        {
            get { return (CheckStockCensusAction)((ITTObject)this).GetParent("CHECKSTOCKCENSUSACTION"); }
            set { this["CHECKSTOCKCENSUSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockActionSignDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionSignDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionSignDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionSignDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionSignDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONSIGNDETAIL", dataRow) { }
        protected StockActionSignDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONSIGNDETAIL", dataRow, isImported) { }
        public StockActionSignDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionSignDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionSignDetail() : base() { }

    }
}