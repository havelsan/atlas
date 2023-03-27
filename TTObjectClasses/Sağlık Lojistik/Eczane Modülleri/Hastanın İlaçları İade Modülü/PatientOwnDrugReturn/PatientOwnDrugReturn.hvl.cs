
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugReturn")] 

    public  partial class PatientOwnDrugReturn : EpisodeAction
    {
        public class PatientOwnDrugReturnList : TTObjectCollection<PatientOwnDrugReturn> { }
                    
        public class ChildPatientOwnDrugReturnCollection : TTObject.TTChildObjectCollection<PatientOwnDrugReturn>
        {
            public ChildPatientOwnDrugReturnCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugReturnCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5b0ccbea-e981-4491-a6de-ed9394324c38"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("f6cb68b3-53ed-45df-a160-a583fc028f1b"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("425b9387-bf11-492a-953b-3f1b56b624b6"); } }
        }

        virtual protected void CreatePatientOwnDrugReturnDetailsCollection()
        {
            _PatientOwnDrugReturnDetails = new PatientOwnDrugReturnDetail.ChildPatientOwnDrugReturnDetailCollection(this, new Guid("674904d8-1aa4-445d-abc4-150d3ba36984"));
            ((ITTChildObjectCollection)_PatientOwnDrugReturnDetails).GetChildren();
        }

        protected PatientOwnDrugReturnDetail.ChildPatientOwnDrugReturnDetailCollection _PatientOwnDrugReturnDetails = null;
        public PatientOwnDrugReturnDetail.ChildPatientOwnDrugReturnDetailCollection PatientOwnDrugReturnDetails
        {
            get
            {
                if (_PatientOwnDrugReturnDetails == null)
                    CreatePatientOwnDrugReturnDetailsCollection();
                return _PatientOwnDrugReturnDetails;
            }
        }

        protected PatientOwnDrugReturn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugReturn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugReturn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugReturn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugReturn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGRETURN", dataRow) { }
        protected PatientOwnDrugReturn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGRETURN", dataRow, isImported) { }
        public PatientOwnDrugReturn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugReturn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugReturn() : base() { }

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