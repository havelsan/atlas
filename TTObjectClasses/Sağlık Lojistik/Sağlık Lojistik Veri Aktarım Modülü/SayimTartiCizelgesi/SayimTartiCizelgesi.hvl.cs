
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SayimTartiCizelgesi")] 

    public  partial class SayimTartiCizelgesi : TTObject
    {
        public class SayimTartiCizelgesiList : TTObjectCollection<SayimTartiCizelgesi> { }
                    
        public class ChildSayimTartiCizelgesiCollection : TTObject.TTChildObjectCollection<SayimTartiCizelgesi>
        {
            public ChildSayimTartiCizelgesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSayimTartiCizelgesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByNSN_Class : TTReportNqlObject 
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

            public string MalzemeNu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMENU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["MALZEMENU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? HEKMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HEKMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Aciklamalar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMALAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["ACIKLAMALAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CinsVeOzellikler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSVEOZELLIKLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["CINSVEOZELLIKLER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? HUY_MainClassID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_MAINCLASSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_MAINCLASSID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string HUY_MainClassName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_MAINCLASSNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? HUY_MainMaterialID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_MAINMATERIALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_MAINMATERIALID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string HUY_MainMaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_MAINMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_MAINMATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MainStoreObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINSTOREOBJECTID"]);
                }
            }

            public int? HUY_StockCardID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_STOCKCARDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_STOCKCARDID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string OlcuBirimiUzun
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLCUBIRIMIUZUN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["OLCUBIRIMIUZUN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcilisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACILISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["ACILISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MasaAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["MASAADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Blokaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOKAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["BLOKAJ"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string CinsVeOzellikler_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSVEOZELLIKLER_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["CINSVEOZELLIKLER_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SayimTartiGrubuEnum? SayimTartiGrubu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAYIMTARTIGRUBU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["SAYIMTARTIGRUBU"].DataType;
                    return (SayimTartiGrubuEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? SiraNu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIRANU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["SIRANU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? Toplam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["TOPLAM"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? ToplamTutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMTUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["TOPLAMTUTAR"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Currency? YeniMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YENIMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["YENIMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public int? HUY_StockID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_STOCKID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_STOCKID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? KullanilmisMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANILMISMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["KULLANILMISMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MuvakkatenVerilen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUVAKKATENVERILEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["MUVAKKATENVERILEN"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string NATOStokNu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOKNU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["NATOSTOKNU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OlcuBirimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLCUBIRIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["OLCUBIRIMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HUY_Aciklamalar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUY_ACIKLAMALAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["HUY_ACIKLAMALAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SeriNumarali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERINUMARALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].AllPropertyDefs["SERINUMARALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetByNSN_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNSN_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNSN_Class() : base() { }
        }

        public static BindingList<SayimTartiCizelgesi.GetByNSN_Class> GetByNSN(string NSN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].QueryDefs["GetByNSN"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NSN", NSN);

            return TTReportNqlObject.QueryObjects<SayimTartiCizelgesi.GetByNSN_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SayimTartiCizelgesi.GetByNSN_Class> GetByNSN(TTObjectContext objectContext, string NSN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAYIMTARTICIZELGESI"].QueryDefs["GetByNSN"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NSN", NSN);

            return TTReportNqlObject.QueryObjects<SayimTartiCizelgesi.GetByNSN_Class>(objectContext, queryDef, paramList, pi);
        }

        public string MalzemeNu
        {
            get { return (string)this["MALZEMENU"]; }
            set { this["MALZEMENU"] = value; }
        }

        public Currency? HEKMevcut
        {
            get { return (Currency?)this["HEKMEVCUT"]; }
            set { this["HEKMEVCUT"] = value; }
        }

        public string Aciklamalar
        {
            get { return (string)this["ACIKLAMALAR"]; }
            set { this["ACIKLAMALAR"] = value; }
        }

        public string CinsVeOzellikler
        {
            get { return (string)this["CINSVEOZELLIKLER"]; }
            set { this["CINSVEOZELLIKLER"] = value; }
        }

        public int? HUY_MainClassID
        {
            get { return (int?)this["HUY_MAINCLASSID"]; }
            set { this["HUY_MAINCLASSID"] = value; }
        }

        public string HUY_MainClassName
        {
            get { return (string)this["HUY_MAINCLASSNAME"]; }
            set { this["HUY_MAINCLASSNAME"] = value; }
        }

        public int? HUY_MainMaterialID
        {
            get { return (int?)this["HUY_MAINMATERIALID"]; }
            set { this["HUY_MAINMATERIALID"] = value; }
        }

        public string HUY_MainMaterialName
        {
            get { return (string)this["HUY_MAINMATERIALNAME"]; }
            set { this["HUY_MAINMATERIALNAME"] = value; }
        }

        public Guid? MainStoreObjectID
        {
            get { return (Guid?)this["MAINSTOREOBJECTID"]; }
            set { this["MAINSTOREOBJECTID"] = value; }
        }

        public int? HUY_StockCardID
        {
            get { return (int?)this["HUY_STOCKCARDID"]; }
            set { this["HUY_STOCKCARDID"] = value; }
        }

        public string OlcuBirimiUzun
        {
            get { return (string)this["OLCUBIRIMIUZUN"]; }
            set { this["OLCUBIRIMIUZUN"] = value; }
        }

        public DateTime? AcilisTarihi
        {
            get { return (DateTime?)this["ACILISTARIHI"]; }
            set { this["ACILISTARIHI"] = value; }
        }

        public string MasaAdi
        {
            get { return (string)this["MASAADI"]; }
            set { this["MASAADI"] = value; }
        }

        public Currency? Blokaj
        {
            get { return (Currency?)this["BLOKAJ"]; }
            set { this["BLOKAJ"] = value; }
        }

        public string CinsVeOzellikler_Shadow
        {
            get { return (string)this["CINSVEOZELLIKLER_SHADOW"]; }
        }

        public SayimTartiGrubuEnum? SayimTartiGrubu
        {
            get { return (SayimTartiGrubuEnum?)(int?)this["SAYIMTARTIGRUBU"]; }
            set { this["SAYIMTARTIGRUBU"] = value; }
        }

        public int? SiraNu
        {
            get { return (int?)this["SIRANU"]; }
            set { this["SIRANU"] = value; }
        }

        public Currency? Toplam
        {
            get { return (Currency?)this["TOPLAM"]; }
            set { this["TOPLAM"] = value; }
        }

        public BigCurrency? ToplamTutar
        {
            get { return (BigCurrency?)this["TOPLAMTUTAR"]; }
            set { this["TOPLAMTUTAR"] = value; }
        }

        public Currency? YeniMevcut
        {
            get { return (Currency?)this["YENIMEVCUT"]; }
            set { this["YENIMEVCUT"] = value; }
        }

        public int? HUY_StockID
        {
            get { return (int?)this["HUY_STOCKID"]; }
            set { this["HUY_STOCKID"] = value; }
        }

        public Currency? KullanilmisMevcut
        {
            get { return (Currency?)this["KULLANILMISMEVCUT"]; }
            set { this["KULLANILMISMEVCUT"] = value; }
        }

        public Currency? MuvakkatenVerilen
        {
            get { return (Currency?)this["MUVAKKATENVERILEN"]; }
            set { this["MUVAKKATENVERILEN"] = value; }
        }

        public string NATOStokNu
        {
            get { return (string)this["NATOSTOKNU"]; }
            set { this["NATOSTOKNU"] = value; }
        }

        public string OlcuBirimi
        {
            get { return (string)this["OLCUBIRIMI"]; }
            set { this["OLCUBIRIMI"] = value; }
        }

        public string HUY_Aciklamalar
        {
            get { return (string)this["HUY_ACIKLAMALAR"]; }
            set { this["HUY_ACIKLAMALAR"] = value; }
        }

        public bool? SeriNumarali
        {
            get { return (bool?)this["SERINUMARALI"]; }
            set { this["SERINUMARALI"] = value; }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMuvakkatCizelgeleriCollection()
        {
            _MuvakkatCizelgeleri = new MuvakkatCizelgesi.ChildMuvakkatCizelgesiCollection(this, new Guid("ec35e1f3-f93c-447d-96c7-b64c5d49d127"));
            ((ITTChildObjectCollection)_MuvakkatCizelgeleri).GetChildren();
        }

        protected MuvakkatCizelgesi.ChildMuvakkatCizelgesiCollection _MuvakkatCizelgeleri = null;
        public MuvakkatCizelgesi.ChildMuvakkatCizelgesiCollection MuvakkatCizelgeleri
        {
            get
            {
                if (_MuvakkatCizelgeleri == null)
                    CreateMuvakkatCizelgeleriCollection();
                return _MuvakkatCizelgeleri;
            }
        }

        virtual protected void CreateDemirbasCizelgeleriCollection()
        {
            _DemirbasCizelgeleri = new DemirbasCizelgesi.ChildDemirbasCizelgesiCollection(this, new Guid("76e18c37-f5a4-4c23-b2d3-9c1095d86fda"));
            ((ITTChildObjectCollection)_DemirbasCizelgeleri).GetChildren();
        }

        protected DemirbasCizelgesi.ChildDemirbasCizelgesiCollection _DemirbasCizelgeleri = null;
        public DemirbasCizelgesi.ChildDemirbasCizelgesiCollection DemirbasCizelgeleri
        {
            get
            {
                if (_DemirbasCizelgeleri == null)
                    CreateDemirbasCizelgeleriCollection();
                return _DemirbasCizelgeleri;
            }
        }

        protected SayimTartiCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SayimTartiCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SayimTartiCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SayimTartiCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SayimTartiCizelgesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAYIMTARTICIZELGESI", dataRow) { }
        protected SayimTartiCizelgesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAYIMTARTICIZELGESI", dataRow, isImported) { }
        public SayimTartiCizelgesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SayimTartiCizelgesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SayimTartiCizelgesi() : base() { }

    }
}