
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoctorPerformanceTerm")] 

    public  partial class DoctorPerformanceTerm : TTDefinitionSet
    {
        public class DoctorPerformanceTermList : TTObjectCollection<DoctorPerformanceTerm> { }
                    
        public class ChildDoctorPerformanceTermCollection : TTObject.TTChildObjectCollection<DoctorPerformanceTerm>
        {
            public ChildDoctorPerformanceTermCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoctorPerformanceTermCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("841e0ecf-72b9-456f-92cd-517717af1758"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Close { get { return new Guid("838bd24f-5d66-4b48-bcc4-9b9aee5a0700"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c5ac9d41-7541-45f4-8130-f148a3babf17"); } }
    /// <summary>
    /// Onaylı
    /// </summary>
            public static Guid Approved { get { return new Guid("07ac060f-fa2d-44b4-9a3a-5bdba2178724"); } }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public int? TotalPoint
        {
            get { return (int?)this["TOTALPOINT"]; }
            set { this["TOTALPOINT"] = value; }
        }

        virtual protected void CreateDPDetailLogsCollection()
        {
            _DPDetailLogs = new DPDetailLog.ChildDPDetailLogCollection(this, new Guid("77dd3aa9-5878-4e38-b745-bc65aeae5a83"));
            ((ITTChildObjectCollection)_DPDetailLogs).GetChildren();
        }

        protected DPDetailLog.ChildDPDetailLogCollection _DPDetailLogs = null;
        public DPDetailLog.ChildDPDetailLogCollection DPDetailLogs
        {
            get
            {
                if (_DPDetailLogs == null)
                    CreateDPDetailLogsCollection();
                return _DPDetailLogs;
            }
        }

        virtual protected void CreateDPMastersCollection()
        {
            _DPMasters = new DPMaster.ChildDPMasterCollection(this, new Guid("bb7ea8ae-3126-43ee-8bf0-576801060219"));
            ((ITTChildObjectCollection)_DPMasters).GetChildren();
        }

        protected DPMaster.ChildDPMasterCollection _DPMasters = null;
        public DPMaster.ChildDPMasterCollection DPMasters
        {
            get
            {
                if (_DPMasters == null)
                    CreateDPMastersCollection();
                return _DPMasters;
            }
        }

        protected DoctorPerformanceTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoctorPerformanceTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoctorPerformanceTerm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoctorPerformanceTerm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoctorPerformanceTerm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCTORPERFORMANCETERM", dataRow) { }
        protected DoctorPerformanceTerm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCTORPERFORMANCETERM", dataRow, isImported) { }
        public DoctorPerformanceTerm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoctorPerformanceTerm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoctorPerformanceTerm() : base() { }

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