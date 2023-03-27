
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationDetail")] 

    public  partial class ExaminationDetail : TTObject
    {
        public class ExaminationDetailList : TTObjectCollection<ExaminationDetail> { }
                    
        public class ChildExaminationDetailCollection : TTObject.TTChildObjectCollection<ExaminationDetail>
        {
            public ChildExaminationDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MuayeneRaporuSartnameMaddeleriNQL_Class : TTReportNqlObject 
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

            public bool? Confirmed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CONFIRMED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ClauseNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLAUSENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CLAUSENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExaminationValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["EXAMINATIONVALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ExaminationDetailTypeEnum? ExaminationDetailType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDETAILTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["EXAMINATIONDETAILTYPE"].DataType;
                    return (ExaminationDetailTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Clause
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLAUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CLAUSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MuayeneRaporuSartnameMaddeleriNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MuayeneRaporuSartnameMaddeleriNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MuayeneRaporuSartnameMaddeleriNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class FunctionTestReportNQL_Class : TTReportNqlObject 
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

            public bool? Confirmed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CONFIRMED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ClauseNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLAUSENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CLAUSENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExaminationValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["EXAMINATIONVALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ExaminationDetailTypeEnum? ExaminationDetailType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDETAILTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["EXAMINATIONDETAILTYPE"].DataType;
                    return (ExaminationDetailTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Clause
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLAUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].AllPropertyDefs["CLAUSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FunctionTestReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FunctionTestReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FunctionTestReportNQL_Class() : base() { }
        }

        public static BindingList<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class> MuayeneRaporuSartnameMaddeleriNQL(string EXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].QueryDefs["MuayeneRaporuSartnameMaddeleriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXAMINATIONOBJECTID", EXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class> MuayeneRaporuSartnameMaddeleriNQL(TTObjectContext objectContext, string EXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].QueryDefs["MuayeneRaporuSartnameMaddeleriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXAMINATIONOBJECTID", EXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationDetail.FunctionTestReportNQL_Class> FunctionTestReportNQL(string EXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].QueryDefs["FunctionTestReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXAMINATIONOBJECTID", EXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<ExaminationDetail.FunctionTestReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationDetail.FunctionTestReportNQL_Class> FunctionTestReportNQL(TTObjectContext objectContext, string EXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONDETAIL"].QueryDefs["FunctionTestReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXAMINATIONOBJECTID", EXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<ExaminationDetail.FunctionTestReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uygundur
    /// </summary>
        public bool? Confirmed
        {
            get { return (bool?)this["CONFIRMED"]; }
            set { this["CONFIRMED"] = value; }
        }

    /// <summary>
    /// Madde No
    /// </summary>
        public string ClauseNo
        {
            get { return (string)this["CLAUSENO"]; }
            set { this["CLAUSENO"] = value; }
        }

    /// <summary>
    /// Bulunan Değer
    /// </summary>
        public string ExaminationValue
        {
            get { return (string)this["EXAMINATIONVALUE"]; }
            set { this["EXAMINATIONVALUE"] = value; }
        }

    /// <summary>
    /// Muayene Tipi
    /// </summary>
        public ExaminationDetailTypeEnum? ExaminationDetailType
        {
            get { return (ExaminationDetailTypeEnum?)(int?)this["EXAMINATIONDETAILTYPE"]; }
            set { this["EXAMINATIONDETAILTYPE"] = value; }
        }

    /// <summary>
    /// Madde
    /// </summary>
        public string Clause
        {
            get { return (string)this["CLAUSE"]; }
            set { this["CLAUSE"] = value; }
        }

        public PurchaseExaminationDetail PurchaseExaminationDetail
        {
            get { return (PurchaseExaminationDetail)((ITTObject)this).GetParent("PURCHASEEXAMINATIONDETAIL"); }
            set { this["PURCHASEEXAMINATIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONDETAIL", dataRow) { }
        protected ExaminationDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONDETAIL", dataRow, isImported) { }
        public ExaminationDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationDetail() : base() { }

    }
}