
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TreatmentDischargeDataCorrection")] 

    /// <summary>
    /// Muayene Tedavi Sonuç Veri Düzeltme
    /// </summary>
    public  partial class TreatmentDischargeDataCorrection : BaseEpisodeActionDataCorrection, IWorkListBaseAction
    {
        public class TreatmentDischargeDataCorrectionList : TTObjectCollection<TreatmentDischargeDataCorrection> { }
                    
        public class ChildTreatmentDischargeDataCorrectionCollection : TTObject.TTChildObjectCollection<TreatmentDischargeDataCorrection>
        {
            public ChildTreatmentDischargeDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTreatmentDischargeDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("0abc8d92-ef84-4378-9a63-3880fa137057"); } }
            public static Guid Cancelled { get { return new Guid("e5779ccd-9721-4c80-b49b-57ecd433ef3f"); } }
            public static Guid Completed { get { return new Guid("5fa82b01-564c-4bdb-81cc-c0caa6cdcba0"); } }
        }

        public DateTime? OldDischargeDate
        {
            get { return (DateTime?)this["OLDDISCHARGEDATE"]; }
            protected set { this["OLDDISCHARGEDATE"] = value; }
        }

        public DateTime? NewDischargeDate
        {
            get { return (DateTime?)this["NEWDISCHARGEDATE"]; }
            set { this["NEWDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Epizot İşlemi
    /// </summary>
        public TreatmentDischarge TreatmentDischarge
        {
            get 
            {   
                if (EpisodeAction is TreatmentDischarge)
                    return (TreatmentDischarge)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TREATMENTDISCHARGEDATACORRECTION", dataRow) { }
        protected TreatmentDischargeDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TREATMENTDISCHARGEDATACORRECTION", dataRow, isImported) { }
        public TreatmentDischargeDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TreatmentDischargeDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TreatmentDischargeDataCorrection() : base() { }

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