
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaInvoiceTermDetailDefinition")] 

    /// <summary>
    /// Medula Fatura Dönem Detay Tanım Ekranı
    /// </summary>
    public  partial class MedulaInvoiceTermDetailDefinition : TerminologyManagerDef
    {
        public class MedulaInvoiceTermDetailDefinitionList : TTObjectCollection<MedulaInvoiceTermDetailDefinition> { }
                    
        public class ChildMedulaInvoiceTermDetailDefinitionCollection : TTObject.TTChildObjectCollection<MedulaInvoiceTermDetailDefinition>
        {
            public ChildMedulaInvoiceTermDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaInvoiceTermDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaInvoiceTermDetailDefs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Termname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceTermDetailDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceTermDetailDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceTermDetailDefs_Class() : base() { }
        }

        public static BindingList<MedulaInvoiceTermDetailDefinition> GetTermDetailByTermAndTypeName(TTObjectContext objectContext, string INVOICETERM, string INVOICETYPENAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDETAILDEFINITION"].QueryDefs["GetTermDetailByTermAndTypeName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICETERM", INVOICETERM);
            paramList.Add("INVOICETYPENAME", INVOICETYPENAME);

            return ((ITTQuery)objectContext).QueryObjects<MedulaInvoiceTermDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<MedulaInvoiceTermDetailDefinition.GetMedulaInvoiceTermDetailDefs_Class> GetMedulaInvoiceTermDetailDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDETAILDEFINITION"].QueryDefs["GetMedulaInvoiceTermDetailDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDetailDefinition.GetMedulaInvoiceTermDetailDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTermDetailDefinition.GetMedulaInvoiceTermDetailDefs_Class> GetMedulaInvoiceTermDetailDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDETAILDEFINITION"].QueryDefs["GetMedulaInvoiceTermDetailDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDetailDefinition.GetMedulaInvoiceTermDetailDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Fatura Türü
    /// </summary>
        public MedulaInvoiceTypeDefinition MedulaInvoiceType
        {
            get { return (MedulaInvoiceTypeDefinition)((ITTObject)this).GetParent("MEDULAINVOICETYPE"); }
            set { this["MEDULAINVOICETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAINVOICETERMDETAILDEFINITION", dataRow) { }
        protected MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAINVOICETERMDETAILDEFINITION", dataRow, isImported) { }
        public MedulaInvoiceTermDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaInvoiceTermDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaInvoiceTermDetailDefinition() : base() { }

    }
}