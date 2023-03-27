
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWTVucutBolgesi")] 

    public  partial class ESWTVucutBolgesi : BaseMedulaDefinition
    {
        public class ESWTVucutBolgesiList : TTObjectCollection<ESWTVucutBolgesi> { }
                    
        public class ChildESWTVucutBolgesiCollection : TTObject.TTChildObjectCollection<ESWTVucutBolgesi>
        {
            public ChildESWTVucutBolgesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWTVucutBolgesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetESWTVucutBolgesiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? eswtVucutBolgesiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESWTVUCUTBOLGESIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESWTVUCUTBOLGESI"].AllPropertyDefs["ESWTVUCUTBOLGESIKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string eswtVucutBolgesiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESWTVUCUTBOLGESIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESWTVUCUTBOLGESI"].AllPropertyDefs["ESWTVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetESWTVucutBolgesiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetESWTVucutBolgesiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetESWTVucutBolgesiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<ESWTVucutBolgesi.GetESWTVucutBolgesiDefinitionQuery_Class> GetESWTVucutBolgesiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ESWTVUCUTBOLGESI"].QueryDefs["GetESWTVucutBolgesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ESWTVucutBolgesi.GetESWTVucutBolgesiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ESWTVucutBolgesi.GetESWTVucutBolgesiDefinitionQuery_Class> GetESWTVucutBolgesiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ESWTVUCUTBOLGESI"].QueryDefs["GetESWTVucutBolgesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ESWTVucutBolgesi.GetESWTVucutBolgesiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string eswtVucutBolgesiAdi
        {
            get { return (string)this["ESWTVUCUTBOLGESIADI"]; }
            set { this["ESWTVUCUTBOLGESIADI"] = value; }
        }

        public string eswtVucutBolgesiAdi_Shadow
        {
            get { return (string)this["ESWTVUCUTBOLGESIADI_SHADOW"]; }
        }

        public int? eswtVucutBolgesiKodu
        {
            get { return (int?)this["ESWTVUCUTBOLGESIKODU"]; }
            set { this["ESWTVUCUTBOLGESIKODU"] = value; }
        }

        protected ESWTVucutBolgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWTVucutBolgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWTVucutBolgesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWTVucutBolgesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWTVucutBolgesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWTVUCUTBOLGESI", dataRow) { }
        protected ESWTVucutBolgesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWTVUCUTBOLGESI", dataRow, isImported) { }
        public ESWTVucutBolgesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWTVucutBolgesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWTVucutBolgesi() : base() { }

    }
}