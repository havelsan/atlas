
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaTakipBilgisi")] 

    /// <summary>
    /// Dönem Evrak No ile okunan medula takip bilgisi
    /// </summary>
    public  partial class MedulaTakipBilgisi : TTObject
    {
        public class MedulaTakipBilgisiList : TTObjectCollection<MedulaTakipBilgisi> { }
                    
        public class ChildMedulaTakipBilgisiCollection : TTObject.TTChildObjectCollection<MedulaTakipBilgisi>
        {
            public ChildMedulaTakipBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaTakipBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTotalPriceByTerm_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetTotalPriceByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalPriceByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalPriceByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalPriceByTermAndGrupAdi_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetTotalPriceByTermAndGrupAdi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalPriceByTermAndGrupAdi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalPriceByTermAndGrupAdi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByTerm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string TakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].AllPropertyDefs["TAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GrupAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].AllPropertyDefs["GRUPADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GrupTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].AllPropertyDefs["GRUPTURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MedulaTakipBilgisiTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].AllPropertyDefs["TYPE"].DataType;
                    return (MedulaTakipBilgisiTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? ToplamTutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMTUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].AllPropertyDefs["TOPLAMTUTAR"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByTerm_Class() : base() { }
        }

        public static BindingList<MedulaTakipBilgisi.GetTotalPriceByTerm_Class> GetTotalPriceByTerm(Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetTotalPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetTotalPriceByTerm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaTakipBilgisi.GetTotalPriceByTerm_Class> GetTotalPriceByTerm(TTObjectContext objectContext, Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetTotalPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetTotalPriceByTerm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaTakipBilgisi.GetTotalPriceByTermAndGrupAdi_Class> GetTotalPriceByTermAndGrupAdi(Guid TERM, string GRUPADI, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetTotalPriceByTermAndGrupAdi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("GRUPADI", GRUPADI);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetTotalPriceByTermAndGrupAdi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaTakipBilgisi.GetTotalPriceByTermAndGrupAdi_Class> GetTotalPriceByTermAndGrupAdi(TTObjectContext objectContext, Guid TERM, string GRUPADI, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetTotalPriceByTermAndGrupAdi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("GRUPADI", GRUPADI);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetTotalPriceByTermAndGrupAdi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaTakipBilgisi.GetByTerm_Class> GetByTerm(Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetByTerm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaTakipBilgisi.GetByTerm_Class> GetByTerm(TTObjectContext objectContext, Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATAKIPBILGISI"].QueryDefs["GetByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<MedulaTakipBilgisi.GetByTerm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public MedulaTakipBilgisiTypeEnum? Type
        {
            get { return (MedulaTakipBilgisiTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string TakipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public string GrupTuru
        {
            get { return (string)this["GRUPTURU"]; }
            set { this["GRUPTURU"] = value; }
        }

        public string GrupAdi
        {
            get { return (string)this["GRUPADI"]; }
            set { this["GRUPADI"] = value; }
        }

        public Currency? ToplamTutar
        {
            get { return (Currency?)this["TOPLAMTUTAR"]; }
            set { this["TOPLAMTUTAR"] = value; }
        }

    /// <summary>
    /// Dönem Evrak No ile okunan medula takip bilgileri
    /// </summary>
        public InvoiceTerm InvoiceTerm
        {
            get { return (InvoiceTerm)((ITTObject)this).GetParent("INVOICETERM"); }
            set { this["INVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaTakipBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaTakipBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaTakipBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaTakipBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaTakipBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULATAKIPBILGISI", dataRow) { }
        protected MedulaTakipBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULATAKIPBILGISI", dataRow, isImported) { }
        public MedulaTakipBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaTakipBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaTakipBilgisi() : base() { }

    }
}