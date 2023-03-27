
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityHealthProcedure")] 

    /// <summary>
    /// Halk Sağlığı Tetkik
    /// </summary>
    public  partial class CommunityHealthProcedure : TTObject
    {
        public class CommunityHealthProcedureList : TTObjectCollection<CommunityHealthProcedure> { }
                    
        public class ChildCommunityHealthProcedureCollection : TTObject.TTChildObjectCollection<CommunityHealthProcedure>
        {
            public ChildCommunityHealthProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityHealthProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCommunityHealthResultReportNQL_Class : TTReportNqlObject 
        {
            public string SamplePlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHREQUEST"].AllPropertyDefs["SAMPLEPLACE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHREQUEST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string SampleType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHREQUEST"].AllPropertyDefs["SAMPLETYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctorobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOROBJECTID"]);
                }
            }

            public string Category
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? CalcMeqAndMval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALCMEQANDMVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["CALCMEQANDMVAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTOBJECTID"]);
                }
            }

            public Guid? Ttobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TTOBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommunityHealthResultReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommunityHealthResultReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommunityHealthResultReportNQL_Class() : base() { }
        }

        public static BindingList<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class> GetCommunityHealthResultReportNQL(string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHPROCEDURE"].QueryDefs["GetCommunityHealthResultReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class> GetCommunityHealthResultReportNQL(TTObjectContext objectContext, string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHPROCEDURE"].QueryDefs["GetCommunityHealthResultReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public double? Result
        {
            get { return (double?)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

        public CommunityHealthTestDefinition ProcedureObject
        {
            get { return (CommunityHealthTestDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CommunityHealthRequest Request
        {
            get { return (CommunityHealthRequest)((ITTObject)this).GetParent("REQUEST"); }
            set { this["REQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CommunityHealthProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityHealthProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityHealthProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityHealthProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityHealthProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYHEALTHPROCEDURE", dataRow) { }
        protected CommunityHealthProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYHEALTHPROCEDURE", dataRow, isImported) { }
        public CommunityHealthProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityHealthProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityHealthProcedure() : base() { }

    }
}