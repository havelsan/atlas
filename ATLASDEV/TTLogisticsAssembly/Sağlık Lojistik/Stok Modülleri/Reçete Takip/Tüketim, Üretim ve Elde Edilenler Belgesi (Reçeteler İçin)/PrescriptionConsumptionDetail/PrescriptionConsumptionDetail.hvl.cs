
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionConsumptionDetail")] 

    public  partial class PrescriptionConsumptionDetail : TTObject
    {
        public class PrescriptionConsumptionDetailList : TTObjectCollection<PrescriptionConsumptionDetail> { }
                    
        public class ChildPrescriptionConsumptionDetailCollection : TTObject.TTChildObjectCollection<PrescriptionConsumptionDetail>
        {
            public ChildPrescriptionConsumptionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionConsumptionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Reçete No
    /// </summary>
        public string PrescriptionNo
        {
            get { return (string)this["PRESCRIPTIONNO"]; }
            set { this["PRESCRIPTIONNO"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı
    /// </summary>
        public string PatienFullName
        {
            get { return (string)this["PATIENFULLNAME"]; }
            set { this["PATIENFULLNAME"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public int? ActionID
        {
            get { return (int?)this["ACTIONID"]; }
            set { this["ACTIONID"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public string ActionDescription
        {
            get { return (string)this["ACTIONDESCRIPTION"]; }
            set { this["ACTIONDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Doktor Adı Soyadı
    /// </summary>
        public string DocktorFullName
        {
            get { return (string)this["DOCKTORFULLNAME"]; }
            set { this["DOCKTORFULLNAME"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public PrescriptionConsDocMatOut PrescriptionConsumptionDocMat
        {
            get { return (PrescriptionConsDocMatOut)((ITTObject)this).GetParent("PRESCRIPTIONCONSUMPTIONDOCMAT"); }
            set { this["PRESCRIPTIONCONSUMPTIONDOCMAT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PresInfirmaryDocMatOut PresInfirmaryDocMatOut
        {
            get { return (PresInfirmaryDocMatOut)((ITTObject)this).GetParent("PRESINFIRMARYDOCMATOUT"); }
            set { this["PRESINFIRMARYDOCMATOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONCONSUMPTIONDETAIL", dataRow) { }
        protected PrescriptionConsumptionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONCONSUMPTIONDETAIL", dataRow, isImported) { }
        public PrescriptionConsumptionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionConsumptionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionConsumptionDetail() : base() { }

    }
}