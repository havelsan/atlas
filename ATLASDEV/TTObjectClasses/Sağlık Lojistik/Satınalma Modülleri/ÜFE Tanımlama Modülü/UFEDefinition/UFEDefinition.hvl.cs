
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UFEDefinition")] 

    public  partial class UFEDefinition : TTDefinitionSet
    {
        public class UFEDefinitionList : TTObjectCollection<UFEDefinition> { }
                    
        public class ChildUFEDefinitionCollection : TTObject.TTChildObjectCollection<UFEDefinition>
        {
            public ChildUFEDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUFEDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class UFEDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? UFEYear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UFEYEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].AllPropertyDefs["UFEYEAR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MonthsEnum? UFEMonth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UFEMONTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].AllPropertyDefs["UFEMONTH"].DataType;
                    return (MonthsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? UFEIndex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UFEINDEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].AllPropertyDefs["UFEINDEX"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Ufesectordefname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UFESECTORDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFESECTORDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UFEDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UFEDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UFEDefFormNQL_Class() : base() { }
        }

        public static BindingList<UFEDefinition> GetUFEDefByYMS(TTObjectContext objectContext, int UFEMONTH, Guid UFESECTORDEFINITIONID, int UFEYEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].QueryDefs["GetUFEDefByYMS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UFEMONTH", UFEMONTH);
            paramList.Add("UFESECTORDEFINITIONID", UFESECTORDEFINITIONID);
            paramList.Add("UFEYEAR", UFEYEAR);

            return ((ITTQuery)objectContext).QueryObjects<UFEDefinition>(queryDef, paramList);
        }

        public static BindingList<UFEDefinition.UFEDefFormNQL_Class> UFEDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].QueryDefs["UFEDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UFEDefinition.UFEDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UFEDefinition.UFEDefFormNQL_Class> UFEDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UFEDEFINITION"].QueryDefs["UFEDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UFEDefinition.UFEDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? UFEYear
        {
            get { return (int?)this["UFEYEAR"]; }
            set { this["UFEYEAR"] = value; }
        }

    /// <summary>
    /// Ay
    /// </summary>
        public MonthsEnum? UFEMonth
        {
            get { return (MonthsEnum?)(int?)this["UFEMONTH"]; }
            set { this["UFEMONTH"] = value; }
        }

    /// <summary>
    /// Endeks
    /// </summary>
        public double? UFEIndex
        {
            get { return (double?)this["UFEINDEX"]; }
            set { this["UFEINDEX"] = value; }
        }

        public UFESectorDefinition UFESectorDefinition
        {
            get { return (UFESectorDefinition)((ITTObject)this).GetParent("UFESECTORDEFINITION"); }
            set { this["UFESECTORDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UFEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UFEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UFEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UFEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UFEDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UFEDEFINITION", dataRow) { }
        protected UFEDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UFEDEFINITION", dataRow, isImported) { }
        public UFEDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UFEDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UFEDefinition() : base() { }

    }
}