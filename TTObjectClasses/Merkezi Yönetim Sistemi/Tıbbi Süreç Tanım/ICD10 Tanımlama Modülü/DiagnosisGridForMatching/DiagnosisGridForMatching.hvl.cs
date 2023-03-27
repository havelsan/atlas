
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisGridForMatching")] 

    public  partial class DiagnosisGridForMatching : TerminologyManagerDef
    {
        public class DiagnosisGridForMatchingList : TTObjectCollection<DiagnosisGridForMatching> { }
                    
        public class ChildDiagnosisGridForMatchingCollection : TTObject.TTChildObjectCollection<DiagnosisGridForMatching>
        {
            public ChildDiagnosisGridForMatchingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisGridForMatchingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnoseSpecialityMatching DiagnoseSpecialityMatching
        {
            get { return (DiagnoseSpecialityMatching)((ITTObject)this).GetParent("DIAGNOSESPECIALITYMATCHING"); }
            set { this["DIAGNOSESPECIALITYMATCHING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisGridForMatching(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisGridForMatching(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisGridForMatching(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisGridForMatching(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisGridForMatching(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISGRIDFORMATCHING", dataRow) { }
        protected DiagnosisGridForMatching(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISGRIDFORMATCHING", dataRow, isImported) { }
        public DiagnosisGridForMatching(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisGridForMatching(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisGridForMatching() : base() { }

    }
}