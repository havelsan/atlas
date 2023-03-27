
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CreatingEpicrisis")] 

    /// <summary>
    /// Epikriz Oluşturma  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class CreatingEpicrisis : EpisodeAction, IWorkListEpisodeAction
    {
        public class CreatingEpicrisisList : TTObjectCollection<CreatingEpicrisis> { }
                    
        public class ChildCreatingEpicrisisCollection : TTObject.TTChildObjectCollection<CreatingEpicrisis>
        {
            public ChildCreatingEpicrisisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCreatingEpicrisisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCreatingEpicrisis_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object AUTOBIOGRAPHY
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTOBIOGRAPHY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["AUTOBIOGRAPHY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object COMPLAINTANDSTORY
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINTANDSTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["COMPLAINTANDSTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PHYSICALEXAMINATION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Suggestion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUGGESTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["SUGGESTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PROCEDURE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["PROCEDURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Birimadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetCreatingEpicrisis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCreatingEpicrisis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCreatingEpicrisis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientEpicrisisBySubepisodeID_Class : TTReportNqlObject 
        {
            public DateTime? Istemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Rapornumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Ozgecmis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZGECMIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["AUTOBIOGRAPHY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Sikayetveoykusu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIKAYETVEOYKUSU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["COMPLAINTANDSTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Fizikimuayene
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIZIKIMUAYENE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Onerilier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONERILIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["SUGGESTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Islemler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["PROCEDURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Birimadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Vizit_id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["VIZIT_ID"]);
                }
            }

            public GetPatientEpicrisisBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientEpicrisisBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientEpicrisisBySubepisodeID_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_EPIKRIZ_Class : TTReportNqlObject 
        {
            public Guid? Hasta_epikriz_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_EPIKRIZ_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public DateTime? Epikriz_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPIKRIZ_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Epikriz_bilgisi_baslik
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPIKRIZ_BILGISI_BASLIK"]);
                }
            }

            public object Epikriz_bilgisi_aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPIKRIZ_BILGISI_ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["AUTOBIOGRAPHY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_EPIKRIZ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_EPIKRIZ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_EPIKRIZ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllEpicrisisReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetAllEpicrisisReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllEpicrisisReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllEpicrisisReport_Class() : base() { }
        }

        public static class States
        {
            public static Guid ReportEntry { get { return new Guid("39eb95c9-5149-4a9a-a997-0d3c1225cc2c"); } }
            public static Guid Completed { get { return new Guid("89bfdc29-31c5-4164-b648-31750a2b07e2"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("529ea491-cedc-4594-9acc-8bbaf8902b40"); } }
    /// <summary>
    /// Ön Onay
    /// </summary>
            public static Guid PreApproval { get { return new Guid("b84fc6ef-1c99-44b9-861e-1293e919dc88"); } }
        }

        public static BindingList<CreatingEpicrisis> GetCreatingEpicrisisById(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetCreatingEpicrisisById"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<CreatingEpicrisis>(queryDef, paramList);
        }

        public static BindingList<CreatingEpicrisis.GetCreatingEpicrisis_Class> GetCreatingEpicrisis(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetCreatingEpicrisis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetCreatingEpicrisis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.GetCreatingEpicrisis_Class> GetCreatingEpicrisis(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetCreatingEpicrisis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetCreatingEpicrisis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis> GetEpicrisisByMasterAction(TTObjectContext objectContext, Guid MASTERACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetEpicrisisByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTION", MASTERACTION);

            return ((ITTQuery)objectContext).QueryObjects<CreatingEpicrisis>(queryDef, paramList);
        }

        public static BindingList<CreatingEpicrisis.GetPatientEpicrisisBySubepisodeID_Class> GetPatientEpicrisisBySubepisodeID(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetPatientEpicrisisBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetPatientEpicrisisBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.GetPatientEpicrisisBySubepisodeID_Class> GetPatientEpicrisisBySubepisodeID(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetPatientEpicrisisBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetPatientEpicrisisBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.VEM_HASTA_EPIKRIZ_Class> VEM_HASTA_EPIKRIZ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["VEM_HASTA_EPIKRIZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.VEM_HASTA_EPIKRIZ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.VEM_HASTA_EPIKRIZ_Class> VEM_HASTA_EPIKRIZ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["VEM_HASTA_EPIKRIZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.VEM_HASTA_EPIKRIZ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.GetAllEpicrisisReport_Class> GetAllEpicrisisReport(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetAllEpicrisisReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetAllEpicrisisReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis.GetAllEpicrisisReport_Class> GetAllEpicrisisReport(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetAllEpicrisisReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CreatingEpicrisis.GetAllEpicrisisReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CreatingEpicrisis> GetPatientAllEpicrisisReport(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetPatientAllEpicrisisReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<CreatingEpicrisis>(queryDef, paramList);
        }

        public static BindingList<CreatingEpicrisis> GetSelectedEpicrisis(TTObjectContext objectContext, Guid PROCEDUREDOCTOR, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CREATINGEPICRISIS"].QueryDefs["GetSelectedEpicrisis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREDOCTOR", PROCEDUREDOCTOR);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<CreatingEpicrisis>(queryDef, paramList);
        }

    /// <summary>
    /// İşlemler
    /// </summary>
        public object PROCEDURE
        {
            get { return (object)this["PROCEDURE"]; }
            set { this["PROCEDURE"] = value; }
        }

    /// <summary>
    /// Öneriler
    /// </summary>
        public object Suggestion
        {
            get { return (object)this["SUGGESTION"]; }
            set { this["SUGGESTION"] = value; }
        }

    /// <summary>
    /// Özgeçmiş
    /// </summary>
        public object AUTOBIOGRAPHY
        {
            get { return (object)this["AUTOBIOGRAPHY"]; }
            set { this["AUTOBIOGRAPHY"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PHYSICALEXAMINATION
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Şikayet ve Öyküsü
    /// </summary>
        public object COMPLAINTANDSTORY
        {
            get { return (object)this["COMPLAINTANDSTORY"]; }
            set { this["COMPLAINTANDSTORY"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Hikayesi
    /// </summary>
        public object STORY
        {
            get { return (object)this["STORY"]; }
            set { this["STORY"] = value; }
        }

    /// <summary>
    /// Bulgular
    /// </summary>
        public object SYMPTOM
        {
            get { return (object)this["SYMPTOM"]; }
            set { this["SYMPTOM"] = value; }
        }

        protected CreatingEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CreatingEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CreatingEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CreatingEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CreatingEpicrisis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CREATINGEPICRISIS", dataRow) { }
        protected CreatingEpicrisis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CREATINGEPICRISIS", dataRow, isImported) { }
        public CreatingEpicrisis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CreatingEpicrisis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CreatingEpicrisis() : base() { }

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