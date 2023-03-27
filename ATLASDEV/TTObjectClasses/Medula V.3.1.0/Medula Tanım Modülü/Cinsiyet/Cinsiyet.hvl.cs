
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Cinsiyet")] 

    /// <summary>
    /// Cinsiyet
    /// </summary>
    public  partial class Cinsiyet : BaseMedulaDefinition
    {
        public class CinsiyetList : TTObjectCollection<Cinsiyet> { }
                    
        public class ChildCinsiyetCollection : TTObject.TTChildObjectCollection<Cinsiyet>
        {
            public ChildCinsiyetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCinsiyetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCinsiyetDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string cinsiyetKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CINSIYET"].AllPropertyDefs["CINSIYETKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string cinsiyetAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CINSIYET"].AllPropertyDefs["CINSIYETADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCinsiyetDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCinsiyetDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCinsiyetDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Cinsiyet.GetCinsiyetDefinitionQuery_Class> GetCinsiyetDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CINSIYET"].QueryDefs["GetCinsiyetDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Cinsiyet.GetCinsiyetDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Cinsiyet.GetCinsiyetDefinitionQuery_Class> GetCinsiyetDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CINSIYET"].QueryDefs["GetCinsiyetDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Cinsiyet.GetCinsiyetDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string cinsiyetAdi_Shadow
        {
            get { return (string)this["CINSIYETADI_SHADOW"]; }
        }

    /// <summary>
    /// Cinsiyet Adı
    /// </summary>
        public string cinsiyetAdi
        {
            get { return (string)this["CINSIYETADI"]; }
            set { this["CINSIYETADI"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kodu
    /// </summary>
        public string cinsiyetKodu
        {
            get { return (string)this["CINSIYETKODU"]; }
            set { this["CINSIYETKODU"] = value; }
        }

        protected Cinsiyet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Cinsiyet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Cinsiyet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Cinsiyet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Cinsiyet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CINSIYET", dataRow) { }
        protected Cinsiyet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CINSIYET", dataRow, isImported) { }
        public Cinsiyet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Cinsiyet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Cinsiyet() : base() { }

    }
}