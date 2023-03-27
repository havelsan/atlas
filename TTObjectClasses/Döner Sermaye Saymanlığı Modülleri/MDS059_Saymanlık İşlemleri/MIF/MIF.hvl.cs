
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MIF")] 

    public  partial class MIF : TTObject
    {
        public class MIFList : TTObjectCollection<MIF> { }
                    
        public class ChildMIFCollection : TTObject.TTChildObjectCollection<MIF>
        {
            public ChildMIFCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMIFCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMIFs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InvoiceTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INVOICETERM"]);
                }
            }

            public string Invoicetermname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICETERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MIFTypeEnum? MIFType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIFTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MIF"].AllPropertyDefs["MIFTYPE"].DataType;
                    return (MIFTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MIF"].AllPropertyDefs["CREATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CreateUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CREATEUSER"]);
                }
            }

            public string Createusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMIFs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMIFs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMIFs_Class() : base() { }
        }

        public static BindingList<MIF.GetMIFs_Class> GetMIFs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MIF"].QueryDefs["GetMIFs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MIF.GetMIFs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MIF.GetMIFs_Class> GetMIFs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MIF"].QueryDefs["GetMIFs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MIF.GetMIFs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

        public MIFTypeEnum? MIFType
        {
            get { return (MIFTypeEnum?)(int?)this["MIFTYPE"]; }
            set { this["MIFTYPE"] = value; }
        }

        public InvoiceTerm InvoiceTerm
        {
            get { return (InvoiceTerm)((ITTObject)this).GetParent("INVOICETERM"); }
            set { this["INVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser CreateUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEUSER"); }
            set { this["CREATEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMIFDetailsCollection()
        {
            _MIFDetails = new MIFDetail.ChildMIFDetailCollection(this, new Guid("b449aefb-c5a7-4c4b-b323-2cf5d9cc88ce"));
            ((ITTChildObjectCollection)_MIFDetails).GetChildren();
        }

        protected MIFDetail.ChildMIFDetailCollection _MIFDetails = null;
        public MIFDetail.ChildMIFDetailCollection MIFDetails
        {
            get
            {
                if (_MIFDetails == null)
                    CreateMIFDetailsCollection();
                return _MIFDetails;
            }
        }

        protected MIF(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MIF(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MIF(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MIF(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MIF(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MIF", dataRow) { }
        protected MIF(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MIF", dataRow, isImported) { }
        public MIF(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MIF(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MIF() : base() { }

    }
}