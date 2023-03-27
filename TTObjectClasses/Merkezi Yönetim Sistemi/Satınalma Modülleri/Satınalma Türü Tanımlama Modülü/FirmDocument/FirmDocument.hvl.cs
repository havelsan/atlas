
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FirmDocument")] 

    public  partial class FirmDocument : TerminologyManagerDef
    {
        public class FirmDocumentList : TTObjectCollection<FirmDocument> { }
                    
        public class ChildFirmDocumentCollection : TTObject.TTChildObjectCollection<FirmDocument>
        {
            public ChildFirmDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFirmDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNeededProjectDocuments_Class : TTReportNqlObject 
        {
            public bool? Mandatory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANDATORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIRMDOCUMENT"].AllPropertyDefs["MANDATORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DocumentName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSFORFIRMSDEFINITION"].AllPropertyDefs["DOCUMENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNeededProjectDocuments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNeededProjectDocuments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNeededProjectDocuments_Class() : base() { }
        }

        public static BindingList<FirmDocument.GetNeededProjectDocuments_Class> GetNeededProjectDocuments(string PURCHASETYPEOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIRMDOCUMENT"].QueryDefs["GetNeededProjectDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASETYPEOBJECTID", PURCHASETYPEOBJECTID);

            return TTReportNqlObject.QueryObjects<FirmDocument.GetNeededProjectDocuments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FirmDocument.GetNeededProjectDocuments_Class> GetNeededProjectDocuments(TTObjectContext objectContext, string PURCHASETYPEOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIRMDOCUMENT"].QueryDefs["GetNeededProjectDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASETYPEOBJECTID", PURCHASETYPEOBJECTID);

            return TTReportNqlObject.QueryObjects<FirmDocument.GetNeededProjectDocuments_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Zorunluluk
    /// </summary>
        public bool? Mandatory
        {
            get { return (bool?)this["MANDATORY"]; }
            set { this["MANDATORY"] = value; }
        }

        public PurchaseTypeDefinition PurchaseTypeDefinition
        {
            get { return (PurchaseTypeDefinition)((ITTObject)this).GetParent("PURCHASETYPEDEFINITION"); }
            set { this["PURCHASETYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchasingDocumentsForFirmsDefinition PurchasingDocsForFirmsDef
        {
            get { return (PurchasingDocumentsForFirmsDefinition)((ITTObject)this).GetParent("PURCHASINGDOCSFORFIRMSDEF"); }
            set { this["PURCHASINGDOCSFORFIRMSDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FirmDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FirmDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FirmDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FirmDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FirmDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIRMDOCUMENT", dataRow) { }
        protected FirmDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIRMDOCUMENT", dataRow, isImported) { }
        public FirmDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FirmDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FirmDocument() : base() { }

    }
}