
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrDrugOrderDetail")] 

    /// <summary>
    /// İlaç Uygulaması
    /// </summary>
    public  partial class ehrDrugOrderDetail : ehrBaseDrugOrder
    {
        public class ehrDrugOrderDetailList : TTObjectCollection<ehrDrugOrderDetail> { }
                    
        public class ChildehrDrugOrderDetailCollection : TTObject.TTChildObjectCollection<ehrDrugOrderDetail>
        {
            public ChildehrDrugOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrDrugOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Stage
        {
            get { return (string)this["STAGE"]; }
            set { this["STAGE"] = value; }
        }

    /// <summary>
    /// Uygulama Notu
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ehrNursingApplication ehrNursingApplication
        {
            get 
            {   
                if (ehrEpisodeAction is ehrNursingApplication)
                    return (ehrNursingApplication)ehrEpisodeAction; 
                return null;
            }            
            set { ehrEpisodeAction = value; }
        }

        protected ehrDrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrDrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrDrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrDrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrDrugOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRDRUGORDERDETAIL", dataRow) { }
        protected ehrDrugOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRDRUGORDERDETAIL", dataRow, isImported) { }
        public ehrDrugOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrDrugOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrDrugOrderDetail() : base() { }

    }
}