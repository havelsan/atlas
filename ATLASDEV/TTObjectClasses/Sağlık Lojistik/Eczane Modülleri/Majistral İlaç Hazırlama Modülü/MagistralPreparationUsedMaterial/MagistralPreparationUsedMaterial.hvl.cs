
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationUsedMaterial")] 

    /// <summary>
    /// Kullanılan Sarf Malzeme Sekmesi
    /// </summary>
    public  partial class MagistralPreparationUsedMaterial : TTObject
    {
        public class MagistralPreparationUsedMaterialList : TTObjectCollection<MagistralPreparationUsedMaterial> { }
                    
        public class ChildMagistralPreparationUsedMaterialCollection : TTObject.TTChildObjectCollection<MagistralPreparationUsedMaterial>
        {
            public ChildMagistralPreparationUsedMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationUsedMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ConsumableMaterialDefinition ConsumableMaterial
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("CONSUMABLEMATERIAL"); }
            set { this["CONSUMABLEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationAction MagistralPreparationAction
        {
            get { return (MagistralPreparationAction)((ITTObject)this).GetParent("MAGISTRALPREPARATIONACTION"); }
            set { this["MAGISTRALPREPARATIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONUSEDMATERIAL", dataRow) { }
        protected MagistralPreparationUsedMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONUSEDMATERIAL", dataRow, isImported) { }
        public MagistralPreparationUsedMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationUsedMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationUsedMaterial() : base() { }

    }
}