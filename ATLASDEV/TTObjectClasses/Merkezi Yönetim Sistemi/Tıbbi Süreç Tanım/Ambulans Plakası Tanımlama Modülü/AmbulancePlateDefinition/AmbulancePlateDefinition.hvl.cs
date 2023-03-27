
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AmbulancePlateDefinition")] 

    public  partial class AmbulancePlateDefinition : TTDefinitionSet
    {
        public class AmbulancePlateDefinitionList : TTObjectCollection<AmbulancePlateDefinition> { }
                    
        public class ChildAmbulancePlateDefinitionCollection : TTObject.TTChildObjectCollection<AmbulancePlateDefinition>
        {
            public ChildAmbulancePlateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmbulancePlateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAmbulancePlateDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Plate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPLATEDEFINITION"].AllPropertyDefs["PLATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAmbulancePlateDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAmbulancePlateDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAmbulancePlateDefinition_Class() : base() { }
        }

        public static BindingList<AmbulancePlateDefinition.GetAmbulancePlateDefinition_Class> GetAmbulancePlateDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPLATEDEFINITION"].QueryDefs["GetAmbulancePlateDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AmbulancePlateDefinition.GetAmbulancePlateDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AmbulancePlateDefinition.GetAmbulancePlateDefinition_Class> GetAmbulancePlateDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPLATEDEFINITION"].QueryDefs["GetAmbulancePlateDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AmbulancePlateDefinition.GetAmbulancePlateDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Plaka
    /// </summary>
        public string Plate
        {
            get { return (string)this["PLATE"]; }
            set { this["PLATE"] = value; }
        }

        protected AmbulancePlateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AmbulancePlateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AmbulancePlateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AmbulancePlateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AmbulancePlateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMBULANCEPLATEDEFINITION", dataRow) { }
        protected AmbulancePlateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMBULANCEPLATEDEFINITION", dataRow, isImported) { }
        public AmbulancePlateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AmbulancePlateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AmbulancePlateDefinition() : base() { }

    }
}