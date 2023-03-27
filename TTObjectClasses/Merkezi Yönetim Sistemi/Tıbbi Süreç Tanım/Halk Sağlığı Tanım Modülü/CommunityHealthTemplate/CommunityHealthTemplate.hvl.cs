
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityHealthTemplate")] 

    public  partial class CommunityHealthTemplate : TTDefinitionSet
    {
        public class CommunityHealthTemplateList : TTObjectCollection<CommunityHealthTemplate> { }
                    
        public class ChildCommunityHealthTemplateCollection : TTObject.TTChildObjectCollection<CommunityHealthTemplate>
        {
            public ChildCommunityHealthTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityHealthTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CommunityHealthTemplateReportNQL_Class : TTReportNqlObject 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTEMPLATE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTEMPLATE"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CommunityHealthTemplateReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CommunityHealthTemplateReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CommunityHealthTemplateReportNQL_Class() : base() { }
        }

        public static BindingList<CommunityHealthTemplate> CommunityHealthTemlateDetailNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTEMPLATE"].QueryDefs["CommunityHealthTemlateDetailNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CommunityHealthTemplate>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CommunityHealthTemplate.CommunityHealthTemplateReportNQL_Class> CommunityHealthTemplateReportNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTEMPLATE"].QueryDefs["CommunityHealthTemplateReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTemplate.CommunityHealthTemplateReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommunityHealthTemplate.CommunityHealthTemplateReportNQL_Class> CommunityHealthTemplateReportNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTEMPLATE"].QueryDefs["CommunityHealthTemplateReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTemplate.CommunityHealthTemplateReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Şablon Adı
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

        virtual protected void CreateDetailsCollection()
        {
            _Details = new CommunityHealthTemlateDetail.ChildCommunityHealthTemlateDetailCollection(this, new Guid("cf22bbd4-6750-41b9-a7d6-51938d43b33a"));
            ((ITTChildObjectCollection)_Details).GetChildren();
        }

        protected CommunityHealthTemlateDetail.ChildCommunityHealthTemlateDetailCollection _Details = null;
        public CommunityHealthTemlateDetail.ChildCommunityHealthTemlateDetailCollection Details
        {
            get
            {
                if (_Details == null)
                    CreateDetailsCollection();
                return _Details;
            }
        }

        protected CommunityHealthTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityHealthTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityHealthTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityHealthTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityHealthTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYHEALTHTEMPLATE", dataRow) { }
        protected CommunityHealthTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYHEALTHTEMPLATE", dataRow, isImported) { }
        public CommunityHealthTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityHealthTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityHealthTemplate() : base() { }

    }
}