
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTestDefinition")] 

    /// <summary>
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
    public  partial class LaboratoryTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class LaboratoryTestDefinitionList : TTObjectCollection<LaboratoryTestDefinition> { }
                    
        public class ChildLaboratoryTestDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryTestDefinition>
        {
            public ChildLaboratoryTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLaboratoryTestDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? IsPanel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPANEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISPANEL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsSubTest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSUBTEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISSUBTEST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryTestDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryTestDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryTestDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLabTestDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetLabTestDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLabTestDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLabTestDef_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLabTestDef_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetLabTestDef_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLabTestDef_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLabTestDef_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_TETKIK_Class : TTReportNqlObject 
        {
            public Guid? Tetkik_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Tetkik_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Loinc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LOINC_KODU"]);
                }
            }

            public string Hizmet_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIZMET_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Rapor_sonuc_sirasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RAPOR_SONUC_SIRASI"]);
                }
            }

            public Boolean? Iptal_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IPTAL_DURUMU"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public DateTime? Guncelleme_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_TETKIK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_TETKIK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_TETKIK_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabTestInstructionsNQL_Class : TTReportNqlObject 
        {
            public string TestDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["TESTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLabTestInstructionsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabTestInstructionsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabTestInstructionsNQL_Class() : base() { }
        }

        public static BindingList<LaboratoryTestDefinition.GetLaboratoryTestDefinitions_Class> GetLaboratoryTestDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetLaboratoryTestDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.GetLaboratoryTestDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryTestDefinition.GetLaboratoryTestDefinitions_Class> GetLaboratoryTestDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetLaboratoryTestDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.GetLaboratoryTestDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryTestDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryTestDefinition>(queryDef, paramList);
        }

        public static BindingList<LaboratoryTestDefinition> GetLaboratoryTestDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetLaboratoryTestDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryTestDefinition>(queryDef, paramList);
        }

        public static BindingList<LaboratoryTestDefinition.OLAP_GetLabTestDef_Class> OLAP_GetLabTestDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["OLAP_GetLabTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.OLAP_GetLabTestDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.OLAP_GetLabTestDef_Class> OLAP_GetLabTestDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["OLAP_GetLabTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.OLAP_GetLabTestDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.OLAP_GetLabTestDef_WithDate_Class> OLAP_GetLabTestDef_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["OLAP_GetLabTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.OLAP_GetLabTestDef_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.OLAP_GetLabTestDef_WithDate_Class> OLAP_GetLabTestDef_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["OLAP_GetLabTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.OLAP_GetLabTestDef_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.VEM_TETKIK_Class> VEM_TETKIK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["VEM_TETKIK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.VEM_TETKIK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.VEM_TETKIK_Class> VEM_TETKIK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["VEM_TETKIK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.VEM_TETKIK_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class> GetLabTestInstructionsNQL(string TESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetLabTestInstructionsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TESTOBJECTID", TESTOBJECTID);

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class> GetLabTestInstructionsNQL(TTObjectContext objectContext, string TESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetLabTestInstructionsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TESTOBJECTID", TESTOBJECTID);

            return TTReportNqlObject.QueryObjects<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTestDefinition> GetByFreeLOINCCode(TTObjectContext objectContext, string FREELOINCCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].QueryDefs["GetByFreeLOINCCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FREELOINCCODE", FREELOINCCODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryTestDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kültür Tetkik
    /// </summary>
        public bool? IsMicrobiologyTest
        {
            get { return (bool?)this["ISMICROBIOLOGYTEST"]; }
            set { this["ISMICROBIOLOGYTEST"] = value; }
        }

    /// <summary>
    /// Sonuç Tipi
    /// </summary>
        public LaboratoryResultTypeEnum? ResultType
        {
            get { return (LaboratoryResultTypeEnum?)(int?)this["RESULTTYPE"]; }
            set { this["RESULTTYPE"] = value; }
        }

    /// <summary>
    /// Kısıtlamalı Tetkik
    /// </summary>
        public bool? IsRestrictedTest
        {
            get { return (bool?)this["ISRESTRICTEDTEST"]; }
            set { this["ISRESTRICTEDTEST"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kontrolü
    /// </summary>
        public bool? IsSexControl
        {
            get { return (bool?)this["ISSEXCONTROL"]; }
            set { this["ISSEXCONTROL"] = value; }
        }

    /// <summary>
    /// Panel Tetkik
    /// </summary>
        public bool? IsPanel
        {
            get { return (bool?)this["ISPANEL"]; }
            set { this["ISPANEL"] = value; }
        }

    /// <summary>
    /// S.A.T Zorunlu
    /// </summary>
        public bool? IsSat
        {
            get { return (bool?)this["ISSAT"]; }
            set { this["ISSAT"] = value; }
        }

    /// <summary>
    /// Alt Tetkik
    /// </summary>
        public bool? IsSubTest
        {
            get { return (bool?)this["ISSUBTEST"]; }
            set { this["ISSUBTEST"] = value; }
        }

    /// <summary>
    /// Ayrı Sayfaya Basım
    /// </summary>
        public bool? IsPrintEveryPage
        {
            get { return (bool?)this["ISPRINTEVERYPAGE"]; }
            set { this["ISPRINTEVERYPAGE"] = value; }
        }

    /// <summary>
    /// Yuvarlama Değeri
    /// </summary>
        public long? RoundValue
        {
            get { return (long?)this["ROUNDVALUE"]; }
            set { this["ROUNDVALUE"] = value; }
        }

    /// <summary>
    /// Moleküler Tetkik
    /// </summary>
        public bool? IsMoleculerTest
        {
            get { return (bool?)this["ISMOLECULERTEST"]; }
            set { this["ISMOLECULERTEST"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kontrolü
    /// </summary>
        public SexEnum? SexControl
        {
            get { return (SexEnum?)(int?)this["SEXCONTROL"]; }
            set { this["SEXCONTROL"] = value; }
        }

    /// <summary>
    /// Sonuç Birimi
    /// </summary>
        public LaboratoryResultUnitEnum? ResultUnit
        {
            get { return (LaboratoryResultUnitEnum?)(int?)this["RESULTUNIT"]; }
            set { this["RESULTUNIT"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public bool? IsHeader
        {
            get { return (bool?)this["ISHEADER"]; }
            set { this["ISHEADER"] = value; }
        }

    /// <summary>
    /// Çok Referanslı
    /// </summary>
        public bool? IsMultiReference
        {
            get { return (bool?)this["ISMULTIREFERENCE"]; }
            set { this["ISMULTIREFERENCE"] = value; }
        }

    /// <summary>
    /// Yükleme Testi
    /// </summary>
        public bool? IsLoad
        {
            get { return (bool?)this["ISLOAD"]; }
            set { this["ISLOAD"] = value; }
        }

    /// <summary>
    /// Çalışmama Nedeni
    /// </summary>
        public string ReasonForPassive
        {
            get { return (string)this["REASONFORPASSIVE"]; }
            set { this["REASONFORPASSIVE"] = value; }
        }

    /// <summary>
    /// Tab Sırası
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Çalışılmayan
    /// </summary>
        public bool? IsPassiveNow
        {
            get { return (bool?)this["ISPASSIVENOW"]; }
            set { this["ISPASSIVENOW"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? DurationValue
        {
            get { return (int?)this["DURATIONVALUE"]; }
            set { this["DURATIONVALUE"] = value; }
        }

    /// <summary>
    /// Süre Kontrollü Tetkik
    /// </summary>
        public bool? IsDurationControl
        {
            get { return (bool?)this["ISDURATIONCONTROL"]; }
            set { this["ISDURATIONCONTROL"] = value; }
        }

    /// <summary>
    /// Bağımlı Test
    /// </summary>
        public bool? IsBoundedTest
        {
            get { return (bool?)this["ISBOUNDEDTEST"]; }
            set { this["ISBOUNDEDTEST"] = value; }
        }

    /// <summary>
    /// 24 Saatlik Test
    /// </summary>
        public bool? Is24HourTest
        {
            get { return (bool?)this["IS24HOURTEST"]; }
            set { this["IS24HOURTEST"] = value; }
        }

    /// <summary>
    /// Fiyat Çarpanı
    /// </summary>
        public long? PriceCoefficient
        {
            get { return (long?)this["PRICECOEFFICIENT"]; }
            set { this["PRICECOEFFICIENT"] = value; }
        }

    /// <summary>
    /// Kültür sonuçlarını tek rapor şeklinde gösterir
    /// </summary>
        public bool? PrintInOneReport
        {
            get { return (bool?)this["PRINTINONEREPORT"]; }
            set { this["PRINTINONEREPORT"] = value; }
        }

    /// <summary>
    /// İstek Yapan Doktorla Hizmet Kaydı Yap
    /// </summary>
        public bool? SendByRequestDoctor
        {
            get { return (bool?)this["SENDBYREQUESTDOCTOR"]; }
            set { this["SENDBYREQUESTDOCTOR"] = value; }
        }

    /// <summary>
    /// Diyabet Takip Formu Gerektirir
    /// </summary>
        public bool? RequiresDiabetesForm
        {
            get { return (bool?)this["REQUIRESDIABETESFORM"]; }
            set { this["REQUIRESDIABETESFORM"] = value; }
        }

    /// <summary>
    /// LBS'te Çalışmayacak
    /// </summary>
        public bool? NotLISTest
        {
            get { return (bool?)this["NOTLISTEST"]; }
            set { this["NOTLISTEST"] = value; }
        }

    /// <summary>
    /// İkili Tarama Formu Gerektirir
    /// </summary>
        public bool? RequiresBinaryScanForm
        {
            get { return (bool?)this["REQUIRESBINARYSCANFORM"]; }
            set { this["REQUIRESBINARYSCANFORM"] = value; }
        }

    /// <summary>
    /// Triple Test Form Gerektirir
    /// </summary>
        public bool? RequiresTripleTestForm
        {
            get { return (bool?)this["REQUIRESTRIPLETESTFORM"]; }
            set { this["REQUIRESTRIPLETESTFORM"] = value; }
        }

    /// <summary>
    /// Üre Nefes Testi Hasta Talimat Raporunu Gerektirir
    /// </summary>
        public bool? RequiresUreaBreathTestReport
        {
            get { return (bool?)this["REQUIRESUREABREATHTESTREPORT"]; }
            set { this["REQUIRESUREABREATHTESTREPORT"] = value; }
        }

    /// <summary>
    /// Tab Açıklaması
    /// </summary>
        public string TabDescription
        {
            get { return (string)this["TABDESCRIPTION"]; }
            set { this["TABDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tahlil Kodu Diğer Olan Alt Tetkiklerin Sonuçlarını Medulaya Gönder
    /// </summary>
        public bool? SendOtherResultsToMedula
        {
            get { return (bool?)this["SENDOTHERRESULTSTOMEDULA"]; }
            set { this["SENDOTHERRESULTSTOMEDULA"] = value; }
        }

    /// <summary>
    /// SKRS LOINC Kodları dışında LIS ta tanımlı kodları tutan alandır. LIS entegrasyonu için kullanılıyor. 
    /// </summary>
        public string FreeLOINCCode
        {
            get { return (string)this["FREELOINCCODE"]; }
            set { this["FREELOINCCODE"] = value; }
        }

    /// <summary>
    /// Bu test istendiğinde belli bir grup testin çalışılmasını sağlamak için tanımlandı. Örn. OGTT testleri
    /// </summary>
        public bool? IsGroupTest
        {
            get { return (bool?)this["ISGROUPTEST"]; }
            set { this["ISGROUPTEST"] = value; }
        }

    /// <summary>
    /// Test için gerekli talimatları içerir.
    /// </summary>
        public string TestDescription
        {
            get { return (string)this["TESTDESCRIPTION"]; }
            set { this["TESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yetişkinler için verilecek uyarı mesajı
    /// </summary>
        public string AdultAlert
        {
            get { return (string)this["ADULTALERT"]; }
            set { this["ADULTALERT"] = value; }
        }

    /// <summary>
    /// Yenidoğanlar için verilecek uyarı mesajı
    /// </summary>
        public string NewBornAlert
        {
            get { return (string)this["NEWBORNALERT"]; }
            set { this["NEWBORNALERT"] = value; }
        }

    /// <summary>
    /// Positif sonuç varsa kontrol eder
    /// </summary>
        public bool? AdultPositive
        {
            get { return (bool?)this["ADULTPOSITIVE"]; }
            set { this["ADULTPOSITIVE"] = value; }
        }

    /// <summary>
    /// Negatif sonuç varsa kontrol eder
    /// </summary>
        public bool? AdultNegative
        {
            get { return (bool?)this["ADULTNEGATIVE"]; }
            set { this["ADULTNEGATIVE"] = value; }
        }

    /// <summary>
    /// Negatif sonuç varsa kontrol eder
    /// </summary>
        public bool? NewBornNegative
        {
            get { return (bool?)this["NEWBORNNEGATIVE"]; }
            set { this["NEWBORNNEGATIVE"] = value; }
        }

    /// <summary>
    /// Positif sonuç varsa kontrol eder
    /// </summary>
        public bool? NewBornPositive
        {
            get { return (bool?)this["NEWBORNPOSITIVE"]; }
            set { this["NEWBORNPOSITIVE"] = value; }
        }

    /// <summary>
    /// Test Birimi İlişkisi
    /// </summary>
        public LaboratoryTestUnitDefinition TestUnit
        {
            get { return (LaboratoryTestUnitDefinition)((ITTObject)this).GetParent("TESTUNIT"); }
            set { this["TESTUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Environment Tanımı İlişkisi
    /// </summary>
        public LaboratoryEnvironmentDefinition Environment
        {
            get { return (LaboratoryEnvironmentDefinition)((ITTObject)this).GetParent("ENVIRONMENT"); }
            set { this["ENVIRONMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Tüpü İlişkisi
    /// </summary>
        public LaboratoryTestTubeDefinition TestTube
        {
            get { return (LaboratoryTestTubeDefinition)((ITTObject)this).GetParent("TESTTUBE"); }
            set { this["TESTTUBE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Türü İlişkisi
    /// </summary>
        public LaboratoryTestTypeDefinition TestType
        {
            get { return (LaboratoryTestTypeDefinition)((ITTObject)this).GetParent("TESTTYPE"); }
            set { this["TESTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Alt Türü İlişkisi
    /// </summary>
        public LaboratoryTestSubTypeDefinition TestSubType
        {
            get { return (LaboratoryTestSubTypeDefinition)((ITTObject)this).GetParent("TESTSUBTYPE"); }
            set { this["TESTSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Formu Tab Tanımı İlişkisi
    /// </summary>
        public LaboratoryRequestFormTabDefinition RequestFormTab
        {
            get { return (LaboratoryRequestFormTabDefinition)((ITTObject)this).GetParent("REQUESTFORMTAB"); }
            set { this["REQUESTFORMTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Branch
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANCH"); }
            set { this["BRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TahlilTipi TahlilTipi
        {
            get { return (TahlilTipi)((ITTObject)this).GetParent("TAHLILTIPI"); }
            set { this["TAHLILTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCinsiyet Sex
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("SEX"); }
            set { this["SEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBoundedTestsCollection()
        {
            _BoundedTests = new LaboratoryGridBoundedTestDefinition.ChildLaboratoryGridBoundedTestDefinitionCollection(this, new Guid("59ea4c32-b91a-4db0-8934-0c9b45b3b3f4"));
            ((ITTChildObjectCollection)_BoundedTests).GetChildren();
        }

        protected LaboratoryGridBoundedTestDefinition.ChildLaboratoryGridBoundedTestDefinitionCollection _BoundedTests = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryGridBoundedTestDefinition.ChildLaboratoryGridBoundedTestDefinitionCollection BoundedTests
        {
            get
            {
                if (_BoundedTests == null)
                    CreateBoundedTestsCollection();
                return _BoundedTests;
            }
        }

        virtual protected void CreateReferenceValuesCollection()
        {
            _ReferenceValues = new LaboratoryGridReferenceValueDefinition.ChildLaboratoryGridReferenceValueDefinitionCollection(this, new Guid("7276daa3-fd19-4438-97b5-1c32c110efdf"));
            ((ITTChildObjectCollection)_ReferenceValues).GetChildren();
        }

        protected LaboratoryGridReferenceValueDefinition.ChildLaboratoryGridReferenceValueDefinitionCollection _ReferenceValues = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryGridReferenceValueDefinition.ChildLaboratoryGridReferenceValueDefinitionCollection ReferenceValues
        {
            get
            {
                if (_ReferenceValues == null)
                    CreateReferenceValuesCollection();
                return _ReferenceValues;
            }
        }

        virtual protected void CreateRestrictedTestsCollection()
        {
            _RestrictedTests = new LaboratoryGridRestrictedTestDefiniton.ChildLaboratoryGridRestrictedTestDefinitonCollection(this, new Guid("ae50ae49-d75f-4626-ab4b-1c58af6eb54a"));
            ((ITTChildObjectCollection)_RestrictedTests).GetChildren();
        }

        protected LaboratoryGridRestrictedTestDefiniton.ChildLaboratoryGridRestrictedTestDefinitonCollection _RestrictedTests = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryGridRestrictedTestDefiniton.ChildLaboratoryGridRestrictedTestDefinitonCollection RestrictedTests
        {
            get
            {
                if (_RestrictedTests == null)
                    CreateRestrictedTestsCollection();
                return _RestrictedTests;
            }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new LaboratoryGridMaterialDefinition.ChildLaboratoryGridMaterialDefinitionCollection(this, new Guid("2c9ab814-1214-41a3-9d7b-4146eec51891"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected LaboratoryGridMaterialDefinition.ChildLaboratoryGridMaterialDefinitionCollection _Materials = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryGridMaterialDefinition.ChildLaboratoryGridMaterialDefinitionCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new LaboratoryGridDepartmentDefinition.ChildLaboratoryGridDepartmentDefinitionCollection(this, new Guid("44cdee78-50aa-4693-880a-5c3da1792d82"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected LaboratoryGridDepartmentDefinition.ChildLaboratoryGridDepartmentDefinitionCollection _Departments = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryGridDepartmentDefinition.ChildLaboratoryGridDepartmentDefinitionCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        virtual protected void CreateLaboratoryCollection()
        {
            _Laboratory = new LaboratoryRequest.ChildLaboratoryRequestCollection(this, new Guid("2d482684-62f3-4a9f-abc7-c589eddc10ed"));
            ((ITTChildObjectCollection)_Laboratory).GetChildren();
        }

        protected LaboratoryRequest.ChildLaboratoryRequestCollection _Laboratory = null;
    /// <summary>
    /// Child collection for Ana Test İlişkisi
    /// </summary>
        public LaboratoryRequest.ChildLaboratoryRequestCollection Laboratory
        {
            get
            {
                if (_Laboratory == null)
                    CreateLaboratoryCollection();
                return _Laboratory;
            }
        }

        virtual protected void CreateTabNamesCollection()
        {
            _TabNames = new LaboratoryTabNamesGrid.ChildLaboratoryTabNamesGridCollection(this, new Guid("47aedffc-a7b6-41e2-af4d-dd925147b0e7"));
            ((ITTChildObjectCollection)_TabNames).GetChildren();
        }

        protected LaboratoryTabNamesGrid.ChildLaboratoryTabNamesGridCollection _TabNames = null;
    /// <summary>
    /// Child collection for Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTabNamesGrid.ChildLaboratoryTabNamesGridCollection TabNames
        {
            get
            {
                if (_TabNames == null)
                    CreateTabNamesCollection();
                return _TabNames;
            }
        }

        virtual protected void CreatePanelTestsCollection()
        {
            _PanelTests = new LaboratoryGridPanelTestDefinition.ChildLaboratoryGridPanelTestDefinitionCollection(this, new Guid("a5168096-2712-41b4-ac2f-fac1de62f6fb"));
            ((ITTChildObjectCollection)_PanelTests).GetChildren();
        }

        protected LaboratoryGridPanelTestDefinition.ChildLaboratoryGridPanelTestDefinitionCollection _PanelTests = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryGridPanelTestDefinition.ChildLaboratoryGridPanelTestDefinitionCollection PanelTests
        {
            get
            {
                if (_PanelTests == null)
                    CreatePanelTestsCollection();
                return _PanelTests;
            }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new LaboratoryGridEquipmentDefinition.ChildLaboratoryGridEquipmentDefinitionCollection(this, new Guid("bd91ca21-bebd-4fdd-a8c4-db393f950e2a"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected LaboratoryGridEquipmentDefinition.ChildLaboratoryGridEquipmentDefinitionCollection _Equipments = null;
    /// <summary>
    /// Child collection for Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryGridEquipmentDefinition.ChildLaboratoryGridEquipmentDefinitionCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        virtual protected void CreateDietLabTestRelationDefinitonsCollection()
        {
            _DietLabTestRelationDefinitons = new DietLabTestRelationDefiniton.ChildDietLabTestRelationDefinitonCollection(this, new Guid("cfca49ed-2081-4ac9-9165-4ac7a37428dd"));
            ((ITTChildObjectCollection)_DietLabTestRelationDefinitons).GetChildren();
        }

        protected DietLabTestRelationDefiniton.ChildDietLabTestRelationDefinitonCollection _DietLabTestRelationDefinitons = null;
        public DietLabTestRelationDefiniton.ChildDietLabTestRelationDefinitonCollection DietLabTestRelationDefinitons
        {
            get
            {
                if (_DietLabTestRelationDefinitons == null)
                    CreateDietLabTestRelationDefinitonsCollection();
                return _DietLabTestRelationDefinitons;
            }
        }

        virtual protected void CreateBranchsCollection()
        {
            _Branchs = new LabGridSpecialityDefinition.ChildLabGridSpecialityDefinitionCollection(this, new Guid("e686b9db-e958-45ea-a499-c0d3c230afec"));
            ((ITTChildObjectCollection)_Branchs).GetChildren();
        }

        protected LabGridSpecialityDefinition.ChildLabGridSpecialityDefinitionCollection _Branchs = null;
    /// <summary>
    /// Child collection for Tahlil Branş İlişkisi
    /// </summary>
        public LabGridSpecialityDefinition.ChildLabGridSpecialityDefinitionCollection Branchs
        {
            get
            {
                if (_Branchs == null)
                    CreateBranchsCollection();
                return _Branchs;
            }
        }

        protected LaboratoryTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTESTDEFINITION", dataRow) { }
        protected LaboratoryTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTESTDEFINITION", dataRow, isImported) { }
        public LaboratoryTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTestDefinition() : base() { }

    }
}