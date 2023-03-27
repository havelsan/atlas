
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseBlockAppointment")] 

    /// <summary>
    /// Blok Randevu İşlemleri için Kullanılan Ana  objedir
    /// </summary>
    public  abstract  partial class BaseBlockAppointment : BaseAdmissionAppointment, IStartFromNewActionInPatientFolder, IAppointmentDef
    {
        public class BaseBlockAppointmentList : TTObjectCollection<BaseBlockAppointment> { }
                    
        public class ChildBaseBlockAppointmentCollection : TTObject.TTChildObjectCollection<BaseBlockAppointment>
        {
            public ChildBaseBlockAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseBlockAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Accepted { get { return new Guid("78f5bc26-9bd4-473f-85a7-764a7ec88a1b"); } }
            public static Guid Acception { get { return new Guid("aed3cf00-0889-41af-bb69-2c7771ed68f4"); } }
            public static Guid Canceled { get { return new Guid("e30ca81e-c6b0-44b2-847e-1aa658c60d12"); } }
            public static Guid Completed { get { return new Guid("921a6968-faca-46a7-8ed5-8a43b8fa1765"); } }
    /// <summary>
    /// Randevu verilir 
    /// </summary>
            public static Guid Request { get { return new Guid("2adbf4f8-e9f8-4224-bde1-794baef9bc28"); } }
        }

    /// <summary>
    /// Randevu Tarihi
    /// </summary>
        public DateTime? AppDate
        {
            get { return (DateTime?)this["APPDATE"]; }
            set { this["APPDATE"] = value; }
        }

        public DateTime? EndDateTime
        {
            get { return (DateTime?)this["ENDDATETIME"]; }
            set { this["ENDDATETIME"] = value; }
        }

        public int? EstimatedTime
        {
            get { return (int?)this["ESTIMATEDTIME"]; }
            set { this["ESTIMATEDTIME"] = value; }
        }

        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

        public DateTime? StartDateTime
        {
            get { return (DateTime?)this["STARTDATETIME"]; }
            set { this["STARTDATETIME"] = value; }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction StarterEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("STARTEREPISODEACTION"); }
            set { this["STARTEREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Gerçekleştiren Doktor Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randevu sonucu İşlemin Başlatılacağı episode
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseBlockAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseBlockAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseBlockAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseBlockAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseBlockAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEBLOCKAPPOINTMENT", dataRow) { }
        protected BaseBlockAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEBLOCKAPPOINTMENT", dataRow, isImported) { }
        public BaseBlockAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseBlockAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseBlockAppointment() : base() { }

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