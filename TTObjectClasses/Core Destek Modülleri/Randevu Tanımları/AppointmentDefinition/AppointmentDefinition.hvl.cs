
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentDefinition")] 

    public  partial class AppointmentDefinition : TTDefinitionSet
    {
        public class AppointmentDefinitionList : TTObjectCollection<AppointmentDefinition> { }
                    
        public class ChildAppointmentDefinitionCollection : TTObject.TTChildObjectCollection<AppointmentDefinition>
        {
            public ChildAppointmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAppointmentDefinition_Class : TTReportNqlObject 
        {
            public int? AppointmentDefinitionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTDEFINITIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].AllPropertyDefs["APPOINTMENTDEFINITIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public AppointmentDefinitionEnum? AppointmentDefinitionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTDEFINITIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].AllPropertyDefs["APPOINTMENTDEFINITIONNAME"].DataType;
                    return (AppointmentDefinitionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? StateOnly
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEONLY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].AllPropertyDefs["STATEONLY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAppointmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentDefinition_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e95e4650-5cc6-4b9d-8461-b41cbca5289c"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("6f61ed98-ef4c-4c28-abcb-da8009f00b64"); } }
        }

        public static BindingList<AppointmentDefinition.GetAppointmentDefinition_Class> GetAppointmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].QueryDefs["GetAppointmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AppointmentDefinition.GetAppointmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AppointmentDefinition.GetAppointmentDefinition_Class> GetAppointmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].QueryDefs["GetAppointmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AppointmentDefinition.GetAppointmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AppointmentDefinition> GetAppointmentDefinitionByName(TTObjectContext objectContext, AppointmentDefinitionEnum APPOINTMENTDEFNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].QueryDefs["GetAppointmentDefinitionByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPOINTMENTDEFNAME", (int)APPOINTMENTDEFNAME);

            return ((ITTQuery)objectContext).QueryObjects<AppointmentDefinition>(queryDef, paramList);
        }

        public static BindingList<AppointmentDefinition> GetAllAppointmentDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].QueryDefs["GetAllAppointmentDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AppointmentDefinition>(queryDef, paramList);
        }

        public static BindingList<AppointmentDefinition> GetAdmissionAppointmentDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTDEFINITION"].QueryDefs["GetAdmissionAppointmentDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AppointmentDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Sadece süreç içerisinden verilecek randevuların StateOnly property si true olmalıdır.
    /// </summary>
        public bool? StateOnly
        {
            get { return (bool?)this["STATEONLY"]; }
            set { this["STATEONLY"] = value; }
        }

    /// <summary>
    /// Randevu Kodu
    /// </summary>
        public int? AppointmentDefinitionID
        {
            get { return (int?)this["APPOINTMENTDEFINITIONID"]; }
            set { this["APPOINTMENTDEFINITIONID"] = value; }
        }

    /// <summary>
    /// Randevu Adı
    /// </summary>
        public string AppDefNameDisplayText
        {
            get { return (string)this["APPDEFNAMEDISPLAYTEXT"]; }
            set { this["APPDEFNAMEDISPLAYTEXT"] = value; }
        }

    /// <summary>
    /// Havale Edene Randevu Ver
    /// </summary>
        public bool? GiveFromResource
        {
            get { return (bool?)this["GIVEFROMRESOURCE"]; }
            set { this["GIVEFROMRESOURCE"] = value; }
        }

    /// <summary>
    /// Ana Kaynağa Randevu Ver
    /// </summary>
        public bool? GiveToMaster
        {
            get { return (bool?)this["GIVETOMASTER"]; }
            set { this["GIVETOMASTER"] = value; }
        }

        public string FormDefID
        {
            get { return (string)this["FORMDEFID"]; }
            set { this["FORMDEFID"] = value; }
        }

    /// <summary>
    /// Randevu Çakışmasına İzin Ver
    /// </summary>
        public bool? OverlapAllowed
        {
            get { return (bool?)this["OVERLAPALLOWED"]; }
            set { this["OVERLAPALLOWED"] = value; }
        }

    /// <summary>
    /// Randevu Adı
    /// </summary>
        public AppointmentDefinitionEnum? AppointmentDefinitionName
        {
            get { return (AppointmentDefinitionEnum?)(int?)this["APPOINTMENTDEFINITIONNAME"]; }
            set { this["APPOINTMENTDEFINITIONNAME"] = value; }
        }

        public string AppDefNameDisplayText_Shad
        {
            get { return (string)this["APPDEFNAMEDISPLAYTEXT_SHAD"]; }
        }

    /// <summary>
    /// Plan dışı randevular için not alanı zorunlu olsun
    /// </summary>
        public bool? IsDescReqForNonScheduledApps
        {
            get { return (bool?)this["ISDESCREQFORNONSCHEDULEDAPPS"]; }
            set { this["ISDESCREQFORNONSCHEDULEDAPPS"] = value; }
        }

    /// <summary>
    /// Planlama Çakışmasına İzin Ver
    /// </summary>
        public bool? ScheduleOverlapAllowed
        {
            get { return (bool?)this["SCHEDULEOVERLAPALLOWED"]; }
            set { this["SCHEDULEOVERLAPALLOWED"] = value; }
        }

    /// <summary>
    /// MHRS'ye Bildir
    /// </summary>
        public bool? SentToMHRS
        {
            get { return (bool?)this["SENTTOMHRS"]; }
            set { this["SENTTOMHRS"] = value; }
        }

        virtual protected void CreateAppointmentCarriersCollection()
        {
            _AppointmentCarriers = new AppointmentCarrier.ChildAppointmentCarrierCollection(this, new Guid("1f64b546-6de1-4e43-8652-4ca8dfc071d4"));
            ((ITTChildObjectCollection)_AppointmentCarriers).GetChildren();
        }

        protected AppointmentCarrier.ChildAppointmentCarrierCollection _AppointmentCarriers = null;
        public AppointmentCarrier.ChildAppointmentCarrierCollection AppointmentCarriers
        {
            get
            {
                if (_AppointmentCarriers == null)
                    CreateAppointmentCarriersCollection();
                return _AppointmentCarriers;
            }
        }

        virtual protected void CreateAppointmentDefinitionRolesCollection()
        {
            _AppointmentDefinitionRoles = new AppointmentDefinitionRole.ChildAppointmentDefinitionRoleCollection(this, new Guid("581e32f2-2f98-419a-a814-5ce5bb9edb9c"));
            ((ITTChildObjectCollection)_AppointmentDefinitionRoles).GetChildren();
        }

        protected AppointmentDefinitionRole.ChildAppointmentDefinitionRoleCollection _AppointmentDefinitionRoles = null;
    /// <summary>
    /// Child collection for Kafa randevusunu randevu tipine göre yapabilecek roller tanımlanır.
    /// </summary>
        public AppointmentDefinitionRole.ChildAppointmentDefinitionRoleCollection AppointmentDefinitionRoles
        {
            get
            {
                if (_AppointmentDefinitionRoles == null)
                    CreateAppointmentDefinitionRolesCollection();
                return _AppointmentDefinitionRoles;
            }
        }

        protected AppointmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTDEFINITION", dataRow) { }
        protected AppointmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTDEFINITION", dataRow, isImported) { }
        public AppointmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentDefinition() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}