
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInvoiceDocumentGroup")] 

    /// <summary>
    /// Hasta Faturası Döküman Grubu
    /// </summary>
    public  partial class PatientInvoiceDocumentGroup : AccountDocumentGroup
    {
        public class PatientInvoiceDocumentGroupList : TTObjectCollection<PatientInvoiceDocumentGroup> { }
                    
        public class ChildPatientInvoiceDocumentGroupCollection : TTObject.TTChildObjectCollection<PatientInvoiceDocumentGroup>
        {
            public ChildPatientInvoiceDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInvoiceDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINVOICEDOCUMENTGROUP", dataRow) { }
        protected PatientInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINVOICEDOCUMENTGROUP", dataRow, isImported) { }
        public PatientInvoiceDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInvoiceDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInvoiceDocumentGroup() : base() { }

    }
}