
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HalfDoseDestruction")] 

    /// <summary>
    /// Yarım Doz İmha İşlemi
    /// </summary>
    public  partial class HalfDoseDestruction : EpisodeAction
    {
        public class HalfDoseDestructionList : TTObjectCollection<HalfDoseDestruction> { }
                    
        public class ChildHalfDoseDestructionCollection : TTObject.TTChildObjectCollection<HalfDoseDestruction>
        {
            public ChildHalfDoseDestructionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHalfDoseDestructionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class HalfDoseReportQuery_Class : TTReportNqlObject 
        {
            public string DrugName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HALFDOSEDESTRUCTIONDETAIL"].AllPropertyDefs["DRUGNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NFCType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NFCTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HALFDOSEDESTRUCTIONDETAIL"].AllPropertyDefs["NFCTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HALFDOSEDESTRUCTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HalfDoseReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HalfDoseReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HalfDoseReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ae3bce9a-968c-40f2-be56-2a883b10cf3d"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("a9d312a1-6e91-438a-b38c-9b1e3c0d4906"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("56eeb5bc-2274-4595-8c05-01faf34fa91b"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("22c76e00-e842-415f-b01f-e6cc9115c083"); } }
        }

        public static BindingList<HalfDoseDestruction.HalfDoseReportQuery_Class> HalfDoseReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HALFDOSEDESTRUCTION"].QueryDefs["HalfDoseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<HalfDoseDestruction.HalfDoseReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HalfDoseDestruction.HalfDoseReportQuery_Class> HalfDoseReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HALFDOSEDESTRUCTION"].QueryDefs["HalfDoseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<HalfDoseDestruction.HalfDoseReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Başlanguç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public Store PharmacyStoreDefinition
        {
            get { return (Store)((ITTObject)this).GetParent("PHARMACYSTOREDEFINITION"); }
            set { this["PHARMACYSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHalfDoseDestructionDetailsCollection()
        {
            _HalfDoseDestructionDetails = new HalfDoseDestructionDetail.ChildHalfDoseDestructionDetailCollection(this, new Guid("9afb4808-6ab0-4b3e-ac08-c206323fef55"));
            ((ITTChildObjectCollection)_HalfDoseDestructionDetails).GetChildren();
        }

        protected HalfDoseDestructionDetail.ChildHalfDoseDestructionDetailCollection _HalfDoseDestructionDetails = null;
        public HalfDoseDestructionDetail.ChildHalfDoseDestructionDetailCollection HalfDoseDestructionDetails
        {
            get
            {
                if (_HalfDoseDestructionDetails == null)
                    CreateHalfDoseDestructionDetailsCollection();
                return _HalfDoseDestructionDetails;
            }
        }

        protected HalfDoseDestruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HalfDoseDestruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HalfDoseDestruction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HalfDoseDestruction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HalfDoseDestruction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HALFDOSEDESTRUCTION", dataRow) { }
        protected HalfDoseDestruction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HALFDOSEDESTRUCTION", dataRow, isImported) { }
        public HalfDoseDestruction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HalfDoseDestruction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HalfDoseDestruction() : base() { }

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