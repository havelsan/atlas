
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MalzemeBilgisi_RaporDVO")] 

    public  partial class MalzemeBilgisi_RaporDVO : BaseMedulaObject
    {
        public class MalzemeBilgisi_RaporDVOList : TTObjectCollection<MalzemeBilgisi_RaporDVO> { }
                    
        public class ChildMalzemeBilgisi_RaporDVOCollection : TTObject.TTChildObjectCollection<MalzemeBilgisi_RaporDVO>
        {
            public ChildMalzemeBilgisi_RaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMalzemeBilgisi_RaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string malzemeKodu
        {
            get { return (string)this["MALZEMEKODU"]; }
            set { this["MALZEMEKODU"] = value; }
        }

        public string malzemeAdi
        {
            get { return (string)this["MALZEMEADI"]; }
            set { this["MALZEMEADI"] = value; }
        }

        public string malzemeTuru
        {
            get { return (string)this["MALZEMETURU"]; }
            set { this["MALZEMETURU"] = value; }
        }

        public int? adet
        {
            get { return (int?)this["ADET"]; }
            set { this["ADET"] = value; }
        }

        public ProtezRaporDVO ProtezRaporDVO
        {
            get { return (ProtezRaporDVO)((ITTObject)this).GetParent("PROTEZRAPORDVO"); }
            set { this["PROTEZRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MALZEMEBILGISI_RAPORDVO", dataRow) { }
        protected MalzemeBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MALZEMEBILGISI_RAPORDVO", dataRow, isImported) { }
        public MalzemeBilgisi_RaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MalzemeBilgisi_RaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MalzemeBilgisi_RaporDVO() : base() { }

    }
}