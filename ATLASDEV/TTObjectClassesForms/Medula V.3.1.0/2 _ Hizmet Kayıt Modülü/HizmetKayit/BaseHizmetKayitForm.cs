
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// BaseHizmetKayitForm
    /// </summary>
    public partial class BaseHizmetKayitForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            createMuayeneBilgisi.Click += new TTControlEventDelegate(createMuayeneBilgisi_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            createMuayeneBilgisi.Click -= new TTControlEventDelegate(createMuayeneBilgisi_Click);
            base.UnBindControlEvents();
        }

        private void createMuayeneBilgisi_Click()
        {
#region BaseHizmetKayitForm_createMuayeneBilgisi_Click
   createMuayeneBilgisi.ReadOnly = true;

            bransKoduMuayeneBilgisiDVO.ReadOnly = false;
            drTescilNoMuayeneBilgisiDVO.ReadOnly = false;
            sutKoduMuayeneBilgisiDVO.ReadOnly = false;
            muayeneTarihiDateTimeMuayeneBilgisiDVO.ReadOnly = false;
            ozelDurumBaseHizmetKayitDVO.ReadOnly = false;

            this._HizmetKayit.hizmetKayitGirisDVO.muayeneBilgisi = new MuayeneBilgisiDVO(this._HizmetKayit.ObjectContext);
            this._HizmetKayit.hizmetKayitGirisDVO.muayeneBilgisi.CreateHizmetSunucuRefNo();
#endregion BaseHizmetKayitForm_createMuayeneBilgisi_Click
        }

        protected override void PreScript()
        {
#region BaseHizmetKayitForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)_HizmetKayit;
            if (iTTObject.IsNew)
                _HizmetKayit.hizmetKayitGirisDVO.saglikTesisKodu = _HizmetKayit.HealthFacilityID.Value;
            if (_HizmetKayit.HealthFacilityID.HasValue)
            {
                string filterexpression = "SAGLIKTESISI = " + ConnectionManager.GuidToString(_HizmetKayit.HealthFacility.ObjectID);
                drTescilNoAmeliyatveGirisimBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoDigerIslemBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoDisBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoHastaYatisBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoKonsultasyonBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoMuayeneBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoTahlilBilgisiDVO.ListFilterExpression = filterexpression;
                drTescilNoTetkikveRadyolojiBilgisiDVO.ListFilterExpression = filterexpression;
            }
#endregion BaseHizmetKayitForm_PreScript

            }
                }
}