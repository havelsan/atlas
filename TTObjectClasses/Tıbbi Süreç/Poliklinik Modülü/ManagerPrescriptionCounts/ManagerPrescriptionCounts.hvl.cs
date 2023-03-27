
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManagerPrescriptionCounts")] 

    public  partial class ManagerPrescriptionCounts : TTObject
    {
        public class ManagerPrescriptionCountsList : TTObjectCollection<ManagerPrescriptionCounts> { }
                    
        public class ChildManagerPrescriptionCountsCollection : TTObject.TTChildObjectCollection<ManagerPrescriptionCounts>
        {
            public ChildManagerPrescriptionCountsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManagerPrescriptionCountsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ManagerPrescriptionCounts> GetManagerPrescriptions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANAGERPRESCRIPTIONCOUNTS"].QueryDefs["GetManagerPrescriptions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ManagerPrescriptionCounts>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// e-Reçete Sayısı
    /// </summary>
        public int? ePrescriptionCount
        {
            get { return (int?)this["EPRESCRIPTIONCOUNT"]; }
            set { this["EPRESCRIPTIONCOUNT"] = value; }
        }

    /// <summary>
    /// Kağıt Reçete Sayısı
    /// </summary>
        public int? PaperPrescriptionCount
        {
            get { return (int?)this["PAPERPRESCRIPTIONCOUNT"]; }
            set { this["PAPERPRESCRIPTIONCOUNT"] = value; }
        }

        public string TotalPrescriptionCounts
        {
            get { return (string)this["TOTALPRESCRIPTIONCOUNTS"]; }
            set { this["TOTALPRESCRIPTIONCOUNTS"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Toplam Oran
    /// </summary>
        public string PrescriptionCountRate
        {
            get { return (string)this["PRESCRIPTIONCOUNTRATE"]; }
            set { this["PRESCRIPTIONCOUNTRATE"] = value; }
        }

        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Acil Branş Reçetesi
    /// </summary>
        public int? EmergencyPrescriptionCount
        {
            get { return (int?)this["EMERGENCYPRESCRIPTIONCOUNT"]; }
            set { this["EMERGENCYPRESCRIPTIONCOUNT"] = value; }
        }

    /// <summary>
    /// Poliklinik Reçete Sayısı
    /// </summary>
        public int? PoliclinicPrescriptionCount
        {
            get { return (int?)this["POLICLINICPRESCRIPTIONCOUNT"]; }
            set { this["POLICLINICPRESCRIPTIONCOUNT"] = value; }
        }

        public ResUser AddedUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ADDEDUSER"); }
            set { this["ADDEDUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManagerPrescriptionCounts(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManagerPrescriptionCounts(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManagerPrescriptionCounts(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManagerPrescriptionCounts(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManagerPrescriptionCounts(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANAGERPRESCRIPTIONCOUNTS", dataRow) { }
        protected ManagerPrescriptionCounts(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANAGERPRESCRIPTIONCOUNTS", dataRow, isImported) { }
        public ManagerPrescriptionCounts(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManagerPrescriptionCounts(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManagerPrescriptionCounts() : base() { }

    }
}