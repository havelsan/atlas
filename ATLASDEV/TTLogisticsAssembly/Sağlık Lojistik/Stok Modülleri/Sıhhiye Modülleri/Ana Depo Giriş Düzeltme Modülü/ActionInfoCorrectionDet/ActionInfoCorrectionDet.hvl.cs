
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActionInfoCorrectionDet")] 

    /// <summary>
    /// Fatura İşlem Düzeltme Detay
    /// </summary>
    public  partial class ActionInfoCorrectionDet : EntryCorrectionProcessDet
    {
        public class ActionInfoCorrectionDetList : TTObjectCollection<ActionInfoCorrectionDet> { }
                    
        public class ChildActionInfoCorrectionDetCollection : TTObject.TTChildObjectCollection<ActionInfoCorrectionDet>
        {
            public ChildActionInfoCorrectionDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActionInfoCorrectionDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ActionInfoCorrection ActionInfoCorrection
        {
            get 
            {   
                if (StockAction is ActionInfoCorrection)
                    return (ActionInfoCorrection)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected ActionInfoCorrectionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActionInfoCorrectionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActionInfoCorrectionDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActionInfoCorrectionDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActionInfoCorrectionDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIONINFOCORRECTIONDET", dataRow) { }
        protected ActionInfoCorrectionDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIONINFOCORRECTIONDET", dataRow, isImported) { }
        public ActionInfoCorrectionDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActionInfoCorrectionDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActionInfoCorrectionDet() : base() { }

    }
}