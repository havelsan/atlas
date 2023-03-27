
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DutiesDetail")] 

    public  partial class DutiesDetail : TTObject
    {
        public class DutiesDetailList : TTObjectCollection<DutiesDetail> { }
                    
        public class ChildDutiesDetailCollection : TTObject.TTChildObjectCollection<DutiesDetail>
        {
            public ChildDutiesDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDutiesDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string DutyCostName
        {
            get { return (string)this["DUTYCOSTNAME"]; }
            set { this["DUTYCOSTNAME"] = value; }
        }

        public Currency? DutyCostPrice
        {
            get { return (Currency?)this["DUTYCOSTPRICE"]; }
            set { this["DUTYCOSTPRICE"] = value; }
        }

        public DutyTypeDef DutyType
        {
            get { return (DutyTypeDef)((ITTObject)this).GetParent("DUTYTYPE"); }
            set { this["DUTYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExchangeTypeDef ExchangeType
        {
            get { return (ExchangeTypeDef)((ITTObject)this).GetParent("EXCHANGETYPE"); }
            set { this["EXCHANGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject ArgeProjectCost
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECTCOST"); }
            set { this["ARGEPROJECTCOST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DutiesDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DutiesDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DutiesDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DutiesDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DutiesDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DUTIESDETAIL", dataRow) { }
        protected DutiesDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DUTIESDETAIL", dataRow, isImported) { }
        public DutiesDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DutiesDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DutiesDetail() : base() { }

    }
}