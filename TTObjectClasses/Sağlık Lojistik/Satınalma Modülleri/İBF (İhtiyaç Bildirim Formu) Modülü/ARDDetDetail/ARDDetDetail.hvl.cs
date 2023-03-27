
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARDDetDetail")] 

    public  partial class ARDDetDetail : TTObject
    {
        public class ARDDetDetailList : TTObjectCollection<ARDDetDetail> { }
                    
        public class ChildARDDetDetailCollection : TTObject.TTChildObjectCollection<ARDDetDetail>
        {
            public ChildARDDetDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARDDetDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public AnnualRequirementDetail AnnualRequirementDetail
        {
            get { return (AnnualRequirementDetail)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETAIL"); }
            set { this["ANNUALREQUIREMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ARDDetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARDDetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARDDetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARDDetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARDDetDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARDDETDETAIL", dataRow) { }
        protected ARDDetDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARDDETDETAIL", dataRow, isImported) { }
        public ARDDetDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARDDetDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARDDetDetail() : base() { }

    }
}