
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRActionConsCancelDetail")] 

    public  partial class CMRActionConsCancelDetail : TTObject
    {
        public class CMRActionConsCancelDetailList : TTObjectCollection<CMRActionConsCancelDetail> { }
                    
        public class ChildCMRActionConsCancelDetailCollection : TTObject.TTChildObjectCollection<CMRActionConsCancelDetail>
        {
            public ChildCMRActionConsCancelDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionConsCancelDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İptal
    /// </summary>
        public bool? DetailCancel
        {
            get { return (bool?)this["DETAILCANCEL"]; }
            set { this["DETAILCANCEL"] = value; }
        }

        public CMRActionConsCancel CMRActionConsCancel
        {
            get { return (CMRActionConsCancel)((ITTObject)this).GetParent("CMRACTIONCONSCANCEL"); }
            set { this["CMRACTIONCONSCANCEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UsedConsumedMaterail UsedConsumedMaterail
        {
            get { return (UsedConsumedMaterail)((ITTObject)this).GetParent("USEDCONSUMEDMATERAIL"); }
            set { this["USEDCONSUMEDMATERAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CMRActionConsCancelDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRActionConsCancelDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRActionConsCancelDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRActionConsCancelDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRActionConsCancelDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTIONCONSCANCELDETAIL", dataRow) { }
        protected CMRActionConsCancelDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTIONCONSCANCELDETAIL", dataRow, isImported) { }
        public CMRActionConsCancelDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRActionConsCancelDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRActionConsCancelDetail() : base() { }

    }
}