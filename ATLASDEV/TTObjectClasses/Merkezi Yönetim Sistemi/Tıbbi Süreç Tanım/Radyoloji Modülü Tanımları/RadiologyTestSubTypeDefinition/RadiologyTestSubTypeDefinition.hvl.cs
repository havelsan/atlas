
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTestSubTypeDefinition")] 

    /// <summary>
    /// Radyoloji Tetkik Alt Tür Tanımları
    /// </summary>
    public  partial class RadiologyTestSubTypeDefinition : TTDefinitionSet
    {
        public class RadiologyTestSubTypeDefinitionList : TTObjectCollection<RadiologyTestSubTypeDefinition> { }
                    
        public class ChildRadiologyTestSubTypeDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTestSubTypeDefinition>
        {
            public ChildRadiologyTestSubTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestSubTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("13046d0e-9adc-4fc5-9cc9-9de5a7e4cd6c"); } }
            public static Guid New { get { return new Guid("7d4c763c-5a29-4774-a7be-83790d5a73a8"); } }
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

    /// <summary>
    /// Id
    /// </summary>
        public long? Id
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTESTSUBTYPEDEFINITION", dataRow) { }
        protected RadiologyTestSubTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTESTSUBTYPEDEFINITION", dataRow, isImported) { }
        public RadiologyTestSubTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTestSubTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTestSubTypeDefinition() : base() { }

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