
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AudiologyDiagnosis")] 

    public  partial class AudiologyDiagnosis : TTObject
    {
        public class AudiologyDiagnosisList : TTObjectCollection<AudiologyDiagnosis> { }
                    
        public class ChildAudiologyDiagnosisCollection : TTObject.TTChildObjectCollection<AudiologyDiagnosis>
        {
            public ChildAudiologyDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAudiologyDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public AudiologyObject AudiologyObject
        {
            get { return (AudiologyObject)((ITTObject)this).GetParent("AUDIOLOGYOBJECT"); }
            set { this["AUDIOLOGYOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AudiologyDiagnosisDef AudiologyDiagnosisDef
        {
            get { return (AudiologyDiagnosisDef)((ITTObject)this).GetParent("AUDIOLOGYDIAGNOSISDEF"); }
            set { this["AUDIOLOGYDIAGNOSISDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AudiologyDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AudiologyDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AudiologyDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AudiologyDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AudiologyDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AUDIOLOGYDIAGNOSIS", dataRow) { }
        protected AudiologyDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AUDIOLOGYDIAGNOSIS", dataRow, isImported) { }
        public AudiologyDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AudiologyDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AudiologyDiagnosis() : base() { }

    }
}