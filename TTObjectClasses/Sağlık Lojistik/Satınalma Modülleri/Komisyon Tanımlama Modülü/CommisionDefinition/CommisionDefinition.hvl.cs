
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommisionDefinition")] 

    /// <summary>
    /// Komisyon Tanımlama
    /// </summary>
    public  partial class CommisionDefinition : TTDefinitionSet
    {
        public class CommisionDefinitionList : TTObjectCollection<CommisionDefinition> { }
                    
        public class ChildCommisionDefinitionCollection : TTObject.TTChildObjectCollection<CommisionDefinition>
        {
            public ChildCommisionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommisionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CommisionTypeDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public CommisionTypeEnum? CommisionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMISIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].AllPropertyDefs["COMMISIONTYPE"].DataType;
                    return (CommisionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CommisionTypeDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CommisionTypeDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CommisionTypeDefinitionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllCommisionDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CommisionTypeEnum? CommisionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMISIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].AllPropertyDefs["COMMISIONTYPE"].DataType;
                    return (CommisionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetAllCommisionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllCommisionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllCommisionDefinition_Class() : base() { }
        }

        public static BindingList<CommisionDefinition> GetCommisionByType(TTObjectContext objectContext, int COMMISIONTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].QueryDefs["GetCommisionByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COMMISIONTYPE", COMMISIONTYPE);

            return ((ITTQuery)objectContext).QueryObjects<CommisionDefinition>(queryDef, paramList);
        }

        public static BindingList<CommisionDefinition.CommisionTypeDefinitionNQL_Class> CommisionTypeDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].QueryDefs["CommisionTypeDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommisionDefinition.CommisionTypeDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommisionDefinition.CommisionTypeDefinitionNQL_Class> CommisionTypeDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].QueryDefs["CommisionTypeDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommisionDefinition.CommisionTypeDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommisionDefinition.GetAllCommisionDefinition_Class> GetAllCommisionDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].QueryDefs["GetAllCommisionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommisionDefinition.GetAllCommisionDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommisionDefinition.GetAllCommisionDefinition_Class> GetAllCommisionDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMISIONDEFINITION"].QueryDefs["GetAllCommisionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommisionDefinition.GetAllCommisionDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Komisyon Türü
    /// </summary>
        public CommisionTypeEnum? CommisionType
        {
            get { return (CommisionTypeEnum?)(int?)this["COMMISIONTYPE"]; }
            set { this["COMMISIONTYPE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateCommisionDefinitionMembersCollection()
        {
            _CommisionDefinitionMembers = new CommisionDefinitionMember.ChildCommisionDefinitionMemberCollection(this, new Guid("29fd24d4-8298-45c5-82f6-d59be0d239ad"));
            ((ITTChildObjectCollection)_CommisionDefinitionMembers).GetChildren();
        }

        protected CommisionDefinitionMember.ChildCommisionDefinitionMemberCollection _CommisionDefinitionMembers = null;
        public CommisionDefinitionMember.ChildCommisionDefinitionMemberCollection CommisionDefinitionMembers
        {
            get
            {
                if (_CommisionDefinitionMembers == null)
                    CreateCommisionDefinitionMembersCollection();
                return _CommisionDefinitionMembers;
            }
        }

        protected CommisionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommisionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommisionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommisionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommisionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMISIONDEFINITION", dataRow) { }
        protected CommisionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMISIONDEFINITION", dataRow, isImported) { }
        public CommisionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommisionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommisionDefinition() : base() { }

    }
}