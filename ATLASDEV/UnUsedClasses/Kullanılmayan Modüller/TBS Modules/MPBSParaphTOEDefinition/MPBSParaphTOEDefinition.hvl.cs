
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSParaphTOEDefinition")] 

    /// <summary>
    /// Paraf TMK Tanımlama
    /// </summary>
    public  partial class MPBSParaphTOEDefinition : TTDefinitionSet
    {
        public class MPBSParaphTOEDefinitionList : TTObjectCollection<MPBSParaphTOEDefinition> { }
                    
        public class ChildMPBSParaphTOEDefinitionCollection : TTObject.TTChildObjectCollection<MPBSParaphTOEDefinition>
        {
            public ChildMPBSParaphTOEDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSParaphTOEDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("398743d9-429a-4a18-a580-e65e9f5bc959"); } }
            public static Guid Completed { get { return new Guid("b5394544-fd2e-4159-9f96-ca060105dab4"); } }
        }

    /// <summary>
    /// Paraf TMK Kodu
    /// </summary>
        public string ParaphTOECode
        {
            get { return (string)this["PARAPHTOECODE"]; }
            set { this["PARAPHTOECODE"] = value; }
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
    /// Ana TMK
    /// </summary>
        public MPBSMainTOEDefinition MainTOE
        {
            get { return (MPBSMainTOEDefinition)((ITTObject)this).GetParent("MAINTOE"); }
            set { this["MAINTOE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Şube
    /// </summary>
        public MPBSOfficeDefinition Office
        {
            get { return (MPBSOfficeDefinition)((ITTObject)this).GetParent("OFFICE"); }
            set { this["OFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPARAPHTOEDEFINITION", dataRow) { }
        protected MPBSParaphTOEDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPARAPHTOEDEFINITION", dataRow, isImported) { }
        public MPBSParaphTOEDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSParaphTOEDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSParaphTOEDefinition() : base() { }

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