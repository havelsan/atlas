
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrEpisode")] 

    public  partial class ehrEpisode : BaseEhr, IOldActions, Itest
    {
        public class ehrEpisodeList : TTObjectCollection<ehrEpisode> { }
                    
        public class ChildehrEpisodeCollection : TTObject.TTChildObjectCollection<ehrEpisode>
        {
            public ChildehrEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Hasta Grubu
    /// </summary>
        public PatientGroupEnum? PatientGroup
        {
            get { return (PatientGroupEnum?)(int?)this["PATIENTGROUP"]; }
            set { this["PATIENTGROUP"] = value; }
        }

    /// <summary>
    /// Episodeda tutulan Obje iken bu Enum değeri o yüzden ehr'ye otomatik kopyalanmaz.
    /// </summary>
        public AdmissionTypeEnum? ReasonForAdmission
        {
            get { return (AdmissionTypeEnum?)(int?)this["REASONFORADMISSION"]; }
            set { this["REASONFORADMISSION"] = value; }
        }

    /// <summary>
    /// Vaka Açılış Tarihi
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Sicil No' Bilgisini Taşıyan Alandır
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Hastanın Aile Reisinin  Adı Bilgisini Taşıyan Alandır
    /// </summary>
        public string HeadOfFamilyName
        {
            get { return (string)this["HEADOFFAMILYNAME"]; }
            set { this["HEADOFFAMILYNAME"] = value; }
        }

    /// <summary>
    /// Hastanın Aile Reisinin  Vakadaki ' TC Kimlik Numarası' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HeadOfFamilyUniqueRefNo
        {
            get { return (string)this["HEADOFFAMILYUNIQUEREFNO"]; }
            set { this["HEADOFFAMILYUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Hastanın Aile Reisinin Vakadaki ' Sicil No' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HOFEmploymentRecordID
        {
            get { return (string)this["HOFEMPLOYMENTRECORDID"]; }
            set { this["HOFEMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Gazi Okul No' Bilgisini Taşıyan Alandır
    /// </summary>
        public string WarVeteraCardNo
        {
            get { return (string)this["WARVETERACARDNO"]; }
            set { this["WARVETERACARDNO"] = value; }
        }

    /// <summary>
    /// Vaka Kapanış Tarihi
    /// </summary>
        public DateTime? ClosingDate
        {
            get { return (DateTime?)this["CLOSINGDATE"]; }
            set { this["CLOSINGDATE"] = value; }
        }

    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition MainSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("MAINSPECIALITY"); }
            set { this["MAINSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryClassDefinitions MilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("MILITARYCLASS"); }
            set { this["MILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryOffice MilitaryOffice
        {
            get { return (MilitaryOffice)((ITTObject)this).GetParent("MILITARYOFFICE"); }
            set { this["MILITARYOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ForcesCommand HOFForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("HOFFORCESCOMMAND"); }
            set { this["HOFFORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryClassDefinitions HOFMilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("HOFMILITARYCLASS"); }
            set { this["HOFMILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryOffice HOFMilitaryOffice
        {
            get { return (MilitaryOffice)((ITTObject)this).GetParent("HOFMILITARYOFFICE"); }
            set { this["HOFMILITARYOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryUnit HOFMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("HOFMILITARYUNIT"); }
            set { this["HOFMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RankDefinitions HOFRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("HOFRANK"); }
            set { this["HOFRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrDiagnosisCollection()
        {
            _ehrDiagnosis = new ehrDiagnosis.ChildehrDiagnosisCollection(this, new Guid("54362efd-ad58-4947-93bb-006c672291b6"));
            ((ITTChildObjectCollection)_ehrDiagnosis).GetChildren();
        }

        protected ehrDiagnosis.ChildehrDiagnosisCollection _ehrDiagnosis = null;
    /// <summary>
    /// Child collection for Vaka Tanıları
    /// </summary>
        public ehrDiagnosis.ChildehrDiagnosisCollection ehrDiagnosis
        {
            get
            {
                if (_ehrDiagnosis == null)
                    CreateehrDiagnosisCollection();
                return _ehrDiagnosis;
            }
        }

        virtual protected void CreateehrActionsCollection()
        {
            _ehrActions = new ehrEpisodeAction.ChildehrEpisodeActionCollection(this, new Guid("3e4697d9-4243-42ec-86bd-cf985c3a5340"));
            ((ITTChildObjectCollection)_ehrActions).GetChildren();
        }

        protected ehrEpisodeAction.ChildehrEpisodeActionCollection _ehrActions = null;
    /// <summary>
    /// Child collection for ehrEpisodeAction
    /// </summary>
        public ehrEpisodeAction.ChildehrEpisodeActionCollection ehrActions
        {
            get
            {
                if (_ehrActions == null)
                    CreateehrActionsCollection();
                return _ehrActions;
            }
        }

        protected ehrEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrEpisode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHREPISODE", dataRow) { }
        protected ehrEpisode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHREPISODE", dataRow, isImported) { }
        public ehrEpisode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrEpisode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrEpisode() : base() { }

    }
}