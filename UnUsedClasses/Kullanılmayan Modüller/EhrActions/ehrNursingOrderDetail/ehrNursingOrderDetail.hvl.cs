
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrNursingOrderDetail")] 

    /// <summary>
    /// Hemşire Takip Gözlem Uygulaması(Tabip  Direktifine  Bağlı)
    /// </summary>
    public  partial class ehrNursingOrderDetail : ehrSubactionProcedure
    {
        public class ehrNursingOrderDetailList : TTObjectCollection<ehrNursingOrderDetail> { }
                    
        public class ChildehrNursingOrderDetailCollection : TTObject.TTChildObjectCollection<ehrNursingOrderDetail>
        {
            public ChildehrNursingOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrNursingOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public string State
        {
            get { return (string)this["STATE"]; }
            set { this["STATE"] = value; }
        }

    /// <summary>
    /// Hemşire Talimatları-Hemşire Talimat Uygulamaları
    /// </summary>
        public ehrBaseNursingOrder ehrBaseNursingOrder
        {
            get { return (ehrBaseNursingOrder)((ITTObject)this).GetParent("EHRBASENURSINGORDER"); }
            set { this["EHRBASENURSINGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrNursingOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrNursingOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrNursingOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrNursingOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrNursingOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRNURSINGORDERDETAIL", dataRow) { }
        protected ehrNursingOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRNURSINGORDERDETAIL", dataRow, isImported) { }
        public ehrNursingOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrNursingOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrNursingOrderDetail() : base() { }

    }
}