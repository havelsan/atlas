
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OtherCostDetail")] 

    public  partial class OtherCostDetail : TTObject
    {
        public class OtherCostDetailList : TTObjectCollection<OtherCostDetail> { }
                    
        public class ChildOtherCostDetailCollection : TTObject.TTChildObjectCollection<OtherCostDetail>
        {
            public ChildOtherCostDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOtherCostDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string OtherCostName
        {
            get { return (string)this["OTHERCOSTNAME"]; }
            set { this["OTHERCOSTNAME"] = value; }
        }

        public Currency? OtherCostPrice
        {
            get { return (Currency?)this["OTHERCOSTPRICE"]; }
            set { this["OTHERCOSTPRICE"] = value; }
        }

        public ArgeProject ArgeProjectCost
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECTCOST"); }
            set { this["ARGEPROJECTCOST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExchangeTypeDef ExchangeType
        {
            get { return (ExchangeTypeDef)((ITTObject)this).GetParent("EXCHANGETYPE"); }
            set { this["EXCHANGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OtherCostDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OtherCostDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OtherCostDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OtherCostDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OtherCostDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OTHERCOSTDETAIL", dataRow) { }
        protected OtherCostDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OTHERCOSTDETAIL", dataRow, isImported) { }
        public OtherCostDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OtherCostDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OtherCostDetail() : base() { }

    }
}