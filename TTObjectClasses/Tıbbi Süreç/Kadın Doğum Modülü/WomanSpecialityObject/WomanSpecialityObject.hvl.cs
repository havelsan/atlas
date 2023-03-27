
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WomanSpecialityObject")] 

    public  partial class WomanSpecialityObject : SpecialityBasedObject
    {
        public class WomanSpecialityObjectList : TTObjectCollection<WomanSpecialityObject> { }
                    
        public class ChildWomanSpecialityObjectCollection : TTObject.TTChildObjectCollection<WomanSpecialityObject>
        {
            public ChildWomanSpecialityObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWomanSpecialityObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Son Kadın Doğum Objesi
    /// </summary>
        public static BindingList<WomanSpecialityObject> GetWomanSpecialityObjectByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOMANSPECIALITYOBJECT"].QueryDefs["GetWomanSpecialityObjectByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<WomanSpecialityObject>(queryDef, paramList);
        }

        public static BindingList<WomanSpecialityObject> GetWomanSpecialityByPatientAndAction(TTObjectContext objectContext, Guid PATIENT, Guid PHYAPP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOMANSPECIALITYOBJECT"].QueryDefs["GetWomanSpecialityByPatientAndAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("PHYAPP", PHYAPP);

            return ((ITTQuery)objectContext).QueryObjects<WomanSpecialityObject>(queryDef, paramList);
        }

    /// <summary>
    /// Rh Kan Uyuşmazlığı
    /// </summary>
        public VarYokGarantiEnum? RhIncompatibility
        {
            get { return (VarYokGarantiEnum?)(int?)this["RHINCOMPATIBILITY"]; }
            set { this["RHINCOMPATIBILITY"] = value; }
        }

    /// <summary>
    /// Akrabalık Durumu
    /// </summary>
        public DegreeOfBloodRelativesEnum? DegreeOfRelationship
        {
            get { return (DegreeOfBloodRelativesEnum?)(int?)this["DEGREEOFRELATIONSHIP"]; }
            set { this["DEGREEOFRELATIONSHIP"] = value; }
        }

    /// <summary>
    /// Eşinin Kan Grubu
    /// </summary>
        public BloodGroupEnum? HusbandBloodGroup
        {
            get { return (BloodGroupEnum?)(int?)this["HUSBANDBLOODGROUP"]; }
            set { this["HUSBANDBLOODGROUP"] = value; }
        }

    /// <summary>
    /// Hastanın geçirdiği gebelik sayısı
    /// </summary>
        public int? NumberOfPregnancy
        {
            get { return (int?)this["NUMBEROFPREGNANCY"]; }
            set { this["NUMBEROFPREGNANCY"] = value; }
        }

    /// <summary>
    /// Hastanın doğum sayısı
    /// </summary>
        public int? Parity
        {
            get { return (int?)this["PARITY"]; }
            set { this["PARITY"] = value; }
        }

    /// <summary>
    /// Hastanın geçirdiği düşük sayısı
    /// </summary>
        public int? Abortion
        {
            get { return (int?)this["ABORTION"]; }
            set { this["ABORTION"] = value; }
        }

    /// <summary>
    /// Hastanın yaşayan bebek sayısı
    /// </summary>
        public int? LivingBabies
        {
            get { return (int?)this["LIVINGBABIES"]; }
            set { this["LIVINGBABIES"] = value; }
        }

    /// <summary>
    /// Hastanın ölü doğum ve sonradan ölan bebek sayısı
    /// </summary>
        public int? DC
        {
            get { return (int?)this["DC"]; }
            set { this["DC"] = value; }
        }

    /// <summary>
    /// Eşinin Adı Soyadı
    /// </summary>
        public string HusbandFullName
        {
            get { return (string)this["HUSBANDFULLNAME"]; }
            set { this["HUSBANDFULLNAME"] = value; }
        }

    /// <summary>
    /// Evlilik Senesi
    /// </summary>
        public int? MarriageDate
        {
            get { return (int?)this["MARRIAGEDATE"]; }
            set { this["MARRIAGEDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Kan Grubu
    /// </summary>
        public BloodGroupEnum? WomanBloodGroup
        {
            get { return (BloodGroupEnum?)(int?)this["WOMANBLOODGROUP"]; }
            set { this["WOMANBLOODGROUP"] = value; }
        }

        public Infertility Infertility
        {
            get { return (Infertility)((ITTObject)this).GetParent("INFERTILITY"); }
            set { this["INFERTILITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PregnancyFollow PregnancyFollow
        {
            get { return (PregnancyFollow)((ITTObject)this).GetParent("PREGNANCYFOLLOW"); }
            set { this["PREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Gynecology Gynecology
        {
            get { return (Gynecology)((ITTObject)this).GetParent("GYNECOLOGY"); }
            set { this["GYNECOLOGY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Husband
        {
            get { return (Patient)((ITTObject)this).GetParent("HUSBAND"); }
            set { this["HUSBAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sayısal verileri tutar
    /// </summary>
        public PregnantInformation PregnantInformation
        {
            get { return (PregnantInformation)((ITTObject)this).GetParent("PREGNANTINFORMATION"); }
            set { this["PREGNANTINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PostpartumFollowUp PostpartumFollowUp
        {
            get { return (PostpartumFollowUp)((ITTObject)this).GetParent("POSTPARTUMFOLLOWUP"); }
            set { this["POSTPARTUMFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WomanSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WomanSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WomanSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WomanSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WomanSpecialityObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOMANSPECIALITYOBJECT", dataRow) { }
        protected WomanSpecialityObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOMANSPECIALITYOBJECT", dataRow, isImported) { }
        public WomanSpecialityObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WomanSpecialityObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WomanSpecialityObject() : base() { }

    }
}