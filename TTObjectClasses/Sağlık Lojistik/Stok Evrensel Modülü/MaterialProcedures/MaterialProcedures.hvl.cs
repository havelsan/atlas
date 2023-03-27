
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialProcedures")] 

    public  partial class MaterialProcedures : TTObject
    {
        public class MaterialProceduresList : TTObjectCollection<MaterialProcedures> { }
                    
        public class ChildMaterialProceduresCollection : TTObject.TTChildObjectCollection<MaterialProcedures>
        {
            public ChildMaterialProceduresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialProceduresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialProcedures_Class : TTReportNqlObject 
        {
            public string Pdname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pdobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PDOBJECTID"]);
                }
            }

            public string Matname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Matobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATOBJECTID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMaterialProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialProcedures_Class() : base() { }
        }

        public static BindingList<MaterialProcedures.GetMaterialProcedures_Class> GetMaterialProcedures(Guid Material, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPROCEDURES"].QueryDefs["GetMaterialProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", Material);

            return TTReportNqlObject.QueryObjects<MaterialProcedures.GetMaterialProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialProcedures.GetMaterialProcedures_Class> GetMaterialProcedures(TTObjectContext objectContext, Guid Material, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPROCEDURES"].QueryDefs["GetMaterialProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", Material);

            return TTReportNqlObject.QueryObjects<MaterialProcedures.GetMaterialProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialProcedures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALPROCEDURES", dataRow) { }
        protected MaterialProcedures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALPROCEDURES", dataRow, isImported) { }
        public MaterialProcedures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialProcedures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialProcedures() : base() { }

    }
}