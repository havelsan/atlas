
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmacyDetail")] 

    /// <summary>
    /// Dağıtım Yapılacak Eczaneler Sekmesi
    /// </summary>
    public  partial class PharmacyDetail : TTObject
    {
        public class PharmacyDetailList : TTObjectCollection<PharmacyDetail> { }
                    
        public class ChildPharmacyDetailCollection : TTObject.TTChildObjectCollection<PharmacyDetail>
        {
            public ChildPharmacyDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmacyDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Guid
    /// </summary>
        public string PharmacyGuid
        {
            get { return (string)this["PHARMACYGUID"]; }
            set { this["PHARMACYGUID"] = value; }
        }

    /// <summary>
    /// Avaraj
    /// </summary>
        public double? Balance
        {
            get { return (double?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// Eczane
    /// </summary>
        public string Pharmacy
        {
            get { return (string)this["PHARMACY"]; }
            set { this["PHARMACY"] = value; }
        }

    /// <summary>
    /// Reçete Miktarı
    /// </summary>
        public double? PrescriptionCount
        {
            get { return (double?)this["PRESCRIPTIONCOUNT"]; }
            set { this["PRESCRIPTIONCOUNT"] = value; }
        }

        public PrescriptionDistribute PrescriptionDistribute
        {
            get { return (PrescriptionDistribute)((ITTObject)this).GetParent("PRESCRIPTIONDISTRIBUTE"); }
            set { this["PRESCRIPTIONDISTRIBUTE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PharmacyDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmacyDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmacyDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmacyDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmacyDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACYDETAIL", dataRow) { }
        protected PharmacyDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACYDETAIL", dataRow, isImported) { }
        public PharmacyDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmacyDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmacyDetail() : base() { }

    }
}