
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvizyonTipi")] 

    /// <summary>
    /// Provizyon Tipi
    /// </summary>
    public  partial class ProvizyonTipi : BaseMedulaDefinition
    {
        public class ProvizyonTipiList : TTObjectCollection<ProvizyonTipi> { }
                    
        public class ChildProvizyonTipiCollection : TTObject.TTChildObjectCollection<ProvizyonTipi>
        {
            public ChildProvizyonTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvizyonTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProvizyonTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string provizyonTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string provizyonTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string provizyonTipiAdi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProvizyonTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProvizyonTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProvizyonTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<ProvizyonTipi.GetProvizyonTipiDefinitionQuery_Class> GetProvizyonTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].QueryDefs["GetProvizyonTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProvizyonTipi.GetProvizyonTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProvizyonTipi.GetProvizyonTipiDefinitionQuery_Class> GetProvizyonTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].QueryDefs["GetProvizyonTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProvizyonTipi.GetProvizyonTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProvizyonTipi> GetProvizyonTipiByKodu(TTObjectContext objectContext, string PROVIZYONTIPIKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].QueryDefs["GetProvizyonTipiByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROVIZYONTIPIKODU", PROVIZYONTIPIKODU);

            return ((ITTQuery)objectContext).QueryObjects<ProvizyonTipi>(queryDef, paramList);
        }

        public string provizyonTipiAdi_Shadow
        {
            get { return (string)this["PROVIZYONTIPIADI_SHADOW"]; }
        }

    /// <summary>
    /// Provizyon Tipi Adı
    /// </summary>
        public string provizyonTipiAdi
        {
            get { return (string)this["PROVIZYONTIPIADI"]; }
            set { this["PROVIZYONTIPIADI"] = value; }
        }

    /// <summary>
    /// Provizyon Tipi Kodu
    /// </summary>
        public string provizyonTipiKodu
        {
            get { return (string)this["PROVIZYONTIPIKODU"]; }
            set { this["PROVIZYONTIPIKODU"] = value; }
        }

        protected ProvizyonTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvizyonTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvizyonTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvizyonTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvizyonTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVIZYONTIPI", dataRow) { }
        protected ProvizyonTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVIZYONTIPI", dataRow, isImported) { }
        public ProvizyonTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvizyonTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvizyonTipi() : base() { }

    }
}