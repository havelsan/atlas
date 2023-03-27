
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
    public partial class PatientMedulaHastaKabulForm : TTForm
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
#region PatientMedulaHastaKabulForm_PreScript
    if (this.PatientMedulaHastaKabulleri == null)
                this.PatientMedulaHastaKabulleri = this._PatientAdmission.Episode.Patient.PatientMedulaHastaKabulleri.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(PatientMedulaHastaKabul.States.Valid) + " AND EPISODE IS NULL");
            if (this.PatientMedulaHastaKabulleri.Count == 0)
                throw new TTException(SystemMessage.GetMessage(708));

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
#endregion PatientMedulaHastaKabulForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientMedulaHastaKabulForm_PostScript
    if (listviewPatientMedulaHastaKabul.SelectedItems.Count == 0)
                throw new Exception(SystemMessage.GetMessage(700)); ;

            ITTListViewItem listViewItem = listviewPatientMedulaHastaKabul.SelectedItems[0];
            if (listViewItem.Tag == null && (listViewItem.Tag is PatientMedulaHastaKabul) == false)
                throw new Exception(SystemMessage.GetMessage(700));

            this._PatientAdmission.PatientMedulaHastaKabul = (PatientMedulaHastaKabul)listViewItem.Tag;
#endregion PatientMedulaHastaKabulForm_PostScript

            }
            
#region PatientMedulaHastaKabulForm_Methods
        public BindingList<PatientMedulaHastaKabul> PatientMedulaHastaKabulleri;
        
#endregion PatientMedulaHastaKabulForm_Methods
    }
}