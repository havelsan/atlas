
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresTypeMaterialMatchDef")] 

    /// <summary>
    /// Reçete Tipi / Malzeme Eşleştirme
    /// </summary>
    public  partial class PresTypeMaterialMatchDef : TerminologyManagerDef
    {
        public class PresTypeMaterialMatchDefList : TTObjectCollection<PresTypeMaterialMatchDef> { }
                    
        public class ChildPresTypeMaterialMatchDefCollection : TTObject.TTChildObjectCollection<PresTypeMaterialMatchDef>
        {
            public ChildPresTypeMaterialMatchDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresTypeMaterialMatchDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPresTypeMaterialMatchDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESTYPEMATERIALMATCHDEF"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPresTypeMaterialMatchDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPresTypeMaterialMatchDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPresTypeMaterialMatchDefList_Class() : base() { }
        }

        public static BindingList<PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class> GetPresTypeMaterialMatchDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESTYPEMATERIALMATCHDEF"].QueryDefs["GetPresTypeMaterialMatchDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class> GetPresTypeMaterialMatchDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESTYPEMATERIALMATCHDEF"].QueryDefs["GetPresTypeMaterialMatchDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PresTypeMaterialMatchDef.GetPresTypeMaterialMatchDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public PrescriptionTypeEnum? PrescriptionType
        {
            get { return (PrescriptionTypeEnum?)(int?)this["PRESCRIPTIONTYPE"]; }
            set { this["PRESCRIPTIONTYPE"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESTYPEMATERIALMATCHDEF", dataRow) { }
        protected PresTypeMaterialMatchDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESTYPEMATERIALMATCHDEF", dataRow, isImported) { }
        public PresTypeMaterialMatchDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresTypeMaterialMatchDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresTypeMaterialMatchDef() : base() { }

    }
}