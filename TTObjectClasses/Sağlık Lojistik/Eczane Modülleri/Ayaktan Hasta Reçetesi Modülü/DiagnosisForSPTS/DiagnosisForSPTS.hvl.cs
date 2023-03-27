
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisForSPTS")] 

    /// <summary>
    /// SPTS Tanıları Sekmesi
    /// </summary>
    public  partial class DiagnosisForSPTS : TTObject
    {
        public class DiagnosisForSPTSList : TTObjectCollection<DiagnosisForSPTS> { }
                    
        public class ChildDiagnosisForSPTSCollection : TTObject.TTChildObjectCollection<DiagnosisForSPTS>
        {
            public ChildDiagnosisForSPTSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisForSPTSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SPTSDiagnosisInfo SPTSDiagnosisInfo
        {
            get { return (SPTSDiagnosisInfo)((ITTObject)this).GetParent("SPTSDIAGNOSISINFO"); }
            set { this["SPTSDIAGNOSISINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisForSPTS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisForSPTS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisForSPTS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisForSPTS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisForSPTS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISFORSPTS", dataRow) { }
        protected DiagnosisForSPTS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISFORSPTS", dataRow, isImported) { }
        public DiagnosisForSPTS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisForSPTS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisForSPTS() : base() { }

    }
}