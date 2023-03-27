
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryResultNotificationInfo")] 

    public  partial class LaboratoryResultNotificationInfo : TTObject
    {
        public class LaboratoryResultNotificationInfoList : TTObjectCollection<LaboratoryResultNotificationInfo> { }
                    
        public class ChildLaboratoryResultNotificationInfoCollection : TTObject.TTChildObjectCollection<LaboratoryResultNotificationInfo>
        {
            public ChildLaboratoryResultNotificationInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryResultNotificationInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPanicNotificationInfo_Class : TTReportNqlObject 
        {
            public Guid? Infoobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INFOOBJECTID"]);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYRESULTNOTIFICATIONINFO"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPanicNotificationInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPanicNotificationInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPanicNotificationInfo_Class() : base() { }
        }

        public static BindingList<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class> GetPanicNotificationInfo(Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYRESULTNOTIFICATIONINFO"].QueryDefs["GetPanicNotificationInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class> GetPanicNotificationInfo(TTObjectContext objectContext, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYRESULTNOTIFICATIONINFO"].QueryDefs["GetPanicNotificationInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bildirimin görülüp görülmediği bilgisi
    /// </summary>
        public bool? IsSeen
        {
            get { return (bool?)this["ISSEEN"]; }
            set { this["ISSEEN"] = value; }
        }

        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// İstem Yapan Doktor ID
    /// </summary>
        public Guid? RequestDoctorID
        {
            get { return (Guid?)this["REQUESTDOCTORID"]; }
            set { this["REQUESTDOCTORID"] = value; }
        }

    /// <summary>
    /// Bildirim Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Panic Değer sonucu olan tetkik bilgisi
    /// </summary>
        public LaboratoryProcedure LaboratoryProcedure
        {
            get { return (LaboratoryProcedure)((ITTObject)this).GetParent("LABORATORYPROCEDURE"); }
            set { this["LABORATORYPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Panik değer sonucu olan alt tetkik bilgisi
    /// </summary>
        public LaboratorySubProcedure LaboratorySubProcedure
        {
            get { return (LaboratorySubProcedure)((ITTObject)this).GetParent("LABORATORYSUBPROCEDURE"); }
            set { this["LABORATORYSUBPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYRESULTNOTIFICATIONINFO", dataRow) { }
        protected LaboratoryResultNotificationInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYRESULTNOTIFICATIONINFO", dataRow, isImported) { }
        public LaboratoryResultNotificationInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryResultNotificationInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryResultNotificationInfo() : base() { }

    }
}