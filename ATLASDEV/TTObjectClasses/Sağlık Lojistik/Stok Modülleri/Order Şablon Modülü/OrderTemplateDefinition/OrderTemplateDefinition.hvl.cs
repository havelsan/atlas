
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrderTemplateDefinition")] 

    /// <summary>
    /// Order Şablon Tanımlama
    /// </summary>
    public  partial class OrderTemplateDefinition : TerminologyManagerDef
    {
        public class OrderTemplateDefinitionList : TTObjectCollection<OrderTemplateDefinition> { }
                    
        public class ChildOrderTemplateDefinitionCollection : TTObject.TTChildObjectCollection<OrderTemplateDefinition>
        {
            public ChildOrderTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrderTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOrderTemplateByParameters_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public Guid? Hospitaltimescheduleobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITALTIMESCHEDULEOBJECTID"]);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDETAIL"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDETAIL"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugOrderTypeEnum? DrugOrderType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDETAIL"].AllPropertyDefs["DRUGORDERTYPE"].DataType;
                    return (DrugOrderTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrderTemplateByParameters_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderTemplateByParameters_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderTemplateByParameters_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrderTemplateDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public OrderTemplateStatusEnum? OrderTemplateStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERTEMPLATESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].AllPropertyDefs["ORDERTEMPLATESTATUS"].DataType;
                    return (OrderTemplateStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetOrderTemplateDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderTemplateDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderTemplateDefinitionList_Class() : base() { }
        }

        public static BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> GetOrderTemplateByParameters(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].QueryDefs["GetOrderTemplateByParameters"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrderTemplateDefinition.GetOrderTemplateByParameters_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> GetOrderTemplateByParameters(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].QueryDefs["GetOrderTemplateByParameters"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrderTemplateDefinition.GetOrderTemplateByParameters_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> GetOrderTemplateDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].QueryDefs["GetOrderTemplateDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> GetOrderTemplateDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORDERTEMPLATEDEFINITION"].QueryDefs["GetOrderTemplateDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public OrderTemplateStatusEnum? OrderTemplateStatus
        {
            get { return (OrderTemplateStatusEnum?)(int?)this["ORDERTEMPLATESTATUS"]; }
            set { this["ORDERTEMPLATESTATUS"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Şablon Sahibi
    /// </summary>
        public Guid? CreatedBy
        {
            get { return (Guid?)this["CREATEDBY"]; }
            set { this["CREATEDBY"] = value; }
        }

        public SpecialityDefinition SpecialityDefinition
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITION"); }
            set { this["SPECIALITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOrderTemplateDetailsCollection()
        {
            _OrderTemplateDetails = new OrderTemplateDetail.ChildOrderTemplateDetailCollection(this, new Guid("c7a6dd1c-aa2c-4a1d-8558-afe3ea6e531d"));
            ((ITTChildObjectCollection)_OrderTemplateDetails).GetChildren();
        }

        protected OrderTemplateDetail.ChildOrderTemplateDetailCollection _OrderTemplateDetails = null;
        public OrderTemplateDetail.ChildOrderTemplateDetailCollection OrderTemplateDetails
        {
            get
            {
                if (_OrderTemplateDetails == null)
                    CreateOrderTemplateDetailsCollection();
                return _OrderTemplateDetails;
            }
        }

        protected OrderTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrderTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrderTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrderTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrderTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORDERTEMPLATEDEFINITION", dataRow) { }
        protected OrderTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORDERTEMPLATEDEFINITION", dataRow, isImported) { }
        public OrderTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrderTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrderTemplateDefinition() : base() { }

    }
}