
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METUnit")] 

    /// <summary>
    /// Birim
    /// </summary>
    public  partial class METUnit : METTargetc
    {
        public class METUnitList : TTObjectCollection<METUnit> { }
                    
        public class ChildMETUnitCollection : TTObject.TTChildObjectCollection<METUnit>
        {
            public ChildMETUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// TmkID
    /// </summary>
        public string TmkID
        {
            get { return (string)this["TMKID"]; }
            set { this["TMKID"] = value; }
        }

        protected METUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METUNIT", dataRow) { }
        protected METUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METUNIT", dataRow, isImported) { }
        public METUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METUnit() : base() { }

    }
}