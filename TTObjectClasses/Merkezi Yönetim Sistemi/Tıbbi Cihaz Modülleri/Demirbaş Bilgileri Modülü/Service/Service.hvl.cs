
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Service")] 

    /// <summary>
    /// Servis
    /// </summary>
    public  partial class Service : TTDefinitionSet
    {
        public class ServiceList : TTObjectCollection<Service> { }
                    
        public class ChildServiceCollection : TTObject.TTChildObjectCollection<Service>
        {
            public ChildServiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildServiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<Service> GetServices(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SERVICE"].QueryDefs["GetServices"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Service>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string code
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

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateFixedAssetMaterialDefinitionsCollection()
        {
            _FixedAssetMaterialDefinitions = new FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection(this, new Guid("3f7edbcd-672d-4f50-aa05-6d05c0a0733d"));
            ((ITTChildObjectCollection)_FixedAssetMaterialDefinitions).GetChildren();
        }

        protected FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection _FixedAssetMaterialDefinitions = null;
        public FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection FixedAssetMaterialDefinitions
        {
            get
            {
                if (_FixedAssetMaterialDefinitions == null)
                    CreateFixedAssetMaterialDefinitionsCollection();
                return _FixedAssetMaterialDefinitions;
            }
        }

        protected Service(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Service(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Service(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Service(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Service(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SERVICE", dataRow) { }
        protected Service(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SERVICE", dataRow, isImported) { }
        public Service(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Service(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Service() : base() { }

    }
}