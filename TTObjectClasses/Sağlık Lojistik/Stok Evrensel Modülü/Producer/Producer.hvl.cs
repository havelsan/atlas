
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Producer")] 

    /// <summary>
    /// Üretici
    /// </summary>
    public  partial class Producer : TerminologyManagerDef
    {
        public class ProducerList : TTObjectCollection<Producer> { }
                    
        public class ChildProducerCollection : TTObject.TTChildObjectCollection<Producer>
        {
            public ChildProducerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProducerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProducerDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetProducerDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProducerDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProducerDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProducerList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public long? ProcuderCodeSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCUDERCODESEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["PROCUDERCODESEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string TaxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["TAXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProducerList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProducerList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProducerList_Class() : base() { }
        }

        public static BindingList<Producer> GetProducerBySPTSProducerID(TTObjectContext objectContext, long SPSTSPRODUCERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].QueryDefs["GetProducerBySPTSProducerID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPSTSPRODUCERID", SPSTSPRODUCERID);

            return ((ITTQuery)objectContext).QueryObjects<Producer>(queryDef, paramList);
        }

        public static BindingList<Producer.GetProducerDefinitionQuery_Class> GetProducerDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].QueryDefs["GetProducerDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Producer.GetProducerDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Producer.GetProducerDefinitionQuery_Class> GetProducerDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].QueryDefs["GetProducerDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Producer.GetProducerDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Producer.GetProducerList_Class> GetProducerList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].QueryDefs["GetProducerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Producer.GetProducerList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Producer.GetProducerList_Class> GetProducerList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].QueryDefs["GetProducerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Producer.GetProducerList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İsim
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? SPTSProducerID
        {
            get { return (long?)this["SPTSPRODUCERID"]; }
            set { this["SPTSPRODUCERID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

    /// <summary>
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Elektronik Posta
    /// </summary>
        public string Email
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Faks
    /// </summary>
        public string Fax
        {
            get { return (string)this["FAX"]; }
            set { this["FAX"] = value; }
        }

    /// <summary>
    /// Vergi No
    /// </summary>
        public string TaxNo
        {
            get { return (string)this["TAXNO"]; }
            set { this["TAXNO"] = value; }
        }

    /// <summary>
    /// Bayi No
    /// </summary>
        public string SupplierNumber
        {
            get { return (string)this["SUPPLIERNUMBER"]; }
            set { this["SUPPLIERNUMBER"] = value; }
        }

    /// <summary>
    /// Vergi Dairesi
    /// </summary>
        public string TaxOfficeName
        {
            get { return (string)this["TAXOFFICENAME"]; }
            set { this["TAXOFFICENAME"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string Telephone
        {
            get { return (string)this["TELEPHONE"]; }
            set { this["TELEPHONE"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Bayi GLN No
    /// </summary>
        public string GLNNo
        {
            get { return (string)this["GLNNO"]; }
            set { this["GLNNO"] = value; }
        }

    /// <summary>
    /// Firma Tanımlayıcı No
    /// </summary>
        public long? FirmIdentifierNo
        {
            get { return (long?)this["FIRMIDENTIFIERNO"]; }
            set { this["FIRMIDENTIFIERNO"] = value; }
        }

    /// <summary>
    /// Sistem Kodu
    /// </summary>
        public TTSequence ProcuderCodeSeq
        {
            get { return GetSequence("PROCUDERCODESEQ"); }
        }

        protected Producer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Producer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Producer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Producer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Producer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCER", dataRow) { }
        protected Producer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCER", dataRow, isImported) { }
        public Producer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Producer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Producer() : base() { }

    }
}