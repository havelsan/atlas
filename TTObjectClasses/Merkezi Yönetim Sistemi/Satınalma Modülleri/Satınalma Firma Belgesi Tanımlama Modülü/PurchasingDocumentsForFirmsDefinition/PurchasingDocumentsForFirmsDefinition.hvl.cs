
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchasingDocumentsForFirmsDefinition")] 

    public  partial class PurchasingDocumentsForFirmsDefinition : TerminologyManagerDef
    {
        public class PurchasingDocumentsForFirmsDefinitionList : TTObjectCollection<PurchasingDocumentsForFirmsDefinition> { }
                    
        public class ChildPurchasingDocumentsForFirmsDefinitionCollection : TTObject.TTChildObjectCollection<PurchasingDocumentsForFirmsDefinition>
        {
            public ChildPurchasingDocumentsForFirmsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchasingDocumentsForFirmsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PurchasingDocumentsForFirmsDefinitionFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public PurchasingDocumentsForFirmsDefinitionFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PurchasingDocumentsForFirmsDefinitionFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PurchasingDocumentsForFirmsDefinitionFormNQL_Class() : base() { }
        }

        public static BindingList<PurchasingDocumentsForFirmsDefinition.PurchasingDocumentsForFirmsDefinitionFormNQL_Class> PurchasingDocumentsForFirmsDefinitionFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSFORFIRMSDEFINITION"].QueryDefs["PurchasingDocumentsForFirmsDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchasingDocumentsForFirmsDefinition.PurchasingDocumentsForFirmsDefinitionFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchasingDocumentsForFirmsDefinition.PurchasingDocumentsForFirmsDefinitionFormNQL_Class> PurchasingDocumentsForFirmsDefinitionFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSFORFIRMSDEFINITION"].QueryDefs["PurchasingDocumentsForFirmsDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchasingDocumentsForFirmsDefinition.PurchasingDocumentsForFirmsDefinitionFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchasingDocumentsForFirmsDefinition> GetPurchasingDocsForFirmsDefByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSFORFIRMSDEFINITION"].QueryDefs["GetPurchasingDocsForFirmsDefByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchasingDocumentsForFirmsDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Belge Adı
    /// </summary>
        public string DocumentName
        {
            get { return (string)this["DOCUMENTNAME"]; }
            set { this["DOCUMENTNAME"] = value; }
        }

        public string DocumentName_Shadow
        {
            get { return (string)this["DOCUMENTNAME_SHADOW"]; }
        }

        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASINGDOCUMENTSFORFIRMSDEFINITION", dataRow) { }
        protected PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASINGDOCUMENTSFORFIRMSDEFINITION", dataRow, isImported) { }
        public PurchasingDocumentsForFirmsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchasingDocumentsForFirmsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchasingDocumentsForFirmsDefinition() : base() { }

    }
}