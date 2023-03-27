
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerDefinition")] 

    /// <summary>
    /// Kurum Tanımlama
    /// </summary>
    public  partial class PayerDefinition : TerminologyManagerDef
    {
        public class PayerDefinitionList : TTObjectCollection<PayerDefinition> { }
                    
        public class ChildPayerDefinitionCollection : TTObject.TTChildObjectCollection<PayerDefinition>
        {
            public ChildPayerDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPayerDefinitionsByCity_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
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

            public GetPayerDefinitionsByCity_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerDefinitionsByCity_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerDefinitionsByCity_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerDefinitions_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? DayOfSent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAYOFSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["DAYOFSENT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FaxNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["FAXNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? LimitOfInvoiceSummaryList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIMITOFINVOICESUMMARYLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["LIMITOFINVOICESUMMARYLIST"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TaxNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TaxOffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ZipCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZIPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ZIPCODE"].DataType;
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

            public GetPayerDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_PayerDefinition_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Type
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TYPE"]);
                }
            }

            public OLAP_PayerDefinition_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_PayerDefinition_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_PayerDefinition_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerDefinitionsWithCity_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPayerDefinitionsWithCity_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerDefinitionsWithCity_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerDefinitionsWithCity_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_PayerDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Type
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TYPE"]);
                }
            }

            public OLAP_PayerDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_PayerDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_PayerDefinition_Class() : base() { }
        }

        public static BindingList<PayerDefinition> GetByCodeInterval(TTObjectContext objectContext, long PARAMCODESTART, long PARAMCODEEND)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetByCodeInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCODESTART", PARAMCODESTART);
            paramList.Add("PARAMCODEEND", PARAMCODEEND);

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitionsByCity_Class> GetPayerDefinitionsByCity(IList<string> PARAMCITY, int PARAMCITYFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitionsByCity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCITY", PARAMCITY);
            paramList.Add("PARAMCITYFLAG", PARAMCITYFLAG);

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitionsByCity_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitionsByCity_Class> GetPayerDefinitionsByCity(TTObjectContext objectContext, IList<string> PARAMCITY, int PARAMCITYFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitionsByCity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCITY", PARAMCITY);
            paramList.Add("PARAMCITYFLAG", PARAMCITYFLAG);

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitionsByCity_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitions_Class> GetPayerDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitions_Class> GetPayerDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerDefinition.OLAP_PayerDefinition_WithDate_Class> OLAP_PayerDefinition_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["OLAP_PayerDefinition_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerDefinition.OLAP_PayerDefinition_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition.OLAP_PayerDefinition_WithDate_Class> OLAP_PayerDefinition_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["OLAP_PayerDefinition_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerDefinition.OLAP_PayerDefinition_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitionsWithCity_Class> GetPayerDefinitionsWithCity(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitionsWithCity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitionsWithCity_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerDefinition.GetPayerDefinitionsWithCity_Class> GetPayerDefinitionsWithCity(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefinitionsWithCity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.GetPayerDefinitionsWithCity_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerDefinition> GetActiveSGKPayers(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetActiveSGKPayers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerDefinition.OLAP_PayerDefinition_Class> OLAP_PayerDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["OLAP_PayerDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.OLAP_PayerDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition.OLAP_PayerDefinition_Class> OLAP_PayerDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["OLAP_PayerDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerDefinition.OLAP_PayerDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerDefinition> GetPayerDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPayerDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerDefinition> GetPaidObject(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetPaidObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerDefinition> GetByDevredilenKurum(TTObjectContext objectContext, Guid DEVREDILENKURUM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].QueryDefs["GetByDevredilenKurum"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEVREDILENKURUM", DEVREDILENKURUM);

            return ((ITTQuery)objectContext).QueryObjects<PayerDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kurum vergi numarası
    /// </summary>
        public string TaxNumber
        {
            get { return (string)this["TAXNUMBER"]; }
            set { this["TAXNUMBER"] = value; }
        }

    /// <summary>
    /// Kurum Posta Kodu
    /// </summary>
        public string ZipCode
        {
            get { return (string)this["ZIPCODE"]; }
            set { this["ZIPCODE"] = value; }
        }

    /// <summary>
    /// Kurum vergi dairesi
    /// </summary>
        public string TaxOffice
        {
            get { return (string)this["TAXOFFICE"]; }
            set { this["TAXOFFICE"] = value; }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Hastaya 5 TL katılım payı hizmeti oluşturulur
    /// </summary>
        public bool? GetPatientParticipation
        {
            get { return (bool?)this["GETPATIENTPARTICIPATION"]; }
            set { this["GETPATIENTPARTICIPATION"] = value; }
        }

    /// <summary>
    /// Kurum Fatura Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Fax numarası
    /// </summary>
        public string FaxNumber
        {
            get { return (string)this["FAXNUMBER"]; }
            set { this["FAXNUMBER"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

    /// <summary>
    /// Kurum kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Kurum sevk süresi
    /// </summary>
        public int? DayOfSent
        {
            get { return (int?)this["DAYOFSENT"]; }
            set { this["DAYOFSENT"] = value; }
        }

    /// <summary>
    /// Fatura icmal listesi maximum limit
    /// </summary>
        public int? LimitOfInvoiceSummaryList
        {
            get { return (int?)this["LIMITOFINVOICESUMMARYLIST"]; }
            set { this["LIMITOFINVOICESUMMARYLIST"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// İç Kurum (Ücretli,Ücretsiz vs. için)
    /// </summary>
        public bool? IsInternal
        {
            get { return (bool?)this["ISINTERNAL"]; }
            set { this["ISINTERNAL"] = value; }
        }

        public bool? OnlineInvoice
        {
            get { return (bool?)this["ONLINEINVOICE"]; }
            set { this["ONLINEINVOICE"] = value; }
        }

    /// <summary>
    /// Oluşan hasta payı AccountTransaction lar faturaya dahil edilmez
    /// </summary>
        public bool? CancelPatientShareAccTrx
        {
            get { return (bool?)this["CANCELPATIENTSHAREACCTRX"]; }
            set { this["CANCELPATIENTSHAREACCTRX"] = value; }
        }

    /// <summary>
    /// Tahsilat Süresi
    /// </summary>
        public int? PaymentDayLimit
        {
            get { return (int?)this["PAYMENTDAYLIMIT"]; }
            set { this["PAYMENTDAYLIMIT"] = value; }
        }

    /// <summary>
    /// Sağlık Turizmi
    /// </summary>
        public bool? HealthTourism
        {
            get { return (bool?)this["HEALTHTOURISM"]; }
            set { this["HEALTHTOURISM"] = value; }
        }

    /// <summary>
    /// Muhasebe İşlem Fişi Türü
    /// </summary>
        public MIFTypeEnum? MIFType
        {
            get { return (MIFTypeEnum?)(int?)this["MIFTYPE"]; }
            set { this["MIFTYPE"] = value; }
        }

    /// <summary>
    /// Kabul alırken tekrar seçime zorla
    /// </summary>
        public bool? SelectInPatientAdmission
        {
            get { return (bool?)this["SELECTINPATIENTADMISSION"]; }
            set { this["SELECTINPATIENTADMISSION"] = value; }
        }

    /// <summary>
    /// Kurum İli
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Türü
    /// </summary>
        public PayerTypeDefinition Type
        {
            get { return (PayerTypeDefinition)((ITTObject)this).GetParent("TYPE"); }
            set { this["TYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bağlı Olduğu Kurum
    /// </summary>
        public PayerDefinition ParentPayer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PARENTPAYER"); }
            set { this["PARENTPAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DevredilenKurum MedulaDevredilenKurum
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("MEDULADEVREDILENKURUM"); }
            set { this["MEDULADEVREDILENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe Gelir Hesap Kırınımı ile ilişki
    /// </summary>
        public RevenueSubAccountCodeDefinition RevenueSubAccountCode
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("REVENUESUBACCOUNTCODE"); }
            set { this["REVENUESUBACCOUNTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCollectedInvoiceCollection()
        {
            _CollectedInvoice = new CollectedInvoice.ChildCollectedInvoiceCollection(this, new Guid("92c6a233-061f-4819-8ea2-37d66e7f97a1"));
            ((ITTChildObjectCollection)_CollectedInvoice).GetChildren();
        }

        protected CollectedInvoice.ChildCollectedInvoiceCollection _CollectedInvoice = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public CollectedInvoice.ChildCollectedInvoiceCollection CollectedInvoice
        {
            get
            {
                if (_CollectedInvoice == null)
                    CreateCollectedInvoiceCollection();
                return _CollectedInvoice;
            }
        }

        virtual protected void CreatePayerInvoiceDocumentsCollection()
        {
            _PayerInvoiceDocuments = new PayerInvoiceDocument.ChildPayerInvoiceDocumentCollection(this, new Guid("9dc19463-3342-4570-9291-47fa0b2e257a"));
            ((ITTChildObjectCollection)_PayerInvoiceDocuments).GetChildren();
        }

        protected PayerInvoiceDocument.ChildPayerInvoiceDocumentCollection _PayerInvoiceDocuments = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public PayerInvoiceDocument.ChildPayerInvoiceDocumentCollection PayerInvoiceDocuments
        {
            get
            {
                if (_PayerInvoiceDocuments == null)
                    CreatePayerInvoiceDocumentsCollection();
                return _PayerInvoiceDocuments;
            }
        }

        virtual protected void CreatePayerAdvancePaymentCollection()
        {
            _PayerAdvancePayment = new PayerAdvancePayment.ChildPayerAdvancePaymentCollection(this, new Guid("1a3a6e72-b8f6-42b5-b97a-4d568ca8f23a"));
            ((ITTChildObjectCollection)_PayerAdvancePayment).GetChildren();
        }

        protected PayerAdvancePayment.ChildPayerAdvancePaymentCollection _PayerAdvancePayment = null;
    /// <summary>
    /// Child collection for Kurum ile ilişki
    /// </summary>
        public PayerAdvancePayment.ChildPayerAdvancePaymentCollection PayerAdvancePayment
        {
            get
            {
                if (_PayerAdvancePayment == null)
                    CreatePayerAdvancePaymentCollection();
                return _PayerAdvancePayment;
            }
        }

        virtual protected void CreateInvoiceCollectionDocumentsCollection()
        {
            _InvoiceCollectionDocuments = new InvoiceCollectionDocument.ChildInvoiceCollectionDocumentCollection(this, new Guid("39dd047b-e5bb-499c-a5dd-c19b7fb385b5"));
            ((ITTChildObjectCollection)_InvoiceCollectionDocuments).GetChildren();
        }

        protected InvoiceCollectionDocument.ChildInvoiceCollectionDocumentCollection _InvoiceCollectionDocuments = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public InvoiceCollectionDocument.ChildInvoiceCollectionDocumentCollection InvoiceCollectionDocuments
        {
            get
            {
                if (_InvoiceCollectionDocuments == null)
                    CreateInvoiceCollectionDocumentsCollection();
                return _InvoiceCollectionDocuments;
            }
        }

        virtual protected void CreateCollectedPatientListCollection()
        {
            _CollectedPatientList = new CollectedPatientList.ChildCollectedPatientListCollection(this, new Guid("c9c4a19a-d184-4fb8-9212-b81806933a17"));
            ((ITTChildObjectCollection)_CollectedPatientList).GetChildren();
        }

        protected CollectedPatientList.ChildCollectedPatientListCollection _CollectedPatientList = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public CollectedPatientList.ChildCollectedPatientListCollection CollectedPatientList
        {
            get
            {
                if (_CollectedPatientList == null)
                    CreateCollectedPatientListCollection();
                return _CollectedPatientList;
            }
        }

        virtual protected void CreateTransferFromPackageCollection()
        {
            _TransferFromPackage = new TransferFromPackage.ChildTransferFromPackageCollection(this, new Guid("415fdbfc-b0d6-406a-8299-cf12be36225d"));
            ((ITTChildObjectCollection)_TransferFromPackage).GetChildren();
        }

        protected TransferFromPackage.ChildTransferFromPackageCollection _TransferFromPackage = null;
    /// <summary>
    /// Child collection for Kurum ile ilişki
    /// </summary>
        public TransferFromPackage.ChildTransferFromPackageCollection TransferFromPackage
        {
            get
            {
                if (_TransferFromPackage == null)
                    CreateTransferFromPackageCollection();
                return _TransferFromPackage;
            }
        }

        virtual protected void CreateAPRCollection()
        {
            _APR = new AccountPayableReceivable.ChildAccountPayableReceivableCollection(this, new Guid("69b46443-7516-4beb-bf2f-cb965f439388"));
            ((ITTChildObjectCollection)_APR).GetChildren();
        }

        protected AccountPayableReceivable.ChildAccountPayableReceivableCollection _APR = null;
    /// <summary>
    /// Child collection for Kurum ile ilişki
    /// </summary>
        public AccountPayableReceivable.ChildAccountPayableReceivableCollection APR
        {
            get
            {
                if (_APR == null)
                    CreateAPRCollection();
                return _APR;
            }
        }

        virtual protected void CreatePayerProtocolDefinitionsCollection()
        {
            _PayerProtocolDefinitions = new PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection(this, new Guid("12d9e2f7-8e88-4df6-93b7-d4e7eb71a797"));
            ((ITTChildObjectCollection)_PayerProtocolDefinitions).GetChildren();
        }

        protected PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection _PayerProtocolDefinitions = null;
    /// <summary>
    /// Child collection for Payer ile Payerprotocol iliskisi
    /// </summary>
        public PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection PayerProtocolDefinitions
        {
            get
            {
                if (_PayerProtocolDefinitions == null)
                    CreatePayerProtocolDefinitionsCollection();
                return _PayerProtocolDefinitions;
            }
        }

        virtual protected void CreateEpisodeProtocolCollection()
        {
            _EpisodeProtocol = new EpisodeProtocol.ChildEpisodeProtocolCollection(this, new Guid("82741589-714d-4416-8344-c24d64d0b200"));
            ((ITTChildObjectCollection)_EpisodeProtocol).GetChildren();
        }

        protected EpisodeProtocol.ChildEpisodeProtocolCollection _EpisodeProtocol = null;
    /// <summary>
    /// Child collection for Kurum ile ilişki
    /// </summary>
        public EpisodeProtocol.ChildEpisodeProtocolCollection EpisodeProtocol
        {
            get
            {
                if (_EpisodeProtocol == null)
                    CreateEpisodeProtocolCollection();
                return _EpisodeProtocol;
            }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("244867a6-7e8c-448a-b5a2-cd244e15a555"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Kurum ile ilişki
    /// </summary>
        public SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection SendingInvoiceDetails
        {
            get
            {
                if (_SendingInvoiceDetails == null)
                    CreateSendingInvoiceDetailsCollection();
                return _SendingInvoiceDetails;
            }
        }

        virtual protected void CreatePayerInvoiceCollection()
        {
            _PayerInvoice = new PayerInvoice.ChildPayerInvoiceCollection(this, new Guid("d8cb416d-3d0f-4b49-8336-7e07dc43c41a"));
            ((ITTChildObjectCollection)_PayerInvoice).GetChildren();
        }

        protected PayerInvoice.ChildPayerInvoiceCollection _PayerInvoice = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoice
        {
            get
            {
                if (_PayerInvoice == null)
                    CreatePayerInvoiceCollection();
                return _PayerInvoice;
            }
        }

        virtual protected void CreateGeneralInvoiceCollection()
        {
            _GeneralInvoice = new GeneralInvoice.ChildGeneralInvoiceCollection(this, new Guid("4001f79c-b5ff-488e-b255-30b8d7b4ff0b"));
            ((ITTChildObjectCollection)_GeneralInvoice).GetChildren();
        }

        protected GeneralInvoice.ChildGeneralInvoiceCollection _GeneralInvoice = null;
    /// <summary>
    /// Child collection for Kurum Adı
    /// </summary>
        public GeneralInvoice.ChildGeneralInvoiceCollection GeneralInvoice
        {
            get
            {
                if (_GeneralInvoice == null)
                    CreateGeneralInvoiceCollection();
                return _GeneralInvoice;
            }
        }

        virtual protected void CreateInvoiceDocumentsCollection()
        {
            _InvoiceDocuments = new InvoiceDocument.ChildInvoiceDocumentCollection(this, new Guid("913b2a5d-bef7-463d-8603-d9bfd9dab7a1"));
            ((ITTChildObjectCollection)_InvoiceDocuments).GetChildren();
        }

        protected InvoiceDocument.ChildInvoiceDocumentCollection _InvoiceDocuments = null;
    /// <summary>
    /// Child collection for Kurumla İlişki
    /// </summary>
        public InvoiceDocument.ChildInvoiceDocumentCollection InvoiceDocuments
        {
            get
            {
                if (_InvoiceDocuments == null)
                    CreateInvoiceDocumentsCollection();
                return _InvoiceDocuments;
            }
        }

        virtual protected void CreateMedulaInvoiceTypeCollection()
        {
            _MedulaInvoiceType = new MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection(this, new Guid("73ee9bf2-6f4c-4aca-b0e9-f78db75319d1"));
            ((ITTChildObjectCollection)_MedulaInvoiceType).GetChildren();
        }

        protected MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection _MedulaInvoiceType = null;
        public MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection MedulaInvoiceType
        {
            get
            {
                if (_MedulaInvoiceType == null)
                    CreateMedulaInvoiceTypeCollection();
                return _MedulaInvoiceType;
            }
        }

        virtual protected void CreateManualInvoiceCollection()
        {
            _ManualInvoice = new ManualInvoice.ChildManualInvoiceCollection(this, new Guid("b3622a91-ae8c-47e8-9522-d2d808a49b2d"));
            ((ITTChildObjectCollection)_ManualInvoice).GetChildren();
        }

        protected ManualInvoice.ChildManualInvoiceCollection _ManualInvoice = null;
    /// <summary>
    /// Child collection for Kurum Adı
    /// </summary>
        public ManualInvoice.ChildManualInvoiceCollection ManualInvoice
        {
            get
            {
                if (_ManualInvoice == null)
                    CreateManualInvoiceCollection();
                return _ManualInvoice;
            }
        }

        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("c8ad2587-6899-424f-a8a1-0b7e1ebe29de"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        virtual protected void CreatePayerInvoicePaymentsCollection()
        {
            _PayerInvoicePayments = new PayerInvoicePayment.ChildPayerInvoicePaymentCollection(this, new Guid("a91ebebc-0744-48af-9b95-fe25b77ee5da"));
            ((ITTChildObjectCollection)_PayerInvoicePayments).GetChildren();
        }

        protected PayerInvoicePayment.ChildPayerInvoicePaymentCollection _PayerInvoicePayments = null;
    /// <summary>
    /// Child collection for Kurum
    /// </summary>
        public PayerInvoicePayment.ChildPayerInvoicePaymentCollection PayerInvoicePayments
        {
            get
            {
                if (_PayerInvoicePayments == null)
                    CreatePayerInvoicePaymentsCollection();
                return _PayerInvoicePayments;
            }
        }

        virtual protected void CreateMIFDetailsCollection()
        {
            _MIFDetails = new MIFDetail.ChildMIFDetailCollection(this, new Guid("8c6569ac-5467-4631-b5df-b1dc1582c7cd"));
            ((ITTChildObjectCollection)_MIFDetails).GetChildren();
        }

        protected MIFDetail.ChildMIFDetailCollection _MIFDetails = null;
        public MIFDetail.ChildMIFDetailCollection MIFDetails
        {
            get
            {
                if (_MIFDetails == null)
                    CreateMIFDetailsCollection();
                return _MIFDetails;
            }
        }

        protected PayerDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERDEFINITION", dataRow) { }
        protected PayerDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERDEFINITION", dataRow, isImported) { }
        protected PayerDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerDefinition() : base() { }

    }
}