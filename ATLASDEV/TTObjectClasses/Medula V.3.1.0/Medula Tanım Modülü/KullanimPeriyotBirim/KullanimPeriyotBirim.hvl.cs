
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KullanimPeriyotBirim")] 

    public  partial class KullanimPeriyotBirim : BaseMedulaDefinition
    {
        public class KullanimPeriyotBirimList : TTObjectCollection<KullanimPeriyotBirim> { }
                    
        public class ChildKullanimPeriyotBirimCollection : TTObject.TTChildObjectCollection<KullanimPeriyotBirim>
        {
            public ChildKullanimPeriyotBirimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKullanimPeriyotBirimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKullanimPeriyotBirimDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string kullanimPeriyotBirimKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANIMPERIYOTBIRIMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KULLANIMPERIYOTBIRIM"].AllPropertyDefs["KULLANIMPERIYOTBIRIMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string kullanimPeriyotBirimAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANIMPERIYOTBIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KULLANIMPERIYOTBIRIM"].AllPropertyDefs["KULLANIMPERIYOTBIRIMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetKullanimPeriyotBirimDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKullanimPeriyotBirimDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKullanimPeriyotBirimDefinitionQuery_Class() : base() { }
        }

        public static BindingList<KullanimPeriyotBirim.GetKullanimPeriyotBirimDefinitionQuery_Class> GetKullanimPeriyotBirimDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KULLANIMPERIYOTBIRIM"].QueryDefs["GetKullanimPeriyotBirimDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KullanimPeriyotBirim.GetKullanimPeriyotBirimDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KullanimPeriyotBirim.GetKullanimPeriyotBirimDefinitionQuery_Class> GetKullanimPeriyotBirimDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KULLANIMPERIYOTBIRIM"].QueryDefs["GetKullanimPeriyotBirimDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KullanimPeriyotBirim.GetKullanimPeriyotBirimDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string kPeriyotBirimAdi_Shadow
        {
            get { return (string)this["KPERIYOTBIRIMADI_SHADOW"]; }
        }

        public string kullanimPeriyotBirimAdi
        {
            get { return (string)this["KULLANIMPERIYOTBIRIMADI"]; }
            set { this["KULLANIMPERIYOTBIRIMADI"] = value; }
        }

        public string kullanimPeriyotBirimKodu
        {
            get { return (string)this["KULLANIMPERIYOTBIRIMKODU"]; }
            set { this["KULLANIMPERIYOTBIRIMKODU"] = value; }
        }

        protected KullanimPeriyotBirim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KullanimPeriyotBirim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KullanimPeriyotBirim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KullanimPeriyotBirim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KullanimPeriyotBirim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KULLANIMPERIYOTBIRIM", dataRow) { }
        protected KullanimPeriyotBirim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KULLANIMPERIYOTBIRIM", dataRow, isImported) { }
        public KullanimPeriyotBirim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KullanimPeriyotBirim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KullanimPeriyotBirim() : base() { }

    }
}