
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvetHayir")] 

    public  partial class EvetHayir : BaseMedulaDefinition
    {
        public class EvetHayirList : TTObjectCollection<EvetHayir> { }
                    
        public class ChildEvetHayirCollection : TTObject.TTChildObjectCollection<EvetHayir>
        {
            public ChildEvetHayirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvetHayirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEvetHayirDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string evetHayirKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVETHAYIRKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EVETHAYIR"].AllPropertyDefs["EVETHAYIRKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string evetHayirAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVETHAYIRADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EVETHAYIR"].AllPropertyDefs["EVETHAYIRADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEvetHayirDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEvetHayirDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEvetHayirDefinitionQuery_Class() : base() { }
        }

        public static BindingList<EvetHayir.GetEvetHayirDefinitionQuery_Class> GetEvetHayirDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EVETHAYIR"].QueryDefs["GetEvetHayirDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EvetHayir.GetEvetHayirDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EvetHayir.GetEvetHayirDefinitionQuery_Class> GetEvetHayirDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EVETHAYIR"].QueryDefs["GetEvetHayirDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EvetHayir.GetEvetHayirDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string evetHayirAdi
        {
            get { return (string)this["EVETHAYIRADI"]; }
            set { this["EVETHAYIRADI"] = value; }
        }

        public string evetHayirAdi_Shadow
        {
            get { return (string)this["EVETHAYIRADI_SHADOW"]; }
        }

        public string evetHayirKodu
        {
            get { return (string)this["EVETHAYIRKODU"]; }
            set { this["EVETHAYIRKODU"] = value; }
        }

        protected EvetHayir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvetHayir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvetHayir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvetHayir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvetHayir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVETHAYIR", dataRow) { }
        protected EvetHayir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVETHAYIR", dataRow, isImported) { }
        public EvetHayir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvetHayir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvetHayir() : base() { }

    }
}