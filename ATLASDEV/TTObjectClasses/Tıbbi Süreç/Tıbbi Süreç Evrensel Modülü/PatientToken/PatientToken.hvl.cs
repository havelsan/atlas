
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientToken")] 

    /// <summary>
    /// Hasta isimlerini içerir
    /// </summary>
    public  partial class PatientToken : TTObject
    {
        public class PatientTokenList : TTObjectCollection<PatientToken> { }
                    
        public class ChildPatientTokenCollection : TTObject.TTChildObjectCollection<PatientToken>
        {
            public ChildPatientTokenCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientTokenCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Token
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].AllPropertyDefs["TOKEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientTokenTypeEnum? TokenType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOKENTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].AllPropertyDefs["TOKENTYPE"].DataType;
                    return (PatientTokenTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public GetByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientByInjection_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public GetPatientByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByInjectionInternal_Class : TTReportNqlObject 
        {
            public string Token
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].AllPropertyDefs["TOKEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientTokenTypeEnum? TokenType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOKENTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].AllPropertyDefs["TOKENTYPE"].DataType;
                    return (PatientTokenTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public GetByInjectionInternal_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInjectionInternal_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInjectionInternal_Class() : base() { }
        }

        public static BindingList<PatientToken> GetByToken(TTObjectContext objectContext, string TOKEN)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByToken"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOKEN", TOKEN);

            return ((ITTQuery)objectContext).QueryObjects<PatientToken>(queryDef, paramList);
        }

        public static BindingList<PatientToken> GetByObjectID(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PatientToken>(queryDef, paramList);
        }

        public static BindingList<PatientToken.GetByInjection_Class> GetByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientToken.GetByInjection_Class> GetByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientToken.GetPatientByInjection_Class> GetPatientByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetPatientByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetPatientByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientToken.GetPatientByInjection_Class> GetPatientByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetPatientByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetPatientByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientToken.GetByInjectionInternal_Class> GetByInjectionInternal(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByInjectionInternal"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetByInjectionInternal_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientToken.GetByInjectionInternal_Class> GetByInjectionInternal(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTOKEN"].QueryDefs["GetByInjectionInternal"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientToken.GetByInjectionInternal_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İsim parçacığı
    /// </summary>
        public string Token
        {
            get { return (string)this["TOKEN"]; }
            set { this["TOKEN"] = value; }
        }

    /// <summary>
    /// Token tipi
    /// </summary>
        public PatientTokenTypeEnum? TokenType
        {
            get { return (PatientTokenTypeEnum?)(int?)this["TOKENTYPE"]; }
            set { this["TOKENTYPE"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientToken(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientToken(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientToken(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientToken(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientToken(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTTOKEN", dataRow) { }
        protected PatientToken(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTTOKEN", dataRow, isImported) { }
        public PatientToken(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientToken(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientToken() : base() { }

    }
}