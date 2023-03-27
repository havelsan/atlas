
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientPresDetail")] 

    public  partial class InpatientPresDetail : TTObject
    {
        public class InpatientPresDetailList : TTObjectCollection<InpatientPresDetail> { }
                    
        public class ChildInpatientPresDetailCollection : TTObject.TTChildObjectCollection<InpatientPresDetail>
        {
            public ChildInpatientPresDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientPresDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InpatientPrescription InpatientPrescription
        {
            get { return (InpatientPrescription)((ITTObject)this).GetParent("INPATIENTPRESCRIPTION"); }
            set { this["INPATIENTPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientPresDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientPresDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientPresDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientPresDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientPresDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTPRESDETAIL", dataRow) { }
        protected InpatientPresDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTPRESDETAIL", dataRow, isImported) { }
        public InpatientPresDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientPresDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientPresDetail() : base() { }

    }
}