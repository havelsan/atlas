
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaniTipi")] 

    /// <summary>
    /// Tanı Tipi
    /// </summary>
    public  partial class TaniTipi : BaseMedulaDefinition
    {
        public class TaniTipiList : TTObjectCollection<TaniTipi> { }
                    
        public class ChildTaniTipiCollection : TTObject.TTChildObjectCollection<TaniTipi>
        {
            public ChildTaniTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaniTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTaniTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string taniTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TANITIPI"].AllPropertyDefs["TANITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string taniTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANITIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TANITIPI"].AllPropertyDefs["TANITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTaniTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTaniTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTaniTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TaniTipi.GetTaniTipiDefinitionQuery_Class> GetTaniTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TANITIPI"].QueryDefs["GetTaniTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaniTipi.GetTaniTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TaniTipi.GetTaniTipiDefinitionQuery_Class> GetTaniTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TANITIPI"].QueryDefs["GetTaniTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaniTipi.GetTaniTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string taniTipiAdi_Shadow
        {
            get { return (string)this["TANITIPIADI_SHADOW"]; }
        }

    /// <summary>
    /// Tanı Tipi Adı
    /// </summary>
        public string taniTipiAdi
        {
            get { return (string)this["TANITIPIADI"]; }
            set { this["TANITIPIADI"] = value; }
        }

    /// <summary>
    /// Tanı Tipi Kodu
    /// </summary>
        public string taniTipiKodu
        {
            get { return (string)this["TANITIPIKODU"]; }
            set { this["TANITIPIKODU"] = value; }
        }

        protected TaniTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaniTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaniTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaniTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaniTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TANITIPI", dataRow) { }
        protected TaniTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TANITIPI", dataRow, isImported) { }
        public TaniTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaniTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaniTipi() : base() { }

    }
}