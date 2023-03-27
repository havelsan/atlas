
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeOkuGirisDVO")] 

    public  partial class EtkinMaddeOkuGirisDVO : BaseMedulaObject
    {
        public class EtkinMaddeOkuGirisDVOList : TTObjectCollection<EtkinMaddeOkuGirisDVO> { }
                    
        public class ChildEtkinMaddeOkuGirisDVOCollection : TTObject.TTChildObjectCollection<EtkinMaddeOkuGirisDVO>
        {
            public ChildEtkinMaddeOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public EtkinMaddeOkuCevapDVO etkinMaddeOkuCevapDVO
        {
            get { return (EtkinMaddeOkuCevapDVO)((ITTObject)this).GetParent("ETKINMADDEOKUCEVAPDVO"); }
            set { this["ETKINMADDEOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDEOKUGIRISDVO", dataRow) { }
        protected EtkinMaddeOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDEOKUGIRISDVO", dataRow, isImported) { }
        public EtkinMaddeOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeOkuGirisDVO() : base() { }

    }
}