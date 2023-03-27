
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReagentTypeDef")] 

    public  partial class ReagentTypeDef : BaseResDevDef
    {
        public class ReagentTypeDefList : TTObjectCollection<ReagentTypeDef> { }
                    
        public class ChildReagentTypeDefCollection : TTObject.TTChildObjectCollection<ReagentTypeDef>
        {
            public ChildReagentTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReagentTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReagentTypeDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetReagentTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReagentTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReagentTypeDef_Class() : base() { }
        }

        public static BindingList<ReagentTypeDef.GetReagentTypeDef_Class> GetReagentTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].QueryDefs["GetReagentTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReagentTypeDef.GetReagentTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReagentTypeDef.GetReagentTypeDef_Class> GetReagentTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].QueryDefs["GetReagentTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReagentTypeDef.GetReagentTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateReagentCostsCollection()
        {
            _ReagentCosts = new ReagentDetail.ChildReagentDetailCollection(this, new Guid("9b4fb3c8-58e2-4e05-b135-3109bec06390"));
            ((ITTChildObjectCollection)_ReagentCosts).GetChildren();
        }

        protected ReagentDetail.ChildReagentDetailCollection _ReagentCosts = null;
        public ReagentDetail.ChildReagentDetailCollection ReagentCosts
        {
            get
            {
                if (_ReagentCosts == null)
                    CreateReagentCostsCollection();
                return _ReagentCosts;
            }
        }

        protected ReagentTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReagentTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReagentTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReagentTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReagentTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REAGENTTYPEDEF", dataRow) { }
        protected ReagentTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REAGENTTYPEDEF", dataRow, isImported) { }
        public ReagentTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReagentTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReagentTypeDef() : base() { }

    }
}