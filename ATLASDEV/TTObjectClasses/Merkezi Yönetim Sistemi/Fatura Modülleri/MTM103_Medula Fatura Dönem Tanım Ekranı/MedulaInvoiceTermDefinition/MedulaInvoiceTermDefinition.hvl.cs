
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaInvoiceTermDefinition")] 

    /// <summary>
    /// Medula Fatura Dönem Tanım Ekranı
    /// </summary>
    public  partial class MedulaInvoiceTermDefinition : TerminologyManagerDef
    {
        public class MedulaInvoiceTermDefinitionList : TTObjectCollection<MedulaInvoiceTermDefinition> { }
                    
        public class ChildMedulaInvoiceTermDefinitionCollection : TTObject.TTChildObjectCollection<MedulaInvoiceTermDefinition>
        {
            public ChildMedulaInvoiceTermDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaInvoiceTermDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaInvoiceTermDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceTermDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceTermDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceTermDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaInvoiceTermDefs_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceTermDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceTermDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceTermDefs_Class() : base() { }
        }

        public static BindingList<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefinitions_Class> GetMedulaInvoiceTermDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].QueryDefs["GetMedulaInvoiceTermDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefinitions_Class> GetMedulaInvoiceTermDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].QueryDefs["GetMedulaInvoiceTermDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTermDefinition> GetTermByDate(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].QueryDefs["GetTermByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaInvoiceTermDefinition>(queryDef, paramList);
        }

        public static BindingList<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefs_Class> GetMedulaInvoiceTermDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].QueryDefs["GetMedulaInvoiceTermDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefs_Class> GetMedulaInvoiceTermDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICETERMDEFINITION"].QueryDefs["GetMedulaInvoiceTermDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaInvoiceTermDefinition.GetMedulaInvoiceTermDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Evrak Referans No
    /// </summary>
        public int? DocumentNo
        {
            get { return (int?)this["DOCUMENTNO"]; }
            set { this["DOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        virtual protected void CreateMedulaCutTransactionCollection()
        {
            _MedulaCutTransaction = new MedulaCutTransaction.ChildMedulaCutTransactionCollection(this, new Guid("c898d2bc-670e-489d-bcbd-06b59ab2f085"));
            ((ITTChildObjectCollection)_MedulaCutTransaction).GetChildren();
        }

        protected MedulaCutTransaction.ChildMedulaCutTransactionCollection _MedulaCutTransaction = null;
    /// <summary>
    /// Child collection for Medula Fatura Dönemi
    /// </summary>
        public MedulaCutTransaction.ChildMedulaCutTransactionCollection MedulaCutTransaction
        {
            get
            {
                if (_MedulaCutTransaction == null)
                    CreateMedulaCutTransactionCollection();
                return _MedulaCutTransaction;
            }
        }

        virtual protected void CreateMedulaParticipationPriceCollection()
        {
            _MedulaParticipationPrice = new MedulaParticipationPrice.ChildMedulaParticipationPriceCollection(this, new Guid("a0452c25-21eb-4803-9e9c-b4b8583ced5b"));
            ((ITTChildObjectCollection)_MedulaParticipationPrice).GetChildren();
        }

        protected MedulaParticipationPrice.ChildMedulaParticipationPriceCollection _MedulaParticipationPrice = null;
    /// <summary>
    /// Child collection for Medula Fatura Dönemi
    /// </summary>
        public MedulaParticipationPrice.ChildMedulaParticipationPriceCollection MedulaParticipationPrice
        {
            get
            {
                if (_MedulaParticipationPrice == null)
                    CreateMedulaParticipationPriceCollection();
                return _MedulaParticipationPrice;
            }
        }

        virtual protected void CreateMedulaProvisionInfoListCollection()
        {
            _MedulaProvisionInfoList = new MedulaProvisionInfoList.ChildMedulaProvisionInfoListCollection(this, new Guid("a688967f-a99d-431b-b831-1d0b168ee532"));
            ((ITTChildObjectCollection)_MedulaProvisionInfoList).GetChildren();
        }

        protected MedulaProvisionInfoList.ChildMedulaProvisionInfoListCollection _MedulaProvisionInfoList = null;
    /// <summary>
    /// Child collection for Medula Fatura Dönemi
    /// </summary>
        public MedulaProvisionInfoList.ChildMedulaProvisionInfoListCollection MedulaProvisionInfoList
        {
            get
            {
                if (_MedulaProvisionInfoList == null)
                    CreateMedulaProvisionInfoListCollection();
                return _MedulaProvisionInfoList;
            }
        }

        virtual protected void CreateMedulaInvoiceTermDetailsCollection()
        {
            _MedulaInvoiceTermDetails = new MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection(this, new Guid("1918e1d6-1415-4d27-a489-438a937f2b49"));
            ((ITTChildObjectCollection)_MedulaInvoiceTermDetails).GetChildren();
        }

        protected MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection _MedulaInvoiceTermDetails = null;
    /// <summary>
    /// Child collection for Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDetailDefinition.ChildMedulaInvoiceTermDetailDefinitionCollection MedulaInvoiceTermDetails
        {
            get
            {
                if (_MedulaInvoiceTermDetails == null)
                    CreateMedulaInvoiceTermDetailsCollection();
                return _MedulaInvoiceTermDetails;
            }
        }

        virtual protected void CreateMedulaSampledProvisionCollection()
        {
            _MedulaSampledProvision = new MedulaSampledProvision.ChildMedulaSampledProvisionCollection(this, new Guid("ff897b7d-3079-4a76-989b-152010fa747f"));
            ((ITTChildObjectCollection)_MedulaSampledProvision).GetChildren();
        }

        protected MedulaSampledProvision.ChildMedulaSampledProvisionCollection _MedulaSampledProvision = null;
    /// <summary>
    /// Child collection for Medula Fatura Dönemi
    /// </summary>
        public MedulaSampledProvision.ChildMedulaSampledProvisionCollection MedulaSampledProvision
        {
            get
            {
                if (_MedulaSampledProvision == null)
                    CreateMedulaSampledProvisionCollection();
                return _MedulaSampledProvision;
            }
        }

        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAINVOICETERMDEFINITION", dataRow) { }
        protected MedulaInvoiceTermDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAINVOICETERMDEFINITION", dataRow, isImported) { }
        public MedulaInvoiceTermDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaInvoiceTermDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaInvoiceTermDefinition() : base() { }

    }
}