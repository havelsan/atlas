
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_VisitorMilitary")] 

    /// <summary>
    /// Misafir XXXXXX Personel
    /// </summary>
    public  abstract  partial class PA_VisitorMilitary : PatientAdmission
    {
        public class PA_VisitorMilitaryList : TTObjectCollection<PA_VisitorMilitary> { }
                    
        public class ChildPA_VisitorMilitaryCollection : TTObject.TTChildObjectCollection<PA_VisitorMilitary>
        {
            public ChildPA_VisitorMilitaryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_VisitorMilitaryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// Geliş Amacı
    /// </summary>
        public VisitingReasonEnum? VisitingReason
        {
            get { return (VisitingReasonEnum?)(int?)this["VISITINGREASON"]; }
            set { this["VISITINGREASON"] = value; }
        }

    /// <summary>
    /// Geçici Sağlık Numarası
    /// </summary>
        public string TemporaryHealtNo
        {
            get { return (string)this["TEMPORARYHEALTNO"]; }
            set { this["TEMPORARYHEALTNO"] = value; }
        }

    /// <summary>
    /// Sağlık Fişi No
    /// </summary>
        public string HealtSlipNumber
        {
            get { return (string)this["HEALTSLIPNUMBER"]; }
            set { this["HEALTSLIPNUMBER"] = value; }
        }

    /// <summary>
    /// Ülke
    /// </summary>
        public Country Country
        {
            get { return (Country)((ITTObject)this).GetParent("COUNTRY"); }
            set { this["COUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mueyeneye Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_VisitorMilitary(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_VisitorMilitary(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_VisitorMilitary(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_VisitorMilitary(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_VisitorMilitary(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_VISITORMILITARY", dataRow) { }
        protected PA_VisitorMilitary(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_VISITORMILITARY", dataRow, isImported) { }
        public PA_VisitorMilitary(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_VisitorMilitary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_VisitorMilitary() : base() { }

    }
}