
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCSummaryDiagnosis")] 

    public  partial class HCSummaryDiagnosis : TTObject
    {
        public class HCSummaryDiagnosisList : TTObjectCollection<HCSummaryDiagnosis> { }
                    
        public class ChildHCSummaryDiagnosisCollection : TTObject.TTChildObjectCollection<HCSummaryDiagnosis>
        {
            public ChildHCSummaryDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCSummaryDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Giriş Tarihi  
    /// </summary>
        public DateTime? DiagnosisDate
        {
            get { return (DateTime?)this["DIAGNOSISDATE"]; }
            set { this["DIAGNOSISDATE"] = value; }
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
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Ana Tanı
    /// </summary>
        public bool? IsMainDiagnosis
        {
            get { return (bool?)this["ISMAINDIAGNOSIS"]; }
            set { this["ISMAINDIAGNOSIS"] = value; }
        }

        public HCSummary HCSummary
        {
            get { return (HCSummary)((ITTObject)this).GetParent("HCSUMMARY"); }
            set { this["HCSUMMARY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCSummaryDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCSummaryDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCSummaryDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCSummaryDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCSummaryDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCSUMMARYDIAGNOSIS", dataRow) { }
        protected HCSummaryDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCSUMMARYDIAGNOSIS", dataRow, isImported) { }
        public HCSummaryDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCSummaryDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCSummaryDiagnosis() : base() { }

    }
}