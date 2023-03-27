
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VitalSign")] 

    public  abstract  partial class VitalSign : TTObject
    {
        public class VitalSignList : TTObjectCollection<VitalSign> { }
                    
        public class ChildVitalSignCollection : TTObject.TTChildObjectCollection<VitalSign>
        {
            public ChildVitalSignCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVitalSignCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uygulama Tarihi
    /// </summary>
        public DateTime? ExecutionDate
        {
            get { return (DateTime?)this["EXECUTIONDATE"]; }
            set { this["EXECUTIONDATE"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingOrderDetailsCollection()
        {
            _NursingOrderDetails = new BaseNursingOrderDetails.ChildBaseNursingOrderDetailsCollection(this, new Guid("232ad889-a7b1-4bd6-9a7c-ae562514dd8f"));
            ((ITTChildObjectCollection)_NursingOrderDetails).GetChildren();
        }

        protected BaseNursingOrderDetails.ChildBaseNursingOrderDetailsCollection _NursingOrderDetails = null;
        public BaseNursingOrderDetails.ChildBaseNursingOrderDetailsCollection NursingOrderDetails
        {
            get
            {
                if (_NursingOrderDetails == null)
                    CreateNursingOrderDetailsCollection();
                return _NursingOrderDetails;
            }
        }

        protected VitalSign(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VitalSign(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VitalSign(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VitalSign(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VitalSign(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VITALSIGN", dataRow) { }
        protected VitalSign(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VITALSIGN", dataRow, isImported) { }
        public VitalSign(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VitalSign(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VitalSign() : base() { }

    }
}