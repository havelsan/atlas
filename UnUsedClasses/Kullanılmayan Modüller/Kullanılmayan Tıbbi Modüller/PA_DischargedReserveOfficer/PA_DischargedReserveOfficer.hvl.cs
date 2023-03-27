
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_DischargedReserveOfficer")] 

    /// <summary>
    /// Terhisli Yedek Subay(Özel Statülü) Kabul 
    /// </summary>
    public  partial class PA_DischargedReserveOfficer : PatientAdmission
    {
        public class PA_DischargedReserveOfficerList : TTObjectCollection<PA_DischargedReserveOfficer> { }
                    
        public class ChildPA_DischargedReserveOfficerCollection : TTObject.TTChildObjectCollection<PA_DischargedReserveOfficer>
        {
            public ChildPA_DischargedReserveOfficerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_DischargedReserveOfficerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tertip
    /// </summary>
        public string ConscriptionPeriod
        {
            get { return (string)this["CONSCRIPTIONPERIOD"]; }
            set { this["CONSCRIPTIONPERIOD"] = value; }
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
    /// XXXXXXe Giriş Tarihi
    /// </summary>
        public DateTime? MilitaryAcceptanceTime
        {
            get { return (DateTime?)this["MILITARYACCEPTANCETIME"]; }
            set { this["MILITARYACCEPTANCETIME"] = value; }
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
    /// Sicil No
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
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
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions MilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("MILITARYCLASS"); }
            set { this["MILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// XXXXXXlik Şubesi
    /// </summary>
        public MilitaryOffice MilitaryOffice
        {
            get { return (MilitaryOffice)((ITTObject)this).GetParent("MILITARYOFFICE"); }
            set { this["MILITARYOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum İli
    /// </summary>
        public City PayerCity
        {
            get { return (City)((ITTObject)this).GetParent("PAYERCITY"); }
            set { this["PAYERCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_DISCHARGEDRESERVEOFFICER", dataRow) { }
        protected PA_DischargedReserveOfficer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_DISCHARGEDRESERVEOFFICER", dataRow, isImported) { }
        public PA_DischargedReserveOfficer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_DischargedReserveOfficer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_DischargedReserveOfficer() : base() { }

    }
}