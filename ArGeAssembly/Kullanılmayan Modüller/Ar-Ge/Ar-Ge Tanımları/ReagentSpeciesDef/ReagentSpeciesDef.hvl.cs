
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReagentSpeciesDef")] 

    public  partial class ReagentSpeciesDef : BaseResDevDef
    {
        public class ReagentSpeciesDefList : TTObjectCollection<ReagentSpeciesDef> { }
                    
        public class ChildReagentSpeciesDefCollection : TTObject.TTChildObjectCollection<ReagentSpeciesDef>
        {
            public ChildReagentSpeciesDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReagentSpeciesDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReagentSpeciesDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTSPECIESDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTSPECIESDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Typecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REAGENTTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetReagentSpeciesDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReagentSpeciesDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReagentSpeciesDef_Class() : base() { }
        }

        public static BindingList<ReagentSpeciesDef.GetReagentSpeciesDef_Class> GetReagentSpeciesDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REAGENTSPECIESDEF"].QueryDefs["GetReagentSpeciesDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReagentSpeciesDef.GetReagentSpeciesDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReagentSpeciesDef.GetReagentSpeciesDef_Class> GetReagentSpeciesDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REAGENTSPECIESDEF"].QueryDefs["GetReagentSpeciesDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReagentSpeciesDef.GetReagentSpeciesDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public ReagentTypeDef ReagentTypes
        {
            get { return (ReagentTypeDef)((ITTObject)this).GetParent("REAGENTTYPES"); }
            set { this["REAGENTTYPES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReagentCostsCollection()
        {
            _ReagentCosts = new ReagentDetail.ChildReagentDetailCollection(this, new Guid("742ef8e1-ccf7-4e17-868d-323b2f0acf24"));
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

        protected ReagentSpeciesDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReagentSpeciesDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReagentSpeciesDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReagentSpeciesDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReagentSpeciesDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REAGENTSPECIESDEF", dataRow) { }
        protected ReagentSpeciesDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REAGENTSPECIESDEF", dataRow, isImported) { }
        public ReagentSpeciesDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReagentSpeciesDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReagentSpeciesDef() : base() { }

    }
}