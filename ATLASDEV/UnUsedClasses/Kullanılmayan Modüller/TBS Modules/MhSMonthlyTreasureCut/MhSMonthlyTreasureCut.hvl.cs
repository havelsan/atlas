
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSMonthlyTreasureCut")] 

    /// <summary>
    /// Aylık Hazine Payı İşlemleri
    /// </summary>
    public  partial class MhSMonthlyTreasureCut : TTObject
    {
        public class MhSMonthlyTreasureCutList : TTObjectCollection<MhSMonthlyTreasureCut> { }
                    
        public class ChildMhSMonthlyTreasureCutCollection : TTObject.TTChildObjectCollection<MhSMonthlyTreasureCut>
        {
            public ChildMhSMonthlyTreasureCutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSMonthlyTreasureCutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ay
    /// </summary>
        public MhSAccountingMonths? Month
        {
            get { return (MhSAccountingMonths?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

    /// <summary>
    /// Kalan Miktar
    /// </summary>
        public double? RemainingAmount
        {
            get { return (double?)this["REMAININGAMOUNT"]; }
            set { this["REMAININGAMOUNT"] = value; }
        }

    /// <summary>
    /// 600 Hesap Bakiye
    /// </summary>
        public double? Account600Balance
        {
            get { return (double?)this["ACCOUNT600BALANCE"]; }
            set { this["ACCOUNT600BALANCE"] = value; }
        }

    /// <summary>
    /// Uygulanan Oran
    /// </summary>
        public double? CutRatio
        {
            get { return (double?)this["CUTRATIO"]; }
            set { this["CUTRATIO"] = value; }
        }

    /// <summary>
    /// Hazine Payı
    /// </summary>
        public double? CutAmount
        {
            get { return (double?)this["CUTAMOUNT"]; }
            set { this["CUTAMOUNT"] = value; }
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
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mahsup Fişi
    /// </summary>
        public MhSChargingSlipOperations Chargingslip
        {
            get { return (MhSChargingSlipOperations)((ITTObject)this).GetParent("CHARGINGSLIP"); }
            set { this["CHARGINGSLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ödeme Fişi
    /// </summary>
        public MhSSpendingSlip Paymentslip
        {
            get { return (MhSSpendingSlip)((ITTObject)this).GetParent("PAYMENTSLIP"); }
            set { this["PAYMENTSLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSMONTHLYTREASURECUT", dataRow) { }
        protected MhSMonthlyTreasureCut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSMONTHLYTREASURECUT", dataRow, isImported) { }
        public MhSMonthlyTreasureCut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSMonthlyTreasureCut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSMonthlyTreasureCut() : base() { }

    }
}