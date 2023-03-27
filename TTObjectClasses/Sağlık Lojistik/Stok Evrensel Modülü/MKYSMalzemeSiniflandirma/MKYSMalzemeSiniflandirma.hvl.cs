
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MKYSMalzemeSiniflandirma")] 

    /// <summary>
    /// MKYS Malzeme Sınıflandırma
    /// </summary>
    public  partial class MKYSMalzemeSiniflandirma : TerminologyManagerDef
    {
        public class MKYSMalzemeSiniflandirmaList : TTObjectCollection<MKYSMalzemeSiniflandirma> { }
                    
        public class ChildMKYSMalzemeSiniflandirmaCollection : TTObject.TTChildObjectCollection<MKYSMalzemeSiniflandirma>
        {
            public ChildMKYSMalzemeSiniflandirmaCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMKYSMalzemeSiniflandirmaCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? MalzemeKayitID
        {
            get { return (int?)this["MALZEMEKAYITID"]; }
            set { this["MALZEMEKAYITID"] = value; }
        }

        public string MalzemeKodu
        {
            get { return (string)this["MALZEMEKODU"]; }
            set { this["MALZEMEKODU"] = value; }
        }

        public string MalzemeAdi
        {
            get { return (string)this["MALZEMEADI"]; }
            set { this["MALZEMEADI"] = value; }
        }

        public DateTime? DegisiklikTarihi
        {
            get { return (DateTime?)this["DEGISIKLIKTARIHI"]; }
            set { this["DEGISIKLIKTARIHI"] = value; }
        }

        public string TibbiSarfKlinikBransi
        {
            get { return (string)this["TIBBISARFKLINIKBRANSI"]; }
            set { this["TIBBISARFKLINIKBRANSI"] = value; }
        }

        public string TibbiSarfKullanimYeri
        {
            get { return (string)this["TIBBISARFKULLANIMYERI"]; }
            set { this["TIBBISARFKULLANIMYERI"] = value; }
        }

        public string TibbiSarfKullanimAmaci
        {
            get { return (string)this["TIBBISARFKULLANIMAMACI"]; }
            set { this["TIBBISARFKULLANIMAMACI"] = value; }
        }

        public string TibbiSarfMalzemeCinsi
        {
            get { return (string)this["TIBBISARFMALZEMECINSI"]; }
            set { this["TIBBISARFMALZEMECINSI"] = value; }
        }

        public string TibbiSarfSutKodu
        {
            get { return (string)this["TIBBISARFSUTKODU"]; }
            set { this["TIBBISARFSUTKODU"] = value; }
        }

        public string LaboratuvarBransi
        {
            get { return (string)this["LABORATUVARBRANSI"]; }
            set { this["LABORATUVARBRANSI"] = value; }
        }

        public string LaboratuvarCinsi
        {
            get { return (string)this["LABORATUVARCINSI"]; }
            set { this["LABORATUVARCINSI"] = value; }
        }

        public string LaboratuvarSutKodu
        {
            get { return (string)this["LABORATUVARSUTKODU"]; }
            set { this["LABORATUVARSUTKODU"] = value; }
        }

        public string CerrahiAletBransi
        {
            get { return (string)this["CERRAHIALETBRANSI"]; }
            set { this["CERRAHIALETBRANSI"] = value; }
        }

        public string CerrahiAletCinsi
        {
            get { return (string)this["CERRAHIALETCINSI"]; }
            set { this["CERRAHIALETCINSI"] = value; }
        }

        public string CerrahiAletSutKodu
        {
            get { return (string)this["CERRAHIALETSUTKODU"]; }
            set { this["CERRAHIALETSUTKODU"] = value; }
        }

        public string BiyomedikalCihazTur
        {
            get { return (string)this["BIYOMEDIKALCIHAZTUR"]; }
            set { this["BIYOMEDIKALCIHAZTUR"] = value; }
        }

        public string BiyomedikalCihazTanim
        {
            get { return (string)this["BIYOMEDIKALCIHAZTANIM"]; }
            set { this["BIYOMEDIKALCIHAZTANIM"] = value; }
        }

        public string BiyomedikalSarfTur
        {
            get { return (string)this["BIYOMEDIKALSARFTUR"]; }
            set { this["BIYOMEDIKALSARFTUR"] = value; }
        }

        public string BiyomedikalSarfTanim
        {
            get { return (string)this["BIYOMEDIKALSARFTANIM"]; }
            set { this["BIYOMEDIKALSARFTANIM"] = value; }
        }

        public string BiyomedikalSarfCins
        {
            get { return (string)this["BIYOMEDIKALSARFCINS"]; }
            set { this["BIYOMEDIKALSARFCINS"] = value; }
        }

        public string BiyomedikalSarfNitelik
        {
            get { return (string)this["BIYOMEDIKALSARFNITELIK"]; }
            set { this["BIYOMEDIKALSARFNITELIK"] = value; }
        }

        public string BiyomedikalSarfSutKodu
        {
            get { return (string)this["BIYOMEDIKALSARFSUTKODU"]; }
            set { this["BIYOMEDIKALSARFSUTKODU"] = value; }
        }

        public string IlacBarkod
        {
            get { return (string)this["ILACBARKOD"]; }
            set { this["ILACBARKOD"] = value; }
        }

        public string IlacAdi
        {
            get { return (string)this["ILACADI"]; }
            set { this["ILACADI"] = value; }
        }

        public string IlacJenerikKodu
        {
            get { return (string)this["ILACJENERIKKODU"]; }
            set { this["ILACJENERIKKODU"] = value; }
        }

        public string IlacJenerikAdi
        {
            get { return (string)this["ILACJENERIKADI"]; }
            set { this["ILACJENERIKADI"] = value; }
        }

        public string Pasif
        {
            get { return (string)this["PASIF"]; }
            set { this["PASIF"] = value; }
        }

        public string BarkodDogrulamaDurumu
        {
            get { return (string)this["BARKODDOGRULAMADURUMU"]; }
            set { this["BARKODDOGRULAMADURUMU"] = value; }
        }

        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSMALZEMESINIFLANDIRMA", dataRow) { }
        protected MKYSMalzemeSiniflandirma(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSMALZEMESINIFLANDIRMA", dataRow, isImported) { }
        public MKYSMalzemeSiniflandirma(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MKYSMalzemeSiniflandirma(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MKYSMalzemeSiniflandirma() : base() { }

    }
}