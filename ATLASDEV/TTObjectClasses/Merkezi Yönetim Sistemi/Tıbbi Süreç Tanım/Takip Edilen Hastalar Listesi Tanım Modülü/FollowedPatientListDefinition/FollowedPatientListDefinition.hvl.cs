
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FollowedPatientListDefinition")] 

    /// <summary>
    /// Takip Edilen Hastalar Listesi Tanım Ekranı
    /// </summary>
    public  partial class FollowedPatientListDefinition : TTDefinitionSet
    {
        public class FollowedPatientListDefinitionList : TTObjectCollection<FollowedPatientListDefinition> { }
                    
        public class ChildFollowedPatientListDefinitionCollection : TTObject.TTChildObjectCollection<FollowedPatientListDefinition>
        {
            public ChildFollowedPatientListDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFollowedPatientListDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFollowedPatientListDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFollowedPatientListDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFollowedPatientListDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFollowedPatientListDefinitionNQL_Class() : base() { }
        }

        public static BindingList<FollowedPatientListDefinition.GetFollowedPatientListDefinitionNQL_Class> GetFollowedPatientListDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].QueryDefs["GetFollowedPatientListDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FollowedPatientListDefinition.GetFollowedPatientListDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FollowedPatientListDefinition.GetFollowedPatientListDefinitionNQL_Class> GetFollowedPatientListDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].QueryDefs["GetFollowedPatientListDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FollowedPatientListDefinition.GetFollowedPatientListDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FollowedPatientListDefinition> GetFollowedPatientListDefinitionForm(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].QueryDefs["GetFollowedPatientListDefinitionForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FollowedPatientListDefinition>(queryDef, paramList);
        }

        public static BindingList<FollowedPatientListDefinition> GetFollowedPatientListByUniqueRefNo(TTObjectContext objectContext, string UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWEDPATIENTLISTDEFINITION"].QueryDefs["GetFollowedPatientListByUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<FollowedPatientListDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// TC Kimlik Numarası
    /// </summary>
        public string UniqueRefNo
        {
            get { return (string)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected FollowedPatientListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FollowedPatientListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FollowedPatientListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FollowedPatientListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FollowedPatientListDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLLOWEDPATIENTLISTDEFINITION", dataRow) { }
        protected FollowedPatientListDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLLOWEDPATIENTLISTDEFINITION", dataRow, isImported) { }
        public FollowedPatientListDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FollowedPatientListDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FollowedPatientListDefinition() : base() { }

    }
}