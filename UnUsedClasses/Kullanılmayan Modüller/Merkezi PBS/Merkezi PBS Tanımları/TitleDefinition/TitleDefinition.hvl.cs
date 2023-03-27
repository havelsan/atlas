
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TitleDefinition")] 

    public  partial class TitleDefinition : TerminologyManagerDef
    {
        public class TitleDefinitionList : TTObjectCollection<TitleDefinition> { }
                    
        public class ChildTitleDefinitionCollection : TTObject.TTChildObjectCollection<TitleDefinition>
        {
            public ChildTitleDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTitleDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTitleDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SEQUENCE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].AllPropertyDefs["SEQUENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetTitleDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTitleDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTitleDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetTitleDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SEQUENCE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].AllPropertyDefs["SEQUENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetTitleDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetTitleDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetTitleDefinition_Class() : base() { }
        }

        public static BindingList<TitleDefinition.GetTitleDefinitionList_Class> GetTitleDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].QueryDefs["GetTitleDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleDefinition.GetTitleDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TitleDefinition.GetTitleDefinitionList_Class> GetTitleDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].QueryDefs["GetTitleDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleDefinition.GetTitleDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TitleDefinition.OLAP_GetTitleDefinition_Class> OLAP_GetTitleDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].QueryDefs["OLAP_GetTitleDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleDefinition.OLAP_GetTitleDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TitleDefinition.OLAP_GetTitleDefinition_Class> OLAP_GetTitleDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEDEFINITION"].QueryDefs["OLAP_GetTitleDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleDefinition.OLAP_GetTitleDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? SEQUENCE
        {
            get { return (int?)this["SEQUENCE"]; }
            set { this["SEQUENCE"] = value; }
        }

        public string DESCRIPTION
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string USERTITLEENUMS
        {
            get { return (string)this["USERTITLEENUMS"]; }
            set { this["USERTITLEENUMS"] = value; }
        }

        public int? SECATTANDANCE
        {
            get { return (int?)this["SECATTANDANCE"]; }
            set { this["SECATTANDANCE"] = value; }
        }

        protected TitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TitleDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TITLEDEFINITION", dataRow) { }
        protected TitleDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TITLEDEFINITION", dataRow, isImported) { }
        public TitleDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TitleDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TitleDefinition() : base() { }

    }
}