
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneGirisReferansNo")] 

    public  partial class MuayeneGirisReferansNo : TTObject
    {
        public class MuayeneGirisReferansNoList : TTObjectCollection<MuayeneGirisReferansNo> { }
                    
        public class ChildMuayeneGirisReferansNoCollection : TTObject.TTChildObjectCollection<MuayeneGirisReferansNo>
        {
            public ChildMuayeneGirisReferansNoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneGirisReferansNoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public TTSequence referansNoSEQ
        {
            get { return GetSequence("REFERANSNOSEQ"); }
        }

        public int? saglikTesisiKodu
        {
            get { return (int?)this["SAGLIKTESISIKODU"]; }
            set { this["SAGLIKTESISIKODU"] = value; }
        }

        protected MuayeneGirisReferansNo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEGIRISREFERANSNO", dataRow) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEGIRISREFERANSNO", dataRow, isImported) { }
        protected MuayeneGirisReferansNo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneGirisReferansNo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneGirisReferansNo() : base() { }

    }
}