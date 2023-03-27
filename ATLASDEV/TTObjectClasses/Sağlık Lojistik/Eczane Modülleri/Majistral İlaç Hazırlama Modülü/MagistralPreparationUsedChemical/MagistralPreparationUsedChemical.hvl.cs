
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationUsedChemical")] 

    /// <summary>
    /// Kullanılan Hammaddeler Sekmesi
    /// </summary>
    public  partial class MagistralPreparationUsedChemical : TTObject
    {
        public class MagistralPreparationUsedChemicalList : TTObjectCollection<MagistralPreparationUsedChemical> { }
                    
        public class ChildMagistralPreparationUsedChemicalCollection : TTObject.TTChildObjectCollection<MagistralPreparationUsedChemical>
        {
            public ChildMagistralPreparationUsedChemicalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationUsedChemicalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public MagistralChemicalDefinition MagistralChemicalDefinition
        {
            get { return (MagistralChemicalDefinition)((ITTObject)this).GetParent("MAGISTRALCHEMICALDEFINITION"); }
            set { this["MAGISTRALCHEMICALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationAction MagistralPreparationAction
        {
            get { return (MagistralPreparationAction)((ITTObject)this).GetParent("MAGISTRALPREPARATIONACTION"); }
            set { this["MAGISTRALPREPARATIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONUSEDCHEMICAL", dataRow) { }
        protected MagistralPreparationUsedChemical(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONUSEDCHEMICAL", dataRow, isImported) { }
        public MagistralPreparationUsedChemical(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationUsedChemical(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationUsedChemical() : base() { }

    }
}