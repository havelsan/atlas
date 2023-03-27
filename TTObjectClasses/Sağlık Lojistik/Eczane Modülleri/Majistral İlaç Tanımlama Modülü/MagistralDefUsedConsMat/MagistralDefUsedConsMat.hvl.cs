
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralDefUsedConsMat")] 

    public  partial class MagistralDefUsedConsMat : TTObject
    {
        public class MagistralDefUsedConsMatList : TTObjectCollection<MagistralDefUsedConsMat> { }
                    
        public class ChildMagistralDefUsedConsMatCollection : TTObject.TTChildObjectCollection<MagistralDefUsedConsMat>
        {
            public ChildMagistralDefUsedConsMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralDefUsedConsMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim Miktar
    /// </summary>
        public double? UnitAmount
        {
            get { return (double?)this["UNITAMOUNT"]; }
            set { this["UNITAMOUNT"] = value; }
        }

        public ConsumableMaterialDefinition ConsumableMaterial
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("CONSUMABLEMATERIAL"); }
            set { this["CONSUMABLEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationDefinition Magistral
        {
            get { return (MagistralPreparationDefinition)((ITTObject)this).GetParent("MAGISTRAL"); }
            set { this["MAGISTRAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralDefUsedConsMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralDefUsedConsMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralDefUsedConsMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralDefUsedConsMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralDefUsedConsMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALDEFUSEDCONSMAT", dataRow) { }
        protected MagistralDefUsedConsMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALDEFUSEDCONSMAT", dataRow, isImported) { }
        public MagistralDefUsedConsMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralDefUsedConsMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralDefUsedConsMat() : base() { }

    }
}