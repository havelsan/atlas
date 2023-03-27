
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KullanimDozBirim")] 

    public  partial class KullanimDozBirim : BaseMedulaDefinition
    {
        public class KullanimDozBirimList : TTObjectCollection<KullanimDozBirim> { }
                    
        public class ChildKullanimDozBirimCollection : TTObject.TTChildObjectCollection<KullanimDozBirim>
        {
            public ChildKullanimDozBirimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKullanimDozBirimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKullanimDozBirimDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string kullanimDozBirimKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANIMDOZBIRIMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KULLANIMDOZBIRIM"].AllPropertyDefs["KULLANIMDOZBIRIMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string kullanimDozBirimAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANIMDOZBIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KULLANIMDOZBIRIM"].AllPropertyDefs["KULLANIMDOZBIRIMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetKullanimDozBirimDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKullanimDozBirimDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKullanimDozBirimDefinitionQuery_Class() : base() { }
        }

        public static BindingList<KullanimDozBirim.GetKullanimDozBirimDefinitionQuery_Class> GetKullanimDozBirimDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KULLANIMDOZBIRIM"].QueryDefs["GetKullanimDozBirimDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KullanimDozBirim.GetKullanimDozBirimDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KullanimDozBirim.GetKullanimDozBirimDefinitionQuery_Class> GetKullanimDozBirimDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KULLANIMDOZBIRIM"].QueryDefs["GetKullanimDozBirimDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KullanimDozBirim.GetKullanimDozBirimDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string kullanimDozBirimAdi
        {
            get { return (string)this["KULLANIMDOZBIRIMADI"]; }
            set { this["KULLANIMDOZBIRIMADI"] = value; }
        }

        public string kullanimDozBirimAdi_Shadow
        {
            get { return (string)this["KULLANIMDOZBIRIMADI_SHADOW"]; }
        }

        public string kullanimDozBirimKodu
        {
            get { return (string)this["KULLANIMDOZBIRIMKODU"]; }
            set { this["KULLANIMDOZBIRIMKODU"] = value; }
        }

        protected KullanimDozBirim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KullanimDozBirim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KullanimDozBirim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KullanimDozBirim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KullanimDozBirim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KULLANIMDOZBIRIM", dataRow) { }
        protected KullanimDozBirim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KULLANIMDOZBIRIM", dataRow, isImported) { }
        public KullanimDozBirim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KullanimDozBirim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KullanimDozBirim() : base() { }

    }
}