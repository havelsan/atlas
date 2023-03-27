
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CodeType")] 

    /// <summary>
    /// ESAW Kod Tipi
    /// </summary>
    public  partial class CodeType : TerminologyManagerDef
    {
        public class CodeTypeList : TTObjectCollection<CodeType> { }
                    
        public class ChildCodeTypeCollection : TTObject.TTChildObjectCollection<CodeType>
        {
            public ChildCodeTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCodeTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCodeTypes_Class : TTReportNqlObject 
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

            public string CodeTypeCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODETYPECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CODETYPE"].AllPropertyDefs["CODETYPECODE"].DataType;
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

            public GetCodeTypes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCodeTypes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCodeTypes_Class() : base() { }
        }

        public static BindingList<CodeType.GetCodeTypes_Class> GetCodeTypes(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CODETYPE"].QueryDefs["GetCodeTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CodeType.GetCodeTypes_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CodeType.GetCodeTypes_Class> GetCodeTypes(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CODETYPE"].QueryDefs["GetCodeTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CodeType.GetCodeTypes_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kod Tipi Adı
    /// </summary>
        public string CodeTypeName
        {
            get { return (string)this["CODETYPENAME"]; }
            set { this["CODETYPENAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string CodeTypeCode
        {
            get { return (string)this["CODETYPECODE"]; }
            set { this["CODETYPECODE"] = value; }
        }

    /// <summary>
    /// Türü
    /// </summary>
        public string Kind
        {
            get { return (string)this["KIND"]; }
            set { this["KIND"] = value; }
        }

        virtual protected void CreateCodeValueCollection()
        {
            _CodeValue = new CodeValue.ChildCodeValueCollection(this, new Guid("f843290c-f3d7-4a05-ad2c-c671e954e9bc"));
            ((ITTChildObjectCollection)_CodeValue).GetChildren();
        }

        protected CodeValue.ChildCodeValueCollection _CodeValue = null;
        public CodeValue.ChildCodeValueCollection CodeValue
        {
            get
            {
                if (_CodeValue == null)
                    CreateCodeValueCollection();
                return _CodeValue;
            }
        }

        protected CodeType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CodeType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CodeType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CodeType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CodeType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CODETYPE", dataRow) { }
        protected CodeType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CODETYPE", dataRow, isImported) { }
        public CodeType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CodeType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CodeType() : base() { }

    }
}