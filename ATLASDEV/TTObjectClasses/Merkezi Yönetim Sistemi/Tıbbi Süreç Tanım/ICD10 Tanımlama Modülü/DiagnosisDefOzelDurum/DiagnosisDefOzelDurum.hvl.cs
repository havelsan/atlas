
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisDefOzelDurum")] 

    public  partial class DiagnosisDefOzelDurum : TerminologyManagerDef
    {
        public class DiagnosisDefOzelDurumList : TTObjectCollection<DiagnosisDefOzelDurum> { }
                    
        public class ChildDiagnosisDefOzelDurumCollection : TTObject.TTChildObjectCollection<DiagnosisDefOzelDurum>
        {
            public ChildDiagnosisDefOzelDurumCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisDefOzelDurumCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISDEFOZELDURUM", dataRow) { }
        protected DiagnosisDefOzelDurum(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISDEFOZELDURUM", dataRow, isImported) { }
        public DiagnosisDefOzelDurum(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisDefOzelDurum(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisDefOzelDurum() : base() { }

    }
}