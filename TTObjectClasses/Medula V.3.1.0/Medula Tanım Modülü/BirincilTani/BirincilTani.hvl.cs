
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BirincilTani")] 

    /// <summary>
    /// Birincil Tanı
    /// </summary>
    public  partial class BirincilTani : BaseMedulaDefinition
    {
        public class BirincilTaniList : TTObjectCollection<BirincilTani> { }
                    
        public class ChildBirincilTaniCollection : TTObject.TTChildObjectCollection<BirincilTani>
        {
            public ChildBirincilTaniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBirincilTaniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBirincilTaniDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string birincilTaniKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRINCILTANIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRINCILTANI"].AllPropertyDefs["BIRINCILTANIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birincilTaniAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRINCILTANIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BIRINCILTANI"].AllPropertyDefs["BIRINCILTANIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBirincilTaniDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBirincilTaniDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBirincilTaniDefinitionQuery_Class() : base() { }
        }

        public static BindingList<BirincilTani.GetBirincilTaniDefinitionQuery_Class> GetBirincilTaniDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRINCILTANI"].QueryDefs["GetBirincilTaniDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BirincilTani.GetBirincilTaniDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BirincilTani.GetBirincilTaniDefinitionQuery_Class> GetBirincilTaniDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRINCILTANI"].QueryDefs["GetBirincilTaniDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BirincilTani.GetBirincilTaniDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string birincilTaniAdi_Shadow
        {
            get { return (string)this["BIRINCILTANIADI_SHADOW"]; }
        }

    /// <summary>
    /// Birincil Tanı Kodu
    /// </summary>
        public string birincilTaniKodu
        {
            get { return (string)this["BIRINCILTANIKODU"]; }
            set { this["BIRINCILTANIKODU"] = value; }
        }

    /// <summary>
    /// Birincil Tanı Adı
    /// </summary>
        public string birincilTaniAdi
        {
            get { return (string)this["BIRINCILTANIADI"]; }
            set { this["BIRINCILTANIADI"] = value; }
        }

        protected BirincilTani(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BirincilTani(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BirincilTani(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BirincilTani(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BirincilTani(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BIRINCILTANI", dataRow) { }
        protected BirincilTani(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BIRINCILTANI", dataRow, isImported) { }
        public BirincilTani(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BirincilTani(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BirincilTani() : base() { }

    }
}