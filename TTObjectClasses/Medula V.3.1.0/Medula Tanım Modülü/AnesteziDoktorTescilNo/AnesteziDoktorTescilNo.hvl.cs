
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesteziDoktorTescilNo")] 

    public  partial class AnesteziDoktorTescilNo : BaseMedulaDefinition
    {
        public class AnesteziDoktorTescilNoList : TTObjectCollection<AnesteziDoktorTescilNo> { }
                    
        public class ChildAnesteziDoktorTescilNoCollection : TTObject.TTChildObjectCollection<AnesteziDoktorTescilNo>
        {
            public ChildAnesteziDoktorTescilNoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesteziDoktorTescilNoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnesteziDoktorTescilNoDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string anesteziDoktorTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTEZIDOKTORTESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTEZIDOKTORTESCILNO"].AllPropertyDefs["ANESTEZIDOKTORTESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string anesteziDoktorAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTEZIDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTEZIDOKTORTESCILNO"].AllPropertyDefs["ANESTEZIDOKTORADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAnesteziDoktorTescilNoDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnesteziDoktorTescilNoDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnesteziDoktorTescilNoDefinitionQuery_Class() : base() { }
        }

        public static BindingList<AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class> GetAnesteziDoktorTescilNoDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTEZIDOKTORTESCILNO"].QueryDefs["GetAnesteziDoktorTescilNoDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class> GetAnesteziDoktorTescilNoDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTEZIDOKTORTESCILNO"].QueryDefs["GetAnesteziDoktorTescilNoDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesteziDoktorTescilNo.GetAnesteziDoktorTescilNoDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string anesteziDoktorAdi_Shadow
        {
            get { return (string)this["ANESTEZIDOKTORADI_SHADOW"]; }
            set { this["ANESTEZIDOKTORADI_SHADOW"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Adı
    /// </summary>
        public string anesteziDoktorAdi
        {
            get { return (string)this["ANESTEZIDOKTORADI"]; }
            set { this["ANESTEZIDOKTORADI"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string anesteziDoktorTescilNo
        {
            get { return (string)this["ANESTEZIDOKTORTESCILNO"]; }
            set { this["ANESTEZIDOKTORTESCILNO"] = value; }
        }

        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTEZIDOKTORTESCILNO", dataRow) { }
        protected AnesteziDoktorTescilNo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTEZIDOKTORTESCILNO", dataRow, isImported) { }
        public AnesteziDoktorTescilNo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesteziDoktorTescilNo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesteziDoktorTescilNo() : base() { }

    }
}