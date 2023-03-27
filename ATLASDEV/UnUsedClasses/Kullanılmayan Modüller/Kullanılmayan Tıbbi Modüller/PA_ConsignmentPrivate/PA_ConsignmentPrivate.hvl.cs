
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_ConsignmentPrivate")] 

    /// <summary>
    /// Sevk Eri Kabul 
    /// </summary>
    public  partial class PA_ConsignmentPrivate : PatientAdmission
    {
        public class PA_ConsignmentPrivateList : TTObjectCollection<PA_ConsignmentPrivate> { }
                    
        public class ChildPA_ConsignmentPrivateCollection : TTObject.TTChildObjectCollection<PA_ConsignmentPrivate>
        {
            public ChildPA_ConsignmentPrivateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_ConsignmentPrivateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// XXXXXXe Giriş Tarihi
    /// </summary>
        public DateTime? MilitaryAcceptanceTime
        {
            get { return (DateTime?)this["MILITARYACCEPTANCETIME"]; }
            set { this["MILITARYACCEPTANCETIME"] = value; }
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
    /// Sağlık Fişi No
    /// </summary>
        public string HealtSlipNumber
        {
            get { return (string)this["HEALTSLIPNUMBER"]; }
            set { this["HEALTSLIPNUMBER"] = value; }
        }

    /// <summary>
    /// XXXXXXlik No
    /// </summary>
        public string MilitaryNo
        {
            get { return (string)this["MILITARYNO"]; }
            set { this["MILITARYNO"] = value; }
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

        protected PA_ConsignmentPrivate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_ConsignmentPrivate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_ConsignmentPrivate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_ConsignmentPrivate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_ConsignmentPrivate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_CONSIGNMENTPRIVATE", dataRow) { }
        protected PA_ConsignmentPrivate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_CONSIGNMENTPRIVATE", dataRow, isImported) { }
        public PA_ConsignmentPrivate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_ConsignmentPrivate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_ConsignmentPrivate() : base() { }

    }
}