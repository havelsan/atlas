
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PanoramaDefinition")] 

    public  partial class PanoramaDefinition : TerminologyManagerDef
    {
        public class PanoramaDefinitionList : TTObjectCollection<PanoramaDefinition> { }
                    
        public class ChildPanoramaDefinitionCollection : TTObject.TTChildObjectCollection<PanoramaDefinition>
        {
            public ChildPanoramaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPanoramaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPanoramaList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PANORAMADEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPanoramaList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPanoramaList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPanoramaList_Class() : base() { }
        }

        public static BindingList<PanoramaDefinition.GetPanoramaList_Class> GetPanoramaList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PANORAMADEFINITION"].QueryDefs["GetPanoramaList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PanoramaDefinition.GetPanoramaList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PanoramaDefinition.GetPanoramaList_Class> GetPanoramaList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PANORAMADEFINITION"].QueryDefs["GetPanoramaList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PanoramaDefinition.GetPanoramaList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

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

        protected PanoramaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PanoramaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PanoramaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PanoramaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PanoramaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PANORAMADEFINITION", dataRow) { }
        protected PanoramaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PANORAMADEFINITION", dataRow, isImported) { }
        public PanoramaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PanoramaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PanoramaDefinition() : base() { }

    }
}