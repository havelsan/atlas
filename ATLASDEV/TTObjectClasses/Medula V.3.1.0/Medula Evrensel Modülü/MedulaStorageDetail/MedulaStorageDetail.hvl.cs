
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaStorageDetail")] 

    /// <summary>
    /// Medula Depolama Birimi Detayları
    /// </summary>
    public  partial class MedulaStorageDetail : TTObject
    {
        public class MedulaStorageDetailList : TTObjectCollection<MedulaStorageDetail> { }
                    
        public class ChildMedulaStorageDetailCollection : TTObject.TTChildObjectCollection<MedulaStorageDetail>
        {
            public ChildMedulaStorageDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaStorageDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Medula Depolama Birimi-Medula Depolama Birimi Detayları
    /// </summary>
        public MedulaStorage MedulaStorage
        {
            get { return (MedulaStorage)((ITTObject)this).GetParent("MEDULASTORAGE"); }
            set { this["MEDULASTORAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Süreci
    /// </summary>
        public BaseMedulaWLAction BaseMedulaWLAction
        {
            get { return (BaseMedulaWLAction)((ITTObject)this).GetParent("BASEMEDULAWLACTION"); }
            set { this["BASEMEDULAWLACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaStorageDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaStorageDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaStorageDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaStorageDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaStorageDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASTORAGEDETAIL", dataRow) { }
        protected MedulaStorageDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASTORAGEDETAIL", dataRow, isImported) { }
        public MedulaStorageDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaStorageDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaStorageDetail() : base() { }

    }
}