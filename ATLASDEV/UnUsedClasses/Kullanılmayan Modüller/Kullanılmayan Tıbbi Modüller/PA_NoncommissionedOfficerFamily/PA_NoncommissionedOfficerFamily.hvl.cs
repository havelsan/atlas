
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_NoncommissionedOfficerFamily")] 

    /// <summary>
    /// Astsubay Ailesi Kabul 
    /// </summary>
    public  partial class PA_NoncommissionedOfficerFamily : PatientAdmission
    {
        public class PA_NoncommissionedOfficerFamilyList : TTObjectCollection<PA_NoncommissionedOfficerFamily> { }
                    
        public class ChildPA_NoncommissionedOfficerFamilyCollection : TTObject.TTChildObjectCollection<PA_NoncommissionedOfficerFamily>
        {
            public ChildPA_NoncommissionedOfficerFamilyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_NoncommissionedOfficerFamilyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Aile Reisinin Adı
    /// </summary>
        public string HeadOfFamilyName
        {
            get { return (string)this["HEADOFFAMILYNAME"]; }
            set { this["HEADOFFAMILYNAME"] = value; }
        }

    /// <summary>
    /// Aile Reisinin TC Kimlik Numarası
    /// </summary>
        public string HeadOfFamilyUniqueRefNo
        {
            get { return (string)this["HEADOFFAMILYUNIQUEREFNO"]; }
            set { this["HEADOFFAMILYUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string HOFRetirementFundId
        {
            get { return (string)this["HOFRETIREMENTFUNDID"]; }
            set { this["HOFRETIREMENTFUNDID"] = value; }
        }

    /// <summary>
    /// Sicil No
    /// </summary>
        public string HOFEmploymentRecordID
        {
            get { return (string)this["HOFEMPLOYMENTRECORDID"]; }
            set { this["HOFEMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions HOFRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("HOFRANK"); }
            set { this["HOFRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yakınlık Derecesi
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit HOFMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("HOFMILITARYUNIT"); }
            set { this["HOFMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions HOFMilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("HOFMILITARYCLASS"); }
            set { this["HOFMILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AssessmentDepartmentDef HOFAssessmentDepartment
        {
            get { return (AssessmentDepartmentDef)((ITTObject)this).GetParent("HOFASSESSMENTDEPARTMENT"); }
            set { this["HOFASSESSMENTDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SalaryPayMasterDefinition HOFSalaryPayMaster
        {
            get { return (SalaryPayMasterDefinition)((ITTObject)this).GetParent("HOFSALARYPAYMASTER"); }
            set { this["HOFSALARYPAYMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand HOFForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("HOFFORCESCOMMAND"); }
            set { this["HOFFORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_NONCOMMISSIONEDOFFICERFAMILY", dataRow) { }
        protected PA_NoncommissionedOfficerFamily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_NONCOMMISSIONEDOFFICERFAMILY", dataRow, isImported) { }
        public PA_NoncommissionedOfficerFamily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_NoncommissionedOfficerFamily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_NoncommissionedOfficerFamily() : base() { }

    }
}