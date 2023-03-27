
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHastaKabul")] 

    /// <summary>
    /// Hasta Kabul
    /// </summary>
    public  abstract  partial class BaseHastaKabul : BaseMedulaAction
    {
        public class BaseHastaKabulList : TTObjectCollection<BaseHastaKabul> { }
                    
        public class ChildBaseHastaKabulCollection : TTObject.TTChildObjectCollection<BaseHastaKabul>
        {
            public ChildBaseHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class HASTAKABULReportQuery_Class : TTReportNqlObject 
        {
            public long? MedulaActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].AllPropertyDefs["MEDULAACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? HealthFacilityID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHFACILITYID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].AllPropertyDefs["HEALTHFACILITYID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public HASTAKABULReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HASTAKABULReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HASTAKABULReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class TAKIPNUMARASIALINMISHASTALARReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? MedulaActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].AllPropertyDefs["MEDULAACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? HealthFacilityID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHFACILITYID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].AllPropertyDefs["HEALTHFACILITYID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string provizyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONGIRISDVO"].AllPropertyDefs["PROVIZYONTARIHI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string bransKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONGIRISDVO"].AllPropertyDefs["BRANSKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string hastaBasvuruNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTABASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONCEVAPDVO"].AllPropertyDefs["HASTABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONCEVAPDVO"].AllPropertyDefs["TAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["AD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["SOYAD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tcKimlikNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["TCKIMLIKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TAKIPNUMARASIALINMISHASTALARReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TAKIPNUMARASIALINMISHASTALARReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TAKIPNUMARASIALINMISHASTALARReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid SentMedula { get { return new Guid("5853a5d1-eced-4a74-8612-8ef52e99f6a6"); } }
            public static Guid New { get { return new Guid("8a5d8f68-7a40-4611-9c33-3575cf4a45a4"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("bec40edb-77f6-4769-a121-f51db3bc0239"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ca3a1a23-9ef1-4fba-b024-8e7551324059"); } }
            public static Guid Cancelled { get { return new Guid("5bde074e-fcba-4fd9-bef1-1d68f93c826e"); } }
            public static Guid SentServer { get { return new Guid("d99d3a60-06af-4331-ac30-a10c275ef8bd"); } }
        }

        public static BindingList<BaseHastaKabul> GetBaseHastaKabulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].QueryDefs["GetBaseHastaKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseHastaKabul>(queryDef, paramList);
        }

        public static BindingList<BaseHastaKabul.HASTAKABULReportQuery_Class> HASTAKABULReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].QueryDefs["HASTAKABULReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseHastaKabul.HASTAKABULReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseHastaKabul.HASTAKABULReportQuery_Class> HASTAKABULReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].QueryDefs["HASTAKABULReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseHastaKabul.HASTAKABULReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class> TAKIPNUMARASIALINMISHASTALARReportQuery(DateTime STARTDATE, DateTime ENDDATE, int HEALTHFACILITYID, int BRANSKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].QueryDefs["TAKIPNUMARASIALINMISHASTALARReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("BRANSKODU", BRANSKODU);

            return TTReportNqlObject.QueryObjects<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class> TAKIPNUMARASIALINMISHASTALARReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int HEALTHFACILITYID, int BRANSKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHASTAKABUL"].QueryDefs["TAKIPNUMARASIALINMISHASTALARReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("BRANSKODU", BRANSKODU);

            return TTReportNqlObject.QueryObjects<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Provizyon Giriş
    /// </summary>
        public ProvizyonGirisDVO provizyonGirisDVO
        {
            get { return (ProvizyonGirisDVO)((ITTObject)this).GetParent("PROVIZYONGIRISDVO"); }
            set { this["PROVIZYONGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHASTAKABUL", dataRow) { }
        protected BaseHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHASTAKABUL", dataRow, isImported) { }
        public BaseHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHastaKabul() : base() { }

    }
}