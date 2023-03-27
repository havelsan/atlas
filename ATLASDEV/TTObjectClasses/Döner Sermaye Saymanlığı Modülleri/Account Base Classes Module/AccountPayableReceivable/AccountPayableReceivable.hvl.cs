
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountPayableReceivable")] 

    /// <summary>
    /// Hasta, kurum ve kullanıcıların balanslarını tutar
    /// </summary>
    public  partial class AccountPayableReceivable : TTObject
    {
        public class AccountPayableReceivableList : TTObjectCollection<AccountPayableReceivable> { }
                    
        public class ChildAccountPayableReceivableCollection : TTObject.TTChildObjectCollection<AccountPayableReceivable>
        {
            public ChildAccountPayableReceivableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountPayableReceivableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAPRByPatient_Class : TTReportNqlObject 
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

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Balance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BALANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["BALANCE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetAPRByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAPRByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAPRByPatient_Class() : base() { }
        }

        public static BindingList<AccountPayableReceivable> GetAPRByResUser(TTObjectContext objectContext, string PARAMRESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].QueryDefs["GetAPRByResUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESUSER", PARAMRESUSER);

            return ((ITTQuery)objectContext).QueryObjects<AccountPayableReceivable>(queryDef, paramList);
        }

        public static BindingList<AccountPayableReceivable.GetAPRByPatient_Class> GetAPRByPatient(string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].QueryDefs["GetAPRByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<AccountPayableReceivable.GetAPRByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountPayableReceivable.GetAPRByPatient_Class> GetAPRByPatient(TTObjectContext objectContext, string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].QueryDefs["GetAPRByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<AccountPayableReceivable.GetAPRByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tip
    /// </summary>
        public APRTypeEnum? Type
        {
            get { return (APRTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// İsim
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Balans
    /// </summary>
        public Currency? Balance
        {
            get { return (Currency?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// Hasta ile ilişki
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı ile ilişki
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum ile ilişki
    /// </summary>
        public PayerDefinition PayerDefinition
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYERDEFINITION"); }
            set { this["PAYERDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAPRTrxsCollection()
        {
            _APRTrxs = new APRTrx.ChildAPRTrxCollection(this, new Guid("3e2d4939-4d8c-4383-970c-49f9f0bbb492"));
            ((ITTChildObjectCollection)_APRTrxs).GetChildren();
        }

        protected APRTrx.ChildAPRTrxCollection _APRTrxs = null;
    /// <summary>
    /// Child collection for AccountPayableReceivable ile relation
    /// </summary>
        public APRTrx.ChildAPRTrxCollection APRTrxs
        {
            get
            {
                if (_APRTrxs == null)
                    CreateAPRTrxsCollection();
                return _APRTrxs;
            }
        }

        protected AccountPayableReceivable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountPayableReceivable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountPayableReceivable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountPayableReceivable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountPayableReceivable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTPAYABLERECEIVABLE", dataRow) { }
        protected AccountPayableReceivable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTPAYABLERECEIVABLE", dataRow, isImported) { }
        public AccountPayableReceivable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountPayableReceivable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountPayableReceivable() : base() { }

    }
}