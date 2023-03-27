
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPayroll")] 

    /// <summary>
    /// Bordro
    /// </summary>
    public  partial class MBSPayroll : TTObject
    {
        public class MBSPayrollList : TTObjectCollection<MBSPayroll> { }
                    
        public class ChildMBSPayrollCollection : TTObject.TTChildObjectCollection<MBSPayroll>
        {
            public ChildMBSPayrollCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPayrollCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam Kesinti
    /// </summary>
        public double? TotalReduction
        {
            get { return (double?)this["TOTALREDUCTION"]; }
            set { this["TOTALREDUCTION"] = value; }
        }

    /// <summary>
    /// Tür  (Property Gerekliyse; enum tanımlanacak)
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Net Tutar
    /// </summary>
        public double? NetIncome
        {
            get { return (double?)this["NETINCOME"]; }
            set { this["NETINCOME"] = value; }
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
    /// Person - Payroll
    /// </summary>
        public MBSPersonnel Personnel
        {
            get { return (MBSPersonnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePeriodsCollection()
        {
            _Periods = new MBSPeriod.ChildMBSPeriodCollection(this, new Guid("b443c74b-5cc6-4569-b7ef-124d53a8e161"));
            ((ITTChildObjectCollection)_Periods).GetChildren();
        }

        protected MBSPeriod.ChildMBSPeriodCollection _Periods = null;
        public MBSPeriod.ChildMBSPeriodCollection Periods
        {
            get
            {
                if (_Periods == null)
                    CreatePeriodsCollection();
                return _Periods;
            }
        }

        virtual protected void CreateAccountsCollection()
        {
            _Accounts = new MBSReductionDeductionAccount.ChildMBSReductionDeductionAccountCollection(this, new Guid("2f3e3300-adba-4f9e-838a-da3631d06d23"));
            ((ITTChildObjectCollection)_Accounts).GetChildren();
        }

        protected MBSReductionDeductionAccount.ChildMBSReductionDeductionAccountCollection _Accounts = null;
        public MBSReductionDeductionAccount.ChildMBSReductionDeductionAccountCollection Accounts
        {
            get
            {
                if (_Accounts == null)
                    CreateAccountsCollection();
                return _Accounts;
            }
        }

        protected MBSPayroll(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPayroll(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPayroll(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPayroll(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPayroll(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPAYROLL", dataRow) { }
        protected MBSPayroll(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPAYROLL", dataRow, isImported) { }
        public MBSPayroll(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPayroll(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPayroll() : base() { }

    }
}