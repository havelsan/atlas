
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResEquipmentAppointment")] 

    /// <summary>
    /// Cihaz Onarım Randevuları
    /// </summary>
    public  partial class ResEquipmentAppointment : TTObject
    {
        public class ResEquipmentAppointmentList : TTObjectCollection<ResEquipmentAppointment> { }
                    
        public class ChildResEquipmentAppointmentCollection : TTObject.TTChildObjectCollection<ResEquipmentAppointment>
        {
            public ChildResEquipmentAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResEquipmentAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ResEquipmentAppointment> GetResEquipmentAppByObjectID(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENTAPPOINTMENT"].QueryDefs["GetResEquipmentAppByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResEquipmentAppointment>(queryDef, paramList);
        }

        public static BindingList<ResEquipmentAppointment> GETBYAPPOINTMENTID(TTObjectContext objectContext, string APPOINTMENTIDPARAM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENTAPPOINTMENT"].QueryDefs["GETBYAPPOINTMENTID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPOINTMENTIDPARAM", APPOINTMENTIDPARAM);

            return ((ITTQuery)objectContext).QueryObjects<ResEquipmentAppointment>(queryDef, paramList);
        }

        public static BindingList<ResEquipmentAppointment> GETBYMKYSNO(TTObjectContext objectContext, string MKYSNOPARAM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENTAPPOINTMENT"].QueryDefs["GETBYMKYSNO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MKYSNOPARAM", MKYSNOPARAM);

            return ((ITTQuery)objectContext).QueryObjects<ResEquipmentAppointment>(queryDef, paramList);
        }

        public string AppointmentID
        {
            get { return (string)this["APPOINTMENTID"]; }
            set { this["APPOINTMENTID"] = value; }
        }

        public string AppointmentDefinition
        {
            get { return (string)this["APPOINTMENTDEFINITION"]; }
            set { this["APPOINTMENTDEFINITION"] = value; }
        }

        public string MkysNo
        {
            get { return (string)this["MKYSNO"]; }
            set { this["MKYSNO"] = value; }
        }

        public long? StartDate
        {
            get { return (long?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public long? EndDate
        {
            get { return (long?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

        protected ResEquipmentAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResEquipmentAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResEquipmentAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResEquipmentAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResEquipmentAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESEQUIPMENTAPPOINTMENT", dataRow) { }
        protected ResEquipmentAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESEQUIPMENTAPPOINTMENT", dataRow, isImported) { }
        public ResEquipmentAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResEquipmentAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResEquipmentAppointment() : base() { }

    }
}