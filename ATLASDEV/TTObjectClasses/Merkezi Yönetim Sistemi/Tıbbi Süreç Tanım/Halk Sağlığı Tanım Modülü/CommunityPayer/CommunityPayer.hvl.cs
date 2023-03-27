
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityPayer")] 

    /// <summary>
    /// Halk Sağlığı Kurum Tanımları
    /// </summary>
    public  partial class CommunityPayer : TTDefinitionSet
    {
        public class CommunityPayerList : TTObjectCollection<CommunityPayer> { }
                    
        public class ChildCommunityPayerCollection : TTObject.TTChildObjectCollection<CommunityPayer>
        {
            public ChildCommunityPayerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityPayerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCommunityPayerList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYPAYER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommunityPayerList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommunityPayerList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommunityPayerList_Class() : base() { }
        }

        public static BindingList<CommunityPayer.GetCommunityPayerList_Class> GetCommunityPayerList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYPAYER"].QueryDefs["GetCommunityPayerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityPayer.GetCommunityPayerList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommunityPayer.GetCommunityPayerList_Class> GetCommunityPayerList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYPAYER"].QueryDefs["GetCommunityPayerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityPayer.GetCommunityPayerList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Adress
        {
            get { return (string)this["ADRESS"]; }
            set { this["ADRESS"] = value; }
        }

        public string TaxNumber
        {
            get { return (string)this["TAXNUMBER"]; }
            set { this["TAXNUMBER"] = value; }
        }

        public string TaxOffice
        {
            get { return (string)this["TAXOFFICE"]; }
            set { this["TAXOFFICE"] = value; }
        }

        virtual protected void CreateGeneralInvoiceCollection()
        {
            _GeneralInvoice = new GeneralInvoice.ChildGeneralInvoiceCollection(this, new Guid("c727f506-2b49-4ec0-aa2c-0562238b9c86"));
            ((ITTChildObjectCollection)_GeneralInvoice).GetChildren();
        }

        protected GeneralInvoice.ChildGeneralInvoiceCollection _GeneralInvoice = null;
        public GeneralInvoice.ChildGeneralInvoiceCollection GeneralInvoice
        {
            get
            {
                if (_GeneralInvoice == null)
                    CreateGeneralInvoiceCollection();
                return _GeneralInvoice;
            }
        }

        protected CommunityPayer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityPayer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityPayer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityPayer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityPayer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYPAYER", dataRow) { }
        protected CommunityPayer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYPAYER", dataRow, isImported) { }
        public CommunityPayer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityPayer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityPayer() : base() { }

    }
}