
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaInvoiceTypeDefinition")] 

    /// <summary>
    /// Medula Fatura Türü Tanım Ekranı
    /// </summary>
    public  partial class MedulaInvoiceTypeDefinition : TerminologyManagerDef
    {
        public class MedulaInvoiceTypeDefinitionList : TTObjectCollection<MedulaInvoiceTypeDefinition> { }
                    
        public class ChildMedulaInvoiceTypeDefinitionCollection : TTObject.TTChildObjectCollection<MedulaInvoiceTypeDefinition>
        {
            public ChildMedulaInvoiceTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaInvoiceTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaInvoiceTypeDefs_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceTypeDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceTypeDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceTypeDefs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaInvoiceTypeDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceTypeDefinitions_Class() : base() { }
        }

        public static BindingList<MedulaInvoiceTypeDefinition> GetMedulaInvoiceTypes(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].QueryDefs["GetMedulaInvoiceTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MedulaInvoiceTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefs_Class> GetMedulaInvoiceTypeDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].QueryDefs["GetMedulaInvoiceTypeDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefs_Class> GetMedulaInvoiceTypeDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].QueryDefs["GetMedulaInvoiceTypeDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefinitions_Class> GetMedulaInvoiceTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].QueryDefs["GetMedulaInvoiceTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefinitions_Class> GetMedulaInvoiceTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETYPEDEFINITION"].QueryDefs["GetMedulaInvoiceTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaInvoiceTermDetailsCollection()
        {
            _MedulaInvoiceTermDetails = new MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection(this, new Guid("af34a2c7-52b2-4830-92b0-54d29e87e86e"));
            ((ITTChildObjectCollection)_MedulaInvoiceTermDetails).GetChildren();
        }

        protected MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection _MedulaInvoiceTermDetails = null;
    /// <summary>
    /// Child collection for Medula Fatura Türü
    /// </summary>
        public MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection MedulaInvoiceTermDetails
        {
            get
            {
                if (_MedulaInvoiceTermDetails == null)
                    CreateMedulaInvoiceTermDetailsCollection();
                return _MedulaInvoiceTermDetails;
            }
        }

        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAINVOICETYPEDEFINITION", dataRow) { }
        protected MedulaInvoiceTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAINVOICETYPEDEFINITION", dataRow, isImported) { }
        public MedulaInvoiceTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaInvoiceTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaInvoiceTypeDefinition() : base() { }

    }
}