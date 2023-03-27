
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PainQualityDefinition")] 

    /// <summary>
    /// Ağrı Niteliği
    /// </summary>
    public  partial class PainQualityDefinition : TerminologyManagerDef
    {
        public class PainQualityDefinitionList : TTObjectCollection<PainQualityDefinition> { }
                    
        public class ChildPainQualityDefinitionCollection : TTObject.TTChildObjectCollection<PainQualityDefinition>
        {
            public ChildPainQualityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPainQualityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPainQuality_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINQUALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPainQuality_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPainQuality_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPainQuality_Class() : base() { }
        }

        public static BindingList<PainQualityDefinition.GetPainQuality_Class> GetPainQuality(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINQUALITYDEFINITION"].QueryDefs["GetPainQuality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainQualityDefinition.GetPainQuality_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainQualityDefinition.GetPainQuality_Class> GetPainQuality(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINQUALITYDEFINITION"].QueryDefs["GetPainQuality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainQualityDefinition.GetPainQuality_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ağrı Niteliği
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        protected PainQualityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PainQualityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PainQualityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PainQualityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PainQualityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAINQUALITYDEFINITION", dataRow) { }
        protected PainQualityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAINQUALITYDEFINITION", dataRow, isImported) { }
        public PainQualityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PainQualityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PainQualityDefinition() : base() { }

    }
}