
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSSistemKodlari")] 

    public  partial class SKRSSistemKodlari : TTDefinitionSet
    {
        public class SKRSSistemKodlariList : TTObjectCollection<SKRSSistemKodlari> { }
                    
        public class ChildSKRSSistemKodlariCollection : TTObject.TTChildObjectCollection<SKRSSistemKodlari>
        {
            public ChildSKRSSistemKodlariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSSistemKodlariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class IsSKRSActive_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public IsSKRSActive_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public IsSKRSActive_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected IsSKRSActive_Class() : base() { }
        }

        public static BindingList<SKRSSistemKodlari> GetBySKRSGuid(TTObjectContext objectContext, string SKRSGUID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSISTEMKODLARI"].QueryDefs["GetBySKRSGuid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSGUID", SKRSGUID);

            return ((ITTQuery)objectContext).QueryObjects<SKRSSistemKodlari>(queryDef, paramList);
        }

        public static BindingList<SKRSSistemKodlari.IsSKRSActive_Class> IsSKRSActive(string SKRSGUID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSISTEMKODLARI"].QueryDefs["IsSKRSActive"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSGUID", SKRSGUID);

            return TTReportNqlObject.QueryObjects<SKRSSistemKodlari.IsSKRSActive_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SKRSSistemKodlari.IsSKRSActive_Class> IsSKRSActive(TTObjectContext objectContext, string SKRSGUID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSISTEMKODLARI"].QueryDefs["IsSKRSActive"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSGUID", SKRSGUID);

            return TTReportNqlObject.QueryObjects<SKRSSistemKodlari.IsSKRSActive_Class>(objectContext, queryDef, paramList, pi);
        }

        public string SKRSGuid
        {
            get { return (string)this["SKRSGUID"]; }
            set { this["SKRSGUID"] = value; }
        }

        public string Adi
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string SqlFilter
        {
            get { return (string)this["SQLFILTER"]; }
            set { this["SQLFILTER"] = value; }
        }

        public string AKTIF
        {
            get { return (string)this["AKTIF"]; }
            set { this["AKTIF"] = value; }
        }

        public DateTime? GuncellemeTarihi
        {
            get { return (DateTime?)this["GUNCELLEMETARIHI"]; }
            set { this["GUNCELLEMETARIHI"] = value; }
        }

        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public DateTime? OlusturmaTarihi
        {
            get { return (DateTime?)this["OLUSTURMATARIHI"]; }
            set { this["OLUSTURMATARIHI"] = value; }
        }

        protected SKRSSistemKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSSistemKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSSistemKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSSistemKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSSistemKodlari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSSISTEMKODLARI", dataRow) { }
        protected SKRSSistemKodlari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSSISTEMKODLARI", dataRow, isImported) { }
        public SKRSSistemKodlari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSSistemKodlari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSSistemKodlari() : base() { }

    }
}