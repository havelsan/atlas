
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TutunKullanimiTedaviSonucu")] 

    public  partial class TutunKullanimiTedaviSonucu : TTObject
    {
        public class TutunKullanimiTedaviSonucuList : TTObjectCollection<TutunKullanimiTedaviSonucu> { }
                    
        public class ChildTutunKullanimiTedaviSonucuCollection : TTObject.TTChildObjectCollection<TutunKullanimiTedaviSonucu>
        {
            public ChildTutunKullanimiTedaviSonucuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTutunKullanimiTedaviSonucuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSTutunTedaviSonucu SKRSTutunTedaviSonucu
        {
            get { return (SKRSTutunTedaviSonucu)((ITTObject)this).GetParent("SKRSTUTUNTEDAVISONUCU"); }
            set { this["SKRSTUTUNTEDAVISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TutunKullanimiVeriSeti TutunKullanimiVeriSeti
        {
            get { return (TutunKullanimiVeriSeti)((ITTObject)this).GetParent("TUTUNKULLANIMIVERISETI"); }
            set { this["TUTUNKULLANIMIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TUTUNKULLANIMITEDAVISONUCU", dataRow) { }
        protected TutunKullanimiTedaviSonucu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TUTUNKULLANIMITEDAVISONUCU", dataRow, isImported) { }
        public TutunKullanimiTedaviSonucu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TutunKullanimiTedaviSonucu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TutunKullanimiTedaviSonucu() : base() { }

    }
}