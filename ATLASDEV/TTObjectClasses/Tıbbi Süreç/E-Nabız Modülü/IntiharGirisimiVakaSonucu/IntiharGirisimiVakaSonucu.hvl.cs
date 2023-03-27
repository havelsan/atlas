
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharGirisimiVakaSonucu")] 

    public  partial class IntiharGirisimiVakaSonucu : TTObject
    {
        public class IntiharGirisimiVakaSonucuList : TTObjectCollection<IntiharGirisimiVakaSonucu> { }
                    
        public class ChildIntiharGirisimiVakaSonucuCollection : TTObject.TTChildObjectCollection<IntiharGirisimiVakaSonucu>
        {
            public ChildIntiharGirisimiVakaSonucuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharGirisimiVakaSonucuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSIntiharKrizVakaSonucu SKRSIntiharKrizVakaSonucu
        {
            get { return (SKRSIntiharKrizVakaSonucu)((ITTObject)this).GetParent("SKRSINTIHARKRIZVAKASONUCU"); }
            set { this["SKRSINTIHARKRIZVAKASONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntiharGirisimKrizVeriSeti IntiharGirisimKrizVeriSeti
        {
            get { return (IntiharGirisimKrizVeriSeti)((ITTObject)this).GetParent("INTIHARGIRISIMKRIZVERISETI"); }
            set { this["INTIHARGIRISIMKRIZVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARGIRISIMIVAKASONUCU", dataRow) { }
        protected IntiharGirisimiVakaSonucu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARGIRISIMIVAKASONUCU", dataRow, isImported) { }
        public IntiharGirisimiVakaSonucu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharGirisimiVakaSonucu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharGirisimiVakaSonucu() : base() { }

    }
}