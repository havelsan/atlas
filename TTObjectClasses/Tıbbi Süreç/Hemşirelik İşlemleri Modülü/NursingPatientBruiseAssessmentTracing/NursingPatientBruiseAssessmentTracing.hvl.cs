
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPatientBruiseAssessmentTracing")] 

    public  partial class NursingPatientBruiseAssessmentTracing : TTObject
    {
        public class NursingPatientBruiseAssessmentTracingList : TTObjectCollection<NursingPatientBruiseAssessmentTracing> { }
                    
        public class ChildNursingPatientBruiseAssessmentTracingCollection : TTObject.TTChildObjectCollection<NursingPatientBruiseAssessmentTracing>
        {
            public ChildNursingPatientBruiseAssessmentTracingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPatientBruiseAssessmentTracingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Evre
    /// </summary>
        public int? Degree
        {
            get { return (int?)this["DEGREE"]; }
            set { this["DEGREE"] = value; }
        }

    /// <summary>
    /// Değerlendirme
    /// </summary>
        public object Assessment
        {
            get { return (object)this["ASSESSMENT"]; }
            set { this["ASSESSMENT"] = value; }
        }

    /// <summary>
    /// D
    /// </summary>
        public int? Other
        {
            get { return (int?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

    /// <summary>
    /// K
    /// </summary>
        public int? Red
        {
            get { return (int?)this["RED"]; }
            set { this["RED"] = value; }
        }

    /// <summary>
    /// Koku
    /// </summary>
        public YesNoEnum? Smell
        {
            get { return (YesNoEnum?)(int?)this["SMELL"]; }
            set { this["SMELL"] = value; }
        }

    /// <summary>
    /// U
    /// </summary>
        public int? Lengthiness
        {
            get { return (int?)this["LENGTHINESS"]; }
            set { this["LENGTHINESS"] = value; }
        }

    /// <summary>
    /// S
    /// </summary>
        public int? Black
        {
            get { return (int?)this["BLACK"]; }
            set { this["BLACK"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Actiondate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// D
    /// </summary>
        public int? Deepness
        {
            get { return (int?)this["DEEPNESS"]; }
            set { this["DEEPNESS"] = value; }
        }

    /// <summary>
    /// G
    /// </summary>
        public int? Wideness
        {
            get { return (int?)this["WIDENESS"]; }
            set { this["WIDENESS"] = value; }
        }

    /// <summary>
    /// Yara Kenarları
    /// </summary>
        public BruiseBorders? BruiseBorders
        {
            get { return (BruiseBorders?)(int?)this["BRUISEBORDERS"]; }
            set { this["BRUISEBORDERS"] = value; }
        }

    /// <summary>
    /// S
    /// </summary>
        public int? Yellow
        {
            get { return (int?)this["YELLOW"]; }
            set { this["YELLOW"] = value; }
        }

    /// <summary>
    /// Akıntı Miktarı
    /// </summary>
        public StreamQuantitative? StreamQuantitative
        {
            get { return (StreamQuantitative?)(int?)this["STREAMQUANTITATIVE"]; }
            set { this["STREAMQUANTITATIVE"] = value; }
        }

    /// <summary>
    /// K
    /// </summary>
        public int? Cavity
        {
            get { return (int?)this["CAVITY"]; }
            set { this["CAVITY"] = value; }
        }

    /// <summary>
    /// Akıntı Rengi
    /// </summary>
        public object StreamColour
        {
            get { return (object)this["STREAMCOLOUR"]; }
            set { this["STREAMCOLOUR"] = value; }
        }

    /// <summary>
    /// Hasta Yara Değerlendirme Takipi
    /// </summary>
        public PatientBruiseAssessmentTracing PatientBruiseAssessTracing
        {
            get { return (PatientBruiseAssessmentTracing)((ITTObject)this).GetParent("PATIENTBRUISEASSESSTRACING"); }
            set { this["PATIENTBRUISEASSESSTRACING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Yara Değerlendirme Takipi
    /// </summary>
        public NursingApplication Nursingapplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPATIENTBRUISEASSESSMENTTRACING", dataRow) { }
        protected NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPATIENTBRUISEASSESSMENTTRACING", dataRow, isImported) { }
        public NursingPatientBruiseAssessmentTracing(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPatientBruiseAssessmentTracing(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPatientBruiseAssessmentTracing() : base() { }

    }
}