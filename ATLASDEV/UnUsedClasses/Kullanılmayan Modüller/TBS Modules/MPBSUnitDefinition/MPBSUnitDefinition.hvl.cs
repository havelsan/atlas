
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSUnitDefinition")] 

    /// <summary>
    /// Birlik Tanımlama
    /// </summary>
    public  partial class MPBSUnitDefinition : TTDefinitionSet
    {
        public class MPBSUnitDefinitionList : TTObjectCollection<MPBSUnitDefinition> { }
                    
        public class ChildMPBSUnitDefinitionCollection : TTObject.TTChildObjectCollection<MPBSUnitDefinition>
        {
            public ChildMPBSUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("d19a142e-0f04-4355-b669-142c4ebc57d7"); } }
            public static Guid Completed { get { return new Guid("ac0bcfb8-b1b3-4306-97d7-5f5f148ff0d4"); } }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateMainTOEDefinitionCollection()
        {
            _MainTOEDefinition = new MPBSMainTOEDefinition.ChildMPBSMainTOEDefinitionCollection(this, new Guid("dbb67f43-89ff-40c9-9bd4-a327fbc1999f"));
            ((ITTChildObjectCollection)_MainTOEDefinition).GetChildren();
        }

        protected MPBSMainTOEDefinition.ChildMPBSMainTOEDefinitionCollection _MainTOEDefinition = null;
        public MPBSMainTOEDefinition.ChildMPBSMainTOEDefinitionCollection MainTOEDefinition
        {
            get
            {
                if (_MainTOEDefinition == null)
                    CreateMainTOEDefinitionCollection();
                return _MainTOEDefinition;
            }
        }

        virtual protected void CreateOfficeDefinitionCollection()
        {
            _OfficeDefinition = new MPBSOfficeDefinition.ChildMPBSOfficeDefinitionCollection(this, new Guid("6e681f44-8395-4169-b19e-ada9ede58721"));
            ((ITTChildObjectCollection)_OfficeDefinition).GetChildren();
        }

        protected MPBSOfficeDefinition.ChildMPBSOfficeDefinitionCollection _OfficeDefinition = null;
    /// <summary>
    /// Child collection for ghrfgh
    /// </summary>
        public MPBSOfficeDefinition.ChildMPBSOfficeDefinitionCollection OfficeDefinition
        {
            get
            {
                if (_OfficeDefinition == null)
                    CreateOfficeDefinitionCollection();
                return _OfficeDefinition;
            }
        }

        protected MPBSUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSUNITDEFINITION", dataRow) { }
        protected MPBSUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSUNITDEFINITION", dataRow, isImported) { }
        public MPBSUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSUnitDefinition() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}