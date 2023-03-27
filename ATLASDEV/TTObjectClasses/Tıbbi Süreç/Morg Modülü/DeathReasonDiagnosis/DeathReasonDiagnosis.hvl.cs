
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeathReasonDiagnosis")] 

    /// <summary>
    /// Ölüm Nedeni Bilgisini Tutan Nesne
    /// </summary>
    public  partial class DeathReasonDiagnosis : TTObject
    {
        public class DeathReasonDiagnosisList : TTObjectCollection<DeathReasonDiagnosis> { }
                    
        public class ChildDeathReasonDiagnosisCollection : TTObject.TTChildObjectCollection<DeathReasonDiagnosis>
        {
            public ChildDeathReasonDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeathReasonDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSOlumNedeniTuru SKRSOlumNedeniTuru
        {
            get { return (SKRSOlumNedeniTuru)((ITTObject)this).GetParent("SKRSOLUMNEDENITURU"); }
            set { this["SKRSOLUMNEDENITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Morgue Morgue
        {
            get { return (Morgue)((ITTObject)this).GetParent("MORGUE"); }
            set { this["MORGUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DeathReasonDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeathReasonDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeathReasonDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeathReasonDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeathReasonDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEATHREASONDIAGNOSIS", dataRow) { }
        protected DeathReasonDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEATHREASONDIAGNOSIS", dataRow, isImported) { }
        public DeathReasonDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeathReasonDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeathReasonDiagnosis() : base() { }

    }
}