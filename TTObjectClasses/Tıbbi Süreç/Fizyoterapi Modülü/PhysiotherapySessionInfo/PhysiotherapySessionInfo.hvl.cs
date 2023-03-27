
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapySessionInfo")] 

    public  partial class PhysiotherapySessionInfo : TTObject
    {
        public class PhysiotherapySessionInfoList : TTObjectCollection<PhysiotherapySessionInfo> { }
                    
        public class ChildPhysiotherapySessionInfoCollection : TTObject.TTChildObjectCollection<PhysiotherapySessionInfo>
        {
            public ChildPhysiotherapySessionInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapySessionInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Planlanan Tarih
    /// </summary>
        public DateTime? PlannedDate
        {
            get { return (DateTime?)this["PLANNEDDATE"]; }
            set { this["PLANNEDDATE"] = value; }
        }

    /// <summary>
    /// Fizyoterapi Emirleri
    /// </summary>
        public PhysiotherapyRequest PhysiotherapyRequest
        {
            get { return (PhysiotherapyRequest)((ITTObject)this).GetParent("PHYSIOTHERAPYREQUEST"); }
            set { this["PHYSIOTHERAPYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePhysiotherapyOrderDetailsCollection()
        {
            _PhysiotherapyOrderDetails = new PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection(this, new Guid("c5754baf-d29f-4c72-9d94-5a2697dde0fc"));
            ((ITTChildObjectCollection)_PhysiotherapyOrderDetails).GetChildren();
        }

        protected PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection _PhysiotherapyOrderDetails = null;
    /// <summary>
    /// Child collection for Fizyoterapi Seansları
    /// </summary>
        public PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection PhysiotherapyOrderDetails
        {
            get
            {
                if (_PhysiotherapyOrderDetails == null)
                    CreatePhysiotherapyOrderDetailsCollection();
                return _PhysiotherapyOrderDetails;
            }
        }

        protected PhysiotherapySessionInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapySessionInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapySessionInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapySessionInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapySessionInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYSESSIONINFO", dataRow) { }
        protected PhysiotherapySessionInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYSESSIONINFO", dataRow, isImported) { }
        public PhysiotherapySessionInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapySessionInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapySessionInfo() : base() { }

    }
}