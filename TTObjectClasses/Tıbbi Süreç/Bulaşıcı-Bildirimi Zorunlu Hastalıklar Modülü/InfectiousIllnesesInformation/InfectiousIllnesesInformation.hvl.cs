
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfectiousIllnesesInformation")] 

    /// <summary>
    /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri 
    /// </summary>
    public  partial class InfectiousIllnesesInformation : EpisodeAction
    {
        public class InfectiousIllnesesInformationList : TTObjectCollection<InfectiousIllnesesInformation> { }
                    
        public class ChildInfectiousIllnesesInformationCollection : TTObject.TTChildObjectCollection<InfectiousIllnesesInformation>
        {
            public ChildInfectiousIllnesesInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfectiousIllnesesInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInfectiousIllnesesInformationNQL_Class : TTReportNqlObject 
        {
            public string IllnesesName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILLNESESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["ILLNESESNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosiscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosisname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTimeOfInfectious
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIMEOFINFECTIOUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["STARTTIMEOFINFECTIOUS"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Skrsvakatipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSVAKATIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVAKATIPI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeathTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATHTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["DEATHTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public string Proceduredoctorrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Job
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["JOB"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Starttimeofinfectious1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIMEOFINFECTIOUS1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].AllPropertyDefs["STARTTIMEOFINFECTIOUS"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientbirthdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Object Mobilephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                }
            }

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Maritalstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MARITALSTATUS"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetInfectiousIllnesesInformationNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInfectiousIllnesesInformationNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInfectiousIllnesesInformationNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("77ac9a1b-66d7-4bbb-8661-48f8e5a64e45"); } }
            public static Guid Completed { get { return new Guid("8aea460f-f296-4e04-b380-36e476b085a2"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a71aad3d-6560-4a6a-8d47-f15ff127c594"); } }
        }

        public static BindingList<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class> GetInfectiousIllnesesInformationNQL(string INFECTIOUSILLNESESINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].QueryDefs["GetInfectiousIllnesesInformationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INFECTIOUSILLNESESINFO", INFECTIOUSILLNESESINFO);

            return TTReportNqlObject.QueryObjects<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class> GetInfectiousIllnesesInformationNQL(TTObjectContext objectContext, string INFECTIOUSILLNESESINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIOUSILLNESESINFORMATION"].QueryDefs["GetInfectiousIllnesesInformationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INFECTIOUSILLNESESINFO", INFECTIOUSILLNESESINFO);

            return TTReportNqlObject.QueryObjects<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hastalığın Başladığı Tarih
    /// </summary>
        public DateTime? StartTimeOfInfectious
        {
            get { return (DateTime?)this["STARTTIMEOFINFECTIOUS"]; }
            set { this["STARTTIMEOFINFECTIOUS"] = value; }
        }

    /// <summary>
    /// Meslek
    /// </summary>
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

    /// <summary>
    /// Ölüm Tarihi
    /// </summary>
        public DateTime? DeathTime
        {
            get { return (DateTime?)this["DEATHTIME"]; }
            set { this["DEATHTIME"] = value; }
        }

    /// <summary>
    /// Hastalığın Adı
    /// </summary>
        public string IllnesesName
        {
            get { return (string)this["ILLNESESNAME"]; }
            set { this["ILLNESESNAME"] = value; }
        }

    /// <summary>
    /// Ölü
    /// </summary>
        public bool? NotAlive
        {
            get { return (bool?)this["NOTALIVE"]; }
            set { this["NOTALIVE"] = value; }
        }

        public EpisodeAction StarterEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("STARTEREPISODEACTION"); }
            set { this["STARTEREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient PatientInfo
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENTINFO"); }
            set { this["PATIENTINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition InfectiousIllnesesDiagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("INFECTIOUSILLNESESDIAGNOSIS"); }
            set { this["INFECTIOUSILLNESESDIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubactionProcedureWithDiagnosis StarterSubactionProcedure
        {
            get { return (SubactionProcedureWithDiagnosis)((ITTObject)this).GetParent("STARTERSUBACTIONPROCEDURE"); }
            set { this["STARTERSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bulaşıcı Hastalık Bildirim Vaka Tipi İlişkisi
    /// </summary>
        public SKRSVakaTipi SKRSVakaTipi
        {
            get { return (SKRSVakaTipi)((ITTObject)this).GetParent("SKRSVAKATIPI"); }
            set { this["SKRSVAKATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InfectiousIllnesesInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfectiousIllnesesInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfectiousIllnesesInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfectiousIllnesesInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfectiousIllnesesInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFECTIOUSILLNESESINFORMATION", dataRow) { }
        protected InfectiousIllnesesInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFECTIOUSILLNESESINFORMATION", dataRow, isImported) { }
        public InfectiousIllnesesInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfectiousIllnesesInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfectiousIllnesesInformation() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}