
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeAccountAction")] 

    /// <summary>
    /// Hasta bazlı finansal işlemlerin ana sınıfı
    /// </summary>
    public  partial class EpisodeAccountAction : EpisodeAction
    {
        public class EpisodeAccountActionList : TTObjectCollection<EpisodeAccountAction> { }
                    
        public class ChildEpisodeAccountActionCollection : TTObject.TTChildObjectCollection<EpisodeAccountAction>
        {
            public ChildEpisodeAccountActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeAccountActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetForCashOfficePatientForm_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String Objectdefdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetForCashOfficePatientForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForCashOfficePatientForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForCashOfficePatientForm_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeWorkListNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Currency? Totalprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public CashOfficeWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeWorkListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeWorkListNQLNoDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public Currency? Totalprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public CashOfficeWorkListNQLNoDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeWorkListNQLNoDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeWorkListNQLNoDate_Class() : base() { }
        }

        public static BindingList<EpisodeAccountAction> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAccountAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAccountAction.GetForCashOfficePatientForm_Class> GetForCashOfficePatientForm(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["GetForCashOfficePatientForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.GetForCashOfficePatientForm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAccountAction.GetForCashOfficePatientForm_Class> GetForCashOfficePatientForm(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["GetForCashOfficePatientForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.GetForCashOfficePatientForm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAccountAction.CashOfficeWorkListNQL_Class> CashOfficeWorkListNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.CashOfficeWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAccountAction.CashOfficeWorkListNQL_Class> CashOfficeWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.CashOfficeWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class> CashOfficeWorkListNQLNoDate(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class> CashOfficeWorkListNQLNoDate(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yapılan toplam indirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Finansal işlemle ilgili açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Finansal işlemi yapan vezne adı
    /// </summary>
        public string CashOfficeName
        {
            get { return (string)this["CASHOFFICENAME"]; }
            set { this["CASHOFFICENAME"] = value; }
        }

    /// <summary>
    /// Finansal işlemin indirimli toplam tutarı
    /// </summary>
        public Currency? GeneralTotalPrice
        {
            get { return (Currency?)this["GENERALTOTALPRICE"]; }
            set { this["GENERALTOTALPRICE"] = value; }
        }

    /// <summary>
    /// Finansal işlemin indirimsiz toplam tutarı
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

        virtual protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("9766d920-a0ea-485c-ad1f-adc9e58c241d"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected AccountDocument.ChildAccountDocumentCollection _AccountDocuments = null;
    /// <summary>
    /// Child collection for Hasta bazlı finansal işlemle ilişki
    /// </summary>
        public AccountDocument.ChildAccountDocumentCollection AccountDocuments
        {
            get
            {
                if (_AccountDocuments == null)
                    CreateAccountDocumentsCollection();
                return _AccountDocuments;
            }
        }

        protected EpisodeAccountAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeAccountAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeAccountAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeAccountAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeAccountAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACCOUNTACTION", dataRow) { }
        protected EpisodeAccountAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACCOUNTACTION", dataRow, isImported) { }
        public EpisodeAccountAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeAccountAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeAccountAction() : base() { }

    }
}