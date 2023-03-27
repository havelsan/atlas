
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyTreatmentNote")] 

    /// <summary>
    /// FTR Tedavi Notu/Açıklamaları
    /// </summary>
    public  partial class PhysiotherapyTreatmentNote : TTObject
    {
        public class PhysiotherapyTreatmentNoteList : TTObjectCollection<PhysiotherapyTreatmentNote> { }
                    
        public class ChildPhysiotherapyTreatmentNoteCollection : TTObject.TTChildObjectCollection<PhysiotherapyTreatmentNote>
        {
            public ChildPhysiotherapyTreatmentNoteCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyTreatmentNoteCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PhysiotherapyTreatmentNote> GetTreatmentNoteByEpisodeActionAndUnit(TTObjectContext objectContext, Guid EpisodeActionID, Guid TreatmentDiagnosisUnit)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYTREATMENTNOTE"].QueryDefs["GetTreatmentNoteByEpisodeActionAndUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EpisodeActionID);
            paramList.Add("TREATMENTDIAGNOSISUNIT", TreatmentDiagnosisUnit);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyTreatmentNote>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyTreatmentNote> GetTreatmentNoteByEpisodeAction(TTObjectContext objectContext, Guid EpisodeActionID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYTREATMENTNOTE"].QueryDefs["GetTreatmentNoteByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EpisodeActionID);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyTreatmentNote>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Seans sonlandırma işlemlerindeki açıklama
    /// </summary>
        public bool? IsCompletedOrder
        {
            get { return (bool?)this["ISCOMPLETEDORDER"]; }
            set { this["ISCOMPLETEDORDER"] = value; }
        }

    /// <summary>
    /// Giriş Yapılan Zaman
    /// </summary>
        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tedavi Tamamlama işlemlerindeki açıklama
    /// </summary>
        public bool? IsCompletedRequest
        {
            get { return (bool?)this["ISCOMPLETEDREQUEST"]; }
            set { this["ISCOMPLETEDREQUEST"] = value; }
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser EntryUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ENTRYUSER"); }
            set { this["ENTRYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYTREATMENTNOTE", dataRow) { }
        protected PhysiotherapyTreatmentNote(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYTREATMENTNOTE", dataRow, isImported) { }
        public PhysiotherapyTreatmentNote(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyTreatmentNote(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyTreatmentNote() : base() { }

    }
}