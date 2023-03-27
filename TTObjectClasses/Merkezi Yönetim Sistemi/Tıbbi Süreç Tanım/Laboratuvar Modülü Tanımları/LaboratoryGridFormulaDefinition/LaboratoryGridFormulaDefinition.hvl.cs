
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridFormulaDefinition")] 

    public  partial class LaboratoryGridFormulaDefinition : TTDefinitionSet
    {
        public class LaboratoryGridFormulaDefinitionList : TTObjectCollection<LaboratoryGridFormulaDefinition> { }
                    
        public class ChildLaboratoryGridFormulaDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridFormulaDefinition>
        {
            public ChildLaboratoryGridFormulaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridFormulaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Formül Değişkeni
    /// </summary>
        public LaboratoryFormulaVariableEnum? FormulaVariable
        {
            get { return (LaboratoryFormulaVariableEnum?)(int?)this["FORMULAVARIABLE"]; }
            set { this["FORMULAVARIABLE"] = value; }
        }

    /// <summary>
    /// Laboratuvar Formül Tanımı İlişkisi
    /// </summary>
        public LaboratoryFormulaDefinition LaboratoryFormula
        {
            get { return (LaboratoryFormulaDefinition)((ITTObject)this).GetParent("LABORATORYFORMULA"); }
            set { this["LABORATORYFORMULA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDFORMULADEFINITION", dataRow) { }
        protected LaboratoryGridFormulaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDFORMULADEFINITION", dataRow, isImported) { }
        public LaboratoryGridFormulaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridFormulaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridFormulaDefinition() : base() { }

    }
}