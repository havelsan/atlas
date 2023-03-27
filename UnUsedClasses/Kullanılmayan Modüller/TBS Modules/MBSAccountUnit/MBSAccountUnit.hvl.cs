
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSAccountUnit")] 

    /// <summary>
    /// Hesap Birimi
    /// </summary>
    public  partial class MBSAccountUnit : TTObject
    {
        public class MBSAccountUnitList : TTObjectCollection<MBSAccountUnit> { }
                    
        public class ChildMBSAccountUnitCollection : TTObject.TTChildObjectCollection<MBSAccountUnit>
        {
            public ChildMBSAccountUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSAccountUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MhSAccountTypes? ddd
        {
            get { return (MhSAccountTypes?)(int?)this["DDD"]; }
            set { this["DDD"] = value; }
        }

    /// <summary>
    /// Toplam
    /// </summary>
        public int? Total
        {
            get { return (int?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        public MARPublicationType? raa
        {
            get { return (MARPublicationType?)(int?)this["RAA"]; }
            set { this["RAA"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public int? Name
        {
            get { return (int?)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? Count
        {
            get { return (int?)this["COUNT"]; }
            set { this["COUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public int? UnitPrice
        {
            get { return (int?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public MBSWatchFeedingA WatchFeeding
        {
            get { return (MBSWatchFeedingA)((ITTObject)this).GetParent("WATCHFEEDING"); }
            set { this["WATCHFEEDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSTDutyExpense EscortDailyPayment
        {
            get { return (MBSTDutyExpense)((ITTObject)this).GetParent("ESCORTDAILYPAYMENT"); }
            set { this["ESCORTDAILYPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSAdditionalLessonPayroll AdditionalLessonAccount
        {
            get { return (MBSAdditionalLessonPayroll)((ITTObject)this).GetParent("ADDITIONALLESSONACCOUNT"); }
            set { this["ADDITIONALLESSONACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSTravel VehicleAccount
        {
            get { return (MBSTravel)((ITTObject)this).GetParent("VEHICLEACCOUNT"); }
            set { this["VEHICLEACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSSoldierAllowanceAssignPrice AllowanceAccount
        {
            get { return (MBSSoldierAllowanceAssignPrice)((ITTObject)this).GetParent("ALLOWANCEACCOUNT"); }
            set { this["ALLOWANCEACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSAdditionalLessonPayroll AdditionalLessonPayrollAcc
        {
            get { return (MBSAdditionalLessonPayroll)((ITTObject)this).GetParent("ADDITIONALLESSONPAYROLLACC"); }
            set { this["ADDITIONALLESSONPAYROLLACC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSAssignPrice AssignAccount
        {
            get { return (MBSAssignPrice)((ITTObject)this).GetParent("ASSIGNACCOUNT"); }
            set { this["ASSIGNACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSAccountUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSAccountUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSAccountUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSAccountUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSAccountUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSACCOUNTUNIT", dataRow) { }
        protected MBSAccountUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSACCOUNTUNIT", dataRow, isImported) { }
        public MBSAccountUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSAccountUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSAccountUnit() : base() { }

    }
}