
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharIzlemVakaSonucu")] 

    public  partial class IntiharIzlemVakaSonucu : TTObject
    {
        public class IntiharIzlemVakaSonucuList : TTObjectCollection<IntiharIzlemVakaSonucu> { }
                    
        public class ChildIntiharIzlemVakaSonucuCollection : TTObject.TTChildObjectCollection<IntiharIzlemVakaSonucu>
        {
            public ChildIntiharIzlemVakaSonucuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharIzlemVakaSonucuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public IntiharIzlemVeriSeti IntiharIzlemVeriSeti
        {
            get { return (IntiharIzlemVeriSeti)((ITTObject)this).GetParent("INTIHARIZLEMVERISETI"); }
            set { this["INTIHARIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIntiharKrizVakaSonucu SKRSIntiharKrizVakaSonucu
        {
            get { return (SKRSIntiharKrizVakaSonucu)((ITTObject)this).GetParent("SKRSINTIHARKRIZVAKASONUCU"); }
            set { this["SKRSINTIHARKRIZVAKASONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARIZLEMVAKASONUCU", dataRow) { }
        protected IntiharIzlemVakaSonucu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARIZLEMVAKASONUCU", dataRow, isImported) { }
        public IntiharIzlemVakaSonucu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharIzlemVakaSonucu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharIzlemVakaSonucu() : base() { }

    }
}