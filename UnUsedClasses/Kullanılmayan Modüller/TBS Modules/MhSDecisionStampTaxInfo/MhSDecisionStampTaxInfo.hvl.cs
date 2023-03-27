
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSDecisionStampTaxInfo")] 

    /// <summary>
    /// Karar Pulu Vergi Bilgileri
    /// </summary>
    public  partial class MhSDecisionStampTaxInfo : TTObject
    {
        public class MhSDecisionStampTaxInfoList : TTObjectCollection<MhSDecisionStampTaxInfo> { }
                    
        public class ChildMhSDecisionStampTaxInfoCollection : TTObject.TTChildObjectCollection<MhSDecisionStampTaxInfo>
        {
            public ChildMhSDecisionStampTaxInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSDecisionStampTaxInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fiş/Yazının Tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Seri, Sıra No
    /// </summary>
        public string OrderNo
        {
            get { return (string)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Toplam Miktar
    /// </summary>
        public double? TotalAmount
        {
            get { return (double?)this["TOTALAMOUNT"]; }
            set { this["TOTALAMOUNT"] = value; }
        }

    /// <summary>
    /// Vergi Numarası
    /// </summary>
        public string TaxNumber
        {
            get { return (string)this["TAXNUMBER"]; }
            set { this["TAXNUMBER"] = value; }
        }

    /// <summary>
    /// Vergi Dairesi
    /// </summary>
        public string TaxDepartment
        {
            get { return (string)this["TAXDEPARTMENT"]; }
            set { this["TAXDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Teslim Ettiren
    /// </summary>
        public string Reciever
        {
            get { return (string)this["RECIEVER"]; }
            set { this["RECIEVER"] = value; }
        }

    /// <summary>
    /// İhale Bedeli
    /// </summary>
        public double? TenderPrice
        {
            get { return (double?)this["TENDERPRICE"]; }
            set { this["TENDERPRICE"] = value; }
        }

    /// <summary>
    /// Teslim Eden Ad Soyad
    /// </summary>
        public string DelivererNameSurname
        {
            get { return (string)this["DELIVERERNAMESURNAME"]; }
            set { this["DELIVERERNAMESURNAME"] = value; }
        }

    /// <summary>
    /// Özel No
    /// </summary>
        public int? PrivateNo
        {
            get { return (int?)this["PRIVATENO"]; }
            set { this["PRIVATENO"] = value; }
        }

    /// <summary>
    /// Adresi
    /// </summary>
        public string DelivererAddress
        {
            get { return (string)this["DELIVERERADDRESS"]; }
            set { this["DELIVERERADDRESS"] = value; }
        }

    /// <summary>
    /// Karar Pulu İşlem Türü
    /// </summary>
        public MhSDecisionStampOperationTypeDefinition OperationType
        {
            get { return (MhSDecisionStampOperationTypeDefinition)((ITTObject)this).GetParent("OPERATIONTYPE"); }
            set { this["OPERATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSDECISIONSTAMPTAXINFO", dataRow) { }
        protected MhSDecisionStampTaxInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSDECISIONSTAMPTAXINFO", dataRow, isImported) { }
        public MhSDecisionStampTaxInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSDecisionStampTaxInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSDecisionStampTaxInfo() : base() { }

    }
}