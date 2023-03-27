
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseGrid")] 

    public  partial class DirectPurchaseGrid : TTObject
    {
        public class DirectPurchaseGridList : TTObjectCollection<DirectPurchaseGrid> { }
                    
        public class ChildDirectPurchaseGridCollection : TTObject.TTChildObjectCollection<DirectPurchaseGrid>
        {
            public ChildDirectPurchaseGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DirectMaterialSupplyAction DirectMaterialSupplyAction
        {
            get { return (DirectMaterialSupplyAction)((ITTObject)this).GetParent("DIRECTMATERIALSUPPLYACTION"); }
            set { this["DIRECTMATERIALSUPPLYACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DirectPurchaseGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASEGRID", dataRow) { }
        protected DirectPurchaseGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASEGRID", dataRow, isImported) { }
        public DirectPurchaseGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseGrid() : base() { }

    }
}