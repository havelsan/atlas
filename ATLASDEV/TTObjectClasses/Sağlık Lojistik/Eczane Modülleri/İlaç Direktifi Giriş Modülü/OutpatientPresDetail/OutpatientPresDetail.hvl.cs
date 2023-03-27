
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OutpatientPresDetail")] 

    public  partial class OutpatientPresDetail : TTObject
    {
        public class OutpatientPresDetailList : TTObjectCollection<OutpatientPresDetail> { }
                    
        public class ChildOutpatientPresDetailCollection : TTObject.TTChildObjectCollection<OutpatientPresDetail>
        {
            public ChildOutpatientPresDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOutpatientPresDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OutPatientPrescription OutPatientPrescription
        {
            get { return (OutPatientPrescription)((ITTObject)this).GetParent("OUTPATIENTPRESCRIPTION"); }
            set { this["OUTPATIENTPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OutpatientPresDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OutpatientPresDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OutpatientPresDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OutpatientPresDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OutpatientPresDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OUTPATIENTPRESDETAIL", dataRow) { }
        protected OutpatientPresDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OUTPATIENTPRESDETAIL", dataRow, isImported) { }
        public OutpatientPresDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OutpatientPresDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OutpatientPresDetail() : base() { }

    }
}