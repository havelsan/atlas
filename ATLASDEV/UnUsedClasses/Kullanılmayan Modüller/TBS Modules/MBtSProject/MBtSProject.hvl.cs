
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSProject")] 

    /// <summary>
    /// Proje
    /// </summary>
    public  partial class MBtSProject : TTObject
    {
        public class MBtSProjectList : TTObjectCollection<MBtSProject> { }
                    
        public class ChildMBtSProjectCollection : TTObject.TTChildObjectCollection<MBtSProject>
        {
            public ChildMBtSProjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSProjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Proje Numarası
    /// </summary>
        public string ProjectNo
        {
            get { return (string)this["PROJECTNO"]; }
            set { this["PROJECTNO"] = value; }
        }

    /// <summary>
    /// MSB gelen ödenek harcanan
    /// </summary>
        public double? MSBDeductionFund
        {
            get { return (double?)this["MSBDEDUCTIONFUND"]; }
            set { this["MSBDEDUCTIONFUND"] = value; }
        }

    /// <summary>
    /// GKB gelen ödenek
    /// </summary>
        public double? GKBIncomingFund
        {
            get { return (double?)this["GKBINCOMINGFUND"]; }
            set { this["GKBINCOMINGFUND"] = value; }
        }

    /// <summary>
    /// KKK gelen ödenek
    /// </summary>
        public double? KKKIncomingFund
        {
            get { return (double?)this["KKKINCOMINGFUND"]; }
            set { this["KKKINCOMINGFUND"] = value; }
        }

    /// <summary>
    /// MSB gelen ödenek
    /// </summary>
        public double? MSBIncomingFund
        {
            get { return (double?)this["MSBINCOMINGFUND"]; }
            set { this["MSBINCOMINGFUND"] = value; }
        }

    /// <summary>
    /// Tahmini bütçe
    /// </summary>
        public double? ApproximateBudget
        {
            get { return (double?)this["APPROXIMATEBUDGET"]; }
            set { this["APPROXIMATEBUDGET"] = value; }
        }

    /// <summary>
    /// GKB gelen ödenek harcanan
    /// </summary>
        public double? GKBDeductionFund
        {
            get { return (double?)this["GKBDEDUCTIONFUND"]; }
            set { this["GKBDEDUCTIONFUND"] = value; }
        }

    /// <summary>
    /// Proje Ad
    /// </summary>
        public string ProjectName
        {
            get { return (string)this["PROJECTNAME"]; }
            set { this["PROJECTNAME"] = value; }
        }

    /// <summary>
    /// KKK gelen ödenek harcanan
    /// </summary>
        public double? KKKDeductionFund
        {
            get { return (double?)this["KKKDEDUCTIONFUND"]; }
            set { this["KKKDEDUCTIONFUND"] = value; }
        }

    /// <summary>
    /// Kesin bütçe
    /// </summary>
        public double? TotalIncomingFund
        {
            get { return (double?)this["TOTALINCOMINGFUND"]; }
            set { this["TOTALINCOMINGFUND"] = value; }
        }

    /// <summary>
    /// Toplam harcama
    /// </summary>
        public double? TotalDeductions
        {
            get { return (double?)this["TOTALDEDUCTIONS"]; }
            set { this["TOTALDEDUCTIONS"] = value; }
        }

        public MBtSAccountancyEntry AccountancyEntry
        {
            get { return (MBtSAccountancyEntry)((ITTObject)this).GetParent("ACCOUNTANCYENTRY"); }
            set { this["ACCOUNTANCYENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSFinanceEntry FinanceEntry
        {
            get { return (MBtSFinanceEntry)((ITTObject)this).GetParent("FINANCEENTRY"); }
            set { this["FINANCEENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIncomingPaymentOrderPaymentsCollection()
        {
            _IncomingPaymentOrderPayments = new MBtSIncomingPaymentOrderPayment.ChildMBtSIncomingPaymentOrderPaymentCollection(this, new Guid("b02d36de-5697-4b68-b0ed-4d4ba0867d64"));
            ((ITTChildObjectCollection)_IncomingPaymentOrderPayments).GetChildren();
        }

        protected MBtSIncomingPaymentOrderPayment.ChildMBtSIncomingPaymentOrderPaymentCollection _IncomingPaymentOrderPayments = null;
        public MBtSIncomingPaymentOrderPayment.ChildMBtSIncomingPaymentOrderPaymentCollection IncomingPaymentOrderPayments
        {
            get
            {
                if (_IncomingPaymentOrderPayments == null)
                    CreateIncomingPaymentOrderPaymentsCollection();
                return _IncomingPaymentOrderPayments;
            }
        }

        protected MBtSProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSProject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSProject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSProject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSPROJECT", dataRow) { }
        protected MBtSProject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSPROJECT", dataRow, isImported) { }
        public MBtSProject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSProject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSProject() : base() { }

    }
}