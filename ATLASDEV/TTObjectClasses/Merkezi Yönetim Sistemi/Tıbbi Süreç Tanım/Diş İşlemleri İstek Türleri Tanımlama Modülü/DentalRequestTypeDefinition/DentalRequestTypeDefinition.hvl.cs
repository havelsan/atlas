
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalRequestTypeDefinition")] 

    /// <summary>
    /// Diş İşlemleri İstek Türleri Tanımları
    /// </summary>
    public  partial class DentalRequestTypeDefinition : TerminologyManagerDef
    {
        public class DentalRequestTypeDefinitionList : TTObjectCollection<DentalRequestTypeDefinition> { }
                    
        public class ChildDentalRequestTypeDefinitionCollection : TTObject.TTChildObjectCollection<DentalRequestTypeDefinition>
        {
            public ChildDentalRequestTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalRequestTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDentalRequestType_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALREQUESTTYPEDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDentalRequestType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalRequestType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalRequestType_Class() : base() { }
        }

        public static BindingList<DentalRequestTypeDefinition.GetDentalRequestType_Class> GetDentalRequestType(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALREQUESTTYPEDEFINITION"].QueryDefs["GetDentalRequestType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalRequestTypeDefinition.GetDentalRequestType_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalRequestTypeDefinition.GetDentalRequestType_Class> GetDentalRequestType(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALREQUESTTYPEDEFINITION"].QueryDefs["GetDentalRequestType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalRequestTypeDefinition.GetDentalRequestType_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalRequestTypeDefinition> GetDentalReqTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALREQUESTTYPEDEFINITION"].QueryDefs["GetDentalReqTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalRequestTypeDefinition>(queryDef, paramList);
        }

        public string Type_Shadow
        {
            get { return (string)this["TYPE_SHADOW"]; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        protected DentalRequestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALREQUESTTYPEDEFINITION", dataRow) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALREQUESTTYPEDEFINITION", dataRow, isImported) { }
        protected DentalRequestTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalRequestTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalRequestTypeDefinition() : base() { }

    }
}