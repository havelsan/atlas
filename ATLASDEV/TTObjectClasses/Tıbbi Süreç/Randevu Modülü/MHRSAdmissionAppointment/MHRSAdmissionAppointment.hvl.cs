
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSAdmissionAppointment")] 

    public  partial class MHRSAdmissionAppointment : AdmissionAppointment
    {
        public class MHRSAdmissionAppointmentList : TTObjectCollection<MHRSAdmissionAppointment> { }
                    
        public class ChildMHRSAdmissionAppointmentCollection : TTObject.TTChildObjectCollection<MHRSAdmissionAppointment>
        {
            public ChildMHRSAdmissionAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSAdmissionAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni Randevu
    /// </summary>
            public static Guid New { get { return new Guid("c50af8e0-7efa-47c7-9644-9dcfdd280abe"); } }
    /// <summary>
    /// Randevu İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7b0b1c45-e784-4ab4-afd7-2579a5368a70"); } }
    /// <summary>
    /// Randevu Verildi
    /// </summary>
            public static Guid Appointment { get { return new Guid("e767ffcc-d13f-4bd0-a039-7a510f1f8be4"); } }
    /// <summary>
    /// Randevu Onaylandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d895c293-abce-49d8-90cb-ddeb0e4afe7a"); } }
        }

        public static BindingList<MHRSAdmissionAppointment> GetMHRSAdmissionAppByRandevuHrm(TTObjectContext objectContext, string RANDEVUHRN)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MHRSADMISSIONAPPOINTMENT"].QueryDefs["GetMHRSAdmissionAppByRandevuHrm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RANDEVUHRN", RANDEVUHRN);

            return ((ITTQuery)objectContext).QueryObjects<MHRSAdmissionAppointment>(queryDef, paramList);
        }

    /// <summary>
    /// MHRS Randevu No
    /// </summary>
        public string RandevuHrn
        {
            get { return (string)this["RANDEVUHRN"]; }
            set { this["RANDEVUHRN"] = value; }
        }

    /// <summary>
    /// Engelli
    /// </summary>
        public bool? IsDisabled
        {
            get { return (bool?)this["ISDISABLED"]; }
            set { this["ISDISABLED"] = value; }
        }

    /// <summary>
    /// Kimsesiz
    /// </summary>
        public bool? IsForlorn
        {
            get { return (bool?)this["ISFORLORN"]; }
            set { this["ISFORLORN"] = value; }
        }

    /// <summary>
    /// Yüksek Riskli Gebe
    /// </summary>
        public bool? IsHighRiskPregnancy
        {
            get { return (bool?)this["ISHIGHRISKPREGNANCY"]; }
            set { this["ISHIGHRISKPREGNANCY"] = value; }
        }

    /// <summary>
    /// Sanal T.C.
    /// </summary>
        public bool? IsVirtuleUniqueRefNo
        {
            get { return (bool?)this["ISVIRTULEUNIQUEREFNO"]; }
            set { this["ISVIRTULEUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Refakatçi İstiyor
    /// </summary>
        public bool? IsWantedCompanion
        {
            get { return (bool?)this["ISWANTEDCOMPANION"]; }
            set { this["ISWANTEDCOMPANION"] = value; }
        }

        protected MHRSAdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSAdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSAdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSAdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSAdmissionAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSADMISSIONAPPOINTMENT", dataRow) { }
        protected MHRSAdmissionAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSADMISSIONAPPOINTMENT", dataRow, isImported) { }
        public MHRSAdmissionAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSAdmissionAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSAdmissionAppointment() : base() { }

    }
}