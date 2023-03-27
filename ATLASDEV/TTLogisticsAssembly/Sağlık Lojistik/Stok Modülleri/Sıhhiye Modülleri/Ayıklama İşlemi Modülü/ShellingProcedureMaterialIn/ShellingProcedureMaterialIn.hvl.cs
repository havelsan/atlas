
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ShellingProcedureMaterialIn")] 

    /// <summary>
    /// Ayıklama işleminde eksilen malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ShellingProcedureMaterialIn : StockActionDetailIn
    {
        public class ShellingProcedureMaterialInList : TTObjectCollection<ShellingProcedureMaterialIn> { }
                    
        public class ChildShellingProcedureMaterialInCollection : TTObject.TTChildObjectCollection<ShellingProcedureMaterialIn>
        {
            public ChildShellingProcedureMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildShellingProcedureMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// HEK Sonucu
    /// </summary>
        public HEKResultEnum? HEKResult
        {
            get { return (HEKResultEnum?)(int?)this["HEKRESULT"]; }
            set { this["HEKRESULT"] = value; }
        }

        public ShellingProcedureMaterialOut OutMaterial
        {
            get { return (ShellingProcedureMaterialOut)((ITTObject)this).GetParent("OUTMATERIAL"); }
            set { this["OUTMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ShellingProcedure ShellingProcedure
        {
            get 
            {   
                if (StockAction is ShellingProcedure)
                    return (ShellingProcedure)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SHELLINGPROCEDUREMATERIALIN", dataRow) { }
        protected ShellingProcedureMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SHELLINGPROCEDUREMATERIALIN", dataRow, isImported) { }
        public ShellingProcedureMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ShellingProcedureMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ShellingProcedureMaterialIn() : base() { }

    }
}