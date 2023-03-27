
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialityDefinition")] 

    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
    public  partial class SpecialityDefinition : BaseMedulaDefinition
    {
        public class SpecialityDefinitionList : TTObjectCollection<SpecialityDefinition> { }
                    
        public class ChildSpecialityDefinitionCollection : TTObject.TTChildObjectCollection<SpecialityDefinition>
        {
            public ChildSpecialityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_SpecialityDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_SpecialityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SpecialityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SpecialityDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSpecialityDefinitionNql_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? MHRSClinicCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSCLINICCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["MHRSCLINICCODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetSpecialityDefinitionNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpecialityDefinitionNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpecialityDefinitionNql_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSpecialityDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSpecialityDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpecialityDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpecialityDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllSpecialityDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public long? ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? EHU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EHU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["EHU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsToBeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTOBECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MHRSClinicCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSCLINICCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["MHRSCLINICCODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPrivate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPRIVATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISPRIVATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsSpecialistRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSPECIALISTREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISSPECIALISTREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMinorSpeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMINORSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISMINORSPECIALITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EpisodeClosingDayLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODECLOSINGDAYLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["EPISODECLOSINGDAYLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMHRSClinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMHRSCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISMHRSCLINIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SpecialityBasedObjectEnum? SpecialityBasedObjectType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYBASEDOBJECTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["SPECIALITYBASEDOBJECTTYPE"].DataType;
                    return (SpecialityBasedObjectEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsBulletin
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBULLETIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISBULLETIN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAllSpecialityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllSpecialityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllSpecialityDefinition_Class() : base() { }
        }

        public static BindingList<SpecialityDefinition.OLAP_SpecialityDefinition_Class> OLAP_SpecialityDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["OLAP_SpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.OLAP_SpecialityDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SpecialityDefinition.OLAP_SpecialityDefinition_Class> OLAP_SpecialityDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["OLAP_SpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.OLAP_SpecialityDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SpecialityDefinition> GetSpecialityDefinitionByExternalCode(TTObjectContext objectContext, long EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<SpecialityDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SpecialityDefinition.GetSpecialityDefinitionNql_Class> GetSpecialityDefinitionNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetSpecialityDefinitionNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition.GetSpecialityDefinitionNql_Class> GetSpecialityDefinitionNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetSpecialityDefinitionNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition.GetSpecialityDefinitionQuery_Class> GetSpecialityDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetSpecialityDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition.GetSpecialityDefinitionQuery_Class> GetSpecialityDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetSpecialityDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition> GetSpecialityDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SpecialityDefinition>(queryDef, paramList);
        }

        public static BindingList<SpecialityDefinition.GetAllSpecialityDefinition_Class> GetAllSpecialityDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetAllSpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetAllSpecialityDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition.GetAllSpecialityDefinition_Class> GetAllSpecialityDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetAllSpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecialityDefinition.GetAllSpecialityDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityDefinition> GetSpecialityByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetSpecialityByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<SpecialityDefinition>(queryDef, paramList);
        }

        public static BindingList<SpecialityDefinition> GetMinorSpecialities(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].QueryDefs["GetMinorSpecialities"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SpecialityDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Sağlık Bakanlığı Özel Kodu
    /// </summary>
        public long? ExternalCode
        {
            get { return (long?)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// EHU Gerektirmez
    /// </summary>
        public bool? EHU
        {
            get { return (bool?)this["EHU"]; }
            set { this["EHU"] = value; }
        }

    /// <summary>
    /// Konsültasyon Yapılabilir
    /// </summary>
        public bool? IsToBeConsultation
        {
            get { return (bool?)this["ISTOBECONSULTATION"]; }
            set { this["ISTOBECONSULTATION"] = value; }
        }

    /// <summary>
    /// MHRS Klinik Kodu
    /// </summary>
        public int? MHRSClinicCode
        {
            get { return (int?)this["MHRSCLINICCODE"]; }
            set { this["MHRSCLINICCODE"] = value; }
        }

    /// <summary>
    /// Kadın Doğum, Psikiatri gibi gizli kalması gerekebilen uzmanlık dalları için.
    /// </summary>
        public bool? IsPrivate
        {
            get { return (bool?)this["ISPRIVATE"]; }
            set { this["ISPRIVATE"] = value; }
        }

    /// <summary>
    /// Uzman Hekim Gerektirir
    /// </summary>
        public bool? IsSpecialistRequired
        {
            get { return (bool?)this["ISSPECIALISTREQUIRED"]; }
            set { this["ISSPECIALISTREQUIRED"] = value; }
        }

    /// <summary>
    /// Yandal Uzmanlık
    /// </summary>
        public bool? IsMinorSpeciality
        {
            get { return (bool?)this["ISMINORSPECIALITY"]; }
            set { this["ISMINORSPECIALITY"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Vaka Geçerlilik Süresi(Gün)
    /// </summary>
        public int? EpisodeClosingDayLimit
        {
            get { return (int?)this["EPISODECLOSINGDAYLIMIT"]; }
            set { this["EPISODECLOSINGDAYLIMIT"] = value; }
        }

    /// <summary>
    /// MHRS Kliniği
    /// </summary>
        public bool? IsMHRSClinic
        {
            get { return (bool?)this["ISMHRSCLINIC"]; }
            set { this["ISMHRSCLINIC"] = value; }
        }

    /// <summary>
    /// Uzmanlık Bazlı Ekranı Varsa Buradan Seçilir
    /// </summary>
        public SpecialityBasedObjectEnum? SpecialityBasedObjectType
        {
            get { return (SpecialityBasedObjectEnum?)(int?)this["SPECIALITYBASEDOBJECTTYPE"]; }
            set { this["SPECIALITYBASEDOBJECTTYPE"] = value; }
        }

    /// <summary>
    /// Vakabaşı Hizmeti Gerektirir
    /// </summary>
        public bool? IsBulletin
        {
            get { return (bool?)this["ISBULLETIN"]; }
            set { this["ISBULLETIN"] = value; }
        }

        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikler SKRSKlinik
        {
            get { return (SKRSKlinikler)((ITTObject)this).GetParent("SKRSKLINIK"); }
            set { this["SKRSKLINIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branş İdari Sorumlusu
    /// </summary>
        public ResUser SpecialityResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALITYRESPONSIBLEUSER"); }
            set { this["SPECIALITYRESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIIMSpecialitiesCollection()
        {
            _IIMSpecialities = new IIMSpeciality.ChildIIMSpecialityCollection(this, new Guid("bf08c437-63ec-412a-ba8b-52b3815382e9"));
            ((ITTChildObjectCollection)_IIMSpecialities).GetChildren();
        }

        protected IIMSpeciality.ChildIIMSpecialityCollection _IIMSpecialities = null;
    /// <summary>
    /// Child collection for Kuralın Branş bilgisi
    /// </summary>
        public IIMSpeciality.ChildIIMSpecialityCollection IIMSpecialities
        {
            get
            {
                if (_IIMSpecialities == null)
                    CreateIIMSpecialitiesCollection();
                return _IIMSpecialities;
            }
        }

        virtual protected void CreateComplaintDefinitionsCollection()
        {
            _ComplaintDefinitions = new ComplaintDefinition.ChildComplaintDefinitionCollection(this, new Guid("238124f6-8ce5-4e6b-9b69-69df2c9b77ce"));
            ((ITTChildObjectCollection)_ComplaintDefinitions).GetChildren();
        }

        protected ComplaintDefinition.ChildComplaintDefinitionCollection _ComplaintDefinitions = null;
        public ComplaintDefinition.ChildComplaintDefinitionCollection ComplaintDefinitions
        {
            get
            {
                if (_ComplaintDefinitions == null)
                    CreateComplaintDefinitionsCollection();
                return _ComplaintDefinitions;
            }
        }

        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("f0018ce4-33f9-4ec3-a1aa-c93d80163749"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
    /// <summary>
    /// Child collection for Takibin Branş bilgisi
    /// </summary>
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        virtual protected void CreateDoktorlarCollection()
        {
            _Doktorlar = new Doktor.ChildDoktorCollection(this, new Guid("f67d4702-ffd9-4d6b-9cce-cea63c5f7711"));
            ((ITTChildObjectCollection)_Doktorlar).GetChildren();
        }

        protected Doktor.ChildDoktorCollection _Doktorlar = null;
        public Doktor.ChildDoktorCollection Doktorlar
        {
            get
            {
                if (_Doktorlar == null)
                    CreateDoktorlarCollection();
                return _Doktorlar;
            }
        }

        virtual protected void CreateResourceSpecialitiesCollection()
        {
            _ResourceSpecialities = new ResourceSpecialityGrid.ChildResourceSpecialityGridCollection(this, new Guid("f5ecc13f-ef05-4dba-9c57-cf837ba27490"));
            ((ITTChildObjectCollection)_ResourceSpecialities).GetChildren();
        }

        protected ResourceSpecialityGrid.ChildResourceSpecialityGridCollection _ResourceSpecialities = null;
        public ResourceSpecialityGrid.ChildResourceSpecialityGridCollection ResourceSpecialities
        {
            get
            {
                if (_ResourceSpecialities == null)
                    CreateResourceSpecialitiesCollection();
                return _ResourceSpecialities;
            }
        }

        virtual protected void CreateDisabledReportSpecialCollection()
        {
            _DisabledReportSpecial = new DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection(this, new Guid("9c0f5617-b9fd-4505-ba92-8768061ed3f1"));
            ((ITTChildObjectCollection)_DisabledReportSpecial).GetChildren();
        }

        protected DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection _DisabledReportSpecial = null;
        public DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection DisabledReportSpecial
        {
            get
            {
                if (_DisabledReportSpecial == null)
                    CreateDisabledReportSpecialCollection();
                return _DisabledReportSpecial;
            }
        }

        virtual protected void CreateMedulaBranchDoctorMatchCollection()
        {
            _MedulaBranchDoctorMatch = new MedulaBranchDoctorMatchDef.ChildMedulaBranchDoctorMatchDefCollection(this, new Guid("566768f8-a7b3-46e5-ab53-89a29856bf8f"));
            ((ITTChildObjectCollection)_MedulaBranchDoctorMatch).GetChildren();
        }

        protected MedulaBranchDoctorMatchDef.ChildMedulaBranchDoctorMatchDefCollection _MedulaBranchDoctorMatch = null;
        public MedulaBranchDoctorMatchDef.ChildMedulaBranchDoctorMatchDefCollection MedulaBranchDoctorMatch
        {
            get
            {
                if (_MedulaBranchDoctorMatch == null)
                    CreateMedulaBranchDoctorMatchCollection();
                return _MedulaBranchDoctorMatch;
            }
        }

        protected SpecialityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALITYDEFINITION", dataRow) { }
        protected SpecialityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALITYDEFINITION", dataRow, isImported) { }
        public SpecialityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialityDefinition() : base() { }

    }
}