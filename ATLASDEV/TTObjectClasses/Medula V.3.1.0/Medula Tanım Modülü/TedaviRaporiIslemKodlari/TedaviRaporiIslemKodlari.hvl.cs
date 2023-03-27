
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviRaporiIslemKodlari")] 

    /// <summary>
    /// Tedavi Raporları İşlem Kodları
    /// </summary>
    public  partial class TedaviRaporiIslemKodlari : BaseMedulaDefinition
    {
        public class TedaviRaporiIslemKodlariList : TTObjectCollection<TedaviRaporiIslemKodlari> { }
                    
        public class ChildTedaviRaporiIslemKodlariCollection : TTObject.TTChildObjectCollection<TedaviRaporiIslemKodlari>
        {
            public ChildTedaviRaporiIslemKodlariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviRaporiIslemKodlariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTedaviTuruRaporuIslemiQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? TedaviRaporuTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORUTURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUTURUKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TedaviRaporuTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUTURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TedaviRaporuIslemi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORUISLEMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TedaviRaporuIslemKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORUISLEMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTedaviTuruRaporuIslemiQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviTuruRaporuIslemiQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviTuruRaporuIslemiQuery_Class() : base() { }
        }

        public static BindingList<TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class> GetTedaviTuruRaporuIslemiQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].QueryDefs["GetTedaviTuruRaporuIslemiQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class> GetTedaviTuruRaporuIslemiQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].QueryDefs["GetTedaviTuruRaporuIslemiQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviRaporiIslemKodlari.GetTedaviTuruRaporuIslemiQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tedavi Raporu İşlemi
    /// </summary>
        public string TedaviRaporuIslemi
        {
            get { return (string)this["TEDAVIRAPORUISLEMI"]; }
            set { this["TEDAVIRAPORUISLEMI"] = value; }
        }

    /// <summary>
    /// Tedavi Raporu İşlem Kodu
    /// </summary>
        public string TedaviRaporuIslemKodu
        {
            get { return (string)this["TEDAVIRAPORUISLEMKODU"]; }
            set { this["TEDAVIRAPORUISLEMKODU"] = value; }
        }

    /// <summary>
    /// Tedavi Raporu Türü
    /// </summary>
        public string TedaviRaporuTuru
        {
            get { return (string)this["TEDAVIRAPORUTURU"]; }
            set { this["TEDAVIRAPORUTURU"] = value; }
        }

    /// <summary>
    /// Tedavi Raporu Türü Kodu
    /// </summary>
        public int? TedaviRaporuTuruKodu
        {
            get { return (int?)this["TEDAVIRAPORUTURUKODU"]; }
            set { this["TEDAVIRAPORUTURUKODU"] = value; }
        }

        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIRAPORIISLEMKODLARI", dataRow) { }
        protected TedaviRaporiIslemKodlari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIRAPORIISLEMKODLARI", dataRow, isImported) { }
        public TedaviRaporiIslemKodlari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviRaporiIslemKodlari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviRaporiIslemKodlari() : base() { }

    }
}