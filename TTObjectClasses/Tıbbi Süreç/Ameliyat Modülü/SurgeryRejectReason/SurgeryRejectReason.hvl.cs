
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryRejectReason")] 

    public  partial class SurgeryRejectReason : TTObject
    {
        public class SurgeryRejectReasonList : TTObjectCollection<SurgeryRejectReason> { }
                    
        public class ChildSurgeryRejectReasonCollection : TTObject.TTChildObjectCollection<SurgeryRejectReason>
        {
            public ChildSurgeryRejectReasonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryRejectReasonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Malzeme Yokluğu
    /// </summary>
        public bool? LackOfMaterial
        {
            get { return (bool?)this["LACKOFMATERIAL"]; }
            set { this["LACKOFMATERIAL"] = value; }
        }

    /// <summary>
    /// Preop Hazırlığının Tamamlanamaması
    /// </summary>
        public bool? PreopPreparation
        {
            get { return (bool?)this["PREOPPREPARATION"]; }
            set { this["PREOPPREPARATION"] = value; }
        }

    /// <summary>
    /// Hasta Ameliyata gelmedi
    /// </summary>
        public bool? PatientNotCome
        {
            get { return (bool?)this["PATIENTNOTCOME"]; }
            set { this["PATIENTNOTCOME"] = value; }
        }

    /// <summary>
    /// Listede Bulunan Ameliyatların Süresinin Uzaması
    /// </summary>
        public bool? ProlongSurgery
        {
            get { return (bool?)this["PROLONGSURGERY"]; }
            set { this["PROLONGSURGERY"] = value; }
        }

    /// <summary>
    /// Diğer Nedenler
    /// </summary>
        public bool? OtherReason
        {
            get { return (bool?)this["OTHERREASON"]; }
            set { this["OTHERREASON"] = value; }
        }

    /// <summary>
    /// diğer Neden Açıklaması
    /// </summary>
        public string OtherReasonExplanation
        {
            get { return (string)this["OTHERREASONEXPLANATION"]; }
            set { this["OTHERREASONEXPLANATION"] = value; }
        }

        protected SurgeryRejectReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryRejectReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryRejectReason(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryRejectReason(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryRejectReason(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYREJECTREASON", dataRow) { }
        protected SurgeryRejectReason(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYREJECTREASON", dataRow, isImported) { }
        public SurgeryRejectReason(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryRejectReason(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryRejectReason() : base() { }

    }
}