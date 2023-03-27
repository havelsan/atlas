
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyRequestTemplateDetail")] 

    public  partial class PhysiotherapyRequestTemplateDetail : ProcedureRequestTemplateDetail
    {
        public class PhysiotherapyRequestTemplateDetailList : TTObjectCollection<PhysiotherapyRequestTemplateDetail> { }
                    
        public class ChildPhysiotherapyRequestTemplateDetailCollection : TTObject.TTChildObjectCollection<PhysiotherapyRequestTemplateDetail>
        {
            public ChildPhysiotherapyRequestTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyRequestTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uygulama Alanı
    /// </summary>
        public string ApplicationArea
        {
            get { return (string)this["APPLICATIONAREA"]; }
            set { this["APPLICATIONAREA"] = value; }
        }

    /// <summary>
    /// Süre/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Tedavi Özellikleri
    /// </summary>
        public string TreatmentProperties
        {
            get { return (string)this["TREATMENTPROPERTIES"]; }
            set { this["TREATMENTPROPERTIES"] = value; }
        }

        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FTRVucutBolgesi FTRApplicationAreaDef
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("FTRAPPLICATIONAREADEF"); }
            set { this["FTRAPPLICATIONAREADEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysiotherapyRequestTemplateDefinition PhysiotherapyRequestTempateDefinition
        {
            get 
            {   
                if (TemplateDefinition is PhysiotherapyRequestTemplateDefinition)
                    return (PhysiotherapyRequestTemplateDefinition)TemplateDefinition; 
                return null;
            }            
            set { TemplateDefinition = value; }
        }

        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYREQUESTTEMPLATEDETAIL", dataRow) { }
        protected PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYREQUESTTEMPLATEDETAIL", dataRow, isImported) { }
        public PhysiotherapyRequestTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyRequestTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyRequestTemplateDetail() : base() { }

    }
}