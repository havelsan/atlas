
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkTedaviTipi")] 

    /// <summary>
    /// Sevk Tedavi Tipi
    /// </summary>
    public  partial class SevkTedaviTipi : BaseMedulaDefinition
    {
        public class SevkTedaviTipiList : TTObjectCollection<SevkTedaviTipi> { }
                    
        public class ChildSevkTedaviTipiCollection : TTObject.TTChildObjectCollection<SevkTedaviTipi>
        {
            public ChildSevkTedaviTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkTedaviTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSevkTedaviTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sevkTedaviTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKTEDAVITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].AllPropertyDefs["SEVKTEDAVITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sevkTedaviTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKTEDAVITIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].AllPropertyDefs["SEVKTEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSevkTedaviTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkTedaviTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkTedaviTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SevkTedaviTipi.GetSevkTedaviTipiDefinitionQuery_Class> GetSevkTedaviTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].QueryDefs["GetSevkTedaviTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkTedaviTipi.GetSevkTedaviTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkTedaviTipi.GetSevkTedaviTipiDefinitionQuery_Class> GetSevkTedaviTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].QueryDefs["GetSevkTedaviTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkTedaviTipi.GetSevkTedaviTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sevk Tedavi Tipi Adı
    /// </summary>
        public string sevkTedaviTipiAdi
        {
            get { return (string)this["SEVKTEDAVITIPIADI"]; }
            set { this["SEVKTEDAVITIPIADI"] = value; }
        }

        public string sevkTedaviTipiAdi_Shadow
        {
            get { return (string)this["SEVKTEDAVITIPIADI_SHADOW"]; }
            set { this["SEVKTEDAVITIPIADI_SHADOW"] = value; }
        }

    /// <summary>
    /// Sevk Tedavi Tipi Kodu
    /// </summary>
        public string sevkTedaviTipiKodu
        {
            get { return (string)this["SEVKTEDAVITIPIKODU"]; }
            set { this["SEVKTEDAVITIPIKODU"] = value; }
        }

        protected SevkTedaviTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkTedaviTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkTedaviTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkTedaviTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkTedaviTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKTEDAVITIPI", dataRow) { }
        protected SevkTedaviTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKTEDAVITIPI", dataRow, isImported) { }
        public SevkTedaviTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkTedaviTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkTedaviTipi() : base() { }

    }
}