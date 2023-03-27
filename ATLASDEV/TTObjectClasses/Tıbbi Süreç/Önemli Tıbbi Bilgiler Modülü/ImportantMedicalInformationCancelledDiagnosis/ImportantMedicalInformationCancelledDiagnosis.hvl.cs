
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportantMedicalInformationCancelledDiagnosis")] 

    public  partial class ImportantMedicalInformationCancelledDiagnosis : TTObject
    {
        public class ImportantMedicalInformationCancelledDiagnosisList : TTObjectCollection<ImportantMedicalInformationCancelledDiagnosis> { }
                    
        public class ChildImportantMedicalInformationCancelledDiagnosisCollection : TTObject.TTChildObjectCollection<ImportantMedicalInformationCancelledDiagnosis>
        {
            public ChildImportantMedicalInformationCancelledDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportantMedicalInformationCancelledDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İptal Tarihi
    /// </summary>
        public DateTime? CancelledDiagnoseDate
        {
            get { return (DateTime?)this["CANCELLEDDIAGNOSEDATE"]; }
            set { this["CANCELLEDDIAGNOSEDATE"] = value; }
        }

        public ImportantMedicalInformation ImportantMedicalInformation
        {
            get { return (ImportantMedicalInformation)((ITTObject)this).GetParent("IMPORTANTMEDICALINFORMATION"); }
            set { this["IMPORTANTMEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanıyı İptal Eden
    /// </summary>
        public ResUser CancelDiagnoseUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("CANCELDIAGNOSEUSER"); }
            set { this["CANCELDIAGNOSEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition CancelledDiagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("CANCELLEDDIAGNOSE"); }
            set { this["CANCELLEDDIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisGrid CancelledDiagnosisGrid
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("CANCELLEDDIAGNOSISGRID"); }
            set { this["CANCELLEDDIAGNOSISGRID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTANTMEDICALINFORMATIONCANCELLEDDIAGNOSIS", dataRow) { }
        protected ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTANTMEDICALINFORMATIONCANCELLEDDIAGNOSIS", dataRow, isImported) { }
        public ImportantMedicalInformationCancelledDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportantMedicalInformationCancelledDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportantMedicalInformationCancelledDiagnosis() : base() { }

    }
}