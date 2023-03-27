
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedAction")] 

    /// <summary>
    /// Planlı Prosedür
    /// </summary>
    public  abstract  partial class PlannedAction : EpisodeActionWithDiagnosis
    {
        public class PlannedActionList : TTObjectCollection<PlannedAction> { }
                    
        public class ChildPlannedActionCollection : TTObject.TTChildObjectCollection<PlannedAction>
        {
            public ChildPlannedActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doktor İade Sebebi
    /// </summary>
        public object DoctorReturnDescription
        {
            get { return (object)this["DOCTORRETURNDESCRIPTION"]; }
            set { this["DOCTORRETURNDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Durdurulma İsteği
    /// </summary>
        public object AbortRequestDescription
        {
            get { return (object)this["ABORTREQUESTDESCRIPTION"]; }
            set { this["ABORTREQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Tedavi Başlangıç Tarih Saati
    /// </summary>
        public DateTime? TreatmentStartDateTime
        {
            get { return (DateTime?)this["TREATMENTSTARTDATETIME"]; }
            set { this["TREATMENTSTARTDATETIME"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOrderDetailsCollectionViews()
        {
        }

        virtual protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(this, new Guid("d68c3afd-d812-414b-b782-52dedb24ce17"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        protected SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection _OrderDetails = null;
    /// <summary>
    /// Child collection for Emir Detayları
    /// </summary>
        public SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection OrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _OrderDetails;
            }
        }

        protected PlannedAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDACTION", dataRow) { }
        protected PlannedAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDACTION", dataRow, isImported) { }
        public PlannedAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedAction() : base() { }

    }
}