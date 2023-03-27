
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipTipi")] 

    /// <summary>
    /// Takip Tipi
    /// </summary>
    public  partial class TakipTipi : BaseMedulaDefinition
    {
        public class TakipTipiList : TTObjectCollection<TakipTipi> { }
                    
        public class ChildTakipTipiCollection : TTObject.TTChildObjectCollection<TakipTipi>
        {
            public ChildTakipTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string takipTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPTIPI"].AllPropertyDefs["TAKIPTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPTIPI"].AllPropertyDefs["TAKIPTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTakipTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TakipTipi.GetTakipTipiDefinitionQuery_Class> GetTakipTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPTIPI"].QueryDefs["GetTakipTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipTipi.GetTakipTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipTipi.GetTakipTipiDefinitionQuery_Class> GetTakipTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPTIPI"].QueryDefs["GetTakipTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipTipi.GetTakipTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string takipTipiAdi_Shadow
        {
            get { return (string)this["TAKIPTIPIADI_SHADOW"]; }
        }

    /// <summary>
    /// Takip Tipi Kodu
    /// </summary>
        public string takipTipiKodu
        {
            get { return (string)this["TAKIPTIPIKODU"]; }
            set { this["TAKIPTIPIKODU"] = value; }
        }

    /// <summary>
    /// Takip Tipi Adı
    /// </summary>
        public string takipTipiAdi
        {
            get { return (string)this["TAKIPTIPIADI"]; }
            set { this["TAKIPTIPIADI"] = value; }
        }

        protected TakipTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPTIPI", dataRow) { }
        protected TakipTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPTIPI", dataRow, isImported) { }
        public TakipTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipTipi() : base() { }

    }
}