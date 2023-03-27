
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceBlocking")] 

    /// <summary>
    /// Fatura Engelleri
    /// </summary>
    public  partial class InvoiceBlocking : TTObject
    {
        public class InvoiceBlockingList : TTObjectCollection<InvoiceBlocking> { }
                    
        public class ChildInvoiceBlockingCollection : TTObject.TTChildObjectCollection<InvoiceBlocking>
        {
            public ChildInvoiceBlockingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceBlockingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceBlocking_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? BlockDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["BLOCKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string BlockDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["BLOCKDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Blocktype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BLOCKTYPE"]);
                }
            }

            public Guid? Blockuserobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BLOCKUSEROBJECTID"]);
                }
            }

            public string Blockusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? UnblockDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNBLOCKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["UNBLOCKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string UnblockDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNBLOCKDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["UNBLOCKDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Unblockuserobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UNBLOCKUSEROBJECTID"]);
                }
            }

            public string Unblockusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNBLOCKUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ModuleName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODULENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["MODULENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceBlocking_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceBlocking_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceBlocking_Class() : base() { }
        }

        public static BindingList<InvoiceBlocking.GetInvoiceBlocking_Class> GetInvoiceBlocking(IList<Guid> EPISODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].QueryDefs["GetInvoiceBlocking"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODES", EPISODES);

            return TTReportNqlObject.QueryObjects<InvoiceBlocking.GetInvoiceBlocking_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceBlocking.GetInvoiceBlocking_Class> GetInvoiceBlocking(TTObjectContext objectContext, IList<Guid> EPISODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKING"].QueryDefs["GetInvoiceBlocking"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODES", EPISODES);

            return TTReportNqlObject.QueryObjects<InvoiceBlocking.GetInvoiceBlocking_Class>(objectContext, queryDef, paramList, pi);
        }

        public DateTime? BlockDate
        {
            get { return (DateTime?)this["BLOCKDATE"]; }
            set { this["BLOCKDATE"] = value; }
        }

        public string BlockDescription
        {
            get { return (string)this["BLOCKDESCRIPTION"]; }
            set { this["BLOCKDESCRIPTION"] = value; }
        }

        public DateTime? UnblockDate
        {
            get { return (DateTime?)this["UNBLOCKDATE"]; }
            set { this["UNBLOCKDATE"] = value; }
        }

        public string UnblockDescription
        {
            get { return (string)this["UNBLOCKDESCRIPTION"]; }
            set { this["UNBLOCKDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        public InvoiceBlockingTypeEnum? BlockingType
        {
            get { return (InvoiceBlockingTypeEnum?)(int?)this["BLOCKINGTYPE"]; }
            set { this["BLOCKINGTYPE"] = value; }
        }

    /// <summary>
    /// Modül İsmi
    /// </summary>
        public string ModuleName
        {
            get { return (string)this["MODULENAME"]; }
            set { this["MODULENAME"] = value; }
        }

    /// <summary>
    /// Engeli Kaldıran Kullanıcı
    /// </summary>
        public ResUser UnblockUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("UNBLOCKUSER"); }
            set { this["UNBLOCKUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Engelleyen Kullanıcı
    /// </summary>
        public ResUser BlockUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("BLOCKUSER"); }
            set { this["BLOCKUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Engelleri
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoiceBlocking(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceBlocking(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceBlocking(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceBlocking(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceBlocking(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEBLOCKING", dataRow) { }
        protected InvoiceBlocking(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEBLOCKING", dataRow, isImported) { }
        public InvoiceBlocking(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceBlocking(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceBlocking() : base() { }

    }
}