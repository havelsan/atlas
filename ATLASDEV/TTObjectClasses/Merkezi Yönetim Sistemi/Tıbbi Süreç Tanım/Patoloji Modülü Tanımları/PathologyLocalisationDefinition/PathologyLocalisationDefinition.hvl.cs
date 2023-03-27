
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyLocalisationDefinition")] 

    public  partial class PathologyLocalisationDefinition : TerminologyManagerDef
    {
        public class PathologyLocalisationDefinitionList : TTObjectCollection<PathologyLocalisationDefinition> { }
                    
        public class ChildPathologyLocalisationDefinitionCollection : TTObject.TTChildObjectCollection<PathologyLocalisationDefinition>
        {
            public ChildPathologyLocalisationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyLocalisationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyLocalisationDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLOCALISATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLOCALISATIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public PathologyLocalisationDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyLocalisationDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyLocalisationDefFormNQL_Class() : base() { }
        }

        public static BindingList<PathologyLocalisationDefinition.PathologyLocalisationDefFormNQL_Class> PathologyLocalisationDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLOCALISATIONDEFINITION"].QueryDefs["PathologyLocalisationDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyLocalisationDefinition.PathologyLocalisationDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyLocalisationDefinition.PathologyLocalisationDefFormNQL_Class> PathologyLocalisationDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLOCALISATIONDEFINITION"].QueryDefs["PathologyLocalisationDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyLocalisationDefinition.PathologyLocalisationDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyLocalisationDefinition> GetPathologyLocalisationDefByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLOCALISATIONDEFINITION"].QueryDefs["GetPathologyLocalisationDefByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PathologyLocalisationDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PathologyLocalisationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyLocalisationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyLocalisationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyLocalisationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyLocalisationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYLOCALISATIONDEFINITION", dataRow) { }
        protected PathologyLocalisationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYLOCALISATIONDEFINITION", dataRow, isImported) { }
        public PathologyLocalisationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyLocalisationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyLocalisationDefinition() : base() { }

    }
}