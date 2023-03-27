
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_DischargedPrivate")] 

    /// <summary>
    /// Terhisli Erbaş/Er (Özel Statülü) Kabul 
    /// </summary>
    public  partial class PA_DischargedPrivate : PatientAdmission
    {
        public class PA_DischargedPrivateList : TTObjectCollection<PA_DischargedPrivate> { }
                    
        public class ChildPA_DischargedPrivateCollection : TTObject.TTChildObjectCollection<PA_DischargedPrivate>
        {
            public ChildPA_DischargedPrivateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_DischargedPrivateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hizmet Alım Süresi Bitiş Tarihi
    /// </summary>
        public DateTime? ServisEndTime
        {
            get { return (DateTime?)this["SERVISENDTIME"]; }
            set { this["SERVISENDTIME"] = value; }
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
    /// Kurum Sicil No
    /// </summary>
        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
        }

    /// <summary>
    /// Terhis Tarihi
    /// </summary>
        public DateTime? DemobilizationTime
        {
            get { return (DateTime?)this["DEMOBILIZATIONTIME"]; }
            set { this["DEMOBILIZATIONTIME"] = value; }
        }

    /// <summary>
    /// Tertip
    /// </summary>
        public string ConscriptionPeriod
        {
            get { return (string)this["CONSCRIPTIONPERIOD"]; }
            set { this["CONSCRIPTIONPERIOD"] = value; }
        }

    /// <summary>
    /// XXXXXXlik Şubesi
    /// </summary>
        public MilitaryOffice MilitaryOffice
        {
            get { return (MilitaryOffice)((ITTObject)this).GetParent("MILITARYOFFICE"); }
            set { this["MILITARYOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayeneye Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum İli
    /// </summary>
        public City PayerCity
        {
            get { return (City)((ITTObject)this).GetParent("PAYERCITY"); }
            set { this["PAYERCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_DischargedPrivate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_DischargedPrivate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_DischargedPrivate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_DischargedPrivate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_DischargedPrivate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_DISCHARGEDPRIVATE", dataRow) { }
        protected PA_DischargedPrivate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_DISCHARGEDPRIVATE", dataRow, isImported) { }
        public PA_DischargedPrivate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_DischargedPrivate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_DischargedPrivate() : base() { }

    }
}