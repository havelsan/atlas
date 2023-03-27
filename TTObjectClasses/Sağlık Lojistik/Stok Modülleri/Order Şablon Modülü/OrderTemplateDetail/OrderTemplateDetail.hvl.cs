
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrderTemplateDetail")] 

    /// <summary>
    /// Order Şablon Detayı
    /// </summary>
    public  partial class OrderTemplateDetail : TTObject
    {
        public class OrderTemplateDetailList : TTObjectCollection<OrderTemplateDetail> { }
                    
        public class ChildOrderTemplateDetailCollection : TTObject.TTChildObjectCollection<OrderTemplateDetail>
        {
            public ChildOrderTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrderTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public DrugOrderTypeEnum? DrugOrderType
        {
            get { return (DrugOrderTypeEnum?)(int?)this["DRUGORDERTYPE"]; }
            set { this["DRUGORDERTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Şekli
    /// </summary>
        public DrugUsageTypeEnum? DrugUsageType
        {
            get { return (DrugUsageTypeEnum?)(int?)this["DRUGUSAGETYPE"]; }
            set { this["DRUGUSAGETYPE"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public HospitalTimeSchedule HospitalTimeSchedule
        {
            get { return (HospitalTimeSchedule)((ITTObject)this).GetParent("HOSPITALTIMESCHEDULE"); }
            set { this["HOSPITALTIMESCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OrderTemplateDefinition OrderTemplateDefinition
        {
            get { return (OrderTemplateDefinition)((ITTObject)this).GetParent("ORDERTEMPLATEDEFINITION"); }
            set { this["ORDERTEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrderTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrderTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrderTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrderTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrderTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORDERTEMPLATEDETAIL", dataRow) { }
        protected OrderTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORDERTEMPLATEDETAIL", dataRow, isImported) { }
        public OrderTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrderTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrderTemplateDetail() : base() { }

    }
}