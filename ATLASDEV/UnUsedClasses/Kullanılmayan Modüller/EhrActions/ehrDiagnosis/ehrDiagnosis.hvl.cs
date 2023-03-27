
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrDiagnosis")] 

    /// <summary>
    /// Tanı
    /// </summary>
    public  partial class ehrDiagnosis : BaseEhr
    {
        public class ehrDiagnosisList : TTObjectCollection<ehrDiagnosis> { }
                    
        public class ChildehrDiagnosisCollection : TTObject.TTChildObjectCollection<ehrDiagnosis>
        {
            public ChildehrDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
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
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnoseType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSETYPE"]; }
            set { this["DIAGNOSETYPE"] = value; }
        }

    /// <summary>
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
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
    /// Vaka Tanıları
    /// </summary>
        public ehrEpisode ehrEpisode
        {
            get { return (ehrEpisode)((ITTObject)this).GetParent("EHREPISODE"); }
            set { this["EHREPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public ehrEpisodeAction ehrEpisodeAction
        {
            get { return (ehrEpisodeAction)((ITTObject)this).GetParent("EHREPISODEACTION"); }
            set { this["EHREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Önemli Tıbbi Bilgiler-Tanı Özgeçmişi
    /// </summary>
        public ehrImportantMedicalInformation ehrImportantMedicalInfo
        {
            get { return (ehrImportantMedicalInformation)((ITTObject)this).GetParent("EHRIMPORTANTMEDICALINFO"); }
            set { this["EHRIMPORTANTMEDICALINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRDIAGNOSIS", dataRow) { }
        protected ehrDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRDIAGNOSIS", dataRow, isImported) { }
        public ehrDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrDiagnosis() : base() { }

    }
}