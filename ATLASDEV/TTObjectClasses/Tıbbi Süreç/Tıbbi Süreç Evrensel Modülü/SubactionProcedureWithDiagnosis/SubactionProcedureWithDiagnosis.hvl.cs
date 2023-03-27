
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubactionProcedureWithDiagnosis")] 

    public  partial class SubactionProcedureWithDiagnosis : SubactionProcedureFlowable
    {
        public class SubactionProcedureWithDiagnosisList : TTObjectCollection<SubactionProcedureWithDiagnosis> { }
                    
        public class ChildSubactionProcedureWithDiagnosisCollection : TTObject.TTChildObjectCollection<SubactionProcedureWithDiagnosis>
        {
            public ChildSubactionProcedureWithDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubactionProcedureWithDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("e2db3184-0b2f-4ec5-8c8e-352fc7b3404c"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected DiagnosisGrid.ChildDiagnosisGridCollection _Diagnosis = null;
        public DiagnosisGrid.ChildDiagnosisGridCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONPROCEDUREWITHDIAGNOSIS", dataRow) { }
        protected SubactionProcedureWithDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONPROCEDUREWITHDIAGNOSIS", dataRow, isImported) { }
        public SubactionProcedureWithDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubactionProcedureWithDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubactionProcedureWithDiagnosis() : base() { }

    }
}