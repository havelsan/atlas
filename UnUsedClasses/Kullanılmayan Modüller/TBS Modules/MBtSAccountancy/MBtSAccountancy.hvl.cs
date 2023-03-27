
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAccountancy")] 

    public  partial class MBtSAccountancy : TTObject
    {
        public class MBtSAccountancyList : TTObjectCollection<MBtSAccountancy> { }
                    
        public class ChildMBtSAccountancyCollection : TTObject.TTChildObjectCollection<MBtSAccountancy>
        {
            public ChildMBtSAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açık avans toplamı
    /// </summary>
        public double? TotalOpenAdvance
        {
            get { return (double?)this["TOTALOPENADVANCE"]; }
            set { this["TOTALOPENADVANCE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
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
    /// GKB tenkis
    /// </summary>
        public double? GKBReduction
        {
            get { return (double?)this["GKBREDUCTION"]; }
            set { this["GKBREDUCTION"] = value; }
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
    /// GKB gelen ödenek
    /// </summary>
        public double? KKKIncomingFund
        {
            get { return (double?)this["KKKINCOMINGFUND"]; }
            set { this["KKKINCOMINGFUND"] = value; }
        }

    /// <summary>
    /// Kesin bütçe
    /// </summary>
        public double? AbsoluteBudget
        {
            get { return (double?)this["ABSOLUTEBUDGET"]; }
            set { this["ABSOLUTEBUDGET"] = value; }
        }

    /// <summary>
    /// MSB tenkis
    /// </summary>
        public double? MSBReduction
        {
            get { return (double?)this["MSBREDUCTION"]; }
            set { this["MSBREDUCTION"] = value; }
        }

    /// <summary>
    /// KKK gelen ödenek
    /// </summary>
        public double? GKBIncomingFund
        {
            get { return (double?)this["GKBINCOMINGFUND"]; }
            set { this["GKBINCOMINGFUND"] = value; }
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
    /// GKB kontenjan ödenek
    /// </summary>
        public double? GKBReservedFund
        {
            get { return (double?)this["GKBRESERVEDFUND"]; }
            set { this["GKBRESERVEDFUND"] = value; }
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
    /// KKK tenkis
    /// </summary>
        public double? KKKReduction
        {
            get { return (double?)this["KKKREDUCTION"]; }
            set { this["KKKREDUCTION"] = value; }
        }

    /// <summary>
    /// MSB kontenjan ödenek
    /// </summary>
        public double? MSBReservedFund
        {
            get { return (double?)this["MSBRESERVEDFUND"]; }
            set { this["MSBRESERVEDFUND"] = value; }
        }

    /// <summary>
    /// Mahsup avans toplamı
    /// </summary>
        public double? TotalAdvanceDeduction
        {
            get { return (double?)this["TOTALADVANCEDEDUCTION"]; }
            set { this["TOTALADVANCEDEDUCTION"] = value; }
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
    /// KKK kontenjan ödenek
    /// </summary>
        public double? KKKReservedFund
        {
            get { return (double?)this["KKKRESERVEDFUND"]; }
            set { this["KKKRESERVEDFUND"] = value; }
        }

        virtual protected void CreatePaymastersCollection()
        {
            _Paymasters = new MBtSPaymaster.ChildMBtSPaymasterCollection(this, new Guid("cd65f95d-6f30-4597-b46d-1a7c4523153d"));
            ((ITTChildObjectCollection)_Paymasters).GetChildren();
        }

        protected MBtSPaymaster.ChildMBtSPaymasterCollection _Paymasters = null;
        public MBtSPaymaster.ChildMBtSPaymasterCollection Paymasters
        {
            get
            {
                if (_Paymasters == null)
                    CreatePaymastersCollection();
                return _Paymasters;
            }
        }

        virtual protected void CreateBudgetsCollection()
        {
            _Budgets = new MBtSBudget.ChildMBtSBudgetCollection(this, new Guid("8638a94f-3c42-4088-931a-5c166eef9b95"));
            ((ITTChildObjectCollection)_Budgets).GetChildren();
        }

        protected MBtSBudget.ChildMBtSBudgetCollection _Budgets = null;
        public MBtSBudget.ChildMBtSBudgetCollection Budgets
        {
            get
            {
                if (_Budgets == null)
                    CreateBudgetsCollection();
                return _Budgets;
            }
        }

        virtual protected void CreateOperationEntriesCollection()
        {
            _OperationEntries = new MBtSOperation.ChildMBtSOperationCollection(this, new Guid("054cf7ab-3458-4bbd-85fd-46371f5e2e63"));
            ((ITTChildObjectCollection)_OperationEntries).GetChildren();
        }

        protected MBtSOperation.ChildMBtSOperationCollection _OperationEntries = null;
        public MBtSOperation.ChildMBtSOperationCollection OperationEntries
        {
            get
            {
                if (_OperationEntries == null)
                    CreateOperationEntriesCollection();
                return _OperationEntries;
            }
        }

        virtual protected void CreateProjectsCollection()
        {
            _Projects = new MBtSProject.ChildMBtSProjectCollection(this, new Guid("ba61d7b0-d39f-41f8-b3a8-51dea29b5080"));
            ((ITTChildObjectCollection)_Projects).GetChildren();
        }

        protected MBtSProject.ChildMBtSProjectCollection _Projects = null;
        public MBtSProject.ChildMBtSProjectCollection Projects
        {
            get
            {
                if (_Projects == null)
                    CreateProjectsCollection();
                return _Projects;
            }
        }

        virtual protected void CreateIncomingDeductionOrdersCollection()
        {
            _IncomingDeductionOrders = new MBtSIncomingDeductionOrder.ChildMBtSIncomingDeductionOrderCollection(this, new Guid("a4f9082c-f3e4-4308-98e2-cd3953a8f5de"));
            ((ITTChildObjectCollection)_IncomingDeductionOrders).GetChildren();
        }

        protected MBtSIncomingDeductionOrder.ChildMBtSIncomingDeductionOrderCollection _IncomingDeductionOrders = null;
        public MBtSIncomingDeductionOrder.ChildMBtSIncomingDeductionOrderCollection IncomingDeductionOrders
        {
            get
            {
                if (_IncomingDeductionOrders == null)
                    CreateIncomingDeductionOrdersCollection();
                return _IncomingDeductionOrders;
            }
        }

        virtual protected void CreateBudgetPreparationInformationsCollection()
        {
            _BudgetPreparationInformations = new MBtSBudgetPreparationInformation.ChildMBtSBudgetPreparationInformationCollection(this, new Guid("9b4729e4-7944-4945-a113-f4605a4ce68b"));
            ((ITTChildObjectCollection)_BudgetPreparationInformations).GetChildren();
        }

        protected MBtSBudgetPreparationInformation.ChildMBtSBudgetPreparationInformationCollection _BudgetPreparationInformations = null;
        public MBtSBudgetPreparationInformation.ChildMBtSBudgetPreparationInformationCollection BudgetPreparationInformations
        {
            get
            {
                if (_BudgetPreparationInformations == null)
                    CreateBudgetPreparationInformationsCollection();
                return _BudgetPreparationInformations;
            }
        }

        protected MBtSAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSACCOUNTANCY", dataRow) { }
        protected MBtSAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSACCOUNTANCY", dataRow, isImported) { }
        public MBtSAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAccountancy() : base() { }

    }
}