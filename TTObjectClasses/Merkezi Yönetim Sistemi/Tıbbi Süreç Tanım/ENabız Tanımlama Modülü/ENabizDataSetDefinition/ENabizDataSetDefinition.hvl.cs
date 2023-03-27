
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabizDataSetDefinition")] 

    /// <summary>
    /// ENabız Veri Seti Tanımları
    /// </summary>
    public  partial class ENabizDataSetDefinition : TerminologyManagerDef
    {
        public class ENabizDataSetDefinitionList : TTObjectCollection<ENabizDataSetDefinition> { }
                    
        public class ChildENabizDataSetDefinitionCollection : TTObject.TTChildObjectCollection<ENabizDataSetDefinition>
        {
            public ChildENabizDataSetDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizDataSetDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetENabizDataSetDefinition_Class : TTReportNqlObject 
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

            public int? MSVSCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSVSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].AllPropertyDefs["MSVSCODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? PackageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].AllPropertyDefs["PACKAGEID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].AllPropertyDefs["PACKAGENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetENabizDataSetDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetENabizDataSetDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetENabizDataSetDefinition_Class() : base() { }
        }

        public static BindingList<ENabizDataSetDefinition> GetENabizDataSetDefinitionByMSVSCode(TTObjectContext objectContext, int MSVSCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].QueryDefs["GetENabizDataSetDefinitionByMSVSCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MSVSCODE", MSVSCODE);

            return ((ITTQuery)objectContext).QueryObjects<ENabizDataSetDefinition>(queryDef, paramList);
        }

        public static BindingList<ENabizDataSetDefinition.GetENabizDataSetDefinition_Class> GetENabizDataSetDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].QueryDefs["GetENabizDataSetDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ENabizDataSetDefinition.GetENabizDataSetDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ENabizDataSetDefinition.GetENabizDataSetDefinition_Class> GetENabizDataSetDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ENABIZDATASETDEFINITION"].QueryDefs["GetENabizDataSetDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ENabizDataSetDefinition.GetENabizDataSetDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// MSVS Kodu
    /// </summary>
        public int? MSVSCode
        {
            get { return (int?)this["MSVSCODE"]; }
            set { this["MSVSCODE"] = value; }
        }

    /// <summary>
    /// Paket ID
    /// </summary>
        public int? PackageID
        {
            get { return (int?)this["PACKAGEID"]; }
            set { this["PACKAGEID"] = value; }
        }

    /// <summary>
    /// Paket Adı 
    /// </summary>
        public string PackageName
        {
            get { return (string)this["PACKAGENAME"]; }
            set { this["PACKAGENAME"] = value; }
        }

        protected ENabizDataSetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabizDataSetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabizDataSetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabizDataSetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabizDataSetDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZDATASETDEFINITION", dataRow) { }
        protected ENabizDataSetDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZDATASETDEFINITION", dataRow, isImported) { }
        public ENabizDataSetDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabizDataSetDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabizDataSetDefinition() : base() { }

    }
}