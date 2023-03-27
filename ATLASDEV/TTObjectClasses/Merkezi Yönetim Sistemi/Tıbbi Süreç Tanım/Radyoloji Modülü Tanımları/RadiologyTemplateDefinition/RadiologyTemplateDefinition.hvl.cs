
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTemplateDefinition")] 

    public  partial class RadiologyTemplateDefinition : TTDefinitionSet
    {
        public class RadiologyTemplateDefinitionList : TTObjectCollection<RadiologyTemplateDefinition> { }
                    
        public class ChildRadiologyTemplateDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTemplateDefinition>
        {
            public ChildRadiologyTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("cb7421f1-1df5-43f2-9270-a8cda334265f"); } }
            public static Guid Completed { get { return new Guid("8ee5821b-2dfe-4755-bc66-df496eb09b74"); } }
        }

    /// <summary>
    /// Id
    /// </summary>
        public int? Id
        {
            get { return (int?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
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

        protected RadiologyTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTEMPLATEDEFINITION", dataRow) { }
        protected RadiologyTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTEMPLATEDEFINITION", dataRow, isImported) { }
        public RadiologyTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTemplateDefinition() : base() { }

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