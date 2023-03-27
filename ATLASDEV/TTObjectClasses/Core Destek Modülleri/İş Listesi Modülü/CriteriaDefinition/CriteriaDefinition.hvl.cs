
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CriteriaDefinition")] 

    public  partial class CriteriaDefinition : TerminologyManagerDef
    {
        public class CriteriaDefinitionList : TTObjectCollection<CriteriaDefinition> { }
                    
        public class ChildCriteriaDefinitionCollection : TTObject.TTChildObjectCollection<CriteriaDefinition>
        {
            public ChildCriteriaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCriteriaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string CriteriaType
        {
            get { return (string)this["CRITERIATYPE"]; }
            set { this["CRITERIATYPE"] = value; }
        }

    /// <summary>
    /// Özel 
    /// </summary>
        public bool? IsSpecial
        {
            get { return (bool?)this["ISSPECIAL"]; }
            set { this["ISSPECIAL"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string DefaultValue
        {
            get { return (string)this["DEFAULTVALUE"]; }
            set { this["DEFAULTVALUE"] = value; }
        }

        public WorkListDefinition Criteria
        {
            get { return (WorkListDefinition)((ITTObject)this).GetParent("CRITERIA"); }
            set { this["CRITERIA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCriteriaValuesCollection()
        {
            _CriteriaValues = new CriteriaValue.ChildCriteriaValueCollection(this, new Guid("dbe266c2-a336-4c49-8065-86384307872c"));
            ((ITTChildObjectCollection)_CriteriaValues).GetChildren();
        }

        protected CriteriaValue.ChildCriteriaValueCollection _CriteriaValues = null;
        public CriteriaValue.ChildCriteriaValueCollection CriteriaValues
        {
            get
            {
                if (_CriteriaValues == null)
                    CreateCriteriaValuesCollection();
                return _CriteriaValues;
            }
        }

        protected CriteriaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CriteriaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CriteriaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CriteriaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CriteriaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CRITERIADEFINITION", dataRow) { }
        protected CriteriaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CRITERIADEFINITION", dataRow, isImported) { }
        public CriteriaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CriteriaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CriteriaDefinition() : base() { }

    }
}