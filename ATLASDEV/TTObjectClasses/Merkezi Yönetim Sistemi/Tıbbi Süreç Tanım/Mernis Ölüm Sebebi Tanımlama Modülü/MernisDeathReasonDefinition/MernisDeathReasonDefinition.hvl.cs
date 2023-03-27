
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MernisDeathReasonDefinition")] 

    /// <summary>
    /// Mernis Ölüm Sebepleri
    /// </summary>
    public  partial class MernisDeathReasonDefinition : TerminologyManagerDef
    {
        public class MernisDeathReasonDefinitionList : TTObjectCollection<MernisDeathReasonDefinition> { }
                    
        public class ChildMernisDeathReasonDefinitionCollection : TTObject.TTChildObjectCollection<MernisDeathReasonDefinition>
        {
            public ChildMernisDeathReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMernisDeathReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetMernisDeathReason_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ReasonName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].AllPropertyDefs["REASONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetMernisDeathReason_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMernisDeathReason_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMernisDeathReason_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMernisDeathReasonDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ReasonName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].AllPropertyDefs["REASONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMernisDeathReasonDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMernisDeathReasonDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMernisDeathReasonDefinition_Class() : base() { }
        }

        public static BindingList<MernisDeathReasonDefinition.OLAP_GetMernisDeathReason_Class> OLAP_GetMernisDeathReason(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].QueryDefs["OLAP_GetMernisDeathReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MernisDeathReasonDefinition.OLAP_GetMernisDeathReason_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MernisDeathReasonDefinition.OLAP_GetMernisDeathReason_Class> OLAP_GetMernisDeathReason(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].QueryDefs["OLAP_GetMernisDeathReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MernisDeathReasonDefinition.OLAP_GetMernisDeathReason_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MernisDeathReasonDefinition.GetMernisDeathReasonDefinition_Class> GetMernisDeathReasonDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].QueryDefs["GetMernisDeathReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MernisDeathReasonDefinition.GetMernisDeathReasonDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MernisDeathReasonDefinition.GetMernisDeathReasonDefinition_Class> GetMernisDeathReasonDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].QueryDefs["GetMernisDeathReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MernisDeathReasonDefinition.GetMernisDeathReasonDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MernisDeathReasonDefinition> GetMernisDeathReasnDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MERNISDEATHREASONDEFINITION"].QueryDefs["GetMernisDeathReasnDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MernisDeathReasonDefinition>(queryDef, paramList);
        }

        public string ReasonName_Shadow
        {
            get { return (string)this["REASONNAME_SHADOW"]; }
        }

    /// <summary>
    /// Ölüm Sebebi
    /// </summary>
        public string ReasonName
        {
            get { return (string)this["REASONNAME"]; }
            set { this["REASONNAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected MernisDeathReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MernisDeathReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MernisDeathReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MernisDeathReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MernisDeathReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MERNISDEATHREASONDEFINITION", dataRow) { }
        protected MernisDeathReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MERNISDEATHREASONDEFINITION", dataRow, isImported) { }
        public MernisDeathReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MernisDeathReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MernisDeathReasonDefinition() : base() { }

    }
}