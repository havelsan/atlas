
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ObeziteEkHastalik")] 

    public  partial class ObeziteEkHastalik : TTObject
    {
        public class ObeziteEkHastalikList : TTObjectCollection<ObeziteEkHastalik> { }
                    
        public class ChildObeziteEkHastalikCollection : TTObject.TTChildObjectCollection<ObeziteEkHastalik>
        {
            public ChildObeziteEkHastalikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildObeziteEkHastalikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ObeziteIzlemVeriSeti ObeziteIzlemVeriSeti
        {
            get { return (ObeziteIzlemVeriSeti)((ITTObject)this).GetParent("OBEZITEIZLEMVERISETI"); }
            set { this["OBEZITEIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ObeziteEkHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ObeziteEkHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ObeziteEkHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ObeziteEkHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ObeziteEkHastalik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OBEZITEEKHASTALIK", dataRow) { }
        protected ObeziteEkHastalik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OBEZITEEKHASTALIK", dataRow, isImported) { }
        public ObeziteEkHastalik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ObeziteEkHastalik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ObeziteEkHastalik() : base() { }

    }
}