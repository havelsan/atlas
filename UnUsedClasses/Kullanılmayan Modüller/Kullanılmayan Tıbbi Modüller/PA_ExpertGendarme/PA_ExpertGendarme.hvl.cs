
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_ExpertGendarme")] 

    /// <summary>
    /// Uzman Jandarma Kabul 
    /// </summary>
    public  partial class PA_ExpertGendarme : PatientAdmission
    {
        public class PA_ExpertGendarmeList : TTObjectCollection<PA_ExpertGendarme> { }
                    
        public class ChildPA_ExpertGendarmeCollection : TTObject.TTChildObjectCollection<PA_ExpertGendarme>
        {
            public ChildPA_ExpertGendarmeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_ExpertGendarmeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// Sağlık Fişi No
    /// </summary>
        public string HealtSlipNumber
        {
            get { return (string)this["HEALTSLIPNUMBER"]; }
            set { this["HEALTSLIPNUMBER"] = value; }
        }

    /// <summary>
    /// Şehit
    /// </summary>
        public bool? Martyr
        {
            get { return (bool?)this["MARTYR"]; }
            set { this["MARTYR"] = value; }
        }

    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
        }

    /// <summary>
    /// Sicil No
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions MilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("MILITARYCLASS"); }
            set { this["MILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayeneye Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tahakkuk Birimi
    /// </summary>
        public AssessmentDepartmentDef AssessmentDepartment
        {
            get { return (AssessmentDepartmentDef)((ITTObject)this).GetParent("ASSESSMENTDEPARTMENT"); }
            set { this["ASSESSMENTDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Maaş Mutemetliği
    /// </summary>
        public SalaryPayMasterDefinition SalartPayMaster
        {
            get { return (SalaryPayMasterDefinition)((ITTObject)this).GetParent("SALARTPAYMASTER"); }
            set { this["SALARTPAYMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_ExpertGendarme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_ExpertGendarme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_ExpertGendarme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_ExpertGendarme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_ExpertGendarme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_EXPERTGENDARME", dataRow) { }
        protected PA_ExpertGendarme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_EXPERTGENDARME", dataRow, isImported) { }
        public PA_ExpertGendarme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_ExpertGendarme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_ExpertGendarme() : base() { }

    }
}