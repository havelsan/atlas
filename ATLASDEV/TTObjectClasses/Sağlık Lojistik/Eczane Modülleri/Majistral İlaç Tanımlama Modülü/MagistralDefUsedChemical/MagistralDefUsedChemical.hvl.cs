
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralDefUsedChemical")] 

    public  partial class MagistralDefUsedChemical : TTObject
    {
        public class MagistralDefUsedChemicalList : TTObjectCollection<MagistralDefUsedChemical> { }
                    
        public class ChildMagistralDefUsedChemicalCollection : TTObject.TTChildObjectCollection<MagistralDefUsedChemical>
        {
            public ChildMagistralDefUsedChemicalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralDefUsedChemicalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim Miktar
    /// </summary>
        public double? UnitAmount
        {
            get { return (double?)this["UNITAMOUNT"]; }
            set { this["UNITAMOUNT"] = value; }
        }

        public MagistralChemicalDefinition MagistralChemicalDefinition
        {
            get { return (MagistralChemicalDefinition)((ITTObject)this).GetParent("MAGISTRALCHEMICALDEFINITION"); }
            set { this["MAGISTRALCHEMICALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationDefinition Magistral
        {
            get { return (MagistralPreparationDefinition)((ITTObject)this).GetParent("MAGISTRAL"); }
            set { this["MAGISTRAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralDefUsedChemical(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralDefUsedChemical(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralDefUsedChemical(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralDefUsedChemical(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralDefUsedChemical(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALDEFUSEDCHEMICAL", dataRow) { }
        protected MagistralDefUsedChemical(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALDEFUSEDCHEMICAL", dataRow, isImported) { }
        public MagistralDefUsedChemical(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralDefUsedChemical(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralDefUsedChemical() : base() { }

    }
}