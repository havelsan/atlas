
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyLabProcedureDef")] 

    public  partial class PathologyLabProcedureDef : TTDefinitionSet
    {
        public class PathologyLabProcedureDefList : TTObjectCollection<PathologyLabProcedureDef> { }
                    
        public class ChildPathologyLabProcedureDefCollection : TTObject.TTChildObjectCollection<PathologyLabProcedureDef>
        {
            public ChildPathologyLabProcedureDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyLabProcedureDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyLabProcedureDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLABPROCEDUREDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLABPROCEDUREDEF"].AllPropertyDefs["NAME"].DataType;
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

            public PathologyLabProcedureDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyLabProcedureDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyLabProcedureDefFormNQL_Class() : base() { }
        }

        public static BindingList<PathologyLabProcedureDef.PathologyLabProcedureDefFormNQL_Class> PathologyLabProcedureDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLABPROCEDUREDEF"].QueryDefs["PathologyLabProcedureDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyLabProcedureDef.PathologyLabProcedureDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyLabProcedureDef.PathologyLabProcedureDefFormNQL_Class> PathologyLabProcedureDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYLABPROCEDUREDEF"].QueryDefs["PathologyLabProcedureDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyLabProcedureDef.PathologyLabProcedureDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreatePathologyLabProcedureCollection()
        {
            _PathologyLabProcedure = new PathologyLabProcedure.ChildPathologyLabProcedureCollection(this, new Guid("64e9ebed-5b09-472e-bae1-a64a474f0780"));
            ((ITTChildObjectCollection)_PathologyLabProcedure).GetChildren();
        }

        protected PathologyLabProcedure.ChildPathologyLabProcedureCollection _PathologyLabProcedure = null;
    /// <summary>
    /// Child collection for Patoloji Lab Hizmet Tanım İlişkisi
    /// </summary>
        public PathologyLabProcedure.ChildPathologyLabProcedureCollection PathologyLabProcedure
        {
            get
            {
                if (_PathologyLabProcedure == null)
                    CreatePathologyLabProcedureCollection();
                return _PathologyLabProcedure;
            }
        }

        protected PathologyLabProcedureDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyLabProcedureDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyLabProcedureDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyLabProcedureDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyLabProcedureDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYLABPROCEDUREDEF", dataRow) { }
        protected PathologyLabProcedureDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYLABPROCEDUREDEF", dataRow, isImported) { }
        public PathologyLabProcedureDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyLabProcedureDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyLabProcedureDef() : base() { }

    }
}