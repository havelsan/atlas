
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedProcedureRequest")] 

    /// <summary>
    /// Planlanan İstemlerin Tutulacağı Ana Nesnedir
    /// </summary>
    public  partial class PlannedProcedureRequest : TTObject
    {
        public class PlannedProcedureRequestList : TTObjectCollection<PlannedProcedureRequest> { }
                    
        public class ChildPlannedProcedureRequestCollection : TTObject.TTChildObjectCollection<PlannedProcedureRequest>
        {
            public ChildPlannedProcedureRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedProcedureRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PlannedProcedureRequest> GetPlannedProcedureRequests(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDPROCEDUREREQUEST"].QueryDefs["GetPlannedProcedureRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PlannedProcedureRequest>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PlannedProcedureRequest> GetPlannedRequestsOnCureComplete(TTObjectContext objectContext, Guid ACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDPROCEDUREREQUEST"].QueryDefs["GetPlannedRequestsOnCureComplete"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONID", ACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<PlannedProcedureRequest>(queryDef, paramList);
        }

        public static BindingList<PlannedProcedureRequest> GetPlannedRequestsOnCureCount(TTObjectContext objectContext, Guid ACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDPROCEDUREREQUEST"].QueryDefs["GetPlannedRequestsOnCureCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONID", ACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<PlannedProcedureRequest>(queryDef, paramList);
        }

    /// <summary>
    /// Kaçıncı Kür
    /// </summary>
        public int? WhichCure
        {
            get { return (int?)this["WHICHCURE"]; }
            set { this["WHICHCURE"] = value; }
        }

    /// <summary>
    /// Kür sayısına göre Planlama yapıldığını belirten değişken
    /// </summary>
        public bool? IsOnCureCount
        {
            get { return (bool?)this["ISONCURECOUNT"]; }
            set { this["ISONCURECOUNT"] = value; }
        }

    /// <summary>
    /// Tedavinin tamamlanmasına göre planlama yapıldığını gösterir
    /// </summary>
        public bool? IsOnTreatmentComplete
        {
            get { return (bool?)this["ISONTREATMENTCOMPLETE"]; }
            set { this["ISONTREATMENTCOMPLETE"] = value; }
        }

    /// <summary>
    /// Planın Oluşturulma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Planlanan Tedavinin Uygulanma zamanı
    /// </summary>
        public DateTime? PlanApplyDate
        {
            get { return (DateTime?)this["PLANAPPLYDATE"]; }
            set { this["PLANAPPLYDATE"] = value; }
        }

    /// <summary>
    /// Planlamanın İptal Edilip Edilmediği Bilgisi
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

        public EpisodeAction ForPlannedEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("FORPLANNEDEPISODEACTION"); }
            set { this["FORPLANNEDEPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser PlannedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("PLANNEDBY"); }
            set { this["PLANNEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureForPlannedRequestCollection()
        {
            _ProcedureForPlannedRequest = new ProcedureForPlannedRequest.ChildProcedureForPlannedRequestCollection(this, new Guid("c29c712e-2f16-4c64-a29d-8f44e64d8a03"));
            ((ITTChildObjectCollection)_ProcedureForPlannedRequest).GetChildren();
        }

        protected ProcedureForPlannedRequest.ChildProcedureForPlannedRequestCollection _ProcedureForPlannedRequest = null;
        public ProcedureForPlannedRequest.ChildProcedureForPlannedRequestCollection ProcedureForPlannedRequest
        {
            get
            {
                if (_ProcedureForPlannedRequest == null)
                    CreateProcedureForPlannedRequestCollection();
                return _ProcedureForPlannedRequest;
            }
        }

        protected PlannedProcedureRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedProcedureRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedProcedureRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedProcedureRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedProcedureRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDPROCEDUREREQUEST", dataRow) { }
        protected PlannedProcedureRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDPROCEDUREREQUEST", dataRow, isImported) { }
        public PlannedProcedureRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedProcedureRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedProcedureRequest() : base() { }

    }
}