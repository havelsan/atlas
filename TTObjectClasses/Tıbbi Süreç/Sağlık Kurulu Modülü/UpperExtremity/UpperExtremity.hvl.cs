
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpperExtremity")] 

    /// <summary>
    /// Üst Ekstremite Protez
    /// </summary>
    public  partial class UpperExtremity : BaseHCExaminationDynamicObject
    {
        public class UpperExtremityList : TTObjectCollection<UpperExtremity> { }
                    
        public class ChildUpperExtremityCollection : TTObject.TTChildObjectCollection<UpperExtremity>
        {
            public ChildUpperExtremityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpperExtremityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tıbbi Gerekçe Yazılmış mı?
    /// </summary>
        public bool? MedicalReason
        {
            get { return (bool?)this["MEDICALREASON"]; }
            set { this["MEDICALREASON"] = value; }
        }

    /// <summary>
    /// sEMG Belgelendirilmiş mi?
    /// </summary>
        public bool? sEMG
        {
            get { return (bool?)this["SEMG"]; }
            set { this["SEMG"] = value; }
        }

    /// <summary>
    /// 3. basamak sağlık kurumu
    /// </summary>
        public bool? ThirdStepHealthInst
        {
            get { return (bool?)this["THIRDSTEPHEALTHINST"]; }
            set { this["THIRDSTEPHEALTHINST"] = value; }
        }

    /// <summary>
    /// FTR Uzman Onayı
    /// </summary>
        public bool? FTRExpertApprove
        {
            get { return (bool?)this["FTREXPERTAPPROVE"]; }
            set { this["FTREXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Ortopedi Uzman Onayı
    /// </summary>
        public bool? OrthopedicExpertApprove
        {
            get { return (bool?)this["ORTHOPEDICEXPERTAPPROVE"]; }
            set { this["ORTHOPEDICEXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Psikiyatri Uzman Onayı
    /// </summary>
        public bool? PsychiatricExpertApprove
        {
            get { return (bool?)this["PSYCHIATRICEXPERTAPPROVE"]; }
            set { this["PSYCHIATRICEXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Başhekim Onayı
    /// </summary>
        public bool? HeadDoctorApprove
        {
            get { return (bool?)this["HEADDOCTORAPPROVE"]; }
            set { this["HEADDOCTORAPPROVE"] = value; }
        }

        protected UpperExtremity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpperExtremity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpperExtremity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpperExtremity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpperExtremity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPPEREXTREMITY", dataRow) { }
        protected UpperExtremity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPPEREXTREMITY", dataRow, isImported) { }
        public UpperExtremity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpperExtremity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpperExtremity() : base() { }

    }
}