
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TutunKullanimiTedaviSekli")] 

    public  partial class TutunKullanimiTedaviSekli : TTObject
    {
        public class TutunKullanimiTedaviSekliList : TTObjectCollection<TutunKullanimiTedaviSekli> { }
                    
        public class ChildTutunKullanimiTedaviSekliCollection : TTObject.TTChildObjectCollection<TutunKullanimiTedaviSekli>
        {
            public ChildTutunKullanimiTedaviSekliCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTutunKullanimiTedaviSekliCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public TutunKullanimiVeriSeti TutunKullanimiVeriSeti
        {
            get { return (TutunKullanimiVeriSeti)((ITTObject)this).GetParent("TUTUNKULLANIMIVERISETI"); }
            set { this["TUTUNKULLANIMIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTedaviSekli SKRSTedaviSekli
        {
            get { return (SKRSTedaviSekli)((ITTObject)this).GetParent("SKRSTEDAVISEKLI"); }
            set { this["SKRSTEDAVISEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TUTUNKULLANIMITEDAVISEKLI", dataRow) { }
        protected TutunKullanimiTedaviSekli(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TUTUNKULLANIMITEDAVISEKLI", dataRow, isImported) { }
        public TutunKullanimiTedaviSekli(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TutunKullanimiTedaviSekli(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TutunKullanimiTedaviSekli() : base() { }

    }
}