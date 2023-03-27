
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresActionDetail")] 

    public  partial class PresActionDetail : TTObject
    {
        public class PresActionDetailList : TTObjectCollection<PresActionDetail> { }
                    
        public class ChildPresActionDetailCollection : TTObject.TTChildObjectCollection<PresActionDetail>
        {
            public ChildPresActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seri Nu
    /// </summary>
        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

    /// <summary>
    /// Cilt Nu
    /// </summary>
        public string VolumeNo
        {
            get { return (string)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

        public CreatePresDetailAction CreatePresDetailAction
        {
            get { return (CreatePresDetailAction)((ITTObject)this).GetParent("CREATEPRESDETAILACTION"); }
            set { this["CREATEPRESDETAILACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PresActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESACTIONDETAIL", dataRow) { }
        protected PresActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESACTIONDETAIL", dataRow, isImported) { }
        public PresActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresActionDetail() : base() { }

    }
}