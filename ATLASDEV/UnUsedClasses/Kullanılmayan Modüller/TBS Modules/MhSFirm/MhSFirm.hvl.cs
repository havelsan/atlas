
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFirm")] 

    /// <summary>
    /// Firma
    /// </summary>
    public  partial class MhSFirm : TTObject
    {
        public class MhSFirmList : TTObjectCollection<MhSFirm> { }
                    
        public class ChildMhSFirmCollection : TTObject.TTChildObjectCollection<MhSFirm>
        {
            public ChildMhSFirmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFirmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Daire Kodu
    /// </summary>
        public int? DepartmentCode
        {
            get { return (int?)this["DEPARTMENTCODE"]; }
            set { this["DEPARTMENTCODE"] = value; }
        }

    /// <summary>
    /// Saymanlık Kodu
    /// </summary>
        public int? PayrollDivisionCode
        {
            get { return (int?)this["PAYROLLDIVISIONCODE"]; }
            set { this["PAYROLLDIVISIONCODE"] = value; }
        }

    /// <summary>
    /// Firma Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Birim Kodu
    /// </summary>
        public int? UnitCode
        {
            get { return (int?)this["UNITCODE"]; }
            set { this["UNITCODE"] = value; }
        }

    /// <summary>
    /// Default Yıl
    /// </summary>
        public MhSPeriod ActivePeriod
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("ACTIVEPERIOD"); }
            set { this["ACTIVEPERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChartsOfAccountsCollection()
        {
            _ChartsOfAccounts = new MhSChartOfAccounts.ChildMhSChartOfAccountsCollection(this, new Guid("0c0681ec-045e-4d4e-ac8e-c5dba7d4f0c7"));
            ((ITTChildObjectCollection)_ChartsOfAccounts).GetChildren();
        }

        protected MhSChartOfAccounts.ChildMhSChartOfAccountsCollection _ChartsOfAccounts = null;
    /// <summary>
    /// Child collection for Firma
    /// </summary>
        public MhSChartOfAccounts.ChildMhSChartOfAccountsCollection ChartsOfAccounts
        {
            get
            {
                if (_ChartsOfAccounts == null)
                    CreateChartsOfAccountsCollection();
                return _ChartsOfAccounts;
            }
        }

        virtual protected void CreatePeriodsCollection()
        {
            _Periods = new MhSPeriod.ChildMhSPeriodCollection(this, new Guid("b3d77b06-81f4-4090-951f-d5cde58cf8a3"));
            ((ITTChildObjectCollection)_Periods).GetChildren();
        }

        protected MhSPeriod.ChildMhSPeriodCollection _Periods = null;
    /// <summary>
    /// Child collection for Calışma Yılları
    /// </summary>
        public MhSPeriod.ChildMhSPeriodCollection Periods
        {
            get
            {
                if (_Periods == null)
                    CreatePeriodsCollection();
                return _Periods;
            }
        }

        protected MhSFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFirm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFirm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFirm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFIRM", dataRow) { }
        protected MhSFirm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFIRM", dataRow, isImported) { }
        public MhSFirm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFirm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFirm() : base() { }

    }
}