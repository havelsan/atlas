
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GuardFormationDefinition")] 

    /// <summary>
    /// Nöbet Teşkili Tanımları
    /// </summary>
    public  partial class GuardFormationDefinition : TTDefinitionSet
    {
        public class GuardFormationDefinitionList : TTObjectCollection<GuardFormationDefinition> { }
                    
        public class ChildGuardFormationDefinitionCollection : TTObject.TTChildObjectCollection<GuardFormationDefinition>
        {
            public ChildGuardFormationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGuardFormationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        virtual protected void CreateGuardsCollection()
        {
            _Guards = new GuardGrid.ChildGuardGridCollection(this, new Guid("8192b6b0-dbdb-4b62-b260-ca02e5eee3f3"));
            ((ITTChildObjectCollection)_Guards).GetChildren();
        }

        protected GuardGrid.ChildGuardGridCollection _Guards = null;
    /// <summary>
    /// Child collection for GuardFormationDefinitionGuard
    /// </summary>
        public GuardGrid.ChildGuardGridCollection Guards
        {
            get
            {
                if (_Guards == null)
                    CreateGuardsCollection();
                return _Guards;
            }
        }

        protected GuardFormationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GuardFormationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GuardFormationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GuardFormationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GuardFormationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUARDFORMATIONDEFINITION", dataRow) { }
        protected GuardFormationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUARDFORMATIONDEFINITION", dataRow, isImported) { }
        protected GuardFormationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GuardFormationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GuardFormationDefinition() : base() { }

    }
}