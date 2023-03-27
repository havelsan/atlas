
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPRuleMaster")] 

    public  partial class DPRuleMaster : TTDefinitionSet
    {
        public class DPRuleMasterList : TTObjectCollection<DPRuleMaster> { }
                    
        public class ChildDPRuleMasterCollection : TTObject.TTChildObjectCollection<DPRuleMaster>
        {
            public ChildDPRuleMasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPRuleMasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public GILDefinition GILDefinition
        {
            get { return (GILDefinition)((ITTObject)this).GetParent("GILDEFINITION"); }
            set { this["GILDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDpRuleDetailsCollection()
        {
            _DpRuleDetails = new DpRuleDetail.ChildDpRuleDetailCollection(this, new Guid("10cef6ce-72ef-4d3f-874e-ca780ac8dc53"));
            ((ITTChildObjectCollection)_DpRuleDetails).GetChildren();
        }

        protected DpRuleDetail.ChildDpRuleDetailCollection _DpRuleDetails = null;
        public DpRuleDetail.ChildDpRuleDetailCollection DpRuleDetails
        {
            get
            {
                if (_DpRuleDetails == null)
                    CreateDpRuleDetailsCollection();
                return _DpRuleDetails;
            }
        }

        virtual protected void CreateDpRuleProceduresCollection()
        {
            _DpRuleProcedures = new DpRuleProcedure.ChildDpRuleProcedureCollection(this, new Guid("a6b1ed13-7b25-4c99-a741-4d90ef1aefaf"));
            ((ITTChildObjectCollection)_DpRuleProcedures).GetChildren();
        }

        protected DpRuleProcedure.ChildDpRuleProcedureCollection _DpRuleProcedures = null;
        public DpRuleProcedure.ChildDpRuleProcedureCollection DpRuleProcedures
        {
            get
            {
                if (_DpRuleProcedures == null)
                    CreateDpRuleProceduresCollection();
                return _DpRuleProcedures;
            }
        }

        virtual protected void CreateDpRuleSpecialitiesCollection()
        {
            _DpRuleSpecialities = new DpRuleSpeciality.ChildDpRuleSpecialityCollection(this, new Guid("910da7ba-6d7f-4227-a360-4793826cbdc8"));
            ((ITTChildObjectCollection)_DpRuleSpecialities).GetChildren();
        }

        protected DpRuleSpeciality.ChildDpRuleSpecialityCollection _DpRuleSpecialities = null;
        public DpRuleSpeciality.ChildDpRuleSpecialityCollection DpRuleSpecialities
        {
            get
            {
                if (_DpRuleSpecialities == null)
                    CreateDpRuleSpecialitiesCollection();
                return _DpRuleSpecialities;
            }
        }

        virtual protected void CreateDpRuleDiagnosisCollection()
        {
            _DpRuleDiagnosis = new DpRuleDiagnos.ChildDpRuleDiagnosCollection(this, new Guid("97be8c4f-c787-455d-ad8b-7b4671b849e6"));
            ((ITTChildObjectCollection)_DpRuleDiagnosis).GetChildren();
        }

        protected DpRuleDiagnos.ChildDpRuleDiagnosCollection _DpRuleDiagnosis = null;
        public DpRuleDiagnos.ChildDpRuleDiagnosCollection DpRuleDiagnosis
        {
            get
            {
                if (_DpRuleDiagnosis == null)
                    CreateDpRuleDiagnosisCollection();
                return _DpRuleDiagnosis;
            }
        }

        virtual protected void CreateDpRuleScriptsCollection()
        {
            _DpRuleScripts = new DpRuleScript.ChildDpRuleScriptCollection(this, new Guid("13166ffd-40e4-40c6-abb8-d2d7e943869c"));
            ((ITTChildObjectCollection)_DpRuleScripts).GetChildren();
        }

        protected DpRuleScript.ChildDpRuleScriptCollection _DpRuleScripts = null;
        public DpRuleScript.ChildDpRuleScriptCollection DpRuleScripts
        {
            get
            {
                if (_DpRuleScripts == null)
                    CreateDpRuleScriptsCollection();
                return _DpRuleScripts;
            }
        }

        protected DPRuleMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPRuleMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPRuleMaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPRuleMaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPRuleMaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPRULEMASTER", dataRow) { }
        protected DPRuleMaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPRULEMASTER", dataRow, isImported) { }
        public DPRuleMaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPRuleMaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPRuleMaster() : base() { }

    }
}