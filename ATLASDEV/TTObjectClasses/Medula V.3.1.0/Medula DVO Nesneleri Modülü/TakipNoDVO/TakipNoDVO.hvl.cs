
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipNoDVO")] 

    public  partial class TakipNoDVO : BaseMedulaObject
    {
        public class TakipNoDVOList : TTObjectCollection<TakipNoDVO> { }
                    
        public class ChildTakipNoDVOCollection : TTObject.TTChildObjectCollection<TakipNoDVO>
        {
            public ChildTakipNoDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipNoDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public OrneklenmisTakiplerCevapDVO OrneklenmisCevapDVO
        {
            get { return (OrneklenmisTakiplerCevapDVO)((ITTObject)this).GetParent("ORNEKLENMISCEVAPDVO"); }
            set { this["ORNEKLENMISCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipNoDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPNODVO", dataRow) { }
        protected TakipNoDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPNODVO", dataRow, isImported) { }
        public TakipNoDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipNoDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipNoDVO() : base() { }

    }
}