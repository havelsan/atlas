
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalPharmacy")] 

    /// <summary>
    /// Dış Eczane 
    /// </summary>
    public  partial class ExternalPharmacy : TTDefinitionSet
    {
        public class ExternalPharmacyList : TTObjectCollection<ExternalPharmacy> { }
                    
        public class ChildExternalPharmacyCollection : TTObject.TTChildObjectCollection<ExternalPharmacy>
        {
            public ChildExternalPharmacyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalPharmacyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExternalPharmacy_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public ExternalPharmacyStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["STATUS"].DataType;
                    return (ExternalPharmacyStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telephone1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEPHONE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["TELEPHONE1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telephone2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEPHONE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["TELEPHONE2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fax
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["FAX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AuthorizedPerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTHORIZEDPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["AUTHORIZEDPERSON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetExternalPharmacy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExternalPharmacy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExternalPharmacy_Class() : base() { }
        }

        public static BindingList<ExternalPharmacy.GetExternalPharmacy_Class> GetExternalPharmacy(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].QueryDefs["GetExternalPharmacy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalPharmacy.GetExternalPharmacy_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalPharmacy.GetExternalPharmacy_Class> GetExternalPharmacy(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].QueryDefs["GetExternalPharmacy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalPharmacy.GetExternalPharmacy_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalPharmacy> GetExternalPharmacys(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].QueryDefs["GetExternalPharmacys"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ExternalPharmacy>(queryDef, paramList);
        }

        public string Telephone2
        {
            get { return (string)this["TELEPHONE2"]; }
            set { this["TELEPHONE2"] = value; }
        }

    /// <summary>
    /// Açılış Zamanı
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

        public string Telephone1
        {
            get { return (string)this["TELEPHONE1"]; }
            set { this["TELEPHONE1"] = value; }
        }

        public string AuthorizedPerson
        {
            get { return (string)this["AUTHORIZEDPERSON"]; }
            set { this["AUTHORIZEDPERSON"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

        public string Fax
        {
            get { return (string)this["FAX"]; }
            set { this["FAX"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public ExternalPharmacyStatusEnum? Status
        {
            get { return (ExternalPharmacyStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreatePrescriptionTransactionsCollection()
        {
            _PrescriptionTransactions = new ExternalPharmacyPrescriptionTransaction.ChildExternalPharmacyPrescriptionTransactionCollection(this, new Guid("1a320f28-d221-4ccc-ab40-03dfb7e0f6b5"));
            ((ITTChildObjectCollection)_PrescriptionTransactions).GetChildren();
        }

        protected ExternalPharmacyPrescriptionTransaction.ChildExternalPharmacyPrescriptionTransactionCollection _PrescriptionTransactions = null;
        public ExternalPharmacyPrescriptionTransaction.ChildExternalPharmacyPrescriptionTransactionCollection PrescriptionTransactions
        {
            get
            {
                if (_PrescriptionTransactions == null)
                    CreatePrescriptionTransactionsCollection();
                return _PrescriptionTransactions;
            }
        }

        virtual protected void CreateExternalPharmacyStatusesCollection()
        {
            _ExternalPharmacyStatuses = new ExternalPharmacyStatus.ChildExternalPharmacyStatusCollection(this, new Guid("1cf6121e-ca59-4fea-91cf-43214745b7cf"));
            ((ITTChildObjectCollection)_ExternalPharmacyStatuses).GetChildren();
        }

        protected ExternalPharmacyStatus.ChildExternalPharmacyStatusCollection _ExternalPharmacyStatuses = null;
        public ExternalPharmacyStatus.ChildExternalPharmacyStatusCollection ExternalPharmacyStatuses
        {
            get
            {
                if (_ExternalPharmacyStatuses == null)
                    CreateExternalPharmacyStatusesCollection();
                return _ExternalPharmacyStatuses;
            }
        }

        protected ExternalPharmacy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalPharmacy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalPharmacy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalPharmacy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalPharmacy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPHARMACY", dataRow) { }
        protected ExternalPharmacy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPHARMACY", dataRow, isImported) { }
        public ExternalPharmacy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalPharmacy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalPharmacy() : base() { }

    }
}