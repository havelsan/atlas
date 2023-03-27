
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarchPatientEx")] 

    public  partial class MedicalResarchPatientEx : EpisodeAction
    {
        public class MedicalResarchPatientExList : TTObjectCollection<MedicalResarchPatientEx> { }
                    
        public class ChildMedicalResarchPatientExCollection : TTObject.TTChildObjectCollection<MedicalResarchPatientEx>
        {
            public ChildMedicalResarchPatientExCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchPatientExCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MedicalResarchPatientExRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Donem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["TERMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Donemkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONEMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Donemadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONEMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHPATIENTEX"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public MedicalResarchPatientExRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MedicalResarchPatientExRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MedicalResarchPatientExRQ_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("1bd7725c-aaeb-41d2-bbe2-78f7cd52c3a0"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Complate { get { return new Guid("735b48fa-8884-460a-b510-35e0df63fecf"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("6d5d7f5a-19ac-4514-a085-d39f879fc13a"); } }
        }

        public static BindingList<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class> MedicalResarchPatientExRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHPATIENTEX"].QueryDefs["MedicalResarchPatientExRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class> MedicalResarchPatientExRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHPATIENTEX"].QueryDefs["MedicalResarchPatientExRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public MedicalResarch MedicalResarch
        {
            get { return (MedicalResarch)((ITTObject)this).GetParent("MEDICALRESARCH"); }
            set { this["MEDICALRESARCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _MedicalResarchPatientExProcedurs = new MedicalResarchPatientExPro.ChildMedicalResarchPatientExProCollection(_SubactionProcedures, "MedicalResarchPatientExProcedurs");
        }

        private MedicalResarchPatientExPro.ChildMedicalResarchPatientExProCollection _MedicalResarchPatientExProcedurs = null;
        public MedicalResarchPatientExPro.ChildMedicalResarchPatientExProCollection MedicalResarchPatientExProcedurs
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _MedicalResarchPatientExProcedurs;
            }            
        }

        protected MedicalResarchPatientEx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarchPatientEx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarchPatientEx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarchPatientEx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarchPatientEx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCHPATIENTEX", dataRow) { }
        protected MedicalResarchPatientEx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCHPATIENTEX", dataRow, isImported) { }
        public MedicalResarchPatientEx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarchPatientEx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarchPatientEx() : base() { }

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