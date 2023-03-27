
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_RedecisionDiagnosisGrid")] 

    /// <summary>
    /// Tanı
    /// </summary>
    public  partial class HealthCommittee_RedecisionDiagnosisGrid : TTObject
    {
        public class HealthCommittee_RedecisionDiagnosisGridList : TTObjectCollection<HealthCommittee_RedecisionDiagnosisGrid> { }
                    
        public class ChildHealthCommittee_RedecisionDiagnosisGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_RedecisionDiagnosisGrid>
        {
            public ChildHealthCommittee_RedecisionDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_RedecisionDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSISTYPE"]; }
            set { this["DIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Birincil Tanı
    /// </summary>
        public bool? IsMainDiagnose
        {
            get { return (bool?)this["ISMAINDIAGNOSE"]; }
            set { this["ISMAINDIAGNOSE"] = value; }
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
    /// Özgeçmişe Ekle
    /// </summary>
        public bool? AddToHistory
        {
            get { return (bool?)this["ADDTOHISTORY"]; }
            set { this["ADDTOHISTORY"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommittee EpisodeAction
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanıyı Koyan
    /// </summary>
        public ResUser ResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEUSER"); }
            set { this["RESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_REDECISIONDIAGNOSISGRID", dataRow) { }
        protected HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_REDECISIONDIAGNOSISGRID", dataRow, isImported) { }
        public HealthCommittee_RedecisionDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_RedecisionDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_RedecisionDiagnosisGrid() : base() { }

    }
}