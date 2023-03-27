
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PainPlaceDefition")] 

    /// <summary>
    /// Ağrının Yeri 
    /// </summary>
    public  partial class PainPlaceDefition : TerminologyManagerDef
    {
        public class PainPlaceDefitionList : TTObjectCollection<PainPlaceDefition> { }
                    
        public class ChildPainPlaceDefitionCollection : TTObject.TTChildObjectCollection<PainPlaceDefition>
        {
            public ChildPainPlaceDefitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPainPlaceDefitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPainPlaceDefition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINPLACEDEFITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPainPlaceDefition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPainPlaceDefition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPainPlaceDefition_Class() : base() { }
        }

        public static BindingList<PainPlaceDefition.GetPainPlaceDefition_Class> GetPainPlaceDefition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINPLACEDEFITION"].QueryDefs["GetPainPlaceDefition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainPlaceDefition.GetPainPlaceDefition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainPlaceDefition.GetPainPlaceDefition_Class> GetPainPlaceDefition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINPLACEDEFITION"].QueryDefs["GetPainPlaceDefition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainPlaceDefition.GetPainPlaceDefition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainPlaceDefition> GetPainPlaceDef(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINPLACEDEFITION"].QueryDefs["GetPainPlaceDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PainPlaceDefition>(queryDef, paramList);
        }

    /// <summary>
    /// Ağrının Yeri
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

        protected PainPlaceDefition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PainPlaceDefition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PainPlaceDefition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PainPlaceDefition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PainPlaceDefition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAINPLACEDEFITION", dataRow) { }
        protected PainPlaceDefition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAINPLACEDEFITION", dataRow, isImported) { }
        public PainPlaceDefition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PainPlaceDefition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PainPlaceDefition() : base() { }

    }
}