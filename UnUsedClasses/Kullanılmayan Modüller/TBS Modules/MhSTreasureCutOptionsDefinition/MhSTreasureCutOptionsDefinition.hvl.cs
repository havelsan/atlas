
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTreasureCutOptionsDefinition")] 

    /// <summary>
    /// Hazine Payı Parametreleri
    /// </summary>
    public  partial class MhSTreasureCutOptionsDefinition : TTDefinitionSet
    {
        public class MhSTreasureCutOptionsDefinitionList : TTObjectCollection<MhSTreasureCutOptionsDefinition> { }
                    
        public class ChildMhSTreasureCutOptionsDefinitionCollection : TTObject.TTChildObjectCollection<MhSTreasureCutOptionsDefinition>
        {
            public ChildMhSTreasureCutOptionsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTreasureCutOptionsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ne İçin Ödendiği
    /// </summary>
        public string WhyPaid
        {
            get { return (string)this["WHYPAID"]; }
            set { this["WHYPAID"] = value; }
        }

    /// <summary>
    /// Bağlı Olduğu Daire
    /// </summary>
        public string ParentDepartment
        {
            get { return (string)this["PARENTDEPARTMENT"]; }
            set { this["PARENTDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Kime Ödeneceği
    /// </summary>
        public string ToWhom
        {
            get { return (string)this["TOWHOM"]; }
            set { this["TOWHOM"] = value; }
        }

    /// <summary>
    /// Özel Hesap No
    /// </summary>
        public string SpecialAccountNo
        {
            get { return (string)this["SPECIALACCOUNTNO"]; }
            set { this["SPECIALACCOUNTNO"] = value; }
        }

    /// <summary>
    /// İşletmenin Adı
    /// </summary>
        public string CompanyName
        {
            get { return (string)this["COMPANYNAME"]; }
            set { this["COMPANYNAME"] = value; }
        }

    /// <summary>
    /// Uygulanacak Oran
    /// </summary>
        public double? CutRatio
        {
            get { return (double?)this["CUTRATIO"]; }
            set { this["CUTRATIO"] = value; }
        }

    /// <summary>
    /// Kayıtlı Olduğu Yer
    /// </summary>
        public string RegisteredTo
        {
            get { return (string)this["REGISTEREDTO"]; }
            set { this["REGISTEREDTO"] = value; }
        }

    /// <summary>
    /// Ödeme Emri Borçlu Hesap
    /// </summary>
        public MhSAccount PaymentSlipCreditAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("PAYMENTSLIPCREDITACCOUNT"); }
            set { this["PAYMENTSLIPCREDITACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mahsup Fişi Alacaklı Hesap
    /// </summary>
        public MhSAccount ChargingSlipCreditAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("CHARGINGSLIPCREDITACCOUNT"); }
            set { this["CHARGINGSLIPCREDITACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mahsup Fişi Borçlu Hesap
    /// </summary>
        public MhSAccount ChargingSlipDebitAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("CHARGINGSLIPDEBITACCOUNT"); }
            set { this["CHARGINGSLIPDEBITACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ödeme Emri Alacaklı Hesap
    /// </summary>
        public MhSAccount PaymentSlipDebitAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("PAYMENTSLIPDEBITACCOUNT"); }
            set { this["PAYMENTSLIPDEBITACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTREASURECUTOPTIONSDEFINITION", dataRow) { }
        protected MhSTreasureCutOptionsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTREASURECUTOPTIONSDEFINITION", dataRow, isImported) { }
        public MhSTreasureCutOptionsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTreasureCutOptionsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTreasureCutOptionsDefinition() : base() { }

    }
}