
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaNakilTanilar")] 

    public  partial class HastaNakilTanilar : TTObject
    {
        public class HastaNakilTanilarList : TTObjectCollection<HastaNakilTanilar> { }
                    
        public class ChildHastaNakilTanilarCollection : TTObject.TTChildObjectCollection<HastaNakilTanilar>
        {
            public ChildHastaNakilTanilarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaNakilTanilarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HastaNakilFormu HastaNakilFormu
        {
            get { return (HastaNakilFormu)((ITTObject)this).GetParent("HASTANAKILFORMU"); }
            set { this["HASTANAKILFORMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaNakilTanilar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaNakilTanilar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaNakilTanilar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaNakilTanilar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaNakilTanilar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTANAKILTANILAR", dataRow) { }
        protected HastaNakilTanilar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTANAKILTANILAR", dataRow, isImported) { }
        public HastaNakilTanilar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaNakilTanilar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaNakilTanilar() : base() { }

    }
}