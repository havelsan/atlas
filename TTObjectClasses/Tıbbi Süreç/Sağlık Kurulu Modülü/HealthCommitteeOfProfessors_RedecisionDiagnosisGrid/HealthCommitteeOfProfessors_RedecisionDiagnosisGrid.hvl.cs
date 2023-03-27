
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessors_RedecisionDiagnosisGrid")] 

    public  partial class HealthCommitteeOfProfessors_RedecisionDiagnosisGrid : TTObject
    {
        public class HealthCommitteeOfProfessors_RedecisionDiagnosisGridList : TTObjectCollection<HealthCommitteeOfProfessors_RedecisionDiagnosisGrid> { }
                    
        public class ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessors_RedecisionDiagnosisGrid>
        {
            public ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tanı Giriş Tarihi
    /// </summary>
        public DateTime? DiagnoseDate
        {
            get { return (DateTime?)this["DIAGNOSEDATE"]; }
            set { this["DIAGNOSEDATE"] = value; }
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
    /// Özgeçmişe Ekle
    /// </summary>
        public bool? AddToHistory
        {
            get { return (bool?)this["ADDTOHISTORY"]; }
            set { this["ADDTOHISTORY"] = value; }
        }

        public HealthCommitteeOfProfessors EpisodeAction
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanıyı Koyan
    /// </summary>
        public ResUser ResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEUSER"); }
            set { this["RESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_REDECISIONDIAGNOSISGRID", dataRow) { }
        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_REDECISIONDIAGNOSISGRID", dataRow, isImported) { }
        public HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessors_RedecisionDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessors_RedecisionDiagnosisGrid() : base() { }

    }
}