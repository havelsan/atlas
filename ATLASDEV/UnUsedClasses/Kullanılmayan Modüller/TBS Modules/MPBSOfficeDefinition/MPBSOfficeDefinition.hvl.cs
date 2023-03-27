
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSOfficeDefinition")] 

    /// <summary>
    /// Şube Tanımlama
    /// </summary>
    public  partial class MPBSOfficeDefinition : TTDefinitionSet
    {
        public class MPBSOfficeDefinitionList : TTObjectCollection<MPBSOfficeDefinition> { }
                    
        public class ChildMPBSOfficeDefinitionCollection : TTObject.TTChildObjectCollection<MPBSOfficeDefinition>
        {
            public ChildMPBSOfficeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSOfficeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("c7995eac-a931-44db-bd86-096146813a8c"); } }
            public static Guid New { get { return new Guid("65cdede5-dc48-49e2-9114-8b06a03db508"); } }
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

    /// <summary>
    /// ghrfgh
    /// </summary>
        public MPBSUnitDefinition UnitDefinition
        {
            get { return (MPBSUnitDefinition)((ITTObject)this).GetParent("UNITDEFINITION"); }
            set { this["UNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSectionDefinitionCollection()
        {
            _SectionDefinition = new MPBSSectionDefinition.ChildMPBSSectionDefinitionCollection(this, new Guid("e73bf8c7-7571-42e2-9e8d-617c165eae01"));
            ((ITTChildObjectCollection)_SectionDefinition).GetChildren();
        }

        protected MPBSSectionDefinition.ChildMPBSSectionDefinitionCollection _SectionDefinition = null;
        public MPBSSectionDefinition.ChildMPBSSectionDefinitionCollection SectionDefinition
        {
            get
            {
                if (_SectionDefinition == null)
                    CreateSectionDefinitionCollection();
                return _SectionDefinition;
            }
        }

        protected MPBSOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSOfficeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSOFFICEDEFINITION", dataRow) { }
        protected MPBSOfficeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSOFFICEDEFINITION", dataRow, isImported) { }
        public MPBSOfficeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSOfficeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSOfficeDefinition() : base() { }

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