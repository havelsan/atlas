
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDentalEpisodeAction")] 

    public  partial class BaseDentalEpisodeAction : PhysicianApplication
    {
        public class BaseDentalEpisodeActionList : TTObjectCollection<BaseDentalEpisodeAction> { }
                    
        public class ChildBaseDentalEpisodeActionCollection : TTObject.TTChildObjectCollection<BaseDentalEpisodeAction>
        {
            public ChildBaseDentalEpisodeActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDentalEpisodeActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ToothNumbers
        {
            get { return (string)this["TOOTHNUMBERS"]; }
            set { this["TOOTHNUMBERS"] = value; }
        }

        override protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("06ea096e-ae43-4fbb-b8ec-8a5da2d3ad42"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected BaseDentalEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDentalEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDentalEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDentalEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDentalEpisodeAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDENTALEPISODEACTION", dataRow) { }
        protected BaseDentalEpisodeAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDENTALEPISODEACTION", dataRow, isImported) { }
        public BaseDentalEpisodeAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDentalEpisodeAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDentalEpisodeAction() : base() { }

    }
}