
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAction")] 

    /// <summary>
    /// Program üzerinde orak özelikler taşıyan işlemlerin ana Nesnesi
    /// </summary>
    public  partial class BaseAction : TTObject, IGeneralWorkList, ISetWorkListDate
    {
        public class BaseActionList : TTObjectCollection<BaseAction> { }
                    
        public class ChildBaseActionCollection : TTObject.TTChildObjectCollection<BaseAction>
        {
            public ChildBaseActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAppointmentActions_Class : TTReportNqlObject 
        {
            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hasapp
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASAPP"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetAppointmentActions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentActions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentActions_Class() : base() { }
        }

        public static BindingList<BaseAction> GetByFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEACTION"].QueryDefs["GetByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseAction> GetByBaseActionWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEACTION"].QueryDefs["GetByBaseActionWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BaseAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseAction> GetByWLFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEACTION"].QueryDefs["GetByWLFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseAction.GetAppointmentActions_Class> GetAppointmentActions(Guid MASTERRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEACTION"].QueryDefs["GetAppointmentActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseAction.GetAppointmentActions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseAction.GetAppointmentActions_Class> GetAppointmentActions(TTObjectContext objectContext, Guid MASTERRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEACTION"].QueryDefs["GetAppointmentActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseAction.GetAppointmentActions_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// İşlem İptal Sebebi
    /// </summary>
        public string ReasonOfCancel
        {
            get { return (string)this["REASONOFCANCEL"]; }
            set { this["REASONOFCANCEL"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        public DateTime? WorkListDate
        {
            get { return (DateTime?)this["WORKLISTDATE"]; }
            set { this["WORKLISTDATE"] = value; }
        }

    /// <summary>
    /// Red Sebebi
    /// </summary>
        public object ReasonOfReject
        {
            get { return (object)this["REASONOFREJECT"]; }
            set { this["REASONOFREJECT"] = value; }
        }

    /// <summary>
    /// İşlem Nu.
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Olap Güncelleme Tarihi
    /// </summary>
        public DateTime? OlapLastUpdate
        {
            get { return (DateTime?)this["OLAPLASTUPDATE"]; }
            set { this["OLAPLASTUPDATE"] = value; }
        }

    /// <summary>
    /// Olap İşlem Tarihi
    /// </summary>
        public DateTime? OlapDate
        {
            get { return (DateTime?)this["OLAPDATE"]; }
            set { this["OLAPDATE"] = value; }
        }

    /// <summary>
    /// Klonlandığı objenin ObjectID sini tutar
    /// </summary>
        public Guid? ClonedObjectID
        {
            get { return (Guid?)this["CLONEDOBJECTID"]; }
            set { this["CLONEDOBJECTID"] = value; }
        }

        public string WorkListDescription
        {
            get { return (string)this["WORKLISTDESCRIPTION"]; }
            set { this["WORKLISTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlemin aktarımla gelip gelmediğine bakar
    /// </summary>
        public bool? IsOldAction
        {
            get { return (bool?)this["ISOLDACTION"]; }
            set { this["ISOLDACTION"] = value; }
        }

        public BaseAction MasterAction
        {
            get { return (BaseAction)((ITTObject)this).GetParent("MASTERACTION"); }
            set { this["MASTERACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAppointmentWithoutResourcesCollection()
        {
            _AppointmentWithoutResources = new AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection(this, new Guid("6d0a3764-e18a-4324-979c-0b7058f8d6c2"));
            ((ITTChildObjectCollection)_AppointmentWithoutResources).GetChildren();
        }

        protected AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection _AppointmentWithoutResources = null;
        public AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection AppointmentWithoutResources
        {
            get
            {
                if (_AppointmentWithoutResources == null)
                    CreateAppointmentWithoutResourcesCollection();
                return _AppointmentWithoutResources;
            }
        }

        virtual protected void CreateAuthorizedUsersCollection()
        {
            _AuthorizedUsers = new AuthorizedUser.ChildAuthorizedUserCollection(this, new Guid("a390d02c-4ec7-4688-9d1a-2fd1b92b4bec"));
            ((ITTChildObjectCollection)_AuthorizedUsers).GetChildren();
        }

        protected AuthorizedUser.ChildAuthorizedUserCollection _AuthorizedUsers = null;
        public AuthorizedUser.ChildAuthorizedUserCollection AuthorizedUsers
        {
            get
            {
                if (_AuthorizedUsers == null)
                    CreateAuthorizedUsersCollection();
                return _AuthorizedUsers;
            }
        }

        virtual protected void CreateLinkedActionsCollectionViews()
        {
        }

        virtual protected void CreateLinkedActionsCollection()
        {
            _LinkedActions = new BaseAction.ChildBaseActionCollection(this, new Guid("85ff4d04-c064-4c33-9d04-a30beaecea63"));
            CreateLinkedActionsCollectionViews();
            ((ITTChildObjectCollection)_LinkedActions).GetChildren();
        }

        protected BaseAction.ChildBaseActionCollection _LinkedActions = null;
        public BaseAction.ChildBaseActionCollection LinkedActions
        {
            get
            {
                if (_LinkedActions == null)
                    CreateLinkedActionsCollection();
                return _LinkedActions;
            }
        }

        virtual protected void CreateAppointmentsCollection()
        {
            _Appointments = new Appointment.ChildAppointmentCollection(this, new Guid("29e4fc56-74df-4b83-9c94-7e8d07dbb7d3"));
            ((ITTChildObjectCollection)_Appointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _Appointments = null;
        public Appointment.ChildAppointmentCollection Appointments
        {
            get
            {
                if (_Appointments == null)
                    CreateAppointmentsCollection();
                return _Appointments;
            }
        }

        virtual protected void CreateUploadedDocumentsCollection()
        {
            _UploadedDocuments = new UploadedDocument.ChildUploadedDocumentCollection(this, new Guid("8f2aa32e-054d-45d9-9a7f-72947b3fce38"));
            ((ITTChildObjectCollection)_UploadedDocuments).GetChildren();
        }

        protected UploadedDocument.ChildUploadedDocumentCollection _UploadedDocuments = null;
        public UploadedDocument.ChildUploadedDocumentCollection UploadedDocuments
        {
            get
            {
                if (_UploadedDocuments == null)
                    CreateUploadedDocumentsCollection();
                return _UploadedDocuments;
            }
        }

        protected BaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEACTION", dataRow) { }
        protected BaseAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEACTION", dataRow, isImported) { }
        public BaseAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAction() : base() { }

    }
}