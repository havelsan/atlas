
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabizPackageDefinition")] 

    public  partial class ENabizPackageDefinition : TTDefinitionSet
    {
        public class ENabizPackageDefinitionList : TTObjectCollection<ENabizPackageDefinition> { }
                    
        public class ChildENabizPackageDefinitionCollection : TTObject.TTChildObjectCollection<ENabizPackageDefinition>
        {
            public ChildENabizPackageDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizPackageDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetENabizPackageDefinitions_Class : TTReportNqlObject 
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

            public int? PackageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ENABIZPACKAGEDEFINITION"].AllPropertyDefs["PACKAGEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PackageName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ENABIZPACKAGEDEFINITION"].AllPropertyDefs["PACKAGENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetENabizPackageDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetENabizPackageDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetENabizPackageDefinitions_Class() : base() { }
        }

        public static BindingList<ENabizPackageDefinition.GetENabizPackageDefinitions_Class> GetENabizPackageDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ENABIZPACKAGEDEFINITION"].QueryDefs["GetENabizPackageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ENabizPackageDefinition.GetENabizPackageDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ENabizPackageDefinition.GetENabizPackageDefinitions_Class> GetENabizPackageDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ENABIZPACKAGEDEFINITION"].QueryDefs["GetENabizPackageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ENabizPackageDefinition.GetENabizPackageDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Paket Kodu
    /// </summary>
        public int? PackageID
        {
            get { return (int?)this["PACKAGEID"]; }
            set { this["PACKAGEID"] = value; }
        }

        public string PackageName
        {
            get { return (string)this["PACKAGENAME"]; }
            set { this["PACKAGENAME"] = value; }
        }

        protected ENabizPackageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabizPackageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabizPackageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabizPackageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabizPackageDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZPACKAGEDEFINITION", dataRow) { }
        protected ENabizPackageDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZPACKAGEDEFINITION", dataRow, isImported) { }
        public ENabizPackageDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabizPackageDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabizPackageDefinition() : base() { }

    }
}