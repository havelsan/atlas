
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabGridSpecialityDefinition")] 

    public  partial class LabGridSpecialityDefinition : TTDefinitionSet
    {
        public class LabGridSpecialityDefinitionList : TTObjectCollection<LabGridSpecialityDefinition> { }
                    
        public class ChildLabGridSpecialityDefinitionCollection : TTObject.TTChildObjectCollection<LabGridSpecialityDefinition>
        {
            public ChildLabGridSpecialityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabGridSpecialityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Branş Listesi
    /// </summary>
        public SpecialityDefinition SpecialityDefiniton
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITON"); }
            set { this["SPECIALITYDEFINITON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tahlil Branş İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LabGridSpecialityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabGridSpecialityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabGridSpecialityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabGridSpecialityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabGridSpecialityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABGRIDSPECIALITYDEFINITION", dataRow) { }
        protected LabGridSpecialityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABGRIDSPECIALITYDEFINITION", dataRow, isImported) { }
        public LabGridSpecialityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabGridSpecialityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabGridSpecialityDefinition() : base() { }

    }
}