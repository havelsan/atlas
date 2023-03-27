
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharIzlemNedeni")] 

    /// <summary>
    /// İntihar Girişimi ya da Kriz Nedeni
    /// </summary>
    public  partial class IntiharIzlemNedeni : TTObject
    {
        public class IntiharIzlemNedeniList : TTObjectCollection<IntiharIzlemNedeni> { }
                    
        public class ChildIntiharIzlemNedeniCollection : TTObject.TTChildObjectCollection<IntiharIzlemNedeni>
        {
            public ChildIntiharIzlemNedeniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharIzlemNedeniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public IntiharIzlemVeriSeti IntiharIzlemVeriSeti
        {
            get { return (IntiharIzlemVeriSeti)((ITTObject)this).GetParent("INTIHARIZLEMVERISETI"); }
            set { this["INTIHARIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIntiharGirisimiyadaKrizNedenleri SKRSIntiharGirisimiNedenleri
        {
            get { return (SKRSIntiharGirisimiyadaKrizNedenleri)((ITTObject)this).GetParent("SKRSINTIHARGIRISIMINEDENLERI"); }
            set { this["SKRSINTIHARGIRISIMINEDENLERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharIzlemNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharIzlemNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharIzlemNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharIzlemNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharIzlemNedeni(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARIZLEMNEDENI", dataRow) { }
        protected IntiharIzlemNedeni(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARIZLEMNEDENI", dataRow, isImported) { }
        public IntiharIzlemNedeni(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharIzlemNedeni(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharIzlemNedeni() : base() { }

    }
}