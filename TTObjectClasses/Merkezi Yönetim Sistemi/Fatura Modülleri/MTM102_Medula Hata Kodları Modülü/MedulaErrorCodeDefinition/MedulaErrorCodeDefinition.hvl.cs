
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaErrorCodeDefinition")] 

    /// <summary>
    /// Medula Hata Kodları
    /// </summary>
    public  partial class MedulaErrorCodeDefinition : TerminologyManagerDef
    {
        public class MedulaErrorCodeDefinitionList : TTObjectCollection<MedulaErrorCodeDefinition> { }
                    
        public class ChildMedulaErrorCodeDefinitionCollection : TTObject.TTChildObjectCollection<MedulaErrorCodeDefinition>
        {
            public ChildMedulaErrorCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaErrorCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaErrorCode_Class : TTReportNqlObject 
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Controlled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].AllPropertyDefs["CONTROLLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].AllPropertyDefs["MESSAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UserNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].AllPropertyDefs["USERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaErrorCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaErrorCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaErrorCode_Class() : base() { }
        }

        public static BindingList<MedulaErrorCodeDefinition> GetAsyncIsTrueByErrorCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].QueryDefs["GetAsyncIsTrueByErrorCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaErrorCodeDefinition>(queryDef, paramList);
        }

        public static BindingList<MedulaErrorCodeDefinition.GetMedulaErrorCode_Class> GetMedulaErrorCode(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].QueryDefs["GetMedulaErrorCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaErrorCodeDefinition.GetMedulaErrorCode_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaErrorCodeDefinition.GetMedulaErrorCode_Class> GetMedulaErrorCode(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].QueryDefs["GetMedulaErrorCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaErrorCodeDefinition.GetMedulaErrorCode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaErrorCodeDefinition> GetMedulaErrorByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].QueryDefs["GetMedulaErrorByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaErrorCodeDefinition>(queryDef, paramList);
        }

        public static BindingList<MedulaErrorCodeDefinition> GetMedulaErrorByCodes(TTObjectContext objectContext, IList<string> Codes)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAERRORCODEDEFINITION"].QueryDefs["GetMedulaErrorByCodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODES", Codes);

            return ((ITTQuery)objectContext).QueryObjects<MedulaErrorCodeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public bool? Controlled
        {
            get { return (bool?)this["CONTROLLED"]; }
            set { this["CONTROLLED"] = value; }
        }

    /// <summary>
    /// Mesaj
    /// </summary>
        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kullanıcı Notu
    /// </summary>
        public string UserNote
        {
            get { return (string)this["USERNOTE"]; }
            set { this["USERNOTE"] = value; }
        }

        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAERRORCODEDEFINITION", dataRow) { }
        protected MedulaErrorCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAERRORCODEDEFINITION", dataRow, isImported) { }
        public MedulaErrorCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaErrorCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaErrorCodeDefinition() : base() { }

    }
}