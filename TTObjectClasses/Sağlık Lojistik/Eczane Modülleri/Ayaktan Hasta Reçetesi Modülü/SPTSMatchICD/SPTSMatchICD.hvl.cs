
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SPTSMatchICD")] 

    /// <summary>
    /// SPTS ile ICD Tanıları Eşleştirmesi
    /// </summary>
    public  partial class SPTSMatchICD : TTObject
    {
        public class SPTSMatchICDList : TTObjectCollection<SPTSMatchICD> { }
                    
        public class ChildSPTSMatchICDCollection : TTObject.TTChildObjectCollection<SPTSMatchICD>
        {
            public ChildSPTSMatchICDCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSPTSMatchICDCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SPTSDiagnosisInfo SPTSDiagnosisInfo
        {
            get { return (SPTSDiagnosisInfo)((ITTObject)this).GetParent("SPTSDIAGNOSISINFO"); }
            set { this["SPTSDIAGNOSISINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SPTSMatchICD(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SPTSMatchICD(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SPTSMatchICD(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SPTSMatchICD(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SPTSMatchICD(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPTSMATCHICD", dataRow) { }
        protected SPTSMatchICD(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPTSMATCHICD", dataRow, isImported) { }
        public SPTSMatchICD(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SPTSMatchICD(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SPTSMatchICD() : base() { }

    }
}