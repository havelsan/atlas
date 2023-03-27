
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharGirisimiKrizNedeni")] 

    public  partial class IntiharGirisimiKrizNedeni : TTObject
    {
        public class IntiharGirisimiKrizNedeniList : TTObjectCollection<IntiharGirisimiKrizNedeni> { }
                    
        public class ChildIntiharGirisimiKrizNedeniCollection : TTObject.TTChildObjectCollection<IntiharGirisimiKrizNedeni>
        {
            public ChildIntiharGirisimiKrizNedeniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharGirisimiKrizNedeniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSIntiharGirisimiyadaKrizNedenleri SKRSIntiharGirisimKrizNeden
        {
            get { return (SKRSIntiharGirisimiyadaKrizNedenleri)((ITTObject)this).GetParent("SKRSINTIHARGIRISIMKRIZNEDEN"); }
            set { this["SKRSINTIHARGIRISIMKRIZNEDEN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntiharGirisimKrizVeriSeti IntiharGirisimKrizVeriSeti
        {
            get { return (IntiharGirisimKrizVeriSeti)((ITTObject)this).GetParent("INTIHARGIRISIMKRIZVERISETI"); }
            set { this["INTIHARGIRISIMKRIZVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARGIRISIMIKRIZNEDENI", dataRow) { }
        protected IntiharGirisimiKrizNedeni(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARGIRISIMIKRIZNEDENI", dataRow, isImported) { }
        public IntiharGirisimiKrizNedeni(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharGirisimiKrizNedeni(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharGirisimiKrizNedeni() : base() { }

    }
}