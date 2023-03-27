
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ComplicationDiagnosis")] 

    /// <summary>
    /// Lohusa İzlem Komplikasyon Tanı Bilgisi
    /// </summary>
    public  partial class ComplicationDiagnosis : TTObject
    {
        public class ComplicationDiagnosisList : TTObjectCollection<ComplicationDiagnosis> { }
                    
        public class ChildComplicationDiagnosisCollection : TTObject.TTChildObjectCollection<ComplicationDiagnosis>
        {
            public ChildComplicationDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildComplicationDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSICD SKRSICD10
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD10"); }
            set { this["SKRSICD10"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PostpartumFollowUp PostpartumFollowUp
        {
            get { return (PostpartumFollowUp)((ITTObject)this).GetParent("POSTPARTUMFOLLOWUP"); }
            set { this["POSTPARTUMFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ComplicationDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ComplicationDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ComplicationDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ComplicationDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ComplicationDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPLICATIONDIAGNOSIS", dataRow) { }
        protected ComplicationDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPLICATIONDIAGNOSIS", dataRow, isImported) { }
        public ComplicationDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ComplicationDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ComplicationDiagnosis() : base() { }

    }
}