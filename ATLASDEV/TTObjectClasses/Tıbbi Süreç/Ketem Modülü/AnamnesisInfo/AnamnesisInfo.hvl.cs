
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnamnesisInfo")] 

    public  partial class AnamnesisInfo : TTObject
    {
        public class AnamnesisInfoList : TTObjectCollection<AnamnesisInfo> { }
                    
        public class ChildAnamnesisInfoCollection : TTObject.TTChildObjectCollection<AnamnesisInfo>
        {
            public ChildAnamnesisInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnamnesisInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSSigaraKullanimi SKRSSigaraKullanimi
        {
            get { return (SKRSSigaraKullanimi)((ITTObject)this).GetParent("SKRSSIGARAKULLANIMI"); }
            set { this["SKRSSIGARAKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMaddeKullanimi SKRSMaddeKullanimi
        {
            get { return (SKRSMaddeKullanimi)((ITTObject)this).GetParent("SKRSMADDEKULLANIMI"); }
            set { this["SKRSMADDEKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAlkolKullanimi SKRSAlkolKullanimi
        {
            get { return (SKRSAlkolKullanimi)((ITTObject)this).GetParent("SKRSALKOLKULLANIMI"); }
            set { this["SKRSALKOLKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnamnesisInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnamnesisInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnamnesisInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnamnesisInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnamnesisInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANAMNESISINFO", dataRow) { }
        protected AnamnesisInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANAMNESISINFO", dataRow, isImported) { }
        public AnamnesisInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnamnesisInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnamnesisInfo() : base() { }

    }
}