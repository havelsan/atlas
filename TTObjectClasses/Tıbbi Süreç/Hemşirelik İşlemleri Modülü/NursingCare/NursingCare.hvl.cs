
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingCare")] 

    /// <summary>
    /// NursingNanda
    /// </summary>
    public  partial class NursingCare : BaseNursingDataEntry
    {
        public class NursingCareList : TTObjectCollection<NursingCare> { }
                    
        public class ChildNursingCareCollection : TTObject.TTChildObjectCollection<NursingCare>
        {
            public ChildNursingCareCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingCareCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingCaresByNursingApplication_Class : TTReportNqlObject 
        {
            public DateTime? EntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGCARE"].AllPropertyDefs["ENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGCARE"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string User
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingCaresByNursingApplication_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingCaresByNursingApplication_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingCaresByNursingApplication_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingCare.GetNursingCaresByNursingApplication_Class> GetNursingCaresByNursingApplication(string NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCARE"].QueryDefs["GetNursingCaresByNursingApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingCare.GetNursingCaresByNursingApplication_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingCare.GetNursingCaresByNursingApplication_Class> GetNursingCaresByNursingApplication(TTObjectContext objectContext, string NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCARE"].QueryDefs["GetNursingCaresByNursingApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingCare.GetNursingCaresByNursingApplication_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        public NursingCareResultEnum? NursingResult
        {
            get { return (NursingCareResultEnum?)(int?)this["NURSINGRESULT"]; }
            set { this["NURSINGRESULT"] = value; }
        }

    /// <summary>
    /// Hemşirelik Problemi
    /// </summary>
        public NursingProblemDefinition NursingProblem
        {
            get { return (NursingProblemDefinition)((ITTObject)this).GetParent("NURSINGPROBLEM"); }
            set { this["NURSINGPROBLEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingReasonGridsCollection()
        {
            _NursingReasonGrids = new NursingReasonGrid.ChildNursingReasonGridCollection(this, new Guid("86e13cba-d579-4927-864a-8b06068584f3"));
            ((ITTChildObjectCollection)_NursingReasonGrids).GetChildren();
        }

        protected NursingReasonGrid.ChildNursingReasonGridCollection _NursingReasonGrids = null;
        public NursingReasonGrid.ChildNursingReasonGridCollection NursingReasonGrids
        {
            get
            {
                if (_NursingReasonGrids == null)
                    CreateNursingReasonGridsCollection();
                return _NursingReasonGrids;
            }
        }

        virtual protected void CreateNursingCareGridsCollection()
        {
            _NursingCareGrids = new NursingCareGrid.ChildNursingCareGridCollection(this, new Guid("c82f2f6e-2710-4fcb-bf87-e9d2efd039fa"));
            ((ITTChildObjectCollection)_NursingCareGrids).GetChildren();
        }

        protected NursingCareGrid.ChildNursingCareGridCollection _NursingCareGrids = null;
        public NursingCareGrid.ChildNursingCareGridCollection NursingCareGrids
        {
            get
            {
                if (_NursingCareGrids == null)
                    CreateNursingCareGridsCollection();
                return _NursingCareGrids;
            }
        }

        virtual protected void CreateNursingTargetGridsCollection()
        {
            _NursingTargetGrids = new NursingTargetGrid.ChildNursingTargetGridCollection(this, new Guid("5b881880-2f5e-4066-a331-5da917ef6b80"));
            ((ITTChildObjectCollection)_NursingTargetGrids).GetChildren();
        }

        protected NursingTargetGrid.ChildNursingTargetGridCollection _NursingTargetGrids = null;
        public NursingTargetGrid.ChildNursingTargetGridCollection NursingTargetGrids
        {
            get
            {
                if (_NursingTargetGrids == null)
                    CreateNursingTargetGridsCollection();
                return _NursingTargetGrids;
            }
        }

        protected NursingCare(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingCare(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingCare(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingCare(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingCare(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGCARE", dataRow) { }
        protected NursingCare(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGCARE", dataRow, isImported) { }
        public NursingCare(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingCare(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingCare() : base() { }

    }
}