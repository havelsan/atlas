
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SEPMaster")] 

    /// <summary>
    /// Medula Başvuru
    /// </summary>
    public  partial class SEPMaster : TTObject
    {
        public class SEPMasterList : TTObjectCollection<SEPMaster> { }
                    
        public class ChildSEPMasterCollection : TTObject.TTChildObjectCollection<SEPMaster>
        {
            public ChildSEPMasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSEPMasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("a2bbaf4b-0f07-4a41-a203-afa2927b0dc6"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        protected SEPMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SEPMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SEPMaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SEPMaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SEPMaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEPMASTER", dataRow) { }
        protected SEPMaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEPMASTER", dataRow, isImported) { }
        public SEPMaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SEPMaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SEPMaster() : base() { }

    }
}