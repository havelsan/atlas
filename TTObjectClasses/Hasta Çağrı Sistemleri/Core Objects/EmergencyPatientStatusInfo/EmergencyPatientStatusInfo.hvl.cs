
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyPatientStatusInfo")] 

    public  partial class EmergencyPatientStatusInfo : TTObject
    {
        public class EmergencyPatientStatusInfoList : TTObjectCollection<EmergencyPatientStatusInfo> { }
                    
        public class ChildEmergencyPatientStatusInfoCollection : TTObject.TTChildObjectCollection<EmergencyPatientStatusInfo>
        {
            public ChildEmergencyPatientStatusInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyPatientStatusInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<EmergencyPatientStatusInfo> GetActiveItems(TTObjectContext objectContext, DateTime STARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYPATIENTSTATUSINFO"].QueryDefs["GetActiveItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<EmergencyPatientStatusInfo>(queryDef, paramList);
        }

        public EmergencyPatientStatusInfoEnum? PatientStatus
        {
            get { return (EmergencyPatientStatusInfoEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Son Güncelleme
    /// </summary>
        public DateTime? LastUpdateTime
        {
            get { return (DateTime?)this["LASTUPDATETIME"]; }
            set { this["LASTUPDATETIME"] = value; }
        }

        virtual protected void CreateEpisodeCollection()
        {
            _Episode = new Episode.ChildEpisodeCollection(this, new Guid("f48c8609-4543-4a8d-9759-8d6d6e651398"));
            ((ITTChildObjectCollection)_Episode).GetChildren();
        }

        protected Episode.ChildEpisodeCollection _Episode = null;
    /// <summary>
    /// Child collection for EmergencyPatientStatusInfo
    /// </summary>
        public Episode.ChildEpisodeCollection Episode
        {
            get
            {
                if (_Episode == null)
                    CreateEpisodeCollection();
                return _Episode;
            }
        }

        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYPATIENTSTATUSINFO", dataRow) { }
        protected EmergencyPatientStatusInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYPATIENTSTATUSINFO", dataRow, isImported) { }
        public EmergencyPatientStatusInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyPatientStatusInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyPatientStatusInfo() : base() { }

    }
}