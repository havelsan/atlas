
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntendedUseOfDisabledReport")] 

    /// <summary>
    /// Engelli Raporu Kullanım Amacı
    /// </summary>
    public  partial class IntendedUseOfDisabledReport : TTObject
    {
        public class IntendedUseOfDisabledReportList : TTObjectCollection<IntendedUseOfDisabledReport> { }
                    
        public class ChildIntendedUseOfDisabledReportCollection : TTObject.TTChildObjectCollection<IntendedUseOfDisabledReport>
        {
            public ChildIntendedUseOfDisabledReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntendedUseOfDisabledReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Engelli Kimlik Kartı Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? DisabledIdentityCardEvalution
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["DISABLEDIDENTITYCARDEVALUTION"]; }
            set { this["DISABLEDIDENTITYCARDEVALUTION"] = value; }
        }

    /// <summary>
    /// Diğer Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? OtherEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["OTHEREVALUATION"]; }
            set { this["OTHEREVALUATION"] = value; }
        }

    /// <summary>
    /// Diğer(Açıklama)
    /// </summary>
        public string OtherExplanation
        {
            get { return (string)this["OTHEREXPLANATION"]; }
            set { this["OTHEREXPLANATION"] = value; }
        }

    /// <summary>
    /// 2022 Sayılı Kanun Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? LawNo2022Evaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["LAWNO2022EVALUATION"]; }
            set { this["LAWNO2022EVALUATION"] = value; }
        }

    /// <summary>
    /// Eğitim Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? EducationEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["EDUCATIONEVALUATION"]; }
            set { this["EDUCATIONEVALUATION"] = value; }
        }

    /// <summary>
    /// İstihdam Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? EmploymentEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["EMPLOYMENTEVALUATION"]; }
            set { this["EMPLOYMENTEVALUATION"] = value; }
        }

    /// <summary>
    /// Sosyal Yardım Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? SocialAidEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["SOCIALAIDEVALUATION"]; }
            set { this["SOCIALAIDEVALUATION"] = value; }
        }

    /// <summary>
    /// Ortez/Protez/İşitme Cihazı Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? OrtesisProsthesEquEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["ORTESISPROSTHESEQUEVALUATION"]; }
            set { this["ORTESISPROSTHESEQUEVALUATION"] = value; }
        }

    /// <summary>
    /// Tekerlekli Sandalye Değerlendirme
    /// </summary>
        public EvetHayirDegerlendirilmediEnum? DisabledChaiEvaluation
        {
            get { return (EvetHayirDegerlendirilmediEnum?)(int?)this["DISABLEDCHAIEVALUATION"]; }
            set { this["DISABLEDCHAIEVALUATION"] = value; }
        }

        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENDEDUSEOFDISABLEDREPORT", dataRow) { }
        protected IntendedUseOfDisabledReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENDEDUSEOFDISABLEDREPORT", dataRow, isImported) { }
        public IntendedUseOfDisabledReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntendedUseOfDisabledReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntendedUseOfDisabledReport() : base() { }

    }
}