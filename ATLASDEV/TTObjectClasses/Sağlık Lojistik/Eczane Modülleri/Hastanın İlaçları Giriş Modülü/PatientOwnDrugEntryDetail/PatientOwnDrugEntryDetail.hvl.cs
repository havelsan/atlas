
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugEntryDetail")] 

    public  partial class PatientOwnDrugEntryDetail : TTObject
    {
        public class PatientOwnDrugEntryDetailList : TTObjectCollection<PatientOwnDrugEntryDetail> { }
                    
        public class ChildPatientOwnDrugEntryDetailCollection : TTObject.TTChildObjectCollection<PatientOwnDrugEntryDetail>
        {
            public ChildPatientOwnDrugEntryDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugEntryDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? SendAmount
        {
            get { return (double?)this["SENDAMOUNT"]; }
            set { this["SENDAMOUNT"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// BarkodMiktar
    /// </summary>
        public double? BarcodeAmount
        {
            get { return (double?)this["BARCODEAMOUNT"]; }
            set { this["BARCODEAMOUNT"] = value; }
        }

        public OwnDrugStatus? Status
        {
            get { return (OwnDrugStatus?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// İlaç
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientOwnDrugEntry PatientOwnDrugEntry
        {
            get { return (PatientOwnDrugEntry)((ITTObject)this).GetParent("PATIENTOWNDRUGENTRY"); }
            set { this["PATIENTOWNDRUGENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGENTRYDETAIL", dataRow) { }
        protected PatientOwnDrugEntryDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGENTRYDETAIL", dataRow, isImported) { }
        public PatientOwnDrugEntryDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugEntryDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugEntryDetail() : base() { }

    }
}