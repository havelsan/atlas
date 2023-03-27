
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AyniFarkliKesi")] 

    /// <summary>
    /// Aynı Farklı Kesi
    /// </summary>
    public  partial class AyniFarkliKesi : BaseMedulaDefinition
    {
        public class AyniFarkliKesiList : TTObjectCollection<AyniFarkliKesi> { }
                    
        public class ChildAyniFarkliKesiCollection : TTObject.TTChildObjectCollection<AyniFarkliKesi>
        {
            public ChildAyniFarkliKesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAyniFarkliKesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAyniFarkliKesiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ayniFarkliKesiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AYNIFARKLIKESIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AYNIFARKLIKESI"].AllPropertyDefs["AYNIFARKLIKESIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ayniFarkliKesiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AYNIFARKLIKESIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AYNIFARKLIKESI"].AllPropertyDefs["AYNIFARKLIKESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAyniFarkliKesiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAyniFarkliKesiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAyniFarkliKesiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<AyniFarkliKesi.GetAyniFarkliKesiDefinitionQuery_Class> GetAyniFarkliKesiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AYNIFARKLIKESI"].QueryDefs["GetAyniFarkliKesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AyniFarkliKesi.GetAyniFarkliKesiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AyniFarkliKesi.GetAyniFarkliKesiDefinitionQuery_Class> GetAyniFarkliKesiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AYNIFARKLIKESI"].QueryDefs["GetAyniFarkliKesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AyniFarkliKesi.GetAyniFarkliKesiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AyniFarkliKesi> GetByAyniFarkliKesiKodu(TTObjectContext objectContext, string AYNIFARKLIKESIKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AYNIFARKLIKESI"].QueryDefs["GetByAyniFarkliKesiKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("AYNIFARKLIKESIKODU", AYNIFARKLIKESIKODU);

            return ((ITTQuery)objectContext).QueryObjects<AyniFarkliKesi>(queryDef, paramList);
        }

        public string ayniFarkliKesiAdi_Shadow
        {
            get { return (string)this["AYNIFARKLIKESIADI_SHADOW"]; }
        }

    /// <summary>
    /// Aynı Farklı Kesi Adı
    /// </summary>
        public string ayniFarkliKesiAdi
        {
            get { return (string)this["AYNIFARKLIKESIADI"]; }
            set { this["AYNIFARKLIKESIADI"] = value; }
        }

    /// <summary>
    /// Aynı Farklı Kesi Kodu
    /// </summary>
        public string ayniFarkliKesiKodu
        {
            get { return (string)this["AYNIFARKLIKESIKODU"]; }
            set { this["AYNIFARKLIKESIKODU"] = value; }
        }

        protected AyniFarkliKesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AyniFarkliKesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AyniFarkliKesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AyniFarkliKesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AyniFarkliKesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AYNIFARKLIKESI", dataRow) { }
        protected AyniFarkliKesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AYNIFARKLIKESI", dataRow, isImported) { }
        public AyniFarkliKesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AyniFarkliKesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AyniFarkliKesi() : base() { }

    }
}