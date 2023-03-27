
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientConsumptionCancel")] 

    /// <summary>
    /// Hasta Sarf Giriş İptali
    /// </summary>
    public  partial class PatientConsumptionCancel : BaseAction, IWorkListBaseAction
    {
        public class PatientConsumptionCancelList : TTObjectCollection<PatientConsumptionCancel> { }
                    
        public class ChildPatientConsumptionCancelCollection : TTObject.TTChildObjectCollection<PatientConsumptionCancel>
        {
            public ChildPatientConsumptionCancelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientConsumptionCancelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Giriş
    /// </summary>
            public static Guid New { get { return new Guid("f12038e9-2d43-4153-aad4-316450e47aa4"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("cb144693-56c4-4a11-8e82-1462351f3ef0"); } }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePCC_SubactionMaterialsCollection()
        {
            _PCC_SubactionMaterials = new PCC_SubactionMaterial.ChildPCC_SubactionMaterialCollection(this, new Guid("377a7c5c-856b-4cae-9426-2989d0e37e0f"));
            ((ITTChildObjectCollection)_PCC_SubactionMaterials).GetChildren();
        }

        protected PCC_SubactionMaterial.ChildPCC_SubactionMaterialCollection _PCC_SubactionMaterials = null;
        public PCC_SubactionMaterial.ChildPCC_SubactionMaterialCollection PCC_SubactionMaterials
        {
            get
            {
                if (_PCC_SubactionMaterials == null)
                    CreatePCC_SubactionMaterialsCollection();
                return _PCC_SubactionMaterials;
            }
        }

        protected PatientConsumptionCancel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientConsumptionCancel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientConsumptionCancel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientConsumptionCancel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientConsumptionCancel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTCONSUMPTIONCANCEL", dataRow) { }
        protected PatientConsumptionCancel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTCONSUMPTIONCANCEL", dataRow, isImported) { }
        public PatientConsumptionCancel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientConsumptionCancel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientConsumptionCancel() : base() { }

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