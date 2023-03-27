
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCUncompleted")] 

    /// <summary>
    /// Tamamlanmamış Sağlık Kurulu
    /// </summary>
    public  partial class HCUncompleted : TTObject
    {
        public class HCUncompletedList : TTObjectCollection<HCUncompleted> { }
                    
        public class ChildHCUncompletedCollection : TTObject.TTChildObjectCollection<HCUncompleted>
        {
            public ChildHCUncompletedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCUncompletedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c3042668-e77c-44ce-b552-a6d109b48d74"); } }
    /// <summary>
    /// Tamamlanmadı
    /// </summary>
            public static Guid Uncompleted { get { return new Guid("b61d33e7-527b-46be-901c-3ac11becb5f7"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("48919def-0520-4482-bd52-e1010d999018"); } }
        }

        public static BindingList<HCUncompleted> GetByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCUNCOMPLETED"].QueryDefs["GetByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<HCUncompleted>(queryDef, paramList);
        }

        public static BindingList<HCUncompleted> GetByPatientAndCreationDate(TTObjectContext objectContext, Guid PATIENT, DateTime STARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCUNCOMPLETED"].QueryDefs["GetByPatientAndCreationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<HCUncompleted>(queryDef, paramList);
        }

    /// <summary>
    /// Vaka Açılış Tarihi
    /// </summary>
        public DateTime? EpisodeOpeningDate
        {
            get { return (DateTime?)this["EPISODEOPENINGDATE"]; }
            set { this["EPISODEOPENINGDATE"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu işleminin ObjectID si
    /// </summary>
        public Guid? HCObjectID
        {
            get { return (Guid?)this["HCOBJECTID"]; }
            set { this["HCOBJECTID"] = value; }
        }

    /// <summary>
    /// Vakanın XXXXXX Protokol No
    /// </summary>
        public string EpisodeHospitalProtocolNo
        {
            get { return (string)this["EPISODEHOSPITALPROTOCOLNO"]; }
            set { this["EPISODEHOSPITALPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu işlem numarası
    /// </summary>
        public string HCActionID
        {
            get { return (string)this["HCACTIONID"]; }
            set { this["HCACTIONID"] = value; }
        }

    /// <summary>
    /// Oluşturulma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saha
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCUncompleted(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCUncompleted(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCUncompleted(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCUncompleted(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCUncompleted(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCUNCOMPLETED", dataRow) { }
        protected HCUncompleted(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCUNCOMPLETED", dataRow, isImported) { }
        public HCUncompleted(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCUncompleted(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCUncompleted() : base() { }

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