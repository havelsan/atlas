
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FallingDownRiskDefinition")] 

    public  partial class FallingDownRiskDefinition : TerminologyManagerDef
    {
        public class FallingDownRiskDefinitionList : TTObjectCollection<FallingDownRiskDefinition> { }
                    
        public class ChildFallingDownRiskDefinitionCollection : TTObject.TTChildObjectCollection<FallingDownRiskDefinition>
        {
            public ChildFallingDownRiskDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFallingDownRiskDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFallingDownRiskDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Score
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public FallingDownRiskTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (FallingDownRiskTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetFallingDownRiskDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFallingDownRiskDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFallingDownRiskDefinition_Class() : base() { }
        }

        public static BindingList<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class> GetFallingDownRiskDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].QueryDefs["GetFallingDownRiskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class> GetFallingDownRiskDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].QueryDefs["GetFallingDownRiskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FallingDownRiskDefinition> GetFallingDownRiskDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].QueryDefs["GetFallingDownRiskDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<FallingDownRiskDefinition>(queryDef, paramList);
        }

        public static BindingList<FallingDownRiskDefinition> GetFallingDownRiskDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FALLINGDOWNRISKDEFINITION"].QueryDefs["GetFallingDownRiskDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FallingDownRiskDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Puan
    /// </summary>
        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

    /// <summary>
    /// Risk Faktörü
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public FallingDownRiskTypeEnum? Type
        {
            get { return (FallingDownRiskTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected FallingDownRiskDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FallingDownRiskDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FallingDownRiskDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FallingDownRiskDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FallingDownRiskDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FALLINGDOWNRISKDEFINITION", dataRow) { }
        protected FallingDownRiskDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FALLINGDOWNRISKDEFINITION", dataRow, isImported) { }
        public FallingDownRiskDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FallingDownRiskDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FallingDownRiskDefinition() : base() { }

    }
}