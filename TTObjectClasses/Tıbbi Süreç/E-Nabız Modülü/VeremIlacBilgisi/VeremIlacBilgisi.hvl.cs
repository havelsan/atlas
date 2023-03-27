
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VeremIlacBilgisi")] 

    public  partial class VeremIlacBilgisi : TTObject
    {
        public class VeremIlacBilgisiList : TTObjectCollection<VeremIlacBilgisi> { }
                    
        public class ChildVeremIlacBilgisiCollection : TTObject.TTChildObjectCollection<VeremIlacBilgisi>
        {
            public ChildVeremIlacBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVeremIlacBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSIlacAdiVerem SKRSIlacAdiVerem
        {
            get { return (SKRSIlacAdiVerem)((ITTObject)this).GetParent("SKRSILACADIVEREM"); }
            set { this["SKRSILACADIVEREM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlacDirenciVerem SKRSIlacDirenciVerem
        {
            get { return (SKRSIlacDirenciVerem)((ITTObject)this).GetParent("SKRSILACDIRENCIVEREM"); }
            set { this["SKRSILACDIRENCIVEREM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VeremVeriSeti VeremVeriSeti
        {
            get { return (VeremVeriSeti)((ITTObject)this).GetParent("VEREMVERISETI"); }
            set { this["VEREMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VeremIlacBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VeremIlacBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VeremIlacBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VeremIlacBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VeremIlacBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEREMILACBILGISI", dataRow) { }
        protected VeremIlacBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEREMILACBILGISI", dataRow, isImported) { }
        public VeremIlacBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VeremIlacBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VeremIlacBilgisi() : base() { }

    }
}