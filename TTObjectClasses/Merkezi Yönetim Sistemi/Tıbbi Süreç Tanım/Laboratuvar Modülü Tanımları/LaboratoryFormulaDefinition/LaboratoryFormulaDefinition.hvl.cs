
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryFormulaDefinition")] 

    public  partial class LaboratoryFormulaDefinition : TTDefinitionSet
    {
        public class LaboratoryFormulaDefinitionList : TTObjectCollection<LaboratoryFormulaDefinition> { }
                    
        public class ChildLaboratoryFormulaDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryFormulaDefinition>
        {
            public ChildLaboratoryFormulaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryFormulaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Formül
    /// </summary>
        public string Formula
        {
            get { return (string)this["FORMULA"]; }
            set { this["FORMULA"] = value; }
        }

        virtual protected void CreateFormulaTestsCollection()
        {
            _FormulaTests = new LaboratoryGridFormulaDefinition.ChildLaboratoryGridFormulaDefinitionCollection(this, new Guid("21450da2-7f25-47e8-828d-aa04eb69e78b"));
            ((ITTChildObjectCollection)_FormulaTests).GetChildren();
        }

        protected LaboratoryGridFormulaDefinition.ChildLaboratoryGridFormulaDefinitionCollection _FormulaTests = null;
    /// <summary>
    /// Child collection for Laboratuvar Formül Tanımı İlişkisi
    /// </summary>
        public LaboratoryGridFormulaDefinition.ChildLaboratoryGridFormulaDefinitionCollection FormulaTests
        {
            get
            {
                if (_FormulaTests == null)
                    CreateFormulaTestsCollection();
                return _FormulaTests;
            }
        }

        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYFORMULADEFINITION", dataRow) { }
        protected LaboratoryFormulaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYFORMULADEFINITION", dataRow, isImported) { }
        public LaboratoryFormulaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryFormulaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryFormulaDefinition() : base() { }

    }
}