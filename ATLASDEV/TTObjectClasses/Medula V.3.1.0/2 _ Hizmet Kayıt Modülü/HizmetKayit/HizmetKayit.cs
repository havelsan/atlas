
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
    /// <summary>
    /// Hizmet Kayıt
    /// </summary>
    public  partial class HizmetKayit : BaseMedulaAction
    {
        public partial class GetHizmetKayitWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                hizmetKayitGirisDVO = new HizmetKayitGirisDVO(ObjectContext);
        }

        public override bool IsExportable
        {
            get
            {
                return true;
            }
        }

        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(hizmetKayitGirisDVO);
            if (hizmetKayitGirisDVO.muayeneBilgisi != null)
                _exportableObjects.Add(hizmetKayitGirisDVO.muayeneBilgisi);

            if (hizmetKayitGirisDVO.hizmetKayitCevapDVO != null)
            {
                _exportableObjects.Add(hizmetKayitGirisDVO.hizmetKayitCevapDVO);

                foreach (HataliIslemBilgisiDVO hataliIslemBilgisiDVO in hizmetKayitGirisDVO.hizmetKayitCevapDVO.hataliKayitlar)
                    _exportableObjects.Add(hataliIslemBilgisiDVO);

                foreach (KayitliIslemBilgisiDVO kayitliIslemBilgisiDVO in hizmetKayitGirisDVO.hizmetKayitCevapDVO.islemBilgileri)
                    _exportableObjects.Add(kayitliIslemBilgisiDVO);
            }

            foreach (TaniBilgisiDVO taniBilgisiDVO in hizmetKayitGirisDVO.tanilar)
                _exportableObjects.Add(taniBilgisiDVO);

            foreach (AmeliyatveGirisimBilgisiDVO ameliyatveGirisimBilgisiDVO in hizmetKayitGirisDVO.ameliyatveGirisimBilgileri)
                _exportableObjects.Add(ameliyatveGirisimBilgisiDVO);

            foreach (DigerIslemBilgisiDVO digerIslemBilgisiDVO in hizmetKayitGirisDVO.digerIslemBilgileri)
                _exportableObjects.Add(digerIslemBilgisiDVO);

            foreach (DisBilgisiDVO disBilgisiDVO in hizmetKayitGirisDVO.disBilgileri)
                _exportableObjects.Add(disBilgisiDVO);

            foreach (HastaYatisBilgisiDVO hastaYatisBilgisiDVO in hizmetKayitGirisDVO.hastaYatisBilgileri)
                _exportableObjects.Add(hastaYatisBilgisiDVO);

            foreach (IlacBilgisiDVO ilacBilgisiDVO in hizmetKayitGirisDVO.ilacBilgileri)
                _exportableObjects.Add(ilacBilgisiDVO);

            foreach (KonsultasyonBilgisiDVO konsultasyonBilgisiDVO in hizmetKayitGirisDVO.konsultasyonBilgileri)
                _exportableObjects.Add(konsultasyonBilgisiDVO);

            foreach (MalzemeBilgisiDVO malzemeBilgisiDVO in hizmetKayitGirisDVO.malzemeBilgileri)
                _exportableObjects.Add(malzemeBilgisiDVO);

            foreach (TahlilBilgisiDVO tahlilBilgisiDVO in hizmetKayitGirisDVO.tahlilBilgileri)
                _exportableObjects.Add(tahlilBilgisiDVO);

            foreach (TetkikveRadyolojiBilgisiDVO tetkikveRadyolojiBilgisiDVO in hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri)
                _exportableObjects.Add(tetkikveRadyolojiBilgisiDVO);
        }
        
#endregion Methods

    }
}