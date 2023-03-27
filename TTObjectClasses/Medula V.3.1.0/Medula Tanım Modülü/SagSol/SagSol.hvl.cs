
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SagSol")] 

    /// <summary>
    /// Sağ Sol
    /// </summary>
    public  partial class SagSol : BaseMedulaDefinition
    {
        public class SagSolList : TTObjectCollection<SagSol> { }
                    
        public class ChildSagSolCollection : TTObject.TTChildObjectCollection<SagSol>
        {
            public ChildSagSolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSagSolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSagSolDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sagSolKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAGSOLKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGSOL"].AllPropertyDefs["SAGSOLKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sagSolAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAGSOLADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGSOL"].AllPropertyDefs["SAGSOLADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSagSolDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSagSolDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSagSolDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SagSol.GetSagSolDefinitionQuery_Class> GetSagSolDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGSOL"].QueryDefs["GetSagSolDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SagSol.GetSagSolDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SagSol.GetSagSolDefinitionQuery_Class> GetSagSolDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGSOL"].QueryDefs["GetSagSolDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SagSol.GetSagSolDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string sagSolAdi_Shadow
        {
            get { return (string)this["SAGSOLADI_SHADOW"]; }
        }

    /// <summary>
    /// Sağ Sol Adı
    /// </summary>
        public string sagSolAdi
        {
            get { return (string)this["SAGSOLADI"]; }
            set { this["SAGSOLADI"] = value; }
        }

    /// <summary>
    /// Sağ Sol Kodu
    /// </summary>
        public string sagSolKodu
        {
            get { return (string)this["SAGSOLKODU"]; }
            set { this["SAGSOLKODU"] = value; }
        }

        protected SagSol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SagSol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SagSol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SagSol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SagSol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGSOL", dataRow) { }
        protected SagSol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGSOL", dataRow, isImported) { }
        public SagSol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SagSol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SagSol() : base() { }

    }
}