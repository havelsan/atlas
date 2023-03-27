
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionDetail")] 

    /// <summary>
    /// Dağıtılacak Reçeteler Sekmesi
    /// </summary>
    public  partial class PrescriptionDetail : TTObject
    {
        public class PrescriptionDetailList : TTObjectCollection<PrescriptionDetail> { }
                    
        public class ChildPrescriptionDetailCollection : TTObject.TTChildObjectCollection<PrescriptionDetail>
        {
            public ChildPrescriptionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Ücret
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Guid
    /// </summary>
        public string PrescriptionGuid
        {
            get { return (string)this["PRESCRIPTIONGUID"]; }
            set { this["PRESCRIPTIONGUID"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public long? ProtocolNo
        {
            get { return (long?)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Dağıt
    /// </summary>
        public bool? Distribute
        {
            get { return (bool?)this["DISTRIBUTE"]; }
            set { this["DISTRIBUTE"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Unite
    /// </summary>
        public string Resource
        {
            get { return (string)this["RESOURCE"]; }
            set { this["RESOURCE"] = value; }
        }

    /// <summary>
    /// Karantina No
    /// </summary>
        public long? QuarantineNo
        {
            get { return (long?)this["QUARANTINENO"]; }
            set { this["QUARANTINENO"] = value; }
        }

    /// <summary>
    /// Hastanın Birliği
    /// </summary>
        public string PatientMilitaryUnit
        {
            get { return (string)this["PATIENTMILITARYUNIT"]; }
            set { this["PATIENTMILITARYUNIT"] = value; }
        }

    /// <summary>
    /// Reçete Türü
    /// </summary>
        public string PrescriptionType
        {
            get { return (string)this["PRESCRIPTIONTYPE"]; }
            set { this["PRESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Dağıtım Numarası
    /// </summary>
        public string DistributionNo
        {
            get { return (string)this["DISTRIBUTIONNO"]; }
            set { this["DISTRIBUTIONNO"] = value; }
        }

        public PrescriptionDistribute PrescriptionDistribute
        {
            get { return (PrescriptionDistribute)((ITTObject)this).GetParent("PRESCRIPTIONDISTRIBUTE"); }
            set { this["PRESCRIPTIONDISTRIBUTE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PrescriptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONDETAIL", dataRow) { }
        protected PrescriptionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONDETAIL", dataRow, isImported) { }
        public PrescriptionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionDetail() : base() { }

    }
}