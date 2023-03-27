
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaniyaBagliSMSGonderim")] 

    /// <summary>
    /// Seçilen tanılar için seçilen kullanıcılara SMS göndermek için
    /// </summary>
    public  partial class TaniyaBagliSMSGonderim : TerminologyManagerDef
    {
        public class TaniyaBagliSMSGonderimList : TTObjectCollection<TaniyaBagliSMSGonderim> { }
                    
        public class ChildTaniyaBagliSMSGonderimCollection : TTObject.TTChildObjectCollection<TaniyaBagliSMSGonderim>
        {
            public ChildTaniyaBagliSMSGonderimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaniyaBagliSMSGonderimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class TaniyaBagliSMSGonderimNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Diagnosisname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosiscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Inpatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TANIYABAGLISMSGONDERIM"].AllPropertyDefs["INPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Outpatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TANIYABAGLISMSGONDERIM"].AllPropertyDefs["OUTPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public TaniyaBagliSMSGonderimNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TaniyaBagliSMSGonderimNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TaniyaBagliSMSGonderimNQL_Class() : base() { }
        }

        public static BindingList<TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class> TaniyaBagliSMSGonderimNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TANIYABAGLISMSGONDERIM"].QueryDefs["TaniyaBagliSMSGonderimNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class> TaniyaBagliSMSGonderimNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TANIYABAGLISMSGONDERIM"].QueryDefs["TaniyaBagliSMSGonderimNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaniyaBagliSMSGonderim.TaniyaBagliSMSGonderimNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TaniyaBagliSMSGonderim> GetDataForTaniyaBagliSMS(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TANIYABAGLISMSGONDERIM"].QueryDefs["GetDataForTaniyaBagliSMS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TaniyaBagliSMSGonderim>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Ayaktan Hastalar İçin Girilmiş Tanılar
    /// </summary>
        public bool? Outpatient
        {
            get { return (bool?)this["OUTPATIENT"]; }
            set { this["OUTPATIENT"] = value; }
        }

    /// <summary>
    /// Yatan Hastalar İçin Girilmiş Tanılar
    /// </summary>
        public bool? Inpatient
        {
            get { return (bool?)this["INPATIENT"]; }
            set { this["INPATIENT"] = value; }
        }

    /// <summary>
    /// SMS Gönderilecek Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TANIYABAGLISMSGONDERIM", dataRow) { }
        protected TaniyaBagliSMSGonderim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TANIYABAGLISMSGONDERIM", dataRow, isImported) { }
        public TaniyaBagliSMSGonderim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaniyaBagliSMSGonderim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaniyaBagliSMSGonderim() : base() { }

    }
}