
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentViewerCompDef")] 

    /// <summary>
    /// Randevu Sırası Bilgisayar Tanımı  
    /// </summary>
    public  partial class AppointmentViewerCompDef : TTDefinitionSet
    {
        public class AppointmentViewerCompDefList : TTObjectCollection<AppointmentViewerCompDef> { }
                    
        public class ChildAppointmentViewerCompDefCollection : TTObject.TTChildObjectCollection<AppointmentViewerCompDef>
        {
            public ChildAppointmentViewerCompDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentViewerCompDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAppointmentViewerCompDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string ComputerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPUTERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].AllPropertyDefs["COMPUTERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ListQueuesSeperate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LISTQUEUESSEPERATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].AllPropertyDefs["LISTQUEUESSEPERATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? RowCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROWCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].AllPropertyDefs["ROWCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentViewerCompDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentViewerCompDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentViewerCompDef_Class() : base() { }
        }

        public static BindingList<AppointmentViewerCompDef> GetAccCompDefByComputerName(TTObjectContext objectContext, string COMPUTERNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].QueryDefs["GetAccCompDefByComputerName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COMPUTERNAME", COMPUTERNAME);

            return ((ITTQuery)objectContext).QueryObjects<AppointmentViewerCompDef>(queryDef, paramList);
        }

        public static BindingList<AppointmentViewerCompDef.GetAppointmentViewerCompDef_Class> GetAppointmentViewerCompDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].QueryDefs["GetAppointmentViewerCompDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AppointmentViewerCompDef.GetAppointmentViewerCompDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AppointmentViewerCompDef.GetAppointmentViewerCompDef_Class> GetAppointmentViewerCompDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENTVIEWERCOMPDEF"].QueryDefs["GetAppointmentViewerCompDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AppointmentViewerCompDef.GetAppointmentViewerCompDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bilgisayar Adı
    /// </summary>
        public string ComputerName
        {
            get { return (string)this["COMPUTERNAME"]; }
            set { this["COMPUTERNAME"] = value; }
        }

    /// <summary>
    /// Kuyrukları Ayrı Listele
    /// </summary>
        public bool? ListQueuesSeperate
        {
            get { return (bool?)this["LISTQUEUESSEPERATE"]; }
            set { this["LISTQUEUESSEPERATE"] = value; }
        }

    /// <summary>
    /// Bir Sayfada Listelenecek Randevu Sayısı
    /// </summary>
        public int? RowCount
        {
            get { return (int?)this["ROWCOUNT"]; }
            set { this["ROWCOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateRelatedResourcesCollection()
        {
            _RelatedResources = new RelatedResource.ChildRelatedResourceCollection(this, new Guid("935d9ea9-61d4-4d4d-afb6-b9e97fdae25a"));
            ((ITTChildObjectCollection)_RelatedResources).GetChildren();
        }

        protected RelatedResource.ChildRelatedResourceCollection _RelatedResources = null;
        public RelatedResource.ChildRelatedResourceCollection RelatedResources
        {
            get
            {
                if (_RelatedResources == null)
                    CreateRelatedResourcesCollection();
                return _RelatedResources;
            }
        }

        virtual protected void CreateRelatedQueuesCollection()
        {
            _RelatedQueues = new RelatedQueues.ChildRelatedQueuesCollection(this, new Guid("cf35b0b8-0bd4-4078-bfc8-a55322d46476"));
            ((ITTChildObjectCollection)_RelatedQueues).GetChildren();
        }

        protected RelatedQueues.ChildRelatedQueuesCollection _RelatedQueues = null;
        public RelatedQueues.ChildRelatedQueuesCollection RelatedQueues
        {
            get
            {
                if (_RelatedQueues == null)
                    CreateRelatedQueuesCollection();
                return _RelatedQueues;
            }
        }

        protected AppointmentViewerCompDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentViewerCompDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentViewerCompDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentViewerCompDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentViewerCompDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTVIEWERCOMPDEF", dataRow) { }
        protected AppointmentViewerCompDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTVIEWERCOMPDEF", dataRow, isImported) { }
        public AppointmentViewerCompDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentViewerCompDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentViewerCompDef() : base() { }

    }
}