
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EntryCorrectionProcessDet")] 

    public  partial class EntryCorrectionProcessDet : StockActionDetail
    {
        public class EntryCorrectionProcessDetList : TTObjectCollection<EntryCorrectionProcessDet> { }
                    
        public class ChildEntryCorrectionProcessDetCollection : TTObject.TTChildObjectCollection<EntryCorrectionProcessDet>
        {
            public ChildEntryCorrectionProcessDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEntryCorrectionProcessDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Eklenecek Miktar
    /// </summary>
        public Currency? AddedAmount
        {
            get { return (Currency?)this["ADDEDAMOUNT"]; }
            set { this["ADDEDAMOUNT"] = value; }
        }

        public StockActionDetailIn StockActionDetailIn
        {
            get { return (StockActionDetailIn)((ITTObject)this).GetParent("STOCKACTIONDETAILIN"); }
            set { this["STOCKACTIONDETAILIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public EntryCorrectionProcess EntryCorrectionProcess
        {
            get 
            {   
                if (StockAction is EntryCorrectionProcess)
                    return (EntryCorrectionProcess)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected EntryCorrectionProcessDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EntryCorrectionProcessDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EntryCorrectionProcessDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EntryCorrectionProcessDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EntryCorrectionProcessDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENTRYCORRECTIONPROCESSDET", dataRow) { }
        protected EntryCorrectionProcessDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENTRYCORRECTIONPROCESSDET", dataRow, isImported) { }
        public EntryCorrectionProcessDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EntryCorrectionProcessDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EntryCorrectionProcessDet() : base() { }

    }
}