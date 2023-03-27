
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDeliveryAction")] 

    /// <summary>
    /// İlaç Teslim İşlemi
    /// </summary>
    public  partial class DrugDeliveryAction : EpisodeAction
    {
        public class DrugDeliveryActionList : TTObjectCollection<DrugDeliveryAction> { }
                    
        public class ChildDrugDeliveryActionCollection : TTObject.TTChildObjectCollection<DrugDeliveryAction>
        {
            public ChildDrugDeliveryActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDeliveryActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugDeliveryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DrugName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDELIVERYACTIONDETAIL"].AllPropertyDefs["DRUGNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? ResDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDELIVERYACTIONDETAIL"].AllPropertyDefs["RESDOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugDeliveryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDeliveryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDeliveryReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("df9a3cd6-b48f-4c47-a649-758b7d2ac65a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("fcd505d8-04fd-4f0f-86c2-9b5518592434"); } }
        }

        public static BindingList<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class> GetDrugDeliveryReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDELIVERYACTION"].QueryDefs["GetDrugDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class> GetDrugDeliveryReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDELIVERYACTION"].QueryDefs["GetDrugDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreateDrugDeliveryActionDetailsCollection()
        {
            _DrugDeliveryActionDetails = new DrugDeliveryActionDetail.ChildDrugDeliveryActionDetailCollection(this, new Guid("b429f78f-0e64-400c-8247-160ebd6d55f6"));
            ((ITTChildObjectCollection)_DrugDeliveryActionDetails).GetChildren();
        }

        protected DrugDeliveryActionDetail.ChildDrugDeliveryActionDetailCollection _DrugDeliveryActionDetails = null;
        public DrugDeliveryActionDetail.ChildDrugDeliveryActionDetailCollection DrugDeliveryActionDetails
        {
            get
            {
                if (_DrugDeliveryActionDetails == null)
                    CreateDrugDeliveryActionDetailsCollection();
                return _DrugDeliveryActionDetails;
            }
        }

        protected DrugDeliveryAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDeliveryAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDeliveryAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDeliveryAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDeliveryAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDELIVERYACTION", dataRow) { }
        protected DrugDeliveryAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDELIVERYACTION", dataRow, isImported) { }
        public DrugDeliveryAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDeliveryAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDeliveryAction() : base() { }

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