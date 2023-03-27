
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugSchedule")] 

    /// <summary>
    /// Hemşirelik İlaç İstek
    /// </summary>
    public  partial class DailyDrugSchedule : StockAction
    {
        public class DailyDrugScheduleList : TTObjectCollection<DailyDrugSchedule> { }
                    
        public class ChildDailyDrugScheduleCollection : TTObject.TTChildObjectCollection<DailyDrugSchedule>
        {
            public ChildDailyDrugScheduleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugScheduleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("f8fae4b1-a7dd-4095-b2bc-4453823b9832"); } }
            public static Guid Completed { get { return new Guid("82e599ee-70da-4d51-953c-f41c8e03f646"); } }
            public static Guid New { get { return new Guid("815aa4d9-3840-4d1c-8996-d157255bf768"); } }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        virtual protected void CreateDailyDrugSchOrdersCollection()
        {
            _DailyDrugSchOrders = new DailyDrugSchOrder.ChildDailyDrugSchOrderCollection(this, new Guid("2ee79f2a-9009-4045-b51f-006847992092"));
            ((ITTChildObjectCollection)_DailyDrugSchOrders).GetChildren();
        }

        protected DailyDrugSchOrder.ChildDailyDrugSchOrderCollection _DailyDrugSchOrders = null;
        public DailyDrugSchOrder.ChildDailyDrugSchOrderCollection DailyDrugSchOrders
        {
            get
            {
                if (_DailyDrugSchOrders == null)
                    CreateDailyDrugSchOrdersCollection();
                return _DailyDrugSchOrders;
            }
        }

        virtual protected void CreateDailyDrugUnDrugsCollection()
        {
            _DailyDrugUnDrugs = new DailyDrugUnDrug.ChildDailyDrugUnDrugCollection(this, new Guid("5fd39143-b45d-4cdf-abdd-c5ee17ac4eb0"));
            ((ITTChildObjectCollection)_DailyDrugUnDrugs).GetChildren();
        }

        protected DailyDrugUnDrug.ChildDailyDrugUnDrugCollection _DailyDrugUnDrugs = null;
        public DailyDrugUnDrug.ChildDailyDrugUnDrugCollection DailyDrugUnDrugs
        {
            get
            {
                if (_DailyDrugUnDrugs == null)
                    CreateDailyDrugUnDrugsCollection();
                return _DailyDrugUnDrugs;
            }
        }

        virtual protected void CreateDailyDrugPatientsCollection()
        {
            _DailyDrugPatients = new DailyDrugPatient.ChildDailyDrugPatientCollection(this, new Guid("a1405d88-a483-4e23-9d22-2ffce81dda4c"));
            ((ITTChildObjectCollection)_DailyDrugPatients).GetChildren();
        }

        protected DailyDrugPatient.ChildDailyDrugPatientCollection _DailyDrugPatients = null;
        public DailyDrugPatient.ChildDailyDrugPatientCollection DailyDrugPatients
        {
            get
            {
                if (_DailyDrugPatients == null)
                    CreateDailyDrugPatientsCollection();
                return _DailyDrugPatients;
            }
        }

        protected DailyDrugSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugSchedule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGSCHEDULE", dataRow) { }
        protected DailyDrugSchedule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGSCHEDULE", dataRow, isImported) { }
        public DailyDrugSchedule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugSchedule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugSchedule() : base() { }

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