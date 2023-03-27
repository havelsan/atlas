
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionPaper")] 

    public  partial class PrescriptionPaper : TTObject
    {
        public class PrescriptionPaperList : TTObjectCollection<PrescriptionPaper> { }
                    
        public class ChildPrescriptionPaperCollection : TTObject.TTChildObjectCollection<PrescriptionPaper>
        {
            public ChildPrescriptionPaperCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionPaperCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPrescriptionPapersDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].AllPropertyDefs["SERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VolumeNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLUMENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].AllPropertyDefs["VOLUMENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionPapersDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionPapersDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionPapersDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionPapers_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].AllPropertyDefs["SERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VolumeNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLUMENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].AllPropertyDefs["VOLUMENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stock
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCK"]);
                }
            }

            public GetPrescriptionPapers_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionPapers_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionPapers_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Kullanılabilir
    /// </summary>
            public static Guid Usable { get { return new Guid("eea82631-ff52-4753-a61a-de3a3167c8ec"); } }
    /// <summary>
    /// Kullanıldı
    /// </summary>
            public static Guid Used { get { return new Guid("b18fdc48-694f-4fe4-9ff4-3d16a409e8d3"); } }
        }

        public static BindingList<PrescriptionPaper.GetPrescriptionPapersDetail_Class> GetPrescriptionPapersDetail(Guid MATERIAL, Guid STORE, int ALLSTORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].QueryDefs["GetPrescriptionPapersDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STORE", STORE);
            paramList.Add("ALLSTORE", ALLSTORE);

            return TTReportNqlObject.QueryObjects<PrescriptionPaper.GetPrescriptionPapersDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionPaper.GetPrescriptionPapersDetail_Class> GetPrescriptionPapersDetail(TTObjectContext objectContext, Guid MATERIAL, Guid STORE, int ALLSTORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].QueryDefs["GetPrescriptionPapersDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STORE", STORE);
            paramList.Add("ALLSTORE", ALLSTORE);

            return TTReportNqlObject.QueryObjects<PrescriptionPaper.GetPrescriptionPapersDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionPaper.GetPrescriptionPapers_Class> GetPrescriptionPapers(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].QueryDefs["GetPrescriptionPapers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PrescriptionPaper.GetPrescriptionPapers_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PrescriptionPaper.GetPrescriptionPapers_Class> GetPrescriptionPapers(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONPAPER"].QueryDefs["GetPrescriptionPapers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PrescriptionPaper.GetPrescriptionPapers_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Seri Nu
    /// </summary>
        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

    /// <summary>
    /// Cilt Nu
    /// </summary>
        public string VolumeNo
        {
            get { return (string)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PrescriptionPaper(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionPaper(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionPaper(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionPaper(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionPaper(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONPAPER", dataRow) { }
        protected PrescriptionPaper(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONPAPER", dataRow, isImported) { }
        public PrescriptionPaper(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionPaper(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionPaper() : base() { }

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