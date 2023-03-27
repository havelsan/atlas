
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisDVO")] 

    public  partial class TeshisDVO : BaseMedulaObject
    {
        public class TeshisDVOList : TTObjectCollection<TeshisDVO> { }
                    
        public class ChildTeshisDVOCollection : TTObject.TTChildObjectCollection<TeshisDVO>
        {
            public ChildTeshisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string adi
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? kodu
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public TeshisOkuCevapDVO TeshisOkuCevapDVO
        {
            get { return (TeshisOkuCevapDVO)((ITTObject)this).GetParent("TESHISOKUCEVAPDVO"); }
            set { this["TESHISOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMaddeSUTKuraliDVO EtkinMaddeSUTKuraliDVO
        {
            get { return (EtkinMaddeSUTKuraliDVO)((ITTObject)this).GetParent("ETKINMADDESUTKURALIDVO"); }
            set { this["ETKINMADDESUTKURALIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TeshisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISDVO", dataRow) { }
        protected TeshisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISDVO", dataRow, isImported) { }
        public TeshisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisDVO() : base() { }

    }
}