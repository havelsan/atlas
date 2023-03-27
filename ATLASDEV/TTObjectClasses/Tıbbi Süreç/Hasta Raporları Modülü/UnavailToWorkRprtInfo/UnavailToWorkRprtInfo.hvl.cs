
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnavailToWorkRprtInfo")] 

    /// <summary>
    /// İş Görememezlik Belgeleri
    /// </summary>
    public  partial class UnavailToWorkRprtInfo : TTObject
    {
        public class UnavailToWorkRprtInfoList : TTObjectCollection<UnavailToWorkRprtInfo> { }
                    
        public class ChildUnavailToWorkRprtInfoCollection : TTObject.TTChildObjectCollection<UnavailToWorkRprtInfo>
        {
            public ChildUnavailToWorkRprtInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnavailToWorkRprtInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnavailToWorkRptInfoQuery_Class : TTReportNqlObject 
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

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedulaChasingNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULACHASINGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["MEDULACHASINGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportSeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTSEQNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Excuse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXCUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["EXCUSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportRowNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTROWNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTROWNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ReportDeleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDELETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTDELETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["RESTINGSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["RESTINGENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetUnavailToWorkRptInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnavailToWorkRptInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnavailToWorkRptInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUndeletedUnavailToWorkRptInfo_Class : TTReportNqlObject 
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

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedulaChasingNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULACHASINGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["MEDULACHASINGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportSeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTSEQNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Excuse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXCUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["EXCUSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportRowNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTROWNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTROWNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ReportDeleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDELETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["REPORTDELETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["RESTINGSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].AllPropertyDefs["RESTINGENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetUndeletedUnavailToWorkRptInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUndeletedUnavailToWorkRptInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUndeletedUnavailToWorkRptInfo_Class() : base() { }
        }

        public static BindingList<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class> GetUnavailToWorkRptInfoQuery(long UNIQUEREFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].QueryDefs["GetUnavailToWorkRptInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return TTReportNqlObject.QueryObjects<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class> GetUnavailToWorkRptInfoQuery(TTObjectContext objectContext, long UNIQUEREFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].QueryDefs["GetUnavailToWorkRptInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return TTReportNqlObject.QueryObjects<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class> GetUndeletedUnavailToWorkRptInfo(long UNIQUEREFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].QueryDefs["GetUndeletedUnavailToWorkRptInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return TTReportNqlObject.QueryObjects<UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class> GetUndeletedUnavailToWorkRptInfo(TTObjectContext objectContext, long UNIQUEREFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNAVAILTOWORKRPRTINFO"].QueryDefs["GetUndeletedUnavailToWorkRptInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return TTReportNqlObject.QueryObjects<UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// T.C. Kimlik No
    /// </summary>
        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// Rapor Takip Numarası
    /// </summary>
        public string MedulaChasingNo
        {
            get { return (string)this["MEDULACHASINGNO"]; }
            set { this["MEDULACHASINGNO"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public string ReportSeqNo
        {
            get { return (string)this["REPORTSEQNO"]; }
            set { this["REPORTSEQNO"] = value; }
        }

    /// <summary>
    /// Mazeret
    /// </summary>
        public string Excuse
        {
            get { return (string)this["EXCUSE"]; }
            set { this["EXCUSE"] = value; }
        }

    /// <summary>
    /// Rapor Sıra Numarası
    /// </summary>
        public string ReportRowNumber
        {
            get { return (string)this["REPORTROWNUMBER"]; }
            set { this["REPORTROWNUMBER"] = value; }
        }

    /// <summary>
    /// Rapor Silindi
    /// </summary>
        public bool? ReportDeleted
        {
            get { return (bool?)this["REPORTDELETED"]; }
            set { this["REPORTDELETED"] = value; }
        }

    /// <summary>
    /// İstirahat Başlangıç Tarihi
    /// </summary>
        public DateTime? RestingStartDate
        {
            get { return (DateTime?)this["RESTINGSTARTDATE"]; }
            set { this["RESTINGSTARTDATE"] = value; }
        }

    /// <summary>
    /// İstirahat Bitiş Tarihi
    /// </summary>
        public DateTime? RestingEndDate
        {
            get { return (DateTime?)this["RESTINGENDDATE"]; }
            set { this["RESTINGENDDATE"] = value; }
        }

        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNAVAILTOWORKRPRTINFO", dataRow) { }
        protected UnavailToWorkRprtInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNAVAILTOWORKRPRTINFO", dataRow, isImported) { }
        public UnavailToWorkRprtInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnavailToWorkRprtInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnavailToWorkRprtInfo() : base() { }

    }
}