
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrDrugOrder")] 

    /// <summary>
    /// İlaç Emirleri
    /// </summary>
    public  partial class ehrDrugOrder : ehrBaseDrugOrder
    {
        public class ehrDrugOrderList : TTObjectCollection<ehrDrugOrder> { }
                    
        public class ChildehrDrugOrderCollection : TTObject.TTChildObjectCollection<ehrDrugOrder>
        {
            public ChildehrDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ehrInPatientPhysicianApplication ehrInPatientPhysicianApp
        {
            get 
            {   
                if (ehrEpisodeAction is ehrInPatientPhysicianApplication)
                    return (ehrInPatientPhysicianApplication)ehrEpisodeAction; 
                return null;
            }            
            set { ehrEpisodeAction = value; }
        }

        protected ehrDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRDRUGORDER", dataRow) { }
        protected ehrDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRDRUGORDER", dataRow, isImported) { }
        public ehrDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrDrugOrder() : base() { }

    }
}