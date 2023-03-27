
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSBankDelivery")] 

    /// <summary>
    /// Banka Teslim Müzekkeresi
    /// </summary>
    public  partial class MhSBankDelivery : TTObject
    {
        public class MhSBankDeliveryList : TTObjectCollection<MhSBankDelivery> { }
                    
        public class ChildMhSBankDeliveryCollection : TTObject.TTChildObjectCollection<MhSBankDelivery>
        {
            public ChildMhSBankDeliveryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSBankDeliveryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fiş Türü
    /// </summary>
        public MhSSlipTypesEnum? SlipType
        {
            get { return (MhSSlipTypesEnum?)(int?)this["SLIPTYPE"]; }
            set { this["SLIPTYPE"] = value; }
        }

    /// <summary>
    /// Saymanlık
    /// </summary>
        public string Division
        {
            get { return (string)this["DIVISION"]; }
            set { this["DIVISION"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
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
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Numarası
    /// </summary>
        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Fiş No
    /// </summary>
        public int? SlipNo
        {
            get { return (int?)this["SLIPNO"]; }
            set { this["SLIPNO"] = value; }
        }

    /// <summary>
    /// Mutemet
    /// </summary>
        public MhSTrusteeDefinition Trustee
        {
            get { return (MhSTrusteeDefinition)((ITTObject)this).GetParent("TRUSTEE"); }
            set { this["TRUSTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Banka
    /// </summary>
        public BankDefinition Bank
        {
            get { return (BankDefinition)((ITTObject)this).GetParent("BANK"); }
            set { this["BANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSBankDelivery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSBankDelivery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSBankDelivery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSBankDelivery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSBankDelivery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSBANKDELIVERY", dataRow) { }
        protected MhSBankDelivery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSBANKDELIVERY", dataRow, isImported) { }
        public MhSBankDelivery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSBankDelivery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSBankDelivery() : base() { }

    }
}