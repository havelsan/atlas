
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisTaahhutKayit")] 

    public  partial class DisTaahhutKayit : BaseMedulaAction
    {
        public class DisTaahhutKayitList : TTObjectCollection<DisTaahhutKayit> { }
                    
        public class ChildDisTaahhutKayitCollection : TTObject.TTChildObjectCollection<DisTaahhutKayit>
        {
            public ChildDisTaahhutKayitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisTaahhutKayitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDisTaahhutKayitWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDisTaahhutKayitWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDisTaahhutKayitWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDisTaahhutKayitWillBeSentToMedulaRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_DIS_TAAHHUT_Class : TTReportNqlObject 
        {
            public Guid? Dis_taahhut_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIS_TAAHHUT_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Object Hasta_basvuru_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Hekim_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HEKIM_KODU"]);
                }
            }

            public int? Taahhut_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAAHHUT_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTCEVAPDVO"].AllPropertyDefs["TAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Takip_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIP_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTKAYITDVO"].AllPropertyDefs["TAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cadde_sokak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CADDE_SOKAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSCADDESOKAK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dis_kapi_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIS_KAPI_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSDISKAPINO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Eposta_adresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPOSTA_ADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSEPOSTA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ic_kapi_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IC_KAPI_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSICKAPINO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Il_plaka_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IL_PLAKA_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSILPLAKA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Telefon_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEFON_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSTELEFON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDVO"].AllPropertyDefs["ADRESSILCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Medula_sonuc_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULA_SONUC_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTCEVAPDVO"].AllPropertyDefs["SONUCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Medula_sonuc_mesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULA_SONUC_MESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTCEVAPDVO"].AllPropertyDefs["SONUCMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Iptal_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IPTAL_DURUMU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_DIS_TAAHHUT_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_DIS_TAAHHUT_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_DIS_TAAHHUT_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("15c25883-3569-4eb5-a415-5e56d8069bac"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("06e97c2a-7454-4999-bed4-5b04f31b8b54"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ba3a2a97-05ee-40c4-b47e-37fbc4fa6b8f"); } }
            public static Guid New { get { return new Guid("49a53583-32f5-470e-bafb-ab16619572b0"); } }
            public static Guid SentMedula { get { return new Guid("9dad4c19-512f-4ac1-8562-36c476430355"); } }
            public static Guid SentServer { get { return new Guid("698fe888-3d3d-4cb1-a385-124099156f8c"); } }
        }

        public static BindingList<DisTaahhutKayit.GetDisTaahhutKayitWillBeSentToMedulaRQ_Class> GetDisTaahhutKayitWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTKAYIT"].QueryDefs["GetDisTaahhutKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutKayit.GetDisTaahhutKayitWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DisTaahhutKayit.GetDisTaahhutKayitWillBeSentToMedulaRQ_Class> GetDisTaahhutKayitWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTKAYIT"].QueryDefs["GetDisTaahhutKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutKayit.GetDisTaahhutKayitWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DisTaahhutKayit.VEM_DIS_TAAHHUT_Class> VEM_DIS_TAAHHUT(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTKAYIT"].QueryDefs["VEM_DIS_TAAHHUT"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DisTaahhutKayit.VEM_DIS_TAAHHUT_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DisTaahhutKayit.VEM_DIS_TAAHHUT_Class> VEM_DIS_TAAHHUT(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTKAYIT"].QueryDefs["VEM_DIS_TAAHHUT"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DisTaahhutKayit.VEM_DIS_TAAHHUT_Class>(objectContext, queryDef, paramList, pi);
        }

        public TaahhutKayitDVO taahhutKayitDVO
        {
            get { return (TaahhutKayitDVO)((ITTObject)this).GetParent("TAAHHUTKAYITDVO"); }
            set { this["TAAHHUTKAYITDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisTaahhutKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisTaahhutKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisTaahhutKayit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisTaahhutKayit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisTaahhutKayit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTAAHHUTKAYIT", dataRow) { }
        protected DisTaahhutKayit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTAAHHUTKAYIT", dataRow, isImported) { }
        public DisTaahhutKayit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisTaahhutKayit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisTaahhutKayit() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}