
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ErrorReportAction")] 

    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
    public  partial class ErrorReportAction : BaseAction, IErrorReportWorkList
    {
        public class ErrorReportActionList : TTObjectCollection<ErrorReportAction> { }
                    
        public class ChildErrorReportActionCollection : TTObject.TTChildObjectCollection<ErrorReportAction>
        {
            public ChildErrorReportActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildErrorReportActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetErrorReportAction_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ErrorReportNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERRORREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ERRORREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public ErrorPriorityEnum? ErrorPriority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERRORPRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["ERRORPRIORITY"].DataType;
                    return (ErrorPriorityEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string SolutionBuilding
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONBUILDING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONBUILDING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SolutionWorkHours
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONWORKHOURS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONWORKHOURS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? SolutionMaterialCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONMATERIALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONMATERIALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SolutionStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONSTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONSTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SolutionEndDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONENDDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONENDDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SolutionDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUTIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["SOLUTIONDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string FromTelephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMTELEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["FROMTELEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? InventoryNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVENTORYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].AllPropertyDefs["INVENTORYNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetErrorReportAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorReportAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorReportAction_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("2f21cf0c-9870-43d3-8230-4d2bbf376656"); } }
            public static Guid Approved { get { return new Guid("17cd64e2-1cc6-4a6e-ae6f-c108a64c2b29"); } }
            public static Guid Assigned { get { return new Guid("7d92fb5a-8b7f-4922-b7ff-b511d80d14cd"); } }
            public static Guid New { get { return new Guid("47395187-f177-4149-b626-f9a452c3ee8a"); } }
            public static Guid Cancelled { get { return new Guid("a3a39bcf-85ad-496a-bd43-536a5d1d7c76"); } }
        }

        public static BindingList<ErrorReportAction> ErrorReportWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].QueryDefs["ErrorReportWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ErrorReportAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ErrorReportAction> ErrorReportByInventoryQuery(TTObjectContext objectContext, Guid INVENTORYID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].QueryDefs["ErrorReportByInventoryQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVENTORYID", INVENTORYID);

            return ((ITTQuery)objectContext).QueryObjects<ErrorReportAction>(queryDef, paramList);
        }

        public static BindingList<ErrorReportAction> ErrorReportByInventoryNoQuery(TTObjectContext objectContext, int INVENTORYNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].QueryDefs["ErrorReportByInventoryNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVENTORYNO", INVENTORYNO);

            return ((ITTQuery)objectContext).QueryObjects<ErrorReportAction>(queryDef, paramList);
        }

        public static BindingList<ErrorReportAction.GetErrorReportAction_Class> GetErrorReportAction(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].QueryDefs["GetErrorReportAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ErrorReportAction.GetErrorReportAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ErrorReportAction.GetErrorReportAction_Class> GetErrorReportAction(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTACTION"].QueryDefs["GetErrorReportAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ErrorReportAction.GetErrorReportAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Problem / Hata Nu.
    /// </summary>
        public TTSequence ErrorReportNO
        {
            get { return GetSequence("ERRORREPORTNO"); }
        }

    /// <summary>
    /// Problem / Hata
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Problem / Hata Detay
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Öncelik
    /// </summary>
        public ErrorPriorityEnum? ErrorPriority
        {
            get { return (ErrorPriorityEnum?)(int?)this["ERRORPRIORITY"]; }
            set { this["ERRORPRIORITY"] = value; }
        }

    /// <summary>
    /// Bina Nu
    /// </summary>
        public string SolutionBuilding
        {
            get { return (string)this["SOLUTIONBUILDING"]; }
            set { this["SOLUTIONBUILDING"] = value; }
        }

    /// <summary>
    /// Toplam İş Saati
    /// </summary>
        public int? SolutionWorkHours
        {
            get { return (int?)this["SOLUTIONWORKHOURS"]; }
            set { this["SOLUTIONWORKHOURS"] = value; }
        }

    /// <summary>
    /// Malzeme Maliyeti
    /// </summary>
        public double? SolutionMaterialCost
        {
            get { return (double?)this["SOLUTIONMATERIALCOST"]; }
            set { this["SOLUTIONMATERIALCOST"] = value; }
        }

    /// <summary>
    /// Çözüm Başlama Tarihi / Saati
    /// </summary>
        public DateTime? SolutionStartDateTime
        {
            get { return (DateTime?)this["SOLUTIONSTARTDATETIME"]; }
            set { this["SOLUTIONSTARTDATETIME"] = value; }
        }

    /// <summary>
    /// Çözüm Bitiş Tarihi / Saati
    /// </summary>
        public DateTime? SolutionEndDateTime
        {
            get { return (DateTime?)this["SOLUTIONENDDATETIME"]; }
            set { this["SOLUTIONENDDATETIME"] = value; }
        }

    /// <summary>
    /// Çözüm Detay
    /// </summary>
        public object SolutionDescription
        {
            get { return (object)this["SOLUTIONDESCRIPTION"]; }
            set { this["SOLUTIONDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string FromTelephone
        {
            get { return (string)this["FROMTELEPHONE"]; }
            set { this["FROMTELEPHONE"] = value; }
        }

    /// <summary>
    /// Envanter No
    /// </summary>
        public int? InventoryNo
        {
            get { return (int?)this["INVENTORYNO"]; }
            set { this["INVENTORYNO"] = value; }
        }

    /// <summary>
    /// İşi İsteyen Birim
    /// </summary>
        public Resource FromResource
        {
            get { return (Resource)((ITTObject)this).GetParent("FROMRESOURCE"); }
            set { this["FROMRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşi Yönlendiren Birim
    /// </summary>
        public Resource ToResource
        {
            get { return (Resource)((ITTObject)this).GetParent("TORESOURCE"); }
            set { this["TORESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşi Yapacak Birim
    /// </summary>
        public Resource OwnerResource
        {
            get { return (Resource)((ITTObject)this).GetParent("OWNERRESOURCE"); }
            set { this["OWNERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşi İsteyen Personel
    /// </summary>
        public ResUser FromUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("FROMUSER"); }
            set { this["FROMUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşi Yapacak Personel
    /// </summary>
        public ResUser OwnerUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("OWNERUSER"); }
            set { this["OWNERUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Problem / Hata Kategorisi
    /// </summary>
        public ErrorReportCategory ErrorReportCategory
        {
            get { return (ErrorReportCategory)((ITTObject)this).GetParent("ERRORREPORTCATEGORY"); }
            set { this["ERRORREPORTCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Envanter
    /// </summary>
        public ErrorReportInventory ErrorReportInventory
        {
            get { return (ErrorReportInventory)((ITTObject)this).GetParent("ERRORREPORTINVENTORY"); }
            set { this["ERRORREPORTINVENTORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ErrorReportAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ErrorReportAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ErrorReportAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ErrorReportAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ErrorReportAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ERRORREPORTACTION", dataRow) { }
        protected ErrorReportAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ERRORREPORTACTION", dataRow, isImported) { }
        public ErrorReportAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ErrorReportAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ErrorReportAction() : base() { }

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