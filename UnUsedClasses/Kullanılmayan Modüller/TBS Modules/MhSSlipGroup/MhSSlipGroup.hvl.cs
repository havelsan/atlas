
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSSlipGroup")] 

    /// <summary>
    /// Fiş Grubu
    /// </summary>
    public  partial class MhSSlipGroup : TTDefinitionSet
    {
        public class MhSSlipGroupList : TTObjectCollection<MhSSlipGroup> { }
                    
        public class ChildMhSSlipGroupCollection : TTObject.TTChildObjectCollection<MhSSlipGroup>
        {
            public ChildMhSSlipGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSSlipGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tip
    /// </summary>
        public MhSSlipGroupTypesEnum? Type
        {
            get { return (MhSSlipGroupTypesEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected MhSSlipGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSSlipGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSSlipGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSSlipGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSSlipGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSSLIPGROUP", dataRow) { }
        protected MhSSlipGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSSLIPGROUP", dataRow, isImported) { }
        public MhSSlipGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSSlipGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSSlipGroup() : base() { }

    }
}