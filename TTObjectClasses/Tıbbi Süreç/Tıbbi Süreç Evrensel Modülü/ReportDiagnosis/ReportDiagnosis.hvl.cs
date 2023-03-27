
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReportDiagnosis")] 

    /// <summary>
    /// Rapor Tanıları 
    /// </summary>
    public  partial class ReportDiagnosis : TTObject
    {
        public class ReportDiagnosisList : TTObjectCollection<ReportDiagnosis> { }
                    
        public class ChildReportDiagnosisCollection : TTObject.TTChildObjectCollection<ReportDiagnosis>
        {
            public ChildReportDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReportDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Giriş Tarihi  
    /// </summary>
        public DateTime? DiagnoseDate
        {
            get { return (DateTime?)this["DIAGNOSEDATE"]; }
            set { this["DIAGNOSEDATE"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisGrid DiagnosisGrid
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("DIAGNOSISGRID"); }
            set { this["DIAGNOSISGRID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTaniTeshisİliskisiCollection()
        {
            _TaniTeshisİliskisi = new TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection(this, new Guid("01bd0936-14f6-4563-a345-98d398741269"));
            ((ITTChildObjectCollection)_TaniTeshisİliskisi).GetChildren();
        }

        protected TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection _TaniTeshisİliskisi = null;
        public TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection TaniTeshisİliskisi
        {
            get
            {
                if (_TaniTeshisİliskisi == null)
                    CreateTaniTeshisİliskisiCollection();
                return _TaniTeshisİliskisi;
            }
        }

        protected ReportDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReportDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReportDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReportDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReportDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPORTDIAGNOSIS", dataRow) { }
        protected ReportDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPORTDIAGNOSIS", dataRow, isImported) { }
        public ReportDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReportDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReportDiagnosis() : base() { }

    }
}