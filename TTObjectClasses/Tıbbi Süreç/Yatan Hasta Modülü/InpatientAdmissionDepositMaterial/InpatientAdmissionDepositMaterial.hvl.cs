
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmissionDepositMaterial")] 

    public  partial class InpatientAdmissionDepositMaterial : TTObject
    {
        public class InpatientAdmissionDepositMaterialList : TTObjectCollection<InpatientAdmissionDepositMaterial> { }
                    
        public class ChildInpatientAdmissionDepositMaterialCollection : TTObject.TTChildObjectCollection<InpatientAdmissionDepositMaterial>
        {
            public ChildInpatientAdmissionDepositMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionDepositMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class InpatientAdmissionDepositMaterialFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONDEPOSITMATERIAL"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public QuarantineProcessTypeEnum? Processtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONDEPOSITMATERIAL"].AllPropertyDefs["QUARANTINEPROCESSTYPE"].DataType;
                    return (QuarantineProcessTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONDEPOSITMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Processuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InpatientAdmissionDepositMaterialFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InpatientAdmissionDepositMaterialFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InpatientAdmissionDepositMaterialFormList_Class() : base() { }
        }

        public static BindingList<InpatientAdmissionDepositMaterial.InpatientAdmissionDepositMaterialFormList_Class> InpatientAdmissionDepositMaterialFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONDEPOSITMATERIAL"].QueryDefs["InpatientAdmissionDepositMaterialFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionDepositMaterial.InpatientAdmissionDepositMaterialFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionDepositMaterial.InpatientAdmissionDepositMaterialFormList_Class> InpatientAdmissionDepositMaterialFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONDEPOSITMATERIAL"].QueryDefs["InpatientAdmissionDepositMaterialFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionDepositMaterial.InpatientAdmissionDepositMaterialFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Karantina işlem Türü
    /// </summary>
        public QuarantineProcessTypeEnum? QuarantineProcessType
        {
            get { return (QuarantineProcessTypeEnum?)(int?)this["QUARANTINEPROCESSTYPE"]; }
            set { this["QUARANTINEPROCESSTYPE"] = value; }
        }

    /// <summary>
    /// Emanet Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

        public ResUser ProcessUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCESSUSER"); }
            set { this["PROCESSUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSIONDEPOSITMATERIAL", dataRow) { }
        protected InpatientAdmissionDepositMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSIONDEPOSITMATERIAL", dataRow, isImported) { }
        public InpatientAdmissionDepositMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmissionDepositMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmissionDepositMaterial() : base() { }

    }
}