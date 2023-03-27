
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VaccineFollowUp")] 

    /// <summary>
    /// Nabız 207 Aşı Veri Seti
    /// </summary>
    public  partial class VaccineFollowUp : EpisodeAction
    {
        public class VaccineFollowUpList : TTObjectCollection<VaccineFollowUp> { }
                    
        public class ChildVaccineFollowUpCollection : TTObject.TTChildObjectCollection<VaccineFollowUp>
        {
            public ChildVaccineFollowUpCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccineFollowUpCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ad3d097b-88ee-43cc-83a1-05146a4e7445"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("336b6706-da8c-427b-98ea-3f0e2ace0b66"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Canceled { get { return new Guid("ec188e7c-4356-46f1-909d-699be7bfc8fa"); } }
        }

        virtual protected void CreateVaccineDetailsCollection()
        {
            _VaccineDetails = new VaccineDetails.ChildVaccineDetailsCollection(this, new Guid("d1248fed-ff22-4827-9b37-959ce4f20cee"));
            ((ITTChildObjectCollection)_VaccineDetails).GetChildren();
        }

        protected VaccineDetails.ChildVaccineDetailsCollection _VaccineDetails = null;
        public VaccineDetails.ChildVaccineDetailsCollection VaccineDetails
        {
            get
            {
                if (_VaccineDetails == null)
                    CreateVaccineDetailsCollection();
                return _VaccineDetails;
            }
        }

        protected VaccineFollowUp(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VaccineFollowUp(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VaccineFollowUp(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VaccineFollowUp(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VaccineFollowUp(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINEFOLLOWUP", dataRow) { }
        protected VaccineFollowUp(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINEFOLLOWUP", dataRow, isImported) { }
        public VaccineFollowUp(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VaccineFollowUp(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VaccineFollowUp() : base() { }

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