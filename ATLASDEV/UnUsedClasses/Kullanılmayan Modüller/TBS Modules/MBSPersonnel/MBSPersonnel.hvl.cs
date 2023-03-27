
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPersonnel")] 

    public  partial class MBSPersonnel : MBSPersonnelBase
    {
        public class MBSPersonnelList : TTObjectCollection<MBSPersonnel> { }
                    
        public class ChildMBSPersonnelCollection : TTObject.TTChildObjectCollection<MBSPersonnel>
        {
            public ChildMBSPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tayin Tarihi
    /// </summary>
        public DateTime? AssignDate
        {
            get { return (DateTime?)this["ASSIGNDATE"]; }
            set { this["ASSIGNDATE"] = value; }
        }

    /// <summary>
    /// İlk işe giriş tarihi
    /// </summary>
        public DateTime? FirstJobStartDate
        {
            get { return (DateTime?)this["FIRSTJOBSTARTDATE"]; }
            set { this["FIRSTJOBSTARTDATE"] = value; }
        }

    /// <summary>
    /// İtibari Hizmet
    /// </summary>
        public string EsteemDuty
        {
            get { return (string)this["ESTEEMDUTY"]; }
            set { this["ESTEEMDUTY"] = value; }
        }

    /// <summary>
    /// Ayrılış tarih
    /// </summary>
        public DateTime? SeparationDate
        {
            get { return (DateTime?)this["SEPARATIONDATE"]; }
            set { this["SEPARATIONDATE"] = value; }
        }

    /// <summary>
    /// Emekli terfi ay
    /// </summary>
        public int? RetiredPromotionMonth
        {
            get { return (int?)this["RETIREDPROMOTIONMONTH"]; }
            set { this["RETIREDPROMOTIONMONTH"] = value; }
        }

    /// <summary>
    /// Fiili hizmet
    /// </summary>
        public string ActualDuty
        {
            get { return (string)this["ACTUALDUTY"]; }
            set { this["ACTUALDUTY"] = value; }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public int? DutyYear
        {
            get { return (int?)this["DUTYYEAR"]; }
            set { this["DUTYYEAR"] = value; }
        }

    /// <summary>
    /// Derece
    /// </summary>
        public int? Degree
        {
            get { return (int?)this["DEGREE"]; }
            set { this["DEGREE"] = value; }
        }

    /// <summary>
    /// Ek Görev
    /// </summary>
        public string AdditionalJob
        {
            get { return (string)this["ADDITIONALJOB"]; }
            set { this["ADDITIONALJOB"] = value; }
        }

    /// <summary>
    /// Ek Görev Yeri
    /// </summary>
        public string AdditionalJobPlace
        {
            get { return (string)this["ADDITIONALJOBPLACE"]; }
            set { this["ADDITIONALJOBPLACE"] = value; }
        }

    /// <summary>
    /// Gelir vergisi matrahı
    /// </summary>
        public double? IncomeTaxAssessment
        {
            get { return (double?)this["INCOMETAXASSESSMENT"]; }
            set { this["INCOMETAXASSESSMENT"] = value; }
        }

    /// <summary>
    /// EMSAN Numarası
    /// </summary>
        public string EMSANNo
        {
            get { return (string)this["EMSANNO"]; }
            set { this["EMSANNO"] = value; }
        }

    /// <summary>
    /// Emekli derece
    /// </summary>
        public int? RetiredDegree
        {
            get { return (int?)this["RETIREDDEGREE"]; }
            set { this["RETIREDDEGREE"] = value; }
        }

    /// <summary>
    /// Medeni hal
    /// </summary>
        public MaritalStatusEnum? MaritalStatus
        {
            get { return (MaritalStatusEnum?)(int?)this["MARITALSTATUS"]; }
            set { this["MARITALSTATUS"] = value; }
        }

    /// <summary>
    /// Başlangıç tarihi
    /// </summary>
        public DateTime? JobStartDate
        {
            get { return (DateTime?)this["JOBSTARTDATE"]; }
            set { this["JOBSTARTDATE"] = value; }
        }

    /// <summary>
    /// Çocuk Sayısı
    /// </summary>
        public int? ChildrenCount
        {
            get { return (int?)this["CHILDRENCOUNT"]; }
            set { this["CHILDRENCOUNT"] = value; }
        }

    /// <summary>
    /// Kademe
    /// </summary>
        public int? Level
        {
            get { return (int?)this["LEVEL"]; }
            set { this["LEVEL"] = value; }
        }

    /// <summary>
    /// Tayin Emir No
    /// </summary>
        public string AssignOrderNo
        {
            get { return (string)this["ASSIGNORDERNO"]; }
            set { this["ASSIGNORDERNO"] = value; }
        }

    /// <summary>
    /// Emekli kademe
    /// </summary>
        public int? RetiredLevel
        {
            get { return (int?)this["RETIREDLEVEL"]; }
            set { this["RETIREDLEVEL"] = value; }
        }

    /// <summary>
    /// Asalet tarih
    /// </summary>
        public DateTime? NobilityDate
        {
            get { return (DateTime?)this["NOBILITYDATE"]; }
            set { this["NOBILITYDATE"] = value; }
        }

    /// <summary>
    /// Terfi Ay
    /// </summary>
        public int? PromotionMonth
        {
            get { return (int?)this["PROMOTIONMONTH"]; }
            set { this["PROMOTIONMONTH"] = value; }
        }

        virtual protected void CreatePayrollsCollection()
        {
            _Payrolls = new MBSPayroll.ChildMBSPayrollCollection(this, new Guid("b653628c-7425-4be4-bca8-43448f5310f1"));
            ((ITTChildObjectCollection)_Payrolls).GetChildren();
        }

        protected MBSPayroll.ChildMBSPayrollCollection _Payrolls = null;
    /// <summary>
    /// Child collection for Person - Payroll
    /// </summary>
        public MBSPayroll.ChildMBSPayrollCollection Payrolls
        {
            get
            {
                if (_Payrolls == null)
                    CreatePayrollsCollection();
                return _Payrolls;
            }
        }

        virtual protected void CreateReductionDeductionValueCollection()
        {
            _ReductionDeductionValue = new MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection(this, new Guid("6ea60017-5bde-4eeb-a46a-aa807a3bc5c9"));
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

        protected MBSPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERSONNEL", dataRow) { }
        protected MBSPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERSONNEL", dataRow, isImported) { }
        public MBSPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPersonnel() : base() { }

    }
}