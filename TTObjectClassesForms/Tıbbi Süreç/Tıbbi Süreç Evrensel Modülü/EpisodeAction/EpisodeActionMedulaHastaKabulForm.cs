
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
    /// Medula Hasta Kabulleri
    /// </summary>
    public partial class EpisodeActionMedulaHastaKabulForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region EpisodeActionMedulaHastaKabulForm_PreScript
    if (this.PatientMedulaHastaKabulleri == null)
                this.PatientMedulaHastaKabulleri = this._EpisodeAction.Episode.EpisodeMedulaHastaKabulleri.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(PatientMedulaHastaKabul.States.Valid));
            if (this.PatientMedulaHastaKabulleri.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(156));
            //throw new TTException("Hastaya ait Medula Hasta Kabul bulunamadı.");

            foreach (PatientMedulaHastaKabul patientMedulaHastaKabul in this.PatientMedulaHastaKabulleri)
            {
                ProvizyonGirisDVO provizyonGirisDVO = patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO;
                ITTListViewItem listViewItem = listviewPatientMedulaHastaKabul.Items.Add(provizyonGirisDVO.provizyonTarihi);
                listViewItem.SubItems.Add(provizyonGirisDVO.provizyonCevapDVO.takipNo);
                listViewItem.SubItems.Add(provizyonGirisDVO.provizyonCevapDVO.hastaBasvuruNo);
                listViewItem.SubItems.Add(SigortaliTuru.GetSigortaliTuru(provizyonGirisDVO.sigortaliTuru).ToString());
                listViewItem.SubItems.Add(SpecialityDefinition.GetBrans(provizyonGirisDVO.bransKodu).ToString());
                listViewItem.SubItems.Add(DevredilenKurum.GetDevredilenKurum(provizyonGirisDVO.devredilenKurum).ToString());
                listViewItem.SubItems.Add(ProvizyonTipi.GetProvizyonTipi(provizyonGirisDVO.provizyonTipi).ToString());
                listViewItem.SubItems.Add(TakipTipi.GetTakipTipi(provizyonGirisDVO.takipTipi).ToString());
                listViewItem.SubItems.Add(TedaviTuru.GetTedaviTuru(provizyonGirisDVO.tedaviTuru).ToString());
                listViewItem.SubItems.Add(TedaviTipi.GetTedaviTipi(provizyonGirisDVO.tedaviTipi).ToString());
                listViewItem.Tag = patientMedulaHastaKabul;
            }
#endregion EpisodeActionMedulaHastaKabulForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region EpisodeActionMedulaHastaKabulForm_PostScript
    if (listviewPatientMedulaHastaKabul.SelectedItems.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(140));
            //throw new Exception("İşlem yapılabilmesi için en az bir adet Medula Hasta Kabul seçmiş olmanız gerekir.");

            ITTListViewItem listViewItem = listviewPatientMedulaHastaKabul.SelectedItems[0];
            if (listViewItem.Tag == null && (listViewItem.Tag is PatientMedulaHastaKabul) == false)
                throw new TTUtils.TTException(SystemMessage.GetMessage(140));
            //throw new Exception("İşlem yapılabilmesi için en az bir adet Medula Hasta Kabul seçmiş olmanız gerekir.");

            this._EpisodeAction.MedulaHastaKabul = (PatientMedulaHastaKabul)listViewItem.Tag;
#endregion EpisodeActionMedulaHastaKabulForm_PostScript

            }
            
#region EpisodeActionMedulaHastaKabulForm_Methods
        public BindingList<PatientMedulaHastaKabul> PatientMedulaHastaKabulleri;
        
#endregion EpisodeActionMedulaHastaKabulForm_Methods
    }
}