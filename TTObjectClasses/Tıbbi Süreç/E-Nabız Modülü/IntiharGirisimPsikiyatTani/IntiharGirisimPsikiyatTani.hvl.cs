
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharGirisimPsikiyatTani")] 

    public  partial class IntiharGirisimPsikiyatTani : TTObject
    {
        public class IntiharGirisimPsikiyatTaniList : TTObjectCollection<IntiharGirisimPsikiyatTani> { }
                    
        public class ChildIntiharGirisimPsikiyatTaniCollection : TTObject.TTChildObjectCollection<IntiharGirisimPsikiyatTani>
        {
            public ChildIntiharGirisimPsikiyatTaniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharGirisimPsikiyatTaniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSICD PsikiyatrikTaniGecmisi
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("PSIKIYATRIKTANIGECMISI"); }
            set { this["PSIKIYATRIKTANIGECMISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntiharGirisimKrizVeriSeti IntiharGirisimKrizVeriSeti
        {
            get { return (IntiharGirisimKrizVeriSeti)((ITTObject)this).GetParent("INTIHARGIRISIMKRIZVERISETI"); }
            set { this["INTIHARGIRISIMKRIZVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARGIRISIMPSIKIYATTANI", dataRow) { }
        protected IntiharGirisimPsikiyatTani(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARGIRISIMPSIKIYATTANI", dataRow, isImported) { }
        public IntiharGirisimPsikiyatTani(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharGirisimPsikiyatTani(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharGirisimPsikiyatTani() : base() { }

    }
}