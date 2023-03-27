
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SterilizationHistory")] 

    /// <summary>
    /// Sterilizasyon Geçmişi
    /// </summary>
    public  partial class SterilizationHistory : TTObject
    {
        public class SterilizationHistoryList : TTObjectCollection<SterilizationHistory> { }
                    
        public class ChildSterilizationHistoryCollection : TTObject.TTChildObjectCollection<SterilizationHistory>
        {
            public ChildSterilizationHistoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSterilizationHistoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSterilizationHistoryForWorkList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public SterilizationPackageMethodEnum? PackageMethod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEMETHOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].AllPropertyDefs["PACKAGEMETHOD"].DataType;
                    return (SterilizationPackageMethodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public IndicatorSelectionEnum? IndicatorSelection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INDICATORSELECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].AllPropertyDefs["INDICATORSELECTION"].DataType;
                    return (IndicatorSelectionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SterilizationEnum? Sterilization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STERILIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].AllPropertyDefs["STERILIZATION"].DataType;
                    return (SterilizationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DeviceLoopNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICELOOPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].AllPropertyDefs["DEVICELOOPNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ResSterilizationDevice
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESSTERILIZATIONDEVICE"]);
                }
            }

            public Guid? Kabuleden
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KABULEDEN"]);
                }
            }

            public Guid? Teslimalan
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESLIMALAN"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetSterilizationHistoryForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSterilizationHistoryForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSterilizationHistoryForWorkList_Class() : base() { }
        }

        public static class States
        {
            public static Guid SterilizationRequest { get { return new Guid("7ba9fab9-8db1-469e-a4a4-24e17725440f"); } }
            public static Guid PrePrepare { get { return new Guid("7f13693f-a079-43b1-b99b-b900de8ac66c"); } }
            public static Guid Prepare { get { return new Guid("8f3c5cf2-fa0c-43e4-8d9c-1bf8c72e77c6"); } }
            public static Guid InDevice { get { return new Guid("4535c0d6-df95-4d0b-8bcd-f03a140b37f5"); } }
            public static Guid Sterilization { get { return new Guid("68966a5d-d46c-4124-89c7-5eddc31df502"); } }
            public static Guid Completed { get { return new Guid("6bc57913-7bed-46a8-97f8-da2b80d9a682"); } }
        }

        public static BindingList<SterilizationHistory.GetSterilizationHistoryForWorkList_Class> GetSterilizationHistoryForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].QueryDefs["GetSterilizationHistoryForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SterilizationHistory.GetSterilizationHistoryForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SterilizationHistory.GetSterilizationHistoryForWorkList_Class> GetSterilizationHistoryForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STERILIZATIONHISTORY"].QueryDefs["GetSterilizationHistoryForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SterilizationHistory.GetSterilizationHistoryForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public SterilizationEnum? Sterilization
        {
            get { return (SterilizationEnum?)(int?)this["STERILIZATION"]; }
            set { this["STERILIZATION"] = value; }
        }

        public SterilizationPackageMethodEnum? PackageMethod
        {
            get { return (SterilizationPackageMethodEnum?)(int?)this["PACKAGEMETHOD"]; }
            set { this["PACKAGEMETHOD"] = value; }
        }

        public IndicatorSelectionEnum? IndicatorSelection
        {
            get { return (IndicatorSelectionEnum?)(int?)this["INDICATORSELECTION"]; }
            set { this["INDICATORSELECTION"] = value; }
        }

        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

        public int? DeviceLoopNo
        {
            get { return (int?)this["DEVICELOOPNO"]; }
            set { this["DEVICELOOPNO"] = value; }
        }

        public ResUser DeliveredUserAfterUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("DELIVEREDUSERAFTERUSER"); }
            set { this["DELIVEREDUSERAFTERUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SterilizationRequest SterilizationRequest
        {
            get { return (SterilizationRequest)((ITTObject)this).GetParent("STERILIZATIONREQUEST"); }
            set { this["STERILIZATIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResReusableMaterial ReusableMaterial
        {
            get { return (ResReusableMaterial)((ITTObject)this).GetParent("REUSABLEMATERIAL"); }
            set { this["REUSABLEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser SterilizationUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("STERILIZATIONUSER"); }
            set { this["STERILIZATIONUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSterilizationDevice ResSterilizationDevice
        {
            get { return (ResSterilizationDevice)((ITTObject)this).GetParent("RESSTERILIZATIONDEVICE"); }
            set { this["RESSTERILIZATIONDEVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SterilizationHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SterilizationHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SterilizationHistory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SterilizationHistory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SterilizationHistory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STERILIZATIONHISTORY", dataRow) { }
        protected SterilizationHistory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STERILIZATIONHISTORY", dataRow, isImported) { }
        public SterilizationHistory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SterilizationHistory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SterilizationHistory() : base() { }

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