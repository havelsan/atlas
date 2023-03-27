
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DocumentDefinition")] 

    public  partial class DocumentDefinition : TerminologyManagerDef
    {
        public class DocumentDefinitionList : TTObjectCollection<DocumentDefinition> { }
                    
        public class ChildDocumentDefinitionCollection : TTObject.TTChildObjectCollection<DocumentDefinition>
        {
            public ChildDocumentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDocumentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDocumentDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].AllPropertyDefs["ISGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].AllPropertyDefs["ISMAINGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Parentdocumentdefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTDOCUMENTDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDocumentDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentDefinitionList_Class() : base() { }
        }

        public static BindingList<DocumentDefinition.GetDocumentDefinitionList_Class> GetDocumentDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].QueryDefs["GetDocumentDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DocumentDefinition.GetDocumentDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DocumentDefinition.GetDocumentDefinitionList_Class> GetDocumentDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTDEFINITION"].QueryDefs["GetDocumentDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DocumentDefinition.GetDocumentDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Grup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

    /// <summary>
    /// Ana Grup
    /// </summary>
        public bool? IsMainGroup
        {
            get { return (bool?)this["ISMAINGROUP"]; }
            set { this["ISMAINGROUP"] = value; }
        }

    /// <summary>
    /// Dosya
    /// </summary>
        public object File
        {
            get { return (object)this["FILE"]; }
            set { this["FILE"] = value; }
        }

    /// <summary>
    /// Dosya Uzantısı
    /// </summary>
        public string FileExtension
        {
            get { return (string)this["FILEEXTENSION"]; }
            set { this["FILEEXTENSION"] = value; }
        }

        public DocumentDefinition ParentDocumentDefinition
        {
            get { return (DocumentDefinition)((ITTObject)this).GetParent("PARENTDOCUMENTDEFINITION"); }
            set { this["PARENTDOCUMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DocumentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DocumentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DocumentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DocumentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DocumentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCUMENTDEFINITION", dataRow) { }
        protected DocumentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCUMENTDEFINITION", dataRow, isImported) { }
        public DocumentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DocumentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DocumentDefinition() : base() { }

    }
}