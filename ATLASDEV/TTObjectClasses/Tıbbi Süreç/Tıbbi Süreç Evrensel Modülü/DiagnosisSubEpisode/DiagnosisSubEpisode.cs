
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
    public  partial class DiagnosisSubEpisode : TTObject
    {

        protected override void PreInsert()
        {
            base.PreInsert();
            CreateSEPDiagnosis();
            ControlAdmissionType();
        }

        protected override void PostInsert()
        {
            base.PostInsert();
            SendToEnabiz103();
        }

        protected override void PreDelete()
        {
            base.PreDelete();
            DeleteSEPDiagnosis();
            SendToEnabiz103();

        }


        public void CreateSEPDiagnosis()
        {
            IList<SEPDiagnosis> sepDiagnosisList = SEPDiagnosis.Select("").ToList();
            foreach (SubEpisodeProtocol sep in SubEpisode.SubEpisodeProtocols)
            {
                if (sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && !sep.IsInvoiced && !sepDiagnosisList.Where(x => x.SubEpisodeProtocol.ObjectID == sep.ObjectID).Any())
                {
                    SEPDiagnosis sepDiagnosis = new SEPDiagnosis(ObjectContext);
                    sepDiagnosis.DiagnosisGrid = DiagnosisGrid;
                    sepDiagnosis.SubEpisodeProtocol = sep;
                    sepDiagnosis.Diagnose = DiagnosisGrid.Diagnose;
                    sepDiagnosis.DiagnosisType = DiagnosisGrid.DiagnosisType;
                    sepDiagnosis.IsMainDiagnose = DiagnosisGrid.IsMainDiagnose;
                    sepDiagnosis.OzelDurum = DiagnosisGrid.OzelDurum;
                    sepDiagnosis.DiagnosisSubEpisode = this;
                }
            }
        }

        public void DeleteSEPDiagnosis()
        {
            IList<SEPDiagnosis> sepDiagnosisList = SEPDiagnosis.Select("").ToList();
            foreach (SEPDiagnosis sepDiagnosis in sepDiagnosisList)
            {
                ((ITTObject)sepDiagnosis).Delete();
            }
        }

        public void SendToEnabiz103()
        {
            var sendToENabiz = true;
            if (DiagnosisGrid.EpisodeAction != null)
                sendToENabiz = DiagnosisGrid.EpisodeAction.SendToENabiz();
            else if (DiagnosisGrid.SubactionProcedure != null)
                sendToENabiz = DiagnosisGrid.SubactionProcedure.SendToENabiz(false);
            if(sendToENabiz)
                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
          
        }

        public void ControlAdmissionType()
        {
            if (SubEpisode.PatientAdmission?.AdmissionType != null && this.DiagnosisGrid?.Diagnose?.AdmissionType != null)
            {
                  if(SubEpisode.PatientAdmission?.AdmissionType != this.DiagnosisGrid?.Diagnose?.AdmissionType)
                    throw new Exception("Bu tanı sadece geliş sebebi " + this.DiagnosisGrid.Diagnose.AdmissionType.provizyonTipiAdi + " olan kabullere girilebilir");
            }
        }
    }
}