//$F33E385E
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class SendMessageToPatientServiceController
    {
        partial void PreScript_SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel, SendMessageToPatient sendMessageToPatient, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._SendMessageToPatient.SubEpisode = episodeAction.SubEpisode;
            }

            Guid? selectedPatientID = viewModel.GetSelectedPatientID();
            if (selectedPatientID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value);
                viewModel._SendMessageToPatient.Patient = patient;
            }

            ContextToViewModel(viewModel, objectContext);
            viewModel._SendMessageToPatient.MessageDate = DateTime.Now;
            BindingList<SKRSHastaMesajlari> _messageList = SKRSHastaMesajlari.GetHastaMesajlariByKodu(objectContext, 4);
            viewModel.HastaMesajlari = _messageList[0];
        }

        partial void AfterContextSaveScript_SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel, SendMessageToPatient sendMessageToPatient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                sendMessageToPatient.SubEpisode = episodeAction.SubEpisode;
            }

            Guid? selectedPatientID = viewModel.GetSelectedPatientID();
            if (selectedPatientID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value);
                sendMessageToPatient.Patient = patient;
            }
            new SendToENabiz(objectContext, sendMessageToPatient.SubEpisode, sendMessageToPatient.ObjectID, sendMessageToPatient.ObjectDef.Name,"411", Common.RecTime());
            objectContext.Save();
            //Mesaj gönder
            //SendENabizMessageToPatient(Convert.ToInt64(sendMessageToPatient.Patient.UniqueRefNo), sendMessageToPatient.SubEpisode.SYSTakipNo, viewModel._SendMessageToPatient.SKRSHastaMesajlari, viewModel._SendMessageToPatient.MessageInfo);
            SendENabizMessageToPatientWGuid(sendMessageToPatient.ObjectID);

        }
        public void SendENabizMessageToPatientWGuid(Guid sendMessageToPatient)
        {

            SendToENabiz sendToENabiz = new SendToENabiz();
            sendToENabiz.ENABIZSend411(sendMessageToPatient.ToString());
        }
        private void SendENabizMessageToPatient(long PatientTC, string SYSTakipNo, SKRSHastaMesajlari hastaMesajlari, string MessageInfo)
        {
            NabizHBYSServis.HastaMesajGonderTalep input = new NabizHBYSServis.HastaMesajGonderTalep();
            input.SKRS_HASTA_MESAJLARI_KODU = Convert.ToInt32(hastaMesajlari.KODU);
            input.SKRS_HASTA_MESAJLARI_ADI = hastaMesajlari.ADI;
            input.HASTA_KIMLIK_NUMARASI = PatientTC;
            input.MESAJ_TARIHI = DateTime.Now;
            input.MESAJ_DETAYI = MessageInfo;
            input.SYSTakipNo = SYSTakipNo;
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition != null)
                input.KURUM_KODU = myTesisSKRSKurumlarDefinition.KODU.ToString(); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
            else
                throw new Exception(TTUtils.CultureService.GetText("M26365", "Kurum Kodu Bulunamadı."));
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            NabizHBYSServis.HastaMesajGonderCevap result = NabizHBYSServis.WebMethods.HastaMesajGonderSync(siteIDGuid, input);
        }
    }
}

namespace Core.Models
{
    public partial class SendMessageToPatientFormViewModel
    {
        public SKRSHastaMesajlari HastaMesajlari
        {
            get;
            set;
        }
    }
}