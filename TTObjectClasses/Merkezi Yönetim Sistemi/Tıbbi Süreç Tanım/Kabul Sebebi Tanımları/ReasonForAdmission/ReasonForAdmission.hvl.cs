
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForAdmission")] 

    /// <summary>
    /// Kabul Sebebi Tanımları
    /// </summary>
    public  partial class ReasonForAdmission : TerminologyManagerDef
    {
        public class ReasonForAdmissionList : TTObjectCollection<ReasonForAdmission> { }
                    
        public class ChildReasonForAdmissionCollection : TTObject.TTChildObjectCollection<ReasonForAdmission>
        {
            public ChildReasonForAdmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForAdmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReasonForAdmissionDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AdmissionTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["TYPE"].DataType;
                    return (AdmissionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetReasonForAdmissionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReasonForAdmissionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReasonForAdmissionDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ReasonForAdmission_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AdmissionTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].AllPropertyDefs["TYPE"].DataType;
                    return (AdmissionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_ReasonForAdmission_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ReasonForAdmission_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ReasonForAdmission_Class() : base() { }
        }

        public static BindingList<ReasonForAdmission> GetReasonForAdmissions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["GetReasonForAdmissions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ReasonForAdmission>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ReasonForAdmission.GetReasonForAdmissionDefinition_Class> GetReasonForAdmissionDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["GetReasonForAdmissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForAdmission.GetReasonForAdmissionDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForAdmission.GetReasonForAdmissionDefinition_Class> GetReasonForAdmissionDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["GetReasonForAdmissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForAdmission.GetReasonForAdmissionDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForAdmission> GetByReasonAdmissionType(TTObjectContext objectContext, AdmissionTypeEnum TYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["GetByReasonAdmissionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", (int)TYPE);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForAdmission>(queryDef, paramList);
        }

        public static BindingList<ReasonForAdmission.OLAP_ReasonForAdmission_Class> OLAP_ReasonForAdmission(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["OLAP_ReasonForAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForAdmission.OLAP_ReasonForAdmission_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReasonForAdmission.OLAP_ReasonForAdmission_Class> OLAP_ReasonForAdmission(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["OLAP_ReasonForAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForAdmission.OLAP_ReasonForAdmission_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReasonForAdmission> GetReasonForAdmissionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSION"].QueryDefs["GetReasonForAdmissionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForAdmission>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Uzmanlık Dalına Göre Kısıtlama
    /// </summary>
        public bool? IgnoreSpeciality
        {
            get { return (bool?)this["IGNORESPECIALITY"]; }
            set { this["IGNORESPECIALITY"] = value; }
        }

    /// <summary>
    /// Kabul Tipi
    /// </summary>
        public AdmissionTypeEnum? Type
        {
            get { return (AdmissionTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Başlatılacak İşlem Tipi(Varsayılan)
    /// </summary>
        public ActionTypeEnum? DefualtActionType
        {
            get { return (ActionTypeEnum?)(int?)this["DEFUALTACTIONTYPE"]; }
            set { this["DEFUALTACTIONTYPE"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
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
    /// Hasta Yatış Başlatılabilir
    /// </summary>
        public bool? AllowedForInpatientAdmission
        {
            get { return (bool?)this["ALLOWEDFORINPATIENTADMISSION"]; }
            set { this["ALLOWEDFORINPATIENTADMISSION"] = value; }
        }

    /// <summary>
    /// Yatışta Döner Sermaye Adımından Geçer
    /// </summary>
        public bool? RequiresFinancialDepControl
        {
            get { return (bool?)this["REQUIRESFINANCIALDEPCONTROL"]; }
            set { this["REQUIRESFINANCIALDEPCONTROL"] = value; }
        }

    /// <summary>
    /// Kontenjan Kontrolü Yapmasın
    /// </summary>
        public bool? IgnoreQuota
        {
            get { return (bool?)this["IGNOREQUOTA"]; }
            set { this["IGNOREQUOTA"] = value; }
        }

    /// <summary>
    /// Tanımlı Tüm Kaynakları Başlat
    /// </summary>
        public bool? FireAllRelatedResources
        {
            get { return (bool?)this["FIREALLRELATEDRESOURCES"]; }
            set { this["FIREALLRELATEDRESOURCES"] = value; }
        }

    /// <summary>
    /// 10 Gün Kontrolü Yapmasın
    /// </summary>
        public bool? IgnoreTenDaysRule
        {
            get { return (bool?)this["IGNORETENDAYSRULE"]; }
            set { this["IGNORETENDAYSRULE"] = value; }
        }

    /// <summary>
    /// Medula İşlemlerine Girme Durumu
    /// </summary>
        public bool? IgnoreMedula
        {
            get { return (bool?)this["IGNOREMEDULA"]; }
            set { this["IGNOREMEDULA"] = value; }
        }

        public ProvizyonTipi ProvizyonTipi
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("PROVIZYONTIPI"); }
            set { this["PROVIZYONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru SigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("SIGORTALITURU"); }
            set { this["SIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IstisnaiHal IstisnaiHal
        {
            get { return (IstisnaiHal)((ITTObject)this).GetParent("ISTISNAIHAL"); }
            set { this["ISTISNAIHAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DevredilenKurum DevredilenKurum
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("DEVREDILENKURUM"); }
            set { this["DEVREDILENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTipi TedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("TEDAVITIPI"); }
            set { this["TEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSVakaTuru SKRSVakaTuru
        {
            get { return (SKRSVakaTuru)((ITTObject)this).GetParent("SKRSVAKATURU"); }
            set { this["SKRSVAKATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRelatedResourcesCollection()
        {
            _RelatedResources = new ReasonForAdmissionRelatedResources.ChildReasonForAdmissionRelatedResourcesCollection(this, new Guid("1a19a361-4454-4258-85c4-09d7ca22edcd"));
            ((ITTChildObjectCollection)_RelatedResources).GetChildren();
        }

        protected ReasonForAdmissionRelatedResources.ChildReasonForAdmissionRelatedResourcesCollection _RelatedResources = null;
    /// <summary>
    /// Child collection for Kabul Sebebi - İlgili Kaynaklar
    /// </summary>
        public ReasonForAdmissionRelatedResources.ChildReasonForAdmissionRelatedResourcesCollection RelatedResources
        {
            get
            {
                if (_RelatedResources == null)
                    CreateRelatedResourcesCollection();
                return _RelatedResources;
            }
        }

        protected ReasonForAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForAdmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORADMISSION", dataRow) { }
        protected ReasonForAdmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORADMISSION", dataRow, isImported) { }
        protected ReasonForAdmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForAdmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForAdmission() : base() { }

    }
}