
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HPVTypeInfo")] 

    /// <summary>
    /// HPV Tipi Bilgisi
    /// </summary>
    public  partial class HPVTypeInfo : TTObject
    {
        public class HPVTypeInfoList : TTObjectCollection<HPVTypeInfo> { }
                    
        public class ChildHPVTypeInfoCollection : TTObject.TTChildObjectCollection<HPVTypeInfo>
        {
            public ChildHPVTypeInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHPVTypeInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSHpvTipi SKRSHpvTipi
        {
            get { return (SKRSHpvTipi)((ITTObject)this).GetParent("SKRSHPVTIPI"); }
            set { this["SKRSHPVTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HPVTypeInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HPVTypeInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HPVTypeInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HPVTypeInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HPVTypeInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HPVTYPEINFO", dataRow) { }
        protected HPVTypeInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HPVTYPEINFO", dataRow, isImported) { }
        public HPVTypeInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HPVTypeInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HPVTypeInfo() : base() { }

    }
}