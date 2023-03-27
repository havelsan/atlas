
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GlaskowComaScaleDefinition")] 

    public  partial class GlaskowComaScaleDefinition : TerminologyManagerDef
    {
        public class GlaskowComaScaleDefinitionList : TTObjectCollection<GlaskowComaScaleDefinition> { }
                    
        public class ChildGlaskowComaScaleDefinitionCollection : TTObject.TTChildObjectCollection<GlaskowComaScaleDefinition>
        {
            public ChildGlaskowComaScaleDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGlaskowComaScaleDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGlaskowComaScaleDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GlaskowComaScaleTypeEnum? GKSType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GKSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].AllPropertyDefs["GKSTYPE"].DataType;
                    return (GlaskowComaScaleTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetGlaskowComaScaleDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGlaskowComaScaleDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGlaskowComaScaleDefinition_Class() : base() { }
        }

        public static BindingList<GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition_Class> GetGlaskowComaScaleDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].QueryDefs["GetGlaskowComaScaleDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition_Class> GetGlaskowComaScaleDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].QueryDefs["GetGlaskowComaScaleDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GlaskowComaScaleDefinition> GetGlasComaScaleDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASKOWCOMASCALEDEFINITION"].QueryDefs["GetGlasComaScaleDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<GlaskowComaScaleDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// GKS
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public GlaskowComaScaleTypeEnum? GKSType
        {
            get { return (GlaskowComaScaleTypeEnum?)(int?)this["GKSTYPE"]; }
            set { this["GKSTYPE"] = value; }
        }

    /// <summary>
    /// Puan
    /// </summary>
        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GLASKOWCOMASCALEDEFINITION", dataRow) { }
        protected GlaskowComaScaleDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GLASKOWCOMASCALEDEFINITION", dataRow, isImported) { }
        public GlaskowComaScaleDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GlaskowComaScaleDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GlaskowComaScaleDefinition() : base() { }

    }
}