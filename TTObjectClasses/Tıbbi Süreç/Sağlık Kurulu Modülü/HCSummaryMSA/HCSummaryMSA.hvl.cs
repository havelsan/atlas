
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCSummaryMSA")] 

    public  partial class HCSummaryMSA : TTObject
    {
        public class HCSummaryMSAList : TTObjectCollection<HCSummaryMSA> { }
                    
        public class ChildHCSummaryMSACollection : TTObject.TTChildObjectCollection<HCSummaryMSA>
        {
            public ChildHCSummaryMSACollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCSummaryMSACollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Madde
    /// </summary>
        public int? Matter
        {
            get { return (int?)this["MATTER"]; }
            set { this["MATTER"] = value; }
        }

    /// <summary>
    /// Fıkra
    /// </summary>
        public int? Anectode
        {
            get { return (int?)this["ANECTODE"]; }
            set { this["ANECTODE"] = value; }
        }

    /// <summary>
    /// Dilim
    /// </summary>
        public SliceEnum? Slice
        {
            get { return (SliceEnum?)(int?)this["SLICE"]; }
            set { this["SLICE"] = value; }
        }

        public HCSummary HCSummary
        {
            get { return (HCSummary)((ITTObject)this).GetParent("HCSUMMARY"); }
            set { this["HCSUMMARY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCSummaryMSA(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCSummaryMSA(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCSummaryMSA(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCSummaryMSA(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCSummaryMSA(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCSUMMARYMSA", dataRow) { }
        protected HCSummaryMSA(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCSUMMARYMSA", dataRow, isImported) { }
        public HCSummaryMSA(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCSummaryMSA(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCSummaryMSA() : base() { }

    }
}