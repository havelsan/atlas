
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CodeValue")] 

    /// <summary>
    /// ESAW Kod Değerleri
    /// </summary>
    public  partial class CodeValue : TerminologyManagerDef
    {
        public class CodeValueList : TTObjectCollection<CodeValue> { }
                    
        public class ChildCodeValueCollection : TTObject.TTChildObjectCollection<CodeValue>
        {
            public ChildCodeValueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCodeValueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCodeValue_Class : TTReportNqlObject 
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

            public string CodeValueCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODEVALUECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CODEVALUE"].AllPropertyDefs["CODEVALUECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CodeValueName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODEVALUENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CODEVALUE"].AllPropertyDefs["CODEVALUENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CodeTypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODETYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CODETYPE"].AllPropertyDefs["CODETYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kind
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CODETYPE"].AllPropertyDefs["KIND"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Codetypeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CODETYPEID"]);
                }
            }

            public GetCodeValue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCodeValue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCodeValue_Class() : base() { }
        }

        public static BindingList<CodeValue.GetCodeValue_Class> GetCodeValue(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CODEVALUE"].QueryDefs["GetCodeValue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CodeValue.GetCodeValue_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CodeValue.GetCodeValue_Class> GetCodeValue(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CODEVALUE"].QueryDefs["GetCodeValue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CodeValue.GetCodeValue_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string CodeValueCode
        {
            get { return (string)this["CODEVALUECODE"]; }
            set { this["CODEVALUECODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string CodeValueName
        {
            get { return (string)this["CODEVALUENAME"]; }
            set { this["CODEVALUENAME"] = value; }
        }

        public CodeType CodeType
        {
            get { return (CodeType)((ITTObject)this).GetParent("CODETYPE"); }
            set { this["CODETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CodeValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CodeValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CodeValue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CodeValue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CodeValue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CODEVALUE", dataRow) { }
        protected CodeValue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CODEVALUE", dataRow, isImported) { }
        public CodeValue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CodeValue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CodeValue() : base() { }

    }
}