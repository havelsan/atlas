
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VaccineSmsInfo")] 

    public  partial class VaccineSmsInfo : TTObject
    {
        public class VaccineSmsInfoList : TTObjectCollection<VaccineSmsInfo> { }
                    
        public class ChildVaccineSmsInfoCollection : TTObject.TTChildObjectCollection<VaccineSmsInfo>
        {
            public ChildVaccineSmsInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccineSmsInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<VaccineSmsInfo> GetSendToBeSmsInfo(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINESMSINFO"].QueryDefs["GetSendToBeSmsInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<VaccineSmsInfo>(queryDef, paramList);
        }

    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

        public bool? CompletedFlag
        {
            get { return (bool?)this["COMPLETEDFLAG"]; }
            set { this["COMPLETEDFLAG"] = value; }
        }

        public VaccineDetails VaccineDetail
        {
            get { return (VaccineDetails)((ITTObject)this).GetParent("VACCINEDETAIL"); }
            set { this["VACCINEDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VaccineSmsInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VaccineSmsInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VaccineSmsInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VaccineSmsInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VaccineSmsInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINESMSINFO", dataRow) { }
        protected VaccineSmsInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINESMSINFO", dataRow, isImported) { }
        public VaccineSmsInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VaccineSmsInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VaccineSmsInfo() : base() { }

    }
}