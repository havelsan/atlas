
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SigortaliTuru")] 

    /// <summary>
    /// Sigortalı Türü
    /// </summary>
    public  partial class SigortaliTuru : BaseMedulaDefinition
    {
        public class SigortaliTuruList : TTObjectCollection<SigortaliTuru> { }
                    
        public class ChildSigortaliTuruCollection : TTObject.TTChildObjectCollection<SigortaliTuru>
        {
            public ChildSigortaliTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSigortaliTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSigortaliTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sigortaliTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGORTALITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].AllPropertyDefs["SIGORTALITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sigortaliTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGORTALITURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].AllPropertyDefs["SIGORTALITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSigortaliTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSigortaliTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSigortaliTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SigortaliTuru.GetSigortaliTuruDefinitionQuery_Class> GetSigortaliTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].QueryDefs["GetSigortaliTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SigortaliTuru.GetSigortaliTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SigortaliTuru.GetSigortaliTuruDefinitionQuery_Class> GetSigortaliTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].QueryDefs["GetSigortaliTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SigortaliTuru.GetSigortaliTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sigortalı Türü Adı
    /// </summary>
        public string sigortaliTuruAdi
        {
            get { return (string)this["SIGORTALITURUADI"]; }
            set { this["SIGORTALITURUADI"] = value; }
        }

        public string sigortaliTuruAdi_Shadow
        {
            get { return (string)this["SIGORTALITURUADI_SHADOW"]; }
        }

    /// <summary>
    /// Sigortalı Türü Kodu
    /// </summary>
        public string sigortaliTuruKodu
        {
            get { return (string)this["SIGORTALITURUKODU"]; }
            set { this["SIGORTALITURUKODU"] = value; }
        }

        protected SigortaliTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SigortaliTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SigortaliTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SigortaliTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SigortaliTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SIGORTALITURU", dataRow) { }
        protected SigortaliTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SIGORTALITURU", dataRow, isImported) { }
        public SigortaliTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SigortaliTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SigortaliTuru() : base() { }

    }
}