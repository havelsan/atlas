
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutNoDVO")] 

    public  partial class TaahhutNoDVO : BaseMedulaObject
    {
        public class TaahhutNoDVOList : TTObjectCollection<TaahhutNoDVO> { }
                    
        public class ChildTaahhutNoDVOCollection : TTObject.TTChildObjectCollection<TaahhutNoDVO>
        {
            public ChildTaahhutNoDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutNoDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? taahhutNo
        {
            get { return (int?)this["TAAHHUTNO"]; }
            set { this["TAAHHUTNO"] = value; }
        }

        public TaahhutKisiCevapDVO TaahhutKisiCevapDVO
        {
            get { return (TaahhutKisiCevapDVO)((ITTObject)this).GetParent("TAAHHUTKISICEVAPDVO"); }
            set { this["TAAHHUTKISICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaahhutNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutNoDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTNODVO", dataRow) { }
        protected TaahhutNoDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTNODVO", dataRow, isImported) { }
        public TaahhutNoDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutNoDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutNoDVO() : base() { }

    }
}