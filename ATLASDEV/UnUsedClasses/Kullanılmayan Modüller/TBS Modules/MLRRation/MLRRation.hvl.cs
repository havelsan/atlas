
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRRation")] 

    public  partial class MLRRation : TTObject
    {
        public class MLRRationList : TTObjectCollection<MLRRation> { }
                    
        public class ChildMLRRationCollection : TTObject.TTChildObjectCollection<MLRRation>
        {
            public ChildMLRRationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRRationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Complete { get { return new Guid("160e472e-c32f-4e93-b648-03d84ec7fc35"); } }
            public static Guid RegimeGroup { get { return new Guid("36b8f631-ad16-41b9-9484-073919a71c49"); } }
            public static Guid New { get { return new Guid("d6123447-fab2-4859-98f2-9073d72d0a1b"); } }
        }

    /// <summary>
    /// Toplam Hasta
    /// </summary>
        public int? PatientCount
        {
            get { return (int?)this["PATIENTCOUNT"]; }
            set { this["PATIENTCOUNT"] = value; }
        }

    /// <summary>
    /// Verileceği Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Düzenleyen Servis
    /// </summary>
        public Service OrganizerService
        {
            get { return (Service)((ITTObject)this).GetParent("ORGANIZERSERVICE"); }
            set { this["ORGANIZERSERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Onaylayan Diyetisyen
    /// </summary>
        public Personnel ApprovalDietician
        {
            get { return (Personnel)((ITTObject)this).GetParent("APPROVALDIETICIAN"); }
            set { this["APPROVALDIETICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Düzenleyen Kişi
    /// </summary>
        public Personnel OrganizerPerson
        {
            get { return (Personnel)((ITTObject)this).GetParent("ORGANIZERPERSON"); }
            set { this["ORGANIZERPERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyetisyen
    /// </summary>
        public Personnel Dietician
        {
            get { return (Personnel)((ITTObject)this).GetParent("DIETICIAN"); }
            set { this["DIETICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Onaylayan
    /// </summary>
        public Personnel ApprovedBy
        {
            get { return (Personnel)((ITTObject)this).GetParent("APPROVEDBY"); }
            set { this["APPROVEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRegimeGroupsCollection()
        {
            _RegimeGroups = new MLRRationRegimeGroup.ChildMLRRationRegimeGroupCollection(this, new Guid("fa6aafcf-5479-453f-9a6e-7c6e1ce4a00a"));
            ((ITTChildObjectCollection)_RegimeGroups).GetChildren();
        }

        protected MLRRationRegimeGroup.ChildMLRRationRegimeGroupCollection _RegimeGroups = null;
    /// <summary>
    /// Child collection for Rasyon
    /// </summary>
        public MLRRationRegimeGroup.ChildMLRRationRegimeGroupCollection RegimeGroups
        {
            get
            {
                if (_RegimeGroups == null)
                    CreateRegimeGroupsCollection();
                return _RegimeGroups;
            }
        }

        protected MLRRation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRRation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRRation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRRation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRRation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRRATION", dataRow) { }
        protected MLRRation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRRATION", dataRow, isImported) { }
        public MLRRation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRRation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRRation() : base() { }

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