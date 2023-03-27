
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPeriod")] 

    /// <summary>
    /// Dönem
    /// </summary>
    public  partial class MBSPeriod : TTObject
    {
        public class MBSPeriodList : TTObjectCollection<MBSPeriod> { }
                    
        public class ChildMBSPeriodCollection : TTObject.TTChildObjectCollection<MBSPeriod>
        {
            public ChildMBSPeriodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPeriodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşletim
    /// </summary>
        public bool? Operation
        {
            get { return (bool?)this["OPERATION"]; }
            set { this["OPERATION"] = value; }
        }

    /// <summary>
    /// Ay
    /// </summary>
        public int? Month
        {
            get { return (int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public MBSPayroll Payroll
        {
            get { return (MBSPayroll)((ITTObject)this).GetParent("PAYROLL"); }
            set { this["PAYROLL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDegreeLevelIndicatorsCollection()
        {
            _DegreeLevelIndicators = new MBSDegreeLevelIndicator.ChildMBSDegreeLevelIndicatorCollection(this, new Guid("4bcf72ab-9f8b-4f14-adf0-00f5717e53ab"));
            ((ITTChildObjectCollection)_DegreeLevelIndicators).GetChildren();
        }

        protected MBSDegreeLevelIndicator.ChildMBSDegreeLevelIndicatorCollection _DegreeLevelIndicators = null;
        public MBSDegreeLevelIndicator.ChildMBSDegreeLevelIndicatorCollection DegreeLevelIndicators
        {
            get
            {
                if (_DegreeLevelIndicators == null)
                    CreateDegreeLevelIndicatorsCollection();
                return _DegreeLevelIndicators;
            }
        }

        virtual protected void CreateTDutyExpensesCollection()
        {
            _TDutyExpenses = new MBSTDutyExpense.ChildMBSTDutyExpenseCollection(this, new Guid("9dbde911-53b0-4379-8e35-0f84ace38e85"));
            ((ITTChildObjectCollection)_TDutyExpenses).GetChildren();
        }

        protected MBSTDutyExpense.ChildMBSTDutyExpenseCollection _TDutyExpenses = null;
        public MBSTDutyExpense.ChildMBSTDutyExpenseCollection TDutyExpenses
        {
            get
            {
                if (_TDutyExpenses == null)
                    CreateTDutyExpensesCollection();
                return _TDutyExpenses;
            }
        }

        virtual protected void CreateCOBCashsCollection()
        {
            _COBCashs = new MBSCOBCash.ChildMBSCOBCashCollection(this, new Guid("f6d85b58-a8cc-4a90-8be3-11950c810530"));
            ((ITTChildObjectCollection)_COBCashs).GetChildren();
        }

        protected MBSCOBCash.ChildMBSCOBCashCollection _COBCashs = null;
        public MBSCOBCash.ChildMBSCOBCashCollection COBCashs
        {
            get
            {
                if (_COBCashs == null)
                    CreateCOBCashsCollection();
                return _COBCashs;
            }
        }

        virtual protected void CreateParametersCollection()
        {
            _Parameters = new MBSSystemParameters.ChildMBSSystemParametersCollection(this, new Guid("6129fbc0-c11a-4d9a-929f-18aa40e3b820"));
            ((ITTChildObjectCollection)_Parameters).GetChildren();
        }

        protected MBSSystemParameters.ChildMBSSystemParametersCollection _Parameters = null;
        public MBSSystemParameters.ChildMBSSystemParametersCollection Parameters
        {
            get
            {
                if (_Parameters == null)
                    CreateParametersCollection();
                return _Parameters;
            }
        }

        virtual protected void CreatePositionJobsCollection()
        {
            _PositionJobs = new MBSPositionJob.ChildMBSPositionJobCollection(this, new Guid("07b2142a-3fb8-4f49-839c-194aafbb22e3"));
            ((ITTChildObjectCollection)_PositionJobs).GetChildren();
        }

        protected MBSPositionJob.ChildMBSPositionJobCollection _PositionJobs = null;
        public MBSPositionJob.ChildMBSPositionJobCollection PositionJobs
        {
            get
            {
                if (_PositionJobs == null)
                    CreatePositionJobsCollection();
                return _PositionJobs;
            }
        }

        virtual protected void CreateAdditionalIndicatorsCollection()
        {
            _AdditionalIndicators = new MBSAdditionalIndicator.ChildMBSAdditionalIndicatorCollection(this, new Guid("d4d75cf9-8bbb-4419-8cac-2ce892c5d2f9"));
            ((ITTChildObjectCollection)_AdditionalIndicators).GetChildren();
        }

        protected MBSAdditionalIndicator.ChildMBSAdditionalIndicatorCollection _AdditionalIndicators = null;
        public MBSAdditionalIndicator.ChildMBSAdditionalIndicatorCollection AdditionalIndicators
        {
            get
            {
                if (_AdditionalIndicators == null)
                    CreateAdditionalIndicatorsCollection();
                return _AdditionalIndicators;
            }
        }

        virtual protected void CreateReductionDeductionValueCollection()
        {
            _ReductionDeductionValue = new MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection(this, new Guid("58eb2d03-70a7-4fa9-a1ac-5bb1b6a10a96"));
            ((ITTChildObjectCollection)_ReductionDeductionValue).GetChildren();
        }

        protected MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection _ReductionDeductionValue = null;
        public MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection ReductionDeductionValue
        {
            get
            {
                if (_ReductionDeductionValue == null)
                    CreateReductionDeductionValueCollection();
                return _ReductionDeductionValue;
            }
        }

        virtual protected void CreateAdditionalLessonPayrollsCollection()
        {
            _AdditionalLessonPayrolls = new MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection(this, new Guid("eb13ca24-a178-45ba-a97b-6879ef4e90c0"));
            ((ITTChildObjectCollection)_AdditionalLessonPayrolls).GetChildren();
        }

        protected MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection _AdditionalLessonPayrolls = null;
        public MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection AdditionalLessonPayrolls
        {
            get
            {
                if (_AdditionalLessonPayrolls == null)
                    CreateAdditionalLessonPayrollsCollection();
                return _AdditionalLessonPayrolls;
            }
        }

        virtual protected void CreateAssignPricesCollection()
        {
            _AssignPrices = new MBSAssignPrice.ChildMBSAssignPriceCollection(this, new Guid("088f44f7-094d-4ecd-90ac-f503fdb309b3"));
            ((ITTChildObjectCollection)_AssignPrices).GetChildren();
        }

        protected MBSAssignPrice.ChildMBSAssignPriceCollection _AssignPrices = null;
        public MBSAssignPrice.ChildMBSAssignPriceCollection AssignPrices
        {
            get
            {
                if (_AssignPrices == null)
                    CreateAssignPricesCollection();
                return _AssignPrices;
            }
        }

        virtual protected void CreateTitlesCollection()
        {
            _Titles = new MBSTitle.ChildMBSTitleCollection(this, new Guid("2a8fa4d0-f7ca-4648-837d-e7039b55b63f"));
            ((ITTChildObjectCollection)_Titles).GetChildren();
        }

        protected MBSTitle.ChildMBSTitleCollection _Titles = null;
        public MBSTitle.ChildMBSTitleCollection Titles
        {
            get
            {
                if (_Titles == null)
                    CreateTitlesCollection();
                return _Titles;
            }
        }

        protected MBSPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPeriod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERIOD", dataRow) { }
        protected MBSPeriod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERIOD", dataRow, isImported) { }
        public MBSPeriod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPeriod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPeriod() : base() { }

    }
}