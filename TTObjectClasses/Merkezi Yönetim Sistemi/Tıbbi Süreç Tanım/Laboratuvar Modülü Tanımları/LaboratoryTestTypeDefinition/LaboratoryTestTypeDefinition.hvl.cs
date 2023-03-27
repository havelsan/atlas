
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTestTypeDefinition")] 

    /// <summary>
    /// Laboratuvar Test Tür Tanımları
    /// </summary>
    public  partial class LaboratoryTestTypeDefinition : TTDefinitionSet
    {
        public class LaboratoryTestTypeDefinitionList : TTObjectCollection<LaboratoryTestTypeDefinition> { }
                    
        public class ChildLaboratoryTestTypeDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryTestTypeDefinition>
        {
            public ChildLaboratoryTestTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTestTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<LaboratoryTestTypeDefinition> GetByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTYPEDEFINITION"].QueryDefs["GetByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryTestTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTESTTYPEDEFINITION", dataRow) { }
        protected LaboratoryTestTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTESTTYPEDEFINITION", dataRow, isImported) { }
        public LaboratoryTestTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTestTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTestTypeDefinition() : base() { }

    }
}