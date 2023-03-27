
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceInclusionMaster")] 

    /// <summary>
    /// Fatura Dahillik Tanımları
    /// </summary>
    public  partial class InvoiceInclusionMaster : TTDefinitionSet
    {
        public class InvoiceInclusionMasterList : TTObjectCollection<InvoiceInclusionMaster> { }
                    
        public class ChildInvoiceInclusionMasterCollection : TTObject.TTChildObjectCollection<InvoiceInclusionMaster>
        {
            public ChildInvoiceInclusionMasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceInclusionMasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceInclusionMaster_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? FirstDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].AllPropertyDefs["FIRSTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].AllPropertyDefs["LASTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceInclusionMaster_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceInclusionMaster_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceInclusionMaster_Class() : base() { }
        }

        public static BindingList<InvoiceInclusionMaster> GetBySpecialityAndProtocol(TTObjectContext objectContext, Guid PROTOCOL, Guid SPECIALITY, string ILKBAGLITAKIP, string AYNIFARKLIBRANS, string PROVIZYONTIPI, string TAKIPTIPI, string TEDAVITIPI, string TEDAVITURU, bool TRIAJCONTROL, string TRIAJ, string ISTISNAIHAL, bool ISTISNAIHALCONTROL, string PAKETDURUM, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].QueryDefs["GetBySpecialityAndProtocol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOL", PROTOCOL);
            paramList.Add("SPECIALITY", SPECIALITY);
            paramList.Add("ILKBAGLITAKIP", ILKBAGLITAKIP);
            paramList.Add("AYNIFARKLIBRANS", AYNIFARKLIBRANS);
            paramList.Add("PROVIZYONTIPI", PROVIZYONTIPI);
            paramList.Add("TAKIPTIPI", TAKIPTIPI);
            paramList.Add("TEDAVITIPI", TEDAVITIPI);
            paramList.Add("TEDAVITURU", TEDAVITURU);
            paramList.Add("TRIAJCONTROL", TRIAJCONTROL);
            paramList.Add("TRIAJ", TRIAJ);
            paramList.Add("ISTISNAIHAL", ISTISNAIHAL);
            paramList.Add("ISTISNAIHALCONTROL", ISTISNAIHALCONTROL);
            paramList.Add("PAKETDURUM", PAKETDURUM);
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceInclusionMaster>(queryDef, paramList);
        }

        public static BindingList<InvoiceInclusionMaster> GetBySpecialityAndProtocolTEMP(TTObjectContext objectContext, string AYNIFARKLIBRANS, DateTime DATE, string ILKBAGLITAKIP, string PAKETDURUM, Guid PROTOCOL, Guid SPECIALITY, string TEDAVITURU, string TRIAJ, bool TRIAJCONTROL, string TEDAVITIPI)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].QueryDefs["GetBySpecialityAndProtocolTEMP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("AYNIFARKLIBRANS", AYNIFARKLIBRANS);
            paramList.Add("DATE", DATE);
            paramList.Add("ILKBAGLITAKIP", ILKBAGLITAKIP);
            paramList.Add("PAKETDURUM", PAKETDURUM);
            paramList.Add("PROTOCOL", PROTOCOL);
            paramList.Add("SPECIALITY", SPECIALITY);
            paramList.Add("TEDAVITURU", TEDAVITURU);
            paramList.Add("TRIAJ", TRIAJ);
            paramList.Add("TRIAJCONTROL", TRIAJCONTROL);
            paramList.Add("TEDAVITIPI", TEDAVITIPI);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceInclusionMaster>(queryDef, paramList);
        }

        public static BindingList<InvoiceInclusionMaster.GetInvoiceInclusionMaster_Class> GetInvoiceInclusionMaster(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].QueryDefs["GetInvoiceInclusionMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionMaster.GetInvoiceInclusionMaster_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceInclusionMaster.GetInvoiceInclusionMaster_Class> GetInvoiceInclusionMaster(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONMASTER"].QueryDefs["GetInvoiceInclusionMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionMaster.GetInvoiceInclusionMaster_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kural Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Geçerlilik Başlama Tarihi
    /// </summary>
        public DateTime? FirstDate
        {
            get { return (DateTime?)this["FIRSTDATE"]; }
            set { this["FIRSTDATE"] = value; }
        }

    /// <summary>
    /// Geçerlilik Bitiş Tarihi
    /// </summary>
        public DateTime? LastDate
        {
            get { return (DateTime?)this["LASTDATE"]; }
            set { this["LASTDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateIIMDetailsCollection()
        {
            _IIMDetails = new IIMDetail.ChildIIMDetailCollection(this, new Guid("cda6355b-bbbe-4dd2-8701-ebc263b6e46a"));
            ((ITTChildObjectCollection)_IIMDetails).GetChildren();
        }

        protected IIMDetail.ChildIIMDetailCollection _IIMDetails = null;
    /// <summary>
    /// Child collection for Kural Detay Bilgisi
    /// </summary>
        public IIMDetail.ChildIIMDetailCollection IIMDetails
        {
            get
            {
                if (_IIMDetails == null)
                    CreateIIMDetailsCollection();
                return _IIMDetails;
            }
        }

        virtual protected void CreateIIMProtocolsCollection()
        {
            _IIMProtocols = new IIMProtocol.ChildIIMProtocolCollection(this, new Guid("01f6a650-8d60-4911-90d2-56ea53c9d413"));
            ((ITTChildObjectCollection)_IIMProtocols).GetChildren();
        }

        protected IIMProtocol.ChildIIMProtocolCollection _IIMProtocols = null;
    /// <summary>
    /// Child collection for Kural Protokol bilgisi
    /// </summary>
        public IIMProtocol.ChildIIMProtocolCollection IIMProtocols
        {
            get
            {
                if (_IIMProtocols == null)
                    CreateIIMProtocolsCollection();
                return _IIMProtocols;
            }
        }

        virtual protected void CreateIIMSpecialitiesCollection()
        {
            _IIMSpecialities = new IIMSpeciality.ChildIIMSpecialityCollection(this, new Guid("799d4d20-2f07-4b88-ab66-eaf2f59bf6f7"));
            ((ITTChildObjectCollection)_IIMSpecialities).GetChildren();
        }

        protected IIMSpeciality.ChildIIMSpecialityCollection _IIMSpecialities = null;
    /// <summary>
    /// Child collection for Kural Branş bilgisi
    /// </summary>
        public IIMSpeciality.ChildIIMSpecialityCollection IIMSpecialities
        {
            get
            {
                if (_IIMSpecialities == null)
                    CreateIIMSpecialitiesCollection();
                return _IIMSpecialities;
            }
        }

        virtual protected void CreateIIMNQLProcedureMaterialsCollection()
        {
            _IIMNQLProcedureMaterials = new IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection(this, new Guid("363c5fb3-aa37-4477-b6b6-4749904e1d51"));
            ((ITTChildObjectCollection)_IIMNQLProcedureMaterials).GetChildren();
        }

        protected IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection _IIMNQLProcedureMaterials = null;
    /// <summary>
    /// Child collection for Kural Bilgisi
    /// </summary>
        public IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection IIMNQLProcedureMaterials
        {
            get
            {
                if (_IIMNQLProcedureMaterials == null)
                    CreateIIMNQLProcedureMaterialsCollection();
                return _IIMNQLProcedureMaterials;
            }
        }

        protected InvoiceInclusionMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceInclusionMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceInclusionMaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceInclusionMaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceInclusionMaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEINCLUSIONMASTER", dataRow) { }
        protected InvoiceInclusionMaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEINCLUSIONMASTER", dataRow, isImported) { }
        public InvoiceInclusionMaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceInclusionMaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceInclusionMaster() : base() { }

    }
}