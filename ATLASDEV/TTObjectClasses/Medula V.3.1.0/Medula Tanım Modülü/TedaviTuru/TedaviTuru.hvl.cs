
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviTuru")] 

    /// <summary>
    /// Tedavi Türü
    /// </summary>
    public  partial class TedaviTuru : BaseMedulaDefinition
    {
        public class TedaviTuruList : TTObjectCollection<TedaviTuru> { }
                    
        public class ChildTedaviTuruCollection : TTObject.TTChildObjectCollection<TedaviTuru>
        {
            public ChildTedaviTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class Olap_GetTedaviTuruDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string tedaviTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Olap_GetTedaviTuruDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public Olap_GetTedaviTuruDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected Olap_GetTedaviTuruDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTedaviTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string tedaviTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTedaviTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TedaviTuru> GetTedaviTuruByCode(TTObjectContext objectContext, string TEDAVITURUKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].QueryDefs["GetTedaviTuruByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TEDAVITURUKODU", TEDAVITURUKODU);

            return ((ITTQuery)objectContext).QueryObjects<TedaviTuru>(queryDef, paramList);
        }

        public static BindingList<TedaviTuru.Olap_GetTedaviTuruDef_Class> Olap_GetTedaviTuruDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].QueryDefs["Olap_GetTedaviTuruDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTuru.Olap_GetTedaviTuruDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TedaviTuru.Olap_GetTedaviTuruDef_Class> Olap_GetTedaviTuruDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].QueryDefs["Olap_GetTedaviTuruDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTuru.Olap_GetTedaviTuruDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<TedaviTuru.GetTedaviTuruDefinitionQuery_Class> GetTedaviTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].QueryDefs["GetTedaviTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTuru.GetTedaviTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviTuru.GetTedaviTuruDefinitionQuery_Class> GetTedaviTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].QueryDefs["GetTedaviTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTuru.GetTedaviTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string tedaviTuruAdi_Shadow
        {
            get { return (string)this["TEDAVITURUADI_SHADOW"]; }
        }

    /// <summary>
    /// Tedavi Türü Kodu
    /// </summary>
        public string tedaviTuruKodu
        {
            get { return (string)this["TEDAVITURUKODU"]; }
            set { this["TEDAVITURUKODU"] = value; }
        }

    /// <summary>
    /// Tedavi Türü Adı
    /// </summary>
        public string tedaviTuruAdi
        {
            get { return (string)this["TEDAVITURUADI"]; }
            set { this["TEDAVITURUADI"] = value; }
        }

        virtual protected void CreateMedulaInvoiceTypeCollection()
        {
            _MedulaInvoiceType = new MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection(this, new Guid("590d1552-6251-4ac3-931f-a2e58f64393a"));
            ((ITTChildObjectCollection)_MedulaInvoiceType).GetChildren();
        }

        protected MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection _MedulaInvoiceType = null;
        public MedulaInvoiceTypeDefinition.ChildMedulaInvoiceTypeDefinitionCollection MedulaInvoiceType
        {
            get
            {
                if (_MedulaInvoiceType == null)
                    CreateMedulaInvoiceTypeCollection();
                return _MedulaInvoiceType;
            }
        }

        protected TedaviTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVITURU", dataRow) { }
        protected TedaviTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVITURU", dataRow, isImported) { }
        public TedaviTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviTuru() : base() { }

    }
}