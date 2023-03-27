
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPeriod")] 

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
    public  partial class MhSPeriod : TTDefinitionSet
    {
        public class MhSPeriodList : TTObjectCollection<MhSPeriod> { }
                    
        public class ChildMhSPeriodCollection : TTObject.TTChildObjectCollection<MhSPeriod>
        {
            public ChildMhSPeriodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPeriodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ad
    /// </summary>
        public string Alias
        {
            get { return (string)this["ALIAS"]; }
            set { this["ALIAS"] = value; }
        }

    /// <summary>
    /// Daire Kodu
    /// </summary>
        public int? Department
        {
            get { return (int?)this["DEPARTMENT"]; }
            set { this["DEPARTMENT"] = value; }
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
    /// Saymanlık Kodu
    /// </summary>
        public int? PayrollDivisionCode
        {
            get { return (int?)this["PAYROLLDIVISIONCODE"]; }
            set { this["PAYROLLDIVISIONCODE"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public long? Year
        {
            get { return (long?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Kapanış Fişi
    /// </summary>
        public MhSTurnoverOperations ClosingSlip
        {
            get { return (MhSTurnoverOperations)((ITTObject)this).GetParent("CLOSINGSLIP"); }
            set { this["CLOSINGSLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önceki Çalışma Yılı
    /// </summary>
        public MhSPeriod PreviousPeriod
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PREVIOUSPERIOD"); }
            set { this["PREVIOUSPERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Açılış Fişi
    /// </summary>
        public MhSOpeningSlipOperations OpeningSlip
        {
            get { return (MhSOpeningSlipOperations)((ITTObject)this).GetParent("OPENINGSLIP"); }
            set { this["OPENINGSLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Calışma Yılları
    /// </summary>
        public MhSFirm Firm
        {
            get { return (MhSFirm)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Planı Şablonu
    /// </summary>
        public MhSChartOfAccounts TemplateChartOfAccounts
        {
            get { return (MhSChartOfAccounts)((ITTObject)this).GetParent("TEMPLATECHARTOFACCOUNTS"); }
            set { this["TEMPLATECHARTOFACCOUNTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNextPeriodCollection()
        {
            _NextPeriod = new MhSPeriod.ChildMhSPeriodCollection(this, new Guid("1bbcb6cc-55d5-49ae-bea1-13e7a758371c"));
            ((ITTChildObjectCollection)_NextPeriod).GetChildren();
        }

        protected MhSPeriod.ChildMhSPeriodCollection _NextPeriod = null;
    /// <summary>
    /// Child collection for Önceki Çalışma Yılı
    /// </summary>
        public MhSPeriod.ChildMhSPeriodCollection NextPeriod
        {
            get
            {
                if (_NextPeriod == null)
                    CreateNextPeriodCollection();
                return _NextPeriod;
            }
        }

        virtual protected void CreateChartOfAccountsCollection()
        {
            _ChartOfAccounts = new MhSChartOfAccounts.ChildMhSChartOfAccountsCollection(this, new Guid("1cfd24d8-ec24-4e0f-8727-7054d09e6e09"));
            ((ITTChildObjectCollection)_ChartOfAccounts).GetChildren();
        }

        protected MhSChartOfAccounts.ChildMhSChartOfAccountsCollection _ChartOfAccounts = null;
    /// <summary>
    /// Child collection for Çalışma Yılı
    /// </summary>
        public MhSChartOfAccounts.ChildMhSChartOfAccountsCollection ChartOfAccounts
        {
            get
            {
                if (_ChartOfAccounts == null)
                    CreateChartOfAccountsCollection();
                return _ChartOfAccounts;
            }
        }

        protected MhSPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPeriod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPERIOD", dataRow) { }
        protected MhSPeriod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPERIOD", dataRow, isImported) { }
        public MhSPeriod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPeriod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPeriod() : base() { }

    }
}