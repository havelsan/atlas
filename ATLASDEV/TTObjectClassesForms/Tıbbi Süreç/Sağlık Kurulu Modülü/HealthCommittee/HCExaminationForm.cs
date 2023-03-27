
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCExaminationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            RationWeight.TextChanged += new TTControlEventDelegate(RationWeight_TextChanged);
            RationHeight.TextChanged += new TTControlEventDelegate(RationHeight_TextChanged);
            HCRequestReason.SelectedObjectChanged += new TTControlEventDelegate(HCRequestReason_SelectedObjectChanged);
            // UnsuitableForMilitServ.CheckedChanged += new TTControlEventDelegate(UnsuitableForMilitServ_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RationWeight.TextChanged -= new TTControlEventDelegate(RationWeight_TextChanged);
            RationHeight.TextChanged -= new TTControlEventDelegate(RationHeight_TextChanged);
            HCRequestReason.SelectedObjectChanged -= new TTControlEventDelegate(HCRequestReason_SelectedObjectChanged);
            //  UnsuitableForMilitServ.CheckedChanged -= new TTControlEventDelegate(UnsuitableForMilitServ_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void HCRequestReason_SelectedObjectChanged()
        {
            #region HCExaminationForm_HCRequestReason_SelectedObjectChanged

            if (_HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
            {
                ttgroupEngel.Visible = true;
                ttgroupKullanimAmaci.Visible = true;
                labelUnworkField.Visible = true;
                UnworkField.Visible = true;
                IsHeavyDisabled.Visible = true;
                labelSendExamination.Visible = true;
                SendExamination.Visible = true;
            }
            else
            {
                ttgroupEngel.Visible = false;
                ttgroupKullanimAmaci.Visible = false;
                labelUnworkField.Visible = false;
                UnworkField.Visible = false;
                IsHeavyDisabled.Visible = false;
                labelSendExamination.Visible = false;
                SendExamination.Visible = false;
            }

            #endregion HCExaminationForm_HCRequestReason_SelectedObjectChanged
        }
        private void RationWeight_TextChanged()
        {
            #region HCExaminationForm_RationWeight_TextChanged
            //          double weight = 0F,height = 1F;
            //          double index = 0F;
            //          double.TryParse(this.RationWeight.Text, out weight);
            //          double.TryParse(this.RationHeight.Text, out height);
            double height = 1;
            double weight = 0;
            double index = 0;
            if (this.RationHeight.Text != "")
                height = Convert.ToDouble(this.RationHeight.Text) / 100;
            if (this.RationWeight.Text != "")
                weight = Convert.ToDouble(this.RationWeight.Text);
            if (height == 0) height = 1;
            index = (weight / (height * height));
            this.BodyMassIndex.Text = index.ToString();
            #endregion HCExaminationForm_RationWeight_TextChanged
        }

        private void RationHeight_TextChanged()
        {
            #region HCExaminationForm_RationHeight_TextChanged
            //            double weight = 0F,height = 1F;
            //            double index = 0F;
            //            double.TryParse(this.RationWeight.Text, out weight);
            //            double.TryParse(this.RationHeight.Text, out height);
            //            if(height == 0) height = 1;
            //            index = (weight / (height*height));
            //            this.OtherMeasurements.Text = index.ToString();

            double height = 1;
            double weight = 0;
            double index = 0;
            if (this.RationHeight.Text != "")
                height = Convert.ToDouble(this.RationHeight.Text) / 100;
            if (this.RationWeight.Text != "")
                weight = Convert.ToDouble(this.RationWeight.Text);
            if (height == 0) height = 1;
            index = (weight / (height * height));
            this.BodyMassIndex.Text = index.ToString();
            #endregion HCExaminationForm_RationHeight_TextChanged
        }

        private void UnsuitableForMilitServ_CheckedChanged()
        {
            #region HCExaminationForm_UnsuitableForMilitServ_CheckedChanged
            //if (this._HealthCommittee.MemberOfHealthCommittee != null && this._HealthCommittee.UnsuitableForMilitaryService == true)
            //         {
            //    if (this._HealthCommittee.MemberOfHealthCommittee.AdditionalMembers.Count == 0)
            //    {
            //        InfoBox.Show("Sağlık Kurulu Heyet Teşkili Tanımlarında İlave İmzacı Üyeler tanımlanmamış! ");
            //        this._HealthCommittee.UnsuitableForMilitaryService = false;
            //    }
            //  }
            #endregion HCExaminationForm_UnsuitableForMilitServ_CheckedChanged
        }



        protected override void PreScript()
        {
            #region HCExaminationForm_PreScript
            base.PreScript();
            this.SetEpisodeRelations();
            this.SetDocumentNumber();

            this.FillHCExaminationInfos();

            this._HealthCommittee.HCHeight = this._HealthCommittee.ClinicHeight;
            this._HealthCommittee.HCWeight = this._HealthCommittee.ClinicWeight;

            if (this._HealthCommittee.HCRequestReason != null && this._HealthCommittee.HCRequestReason.ReasonForExamination != null)
            {
                HCRequestReason.ListFilterExpression = "REASONFOREXAMINATION='" + this._HealthCommittee.HCRequestReason.ReasonForExamination.ObjectID.ToString() + "'";
            }

            if (HealthCommittee.CheckIfAllCancelledOrNotExists(this._HealthCommittee))
            {
                //throw new Exception("Hastaya ait Sağlık Kurulu Muayenesi bulunmamaktadır!\r\nİşleme devam edilemez.");
                throw new TTUtils.TTException(SystemMessage.GetMessage(486));
            }

            if (_HealthCommittee.HCRequestReason != null && _HealthCommittee.HCRequestReason.ReasonForExamination != null && _HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
            {
                if (_HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                {
                    double? ratio = HealthCommittee.CalculateFunctionRatio(this._HealthCommittee);
                    if (ratio != null)
                        this._HealthCommittee.FunctionRatio = ratio;
                }
            }


            string HCReportIntendedUseEvaluation = TTObjectClasses.SystemParameter.GetParameterValue("HCREPORTINTENDEDUSEEVALUATION", null);
            if (HCReportIntendedUseEvaluation == "Değerlendirilmedi")
            {
                this.EducationEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.EmploymentEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.SocialAidEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.DisabledChaiEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                this.LawNo2022EvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
            }
            else if (HCReportIntendedUseEvaluation == "Hayır")
            {
                this.EducationEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.EmploymentEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.SocialAidEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.DisabledChaiEvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
                this.LawNo2022EvaluationIntendedUseOfDisabledReport.SelectedValue = EvetHayirDegerlendirilmediEnum.Hayir;
            }

            if (_HealthCommittee.ReportDiagnosis == null)
            {
                int i = 0;
                foreach (DiagnosisGrid diagnose in _HealthCommittee.Episode.Diagnosis)
                {
                    i++;
                    if (diagnose.Diagnose != null)
                    {
                        _HealthCommittee.ReportDiagnose += diagnose.Diagnose.Name;
                        if (i != _HealthCommittee.Episode.Diagnosis.Count)
                            _HealthCommittee.ReportDiagnose += " + ";
                    }
                }
            }


            // Uçucu Sağlık Kurulu ile ilgili alanların görünür yapılması
            //if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee)
            //{
            //    this.lblAircraftType.Visible = true;
            //    this.AircraftType.Visible = true;
            //    this.lblLastHealthCommitteeResult.Visible = true;
            //    this.LastHealthCommitteeResult.Visible = true;
            //    this.lblHCDutyType.Visible = true;
            //    this.HCDutyType.Visible = true;
            //}

            //Picture Setting
            //GroupBox pBox2 = (GroupBox)this.ttgroupbox2;
            //PictureBox pic = new PictureBox();
            //pic.Dock = DockStyle.Fill;
            //pic.BackgroundImage = (Image)this._HealthCommittee.Picture;
            //pic.BackgroundImageLayout = ImageLayout.Zoom;
            //pBox2.Controls.Add(pic);

            // Heyet Muayenesi adımında, Muayeneden sağlık kurulu heyet ölçümüne kopyalamak için
            //if(this._HealthCommittee.CurrentStateDefID == HealthCommittee.States.CommitteeExamination)
            //{
            //    foreach(EpisodeAction episodeAction in this._HealthCommittee.LinkedActions)
            //    {
            //        if(episodeAction is HealthCommitteeExamination)
            //        {
            //            HealthCommitteeExamination hce = (HealthCommitteeExamination)episodeAction;
            //            if(hce.MasterResource is ResPoliclinic)
            //            {
            //                ResPoliclinic policlinic = (ResPoliclinic)hce.MasterResource;
            //                if(policlinic.CopyHeightWeight == true)
            //                {
            //                    this._HealthCommittee.HCHeight = hce.Height;
            //                    this._HealthCommittee.HCWeight = hce.Weight;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}


            #endregion HCExaminationForm_PreScript

        }
        protected override void ClientSidePreScript()
        {
            #region HCExaminationForm_ClientSidePreScript
            base.ClientSidePreScript();

            if (_HealthCommittee.HCRequestReason != null && _HealthCommittee.HCRequestReason.ReasonForExamination != null && _HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
            {
                if (_HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                {
                    ttgroupEngel.Visible = true;
                    ttgroupKullanimAmaci.Visible = true;
                    labelUnworkField.Visible = true;
                    UnworkField.Visible = true;
                    IsHeavyDisabled.Visible = true;
                    labelSendExamination.Visible = true;
                    SendExamination.Visible = true;
                    //  DecisionOffer.Visible = false;
                    HealthCommitteeDecision.DisplayText = "Teşhisler";
                    FunctionRatio.Visible = true;
                }
                else
                {
                    ttgroupEngel.Visible = false;
                    ttgroupKullanimAmaci.Visible = false;
                    labelUnworkField.Visible = false;
                    UnworkField.Visible = false;
                    IsHeavyDisabled.Visible = false;
                    labelSendExamination.Visible = false;
                    SendExamination.Visible = false;
                    //DecisionOffer.Visible = true;
                    HealthCommitteeDecision.DisplayText = "Karar";
                    FunctionRatio.Visible = false
                        ;
                }
            }
            #endregion HCExaminationForm_ClientSidePreScript
        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region HCExaminationForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);

            if (transDef != null)
            {
                //if (transDef.FromStateDefID.Equals(HealthCommittee.States.CommitteeExamination) && transDef.ToStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance))
                //{
                //    if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Heyet Kabul", "Herhangi bir Sağlık Kurulu Muayenesini kliniğe iade etmek istiyor musunuz?\r\n") == "E")
                //        BackCommitteeForReturn();
                //}               
            }
            #endregion HCExaminationForm_ClientSidePostScript

        }

        #region HCExaminationForm_Methods
        private void SetEpisodeRelations()
        {
            //            MilitaryClassDefinitions militaryClass= this._HealthCommittee.Episode.MyMilitaryClass();
            //            if (militaryClass!=null)
            //            {
            //                this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            //            }

            //            RankDefinitions rank= this._HealthCommittee.Episode.MyRank();
            //            if (rank!=null)
            //            {
            //                this.Rank.SelectedObjectID=rank.ObjectID;
            //            }

            //            MilitaryOffice militaryOffice = this._HealthCommittee.Episode.MyMilitaryOffice();
            //            if (militaryOffice!=null)
            //            {
            //                this._HealthCommittee.LocalBranch = militaryOffice;
            //                this.MilitaryOffice.SelectedObjectID=militaryOffice.ObjectID;
            //            }




            //this.EmploymentRecordID.Text = this._HealthCommittee.Episode.MyEmploymentRecordID();

            //            MilitaryUnit pMUnit = this._HealthCommittee.Episode.MyMilitaryUnit();
            //            if(pMUnit != null)
            //            {
            //                this.MilitaryUnit.SelectedObjectID = pMUnit.ObjectID;
            //            }

            //this.Adres.Text = this._HealthCommittee.Episode.MyAddress();

            this.DocumentNumber.Text = SubEpisode.MyDocumentNumber(this._HealthCommittee.SubEpisode);

            DateTime? pDocDate = SubEpisode.MyDocumentDate(this._HealthCommittee.SubEpisode);
            if (pDocDate != null)
                this.DocumentDate.ControlValue = pDocDate.Value;
        }

        private void SetDocumentNumber()
        {
            int nDocNumber = 0;
            string sCategory = "";
            /*
            switch(this._HealthCommittee.SubEpisode.PatientAdmission.PatientGroup.Value)
            {
                case PatientGroupEnum.NoncommissionedOfficer:
                    sCategory = "Astsubay";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.NoncommissionedOfficerFamily:
                    sCategory = "Astsubay Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredNoncommissionedOfficer:
                    sCategory = "Emekli Astsubay";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredNoncommissionedOfficerFamily:
                    sCategory = "Emekli Astsubay Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredExpertGendarmeFamily:
                    sCategory = "Emekli Uzman Jandarma Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredExpertGendarme:
                    sCategory = "Emekli Uzman Jandarma";
                    nDocNumber = 1;
                    break;
                    //sözleşmeli Astsubay eklenecek
                case PatientGroupEnum.GeneralAdmiral:
                    sCategory = "General//Amiral";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredGeneral:
                    sCategory = "Emekli General";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredGeneralFamily:
                    sCategory = "Emekli General/Amiral Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.GeneralAdmiralFamily:
                    sCategory = "Emekli General/Amiral Ailesi";
                    nDocNumber = 1;
                    break;
                    //Kurmay Subay eklenecek
                case PatientGroupEnum.Officer:
                    sCategory = "Subay";
                    nDocNumber = 1;
                    break;
                    
                case PatientGroupEnum.OfficerFamily:
                    sCategory = "Subay Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredOfficerFamily:
                    sCategory = "Emekli Subay Ailesi";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.RetiredOfficer:
                    sCategory = "Emekli Subay";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.DischargedReserveOfficer:
                    sCategory = "Terhisli Yedek Subay";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.VisitorOfficer:
                    sCategory = "Misafir Subay";
                    nDocNumber = 1;
                    break;
                case PatientGroupEnum.VisitorOfficerFamily:
                    sCategory = "Misafir Subay Ailesi";
                    nDocNumber = 1;
                    break;
                    //                case PatientGroupEnum.MilitaryNurseCandidate:
                    //                    nDocNumber = 2;
                    //                    break;
                    //Case UCase("HEMŞİRE"),UCase("HEMŞİRE ADAYI"),UCase("HEMŞİRE AİLESİ"),UCase("HEMŞİRE E AİLESİ"),UCase("HEMŞİRE EMEKLİSİ")
                case PatientGroupEnum.MilitaryCivilOfficial:
                    sCategory = "XXXXXX Sivil Memur";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.MilitaryCivilOfficialCandidate:
                    sCategory = "XXXXXX Sivil Memur Adayı";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.MilitaryCivilOfficialFamily:
                    sCategory = "XXXXXX Sivil Memur Ailesi";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.RetiredMilitaryCivilOfficialFamily:
                    sCategory = "Emekli XXXXXX Sivil Memur Ailesi";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.ExpertNonCom:
                    sCategory = "Uzman Erbaş";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.ExpertNonComCandidate:
                    sCategory = "Uzman Erbaş Adayı";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.ExpertNonComFamily:
                    sCategory = "Uzman Erbaş Ailesi";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.RetiredExpertNonCom:
                    sCategory = "Emekli Uzman Erbaş";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.RetiredExpertNonComFamily:
                    sCategory = "Emekli Uzman Erbaş Ailesi";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.ExpertGendarme:
                    sCategory = "Uzman Jandarma";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.ExpertGendarmeFamily:
                    sCategory = "Uzman Jandarma Ailesi";
                    nDocNumber = 2;
                    break;
                    //UCase("TERHISLI UZER AILESI"),UCase("TERHISLI UZMAN ERBAS")
                case PatientGroupEnum.MilitaryWorker:
                    sCategory = "Uzman Jandarma Ailesi";
                    nDocNumber = 2;
                    break;
                case PatientGroupEnum.MilitaryWorkerCandidate:
                    sCategory = "XXXXXX İşçi Adayı";
                    nDocNumber = 2;
                    break;
                    
                    
                    //Case UCase("SEVKETABIYEDEKSUBAYA"),UCase("YEDEK SUBAY ADAYI")
                case PatientGroupEnum.Cadet:
                    sCategory = "XXXXXX Öğrenci";
                    nDocNumber = 3;
                    break;
                case PatientGroupEnum.CadetCandidate:
                    sCategory = "XXXXXX Öğrenci Adayı";
                    nDocNumber = 3;
                    break;
                case PatientGroupEnum.VisitorCadet:
                    sCategory = "Misafir XXXXXX Öğrenci";
                    nDocNumber = 3;
                    break;
                case PatientGroupEnum.RetiredCivilian:
                    sCategory = "Sivil Emekli";
                    nDocNumber = 5;
                    break;
                case PatientGroupEnum.PaidCivilian:
                    sCategory = "Sivil Ücretli";
                    nDocNumber = 5;
                    break;
                case PatientGroupEnum.CivilianConsignment:
                    sCategory = "Sivil Sevkli";
                    nDocNumber = 5;
                    break;
                case PatientGroupEnum.UnpaidCivilian:
                    sCategory = "Sivil Ücretsiz";
                    nDocNumber = 5;
                    break;
                case PatientGroupEnum.PrivateNonCom:
                    sCategory = "Er";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.TemporaryVillageSecurity:
                    sCategory = "Geçici Köy Korucusu";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.MartyrFamily:
                    sCategory = "Şehit Ailesi";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.ConsignmentPrivate:
                    sCategory = "Sevk Eri";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.RollCallPrivate:
                    sCategory = "Yoklama Eri";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.PatientWithGreenCard:
                    sCategory = "Yeşil Kartlı Hasta";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.DischargedPrivate:
                    sCategory = "Terhisli Er";
                    nDocNumber = 7;
                    break;
                case PatientGroupEnum.PrimeMinistry:
                    //Case UCase("BAŞBAKANLIK (F022)"),UCase("EMEKLIER"),UCase("EMEKLIERAILESI"),UCase("FAKIR")
                    //Case UCase("KOY KORUYUCUSU"),UCase("PEŞMERGE")
                    sCategory = "Terhisli Erbaş";
                    nDocNumber = 7;
                    break;
                    
                default:
                    sCategory = this._HealthCommittee.SubEpisode.PatientAdmission.ObjectDef.Description;
                    nDocNumber = 4;
                    break;
            }
             */
            nDocNumber = 1;  // defter numaralarının kaldırılması istendi bu yüzden hepsi 1 yapıldı

            if (!((ITTObject)this._HealthCommittee).IsReadOnly)
            {
                this.BookNumber.Text = nDocNumber.ToString();
            }
        }


        private void FillHCExaminationInfos()
        {
            ArrayList actions = EpisodeAction.GetLinkedEpisodeActions(this._HealthCommittee);
            IList diagnosisCodeList = new List<string>();
            IList MatterSliceAnectodeGridControlList = new List<string>();
            string offerOfDecision = String.Empty;
            string control = string.Empty;

            // Tanılar tekrar eklenmemesini kontrol etmek için listeye eklenir
            foreach (HealthCommittee_DiagnosisGrid HCDiagnosis in _HealthCommittee.Diagnosis)
                diagnosisCodeList.Add(HCDiagnosis.Diagnose.Code);

            // Madde, Dilim, Fıkralar tekrar eklenmemesini kontrol etmek için listeye eklenir
            foreach (HealthCommittee_MatterSliceAnectodeGrid HCmsa in _HealthCommittee.MatterSliceAnectodes)
            {
                control = (HCmsa.Matter != null) ? HCmsa.Matter.Value.ToString() : "";
                control += (HCmsa.Slice != null) ? HCmsa.Slice.Value.ToString() : "";
                control += (HCmsa.Anectode != null) ? HCmsa.Anectode.Value.ToString() : "";
                MatterSliceAnectodeGridControlList.Add(control);
            }

            foreach (EpisodeAction eaction in actions)
            {
                if (eaction is HealthCommitteeExamination)
                {
                    HealthCommitteeExamination pExam = eaction as HealthCommitteeExamination;

                    if (!pExam.IsCancelled && pExam.CurrentStateDefID != HealthCommitteeExamination.States.PatientNoShown)
                    {
                        // Tanılar
                        foreach (DiagnosisGrid pChildGrid in pExam.SecDiagnosis)
                        {
                            if (pChildGrid.DiagnoseCode.Trim() != "Z13.9") // Z13.9 tanısı gride eklenmeyecek
                            {
                                if (!diagnosisCodeList.Contains(pChildGrid.Diagnose.Code)) // Gridde olan tanılar tekrar eklenmeyecek
                                {
                                    HealthCommittee_DiagnosisGrid diagnosis = new HealthCommittee_DiagnosisGrid(_HealthCommittee.ObjectContext);
                                    _HealthCommittee.Diagnosis.Add(diagnosis);
                                    diagnosis.AddToHistory = pChildGrid.AddToHistory;
                                    diagnosis.Diagnose = pChildGrid.Diagnose;
                                    diagnosis.FreeDiagnosis = pChildGrid.FreeDiagnosis;
                                    diagnosis.IsMainDiagnose = pChildGrid.IsMainDiagnose;
                                    diagnosis.ResponsibleUser = pChildGrid.ResponsibleUser;
                                    diagnosis.DiagnoseDate = pChildGrid.DiagnoseDate;
                                    diagnosisCodeList.Add(pChildGrid.Diagnose.Code);
                                }
                            }
                        }
                        // Karar Teklifi
                        if (pExam.OfferOfDecision != null)
                        {
                            if (pExam.OfferOfDecision.Trim() != "")
                                offerOfDecision += pExam.OfferOfDecision + "\r\n\r\n";

                            if (_HealthCommittee.HCRequestReason != null && _HealthCommittee.HCRequestReason.ReasonForExamination != null && _HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                            {
                                if (_HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                                {
                                    IList<SystemForDisabledReportDefinition> sdrList = SystemForDisabledReportDefinition.GetAllSystemForDisabledReportDef(this._HealthCommittee.ObjectContext);
                                    foreach (SystemForDisabledReportDefinition sdr in sdrList)
                                    {
                                        SystemForHealthCommitteeGrid systemForHealthCommitteeGrid = new SystemForHealthCommitteeGrid(this._HealthCommittee.ObjectContext);
                                        systemForHealthCommitteeGrid.SystemForDisabled = sdr;

                                        foreach (DisabledReportSpecialGrid disabledReportSpecial in sdr.DisabledReport)
                                        {
                                            if (disabledReportSpecial.Speciality.ObjectID == pExam.ProcedureSpeciality.ObjectID)
                                                systemForHealthCommitteeGrid.DisabledOfferDecision += pExam.OfferOfDecision;
                                        }
                                        this._HealthCommittee.SystemForHealthCommitteeGrid.Add(systemForHealthCommitteeGrid);
                                    }
                                }
                            }
                        }

                        //Madde, Dilim, Fıkra
                        foreach (MatterSliceAnectodeGrid mAnectode in pExam.MatterSliceAnectodes)
                        {
                            control = (mAnectode.Matter != null) ? mAnectode.Matter.Value.ToString() : "";
                            control += (mAnectode.Slice != null) ? mAnectode.Slice.Value.ToString() : "";
                            control += (mAnectode.Anectode != null) ? mAnectode.Anectode.Value.ToString() : "";

                            if (!MatterSliceAnectodeGridControlList.Contains(control))
                            {
                                HealthCommittee_MatterSliceAnectodeGrid mSAnectode = new HealthCommittee_MatterSliceAnectodeGrid(_HealthCommittee.ObjectContext);
                                _HealthCommittee.MatterSliceAnectodes.Add(mSAnectode);
                                mSAnectode.Matter = mAnectode.Matter;
                                mSAnectode.Slice = mAnectode.Slice;
                                mSAnectode.Anectode = mAnectode.Anectode;
                                MatterSliceAnectodeGridControlList.Add(control);
                            }
                        }
                    }
                }
                //else if (eaction is HealthCommitteeExaminationFromOtherHospitals)
                //{
                //    HealthCommitteeExaminationFromOtherHospitals pExam = eaction as HealthCommitteeExaminationFromOtherHospitals;

                //    if (!pExam.IsCancelled)
                //    {
                //        // Tanılar
                //        foreach (DiagnosisGrid pChildGrid in pExam.SecDiagnosis)
                //        {
                //            if (pChildGrid.DiagnoseCode.Trim() != "Z13.9") // Z13.9 tanısı gride eklenmeyecek
                //            {
                //                if (!diagnosisCodeList.Contains(pChildGrid.Diagnose.Code)) // Gridde olan tanılar tekrar eklenmeyecek
                //                {
                //                    HealthCommittee_DiagnosisGrid diagnosis = new HealthCommittee_DiagnosisGrid(_HealthCommittee.ObjectContext);
                //                    _HealthCommittee.Diagnosis.Add(diagnosis);
                //                    diagnosis.AddToHistory = pChildGrid.AddToHistory;
                //                    diagnosis.Diagnose = pChildGrid.Diagnose;
                //                    diagnosis.FreeDiagnosis = pChildGrid.FreeDiagnosis;
                //                    diagnosis.IsMainDiagnose = pChildGrid.IsMainDiagnose;
                //                    diagnosis.ResponsibleUser = pChildGrid.ResponsibleUser;
                //                    diagnosis.DiagnoseDate = pChildGrid.DiagnoseDate;
                //                    diagnosisCodeList.Add(pChildGrid.Diagnose.Code);
                //                }
                //            }
                //        }
                //        // Karar Teklifi
                //        if (pExam.OfferOfDecision != null)
                //        {
                //            if (pExam.OfferOfDecision.Trim() != "")
                //                offerOfDecision += pExam.OfferOfDecision + "\r\n\r\n";
                //        }
                //        //Madde, Dilim, Fıkra
                //        foreach (MatterSliceAnectodeGrid mAnectodeForOtherHosp in pExam.MatterSliceAnectodes)
                //        {
                //            control = (mAnectodeForOtherHosp.Matter != null) ? mAnectodeForOtherHosp.Matter.Value.ToString() : "";
                //            control += (mAnectodeForOtherHosp.Slice != null) ? mAnectodeForOtherHosp.Slice.Value.ToString() : "";
                //            control += (mAnectodeForOtherHosp.Anectode != null) ? mAnectodeForOtherHosp.Anectode.Value.ToString() : "";

                //            if (!MatterSliceAnectodeGridControlList.Contains(control))
                //            {
                //                HealthCommittee_MatterSliceAnectodeGrid mSAnectode = new HealthCommittee_MatterSliceAnectodeGrid(_HealthCommittee.ObjectContext);
                //                _HealthCommittee.MatterSliceAnectodes.Add(mSAnectode);
                //                mSAnectode.Matter = mAnectodeForOtherHosp.Matter;
                //                mSAnectode.Slice = mAnectodeForOtherHosp.Slice;
                //                mSAnectode.Anectode = mAnectodeForOtherHosp.Anectode;
                //                MatterSliceAnectodeGridControlList.Add(control);
                //            }
                //        }
                //    }
                //}
            }

            //Karar Teklifi alanı boş ise muayenelerdekileri getirsin
            if (!((ITTObject)this._HealthCommittee).IsReadOnly)
            {
                if (_HealthCommittee.DecisionOffer == null)
                    _HealthCommittee.DecisionOffer = Common.GetRTFOfTextString(offerOfDecision);
                else
                {
                    if (Common.GetTextOfRTFString(_HealthCommittee.DecisionOffer.ToString()).Trim() == "")
                        _HealthCommittee.DecisionOffer = Common.GetRTFOfTextString(offerOfDecision);
                }
            }
        }

        #endregion HCExaminationForm_Methods

        #region HCExaminationForm_ClientSideMethods
        private void BackCommitteeForReturn()
        {
            //ArrayList arrList = this._HealthCommittee.GetLinkedEpisodeActions();
            //MultiSelectForm theFrm = new MultiSelectForm();
            //foreach (EpisodeAction eaction in arrList)
            //{
            //    HealthCommitteeExamination exam = eaction as HealthCommitteeExamination;
            //    if (exam != null && exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
            //        theFrm.AddMSItem("İşlem no :" + exam.ID.Value.ToString() + ", Bölüm :" + exam.MasterResource.Name, exam.ObjectID.ToString(), exam);
            //}

            //string sKey = theFrm.GetMSItem(this, "İade edilen muayeneyi seçiniz.", true, true, true);
            //if (!string.IsNullOrEmpty(sKey))
            //{
            //    string returnDescription = "";
            //    foreach (object a in theFrm.MSSelectedItemObjects)
            //    {
            //        //HealthCommitteeExamination theExam = (HealthCommitteeExamination)this._HealthCommittee.ObjectContext.GetObject(new Guid(sKey),"HealthCommitteeExamination");
            //        HealthCommitteeExamination theExam = a as HealthCommitteeExamination;
            //        ITTObject pObject = (ITTObject)theExam;
            //        pObject.UndoLastTransition();

            //        StringEntryForm pEntryFrm = new StringEntryForm();
            //        DialogResult res = pEntryFrm.ShowStringDialog(this, "İade Sebebini Giriniz (" + theExam.MasterResource.Name + ")");
            //        if (res == DialogResult.OK)
            //        {
            //            returnDescription += pEntryFrm.StringContent + " , ";
            //            theExam.ReturnDescription = pEntryFrm.StringContent;
            //            theExam.ReturnDate = Common.RecTime();
            //            theExam.Update();
            //        }
            //    }
            //   // this._HealthCommittee.ClinicalReturnDescription = returnDescription.Substring(0, (returnDescription.Length - 3));
            //}
            //else
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(80));
        }

        #endregion HCExaminationForm_ClientSideMethods
    }
}