//$DCE41A1D
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class DispatchToOtherHospitalServiceController
    {
        partial void PreScript_DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel, DispatchToOtherHospital dispatchToOtherHospital, TTObjectContext objectContext)
        {
            if (((ITTObject)dispatchToOtherHospital).IsNew)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    viewModel._DispatchToOtherHospital.SetMyPropertiesByMasterAction(episodeAction);
                    viewModel._DispatchToOtherHospital.MasterAction = episodeAction;
                    viewModel._DispatchToOtherHospital.ProcedureSpeciality = episodeAction.ProcedureSpeciality;

                    if (dispatchToOtherHospital.Episode.Diagnosis.Count == 0)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25312", "Bu i�lem herhangi bir tan�s� olmayan vakalarda ba�lat�lamaz."));
                    //var _medula = dispatchToOtherHospital.SubEpisode.SubEpisodeProtocols.FirstOrDefault(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && !string.IsNullOrEmpty(x.MedulaTakipNo));
                    //var _medula = dispatchToOtherHospital.SubEpisode.SGKSEPWithProvisionNo;
                    //if (_medula == null)
                    //{
                    //    throw new TTUtils.TTException("Provizyon Numaras� Olmayan Kabuller ��in Sevk i�lemi ba�lat�lamaz.");
                    //}
                }

                if (Common.CurrentDoctor != null)
                {
                    DoctorGrid dg = new DoctorGrid(objectContext);
                    dg.ResUser = Common.CurrentDoctor;
                    dispatchToOtherHospital.DoctorsGrid.Add(dg);
                }
            }

            viewModel.isSGK = dispatchToOtherHospital.SubEpisode.IsSGK;
            dispatchToOtherHospital.GSSOwnerName = dispatchToOtherHospital.Episode?.Patient?.FullName;
            var formDefID = Guid.Parse("a00af0a1-7d03-4c83-bd38-c01c42ed266f");
            var objectDefID = Guid.Parse("11e3d6ee-37f5-465d-9df1-db88c4d570b1");
            objectContext.LoadFormObjects(formDefID, viewModel._DispatchToOtherHospital.ObjectID, objectDefID);
            ArrangeButtons(viewModel);
            ContextToViewModel(viewModel, objectContext);

            //ContextToViewModel den sonra �a��r�lmal� //TANI i�in
            //viewModel.GridDiagnosisGridList = dispatchToOtherHospital.DiagnosisGrid_PreScript();
        }

        partial void PostScript_DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel, DispatchToOtherHospital dispatchToOtherHospital, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //Taburcu i�lemleri �zerinden giri,� yap�ld� ise otomatik SendMedulaya ge�er
            if (viewModel.isStartedByTreatmentDischarge == true && dispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.New)
            {
                transDef = dispatchToOtherHospital.CurrentStateDef.OutgoingTransitions[DispatchToOtherHospital.States.SendMedula];
                objectContext.Update();
                dispatchToOtherHospital.CurrentStateDefID = DispatchToOtherHospital.States.SendMedula;
            }
            if (transDef != null && ((transDef.FromStateDefID == DispatchToOtherHospital.States.New && transDef.ToStateDefID == DispatchToOtherHospital.States.SendMedula) ||
                          transDef.FromStateDefID == DispatchToOtherHospital.States.DeleteDispatchProvision && transDef.ToStateDefID == DispatchToOtherHospital.States.SendMedula))
            {
                if (dispatchToOtherHospital.Episode != null && dispatchToOtherHospital.SubEpisode.IsSGK == true)
                {
                    
                    try
                    {
                        var _medula = dispatchToOtherHospital.SubEpisode.SGKSEPWithProvisionNo;

                        if (_medula == null)
                        {
                            throw new TTUtils.TTException("Provizyon Numaras� Olmayan Kabuller ��in Sevk i�lemi ba�lat�lamaz.");
                        }
                        else
                            dispatchToOtherHospital.MedulaESevkBildirSync();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }

            //TANI i�in
            //dispatchToOtherHospital.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);
        }

        public void ArrangeButtons(DispatchToOtherHospitalFormViewModel viewModel)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == DispatchToOtherHospital.States.Dispatched)
                    removedOutgoingTransitions.Add(trans);
            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }


        #region WEBSERVICE
        public void MedulaESevkBildirSync(DispatchToOtherHospital dispatchToOtherHospital)
        {
            dispatchToOtherHospital.MedulaESevkBildirSync();
            //try
            //{
            //    SevkIslemleri.sevkCevapDVO sevkCevapDVO = new SevkIslemleri.sevkCevapDVO();
            //    sevkCevapDVO = SevkIslemleri.WebMethods.sevkBildirSync(TTObjectClasses.Sites.SiteLocalHost, this.GetSevkBildirimDVO(dispatchToOtherHospital));

            //    if (sevkCevapDVO != null)
            //    {
            //        if (String.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
            //        {
            //            if (sevkCevapDVO.sonucKodu.Equals("0000"))
            //            {
            //                InfoMessageService.Instance.ShowMessage("E-sevk bildirim i�lemi ba�ar� ile sonu�land�. Sevk Takip No: " + sevkCevapDVO.sevkTakipNo);
            //                dispatchToOtherHospital.MedulaSevkTakipNo = sevkCevapDVO.sevkTakipNo;
            //            }
            //            else
            //            {
            //                if (String.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
            //                    throw new Exception("E-sevk bildiriminde hata var. Sonu� Mesaj� :" + sevkCevapDVO.sonucMesaji);
            //                else throw new Exception("E-sevk bildiriminde hata var");
            //            }
            //        }
            //        else
            //        {
            //            if (String.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
            //                throw new Exception("Medula sevk bildiriminde hata var: " + sevkCevapDVO.sonucMesaji);
            //            else throw new Exception("Medulaya e-sevk bildirimi yap�lmas� s�ras�nda hata olu�tu! Sonu� Kodu ve Sonu� Mesaj� alan� bo�!");
            //        }
            //    }
            //    else throw new Exception("Medulaya e-sevk bildirimi yap�lamad�!");
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}

        }

        //public bool MutatDisiAracRaporKaydetSync(DispatchToOtherHospital dispatchToOtherHospital)
        //{
        //    try
        //    {
        //        SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, this.GetMutatDisiRaporDVO(dispatchToOtherHospital));
        //        if (mutatDisiRaporCevapDVO != null)
        //        {
        //            if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
        //            {
        //                if (mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoMessageService.Instance.ShowMessage("Mutat d��� ara� rapor bildirim i�lemi ba�ar� ile sonu�land�. Rapor id: " + mutatDisiRaporCevapDVO.raporId);
        //                    dispatchToOtherHospital.MutatDisiAracRaporId = mutatDisiRaporCevapDVO.raporId;
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("Mutat d��� ara� rapor bildiriminde hata var. Sonu� Mesaj� :" + mutatDisiRaporCevapDVO.sonucMesaji);
        //                    else throw new Exception("Mutat d��� ara� rapor bildiriminde hata var.Sonu� mesaj� alan� bo�.");
        //                }
        //            }
        //            else
        //            {
        //                if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
        //                    throw new Exception(mutatDisiRaporCevapDVO.sonucMesaji);
        //                throw new Exception("Medulaya mutat d��� ara� rapor bildirimi yap�lmas� s�ras�nda hata olu�tu! Sonu� Kodu alan� bo�!");
        //            }
        //        }
        //        else throw new Exception("Medulaya mutat d��� ara� rapor bildirimi yap�lamad�.Cevap d�nmedi!");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Medulaya mutat d��� ara� rapor bildirimi yap�lmas� s�ras�nda hata olu�tu! " + e.Message);
        //    }

        //}

        public bool MedulaESevkBildirimIptalSync(DispatchToOtherHospital dispatchToOtherHospital)
        {
            try
            {
                SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO = SevkIslemleri.WebMethods.sevkBildirimIptalSync(TTObjectClasses.Sites.SiteLocalHost, this.GetSevkBildirimIptalDVO(dispatchToOtherHospital));
                if (sevkIptalCevapDVO != null)
                {
                    if (String.IsNullOrEmpty(sevkIptalCevapDVO.sonucKodu) == false)
                    {
                        if (sevkIptalCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoMessageService.Instance.ShowMessage("Sevk Takip No: " + dispatchToOtherHospital.MedulaSevkTakipNo + " olan sevkin ipta i�lemi ba�ar� ile sonu�land�.");
                            dispatchToOtherHospital.MedulaSevkTakipNo = null;
                            return true;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception(TTUtils.CultureService.GetText("M26847", "Sevk bildirimi ipta i�leminde hata var:Sonu� Mesaj� :")+ sevkIptalCevapDVO.sonucMesaji);
                            else throw new Exception(TTUtils.CultureService.GetText("M26849", "Sevk bildirimi iptal i�leminde hata var.Sonu� mesaj� alan� bo�!"));
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(sevkIptalCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya sevk bildirimi iptali yap�lmas� s�ras�nda hata olu�tu! Sonu� Kodu alan� bo�!");
                    }
                }
                else throw new Exception("Medulaya sevk bildirimi iptal i�lemi yap�lamad�.Cevap d�nmedi!");
            }
            catch (Exception e)
            {
                throw new Exception("Medula sevk bildirimi iptal i�lemi s�ras�nda hata olu�tu! " + e.Message);
            }

        }

        public bool MutatDisiAracRaporSilSync(DispatchToOtherHospital dispatchToOtherHospital)
        {
            try
            {
                SevkIslemleri.mutatDisiIptalCevapDVO mutatDisiIptalCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, this.GetMutatDisiRaporIptalDVO(dispatchToOtherHospital));
                if (mutatDisiIptalCevapDVO != null)
                {
                    if (String.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucKodu) == false)
                    {
                        if (mutatDisiIptalCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoMessageService.Instance.ShowMessage("Mutat d��� ara� rapor id: " + dispatchToOtherHospital.MutatDisiAracRaporId + " olan raporun silme i�lemi ba�ar� ile sonu�land�.");
                            dispatchToOtherHospital.MutatDisiAracRaporId = null;
                            return true;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception("Mutat d��� ara� rapor  silme i�leminde hata var:Sonu� Mesaj� :" + mutatDisiIptalCevapDVO.sonucMesaji);
                            else throw new Exception("Mutat d��� ara� rapor silme i�leminde hata var.Sonu� mesaj� alan� bo�.");
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(mutatDisiIptalCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya mutat d��� ara� rapor silme i�lemi s�ras�nda hata olu�tu! Sonu� Kodu alan� bo�!");
                    }
                }
                else throw new Exception("Medulaya mutat d��� ara� rapor silme i�lemi yap�lamad�.Cevap d�nmedi!");
            }
            catch (Exception e)
            {
                throw new Exception("Medulaya mutat d��� ara� rapor silme i�lemi s�ras�nda hata olu�tu! " + e.Message);
            }

        }

        #endregion

        #region GET
        //public SevkIslemleri.sevkBildirimDVO GetSevkBildirimDVO(DispatchToOtherHospital dispatchToOtherHospital)
        //{
        //    SevkIslemleri.sevkBildirimDVO sevkBildirimDVO = new SevkIslemleri.sevkBildirimDVO();
        //    // *sevkTakipNo : Sevke karar verilen takip numaras�

        //    if (dispatchToOtherHospital.Episode != null && dispatchToOtherHospital.SubEpisode.PatientAdmission != null && dispatchToOtherHospital.SubEpisode.PatientAdmission.SEP != null && !String.IsNullOrEmpty(dispatchToOtherHospital.SubEpisode.PatientAdmission.SEP.MedulaTakipNo))
        //        sevkBildirimDVO.sevkTakipNo = dispatchToOtherHospital.SubEpisode.PatientAdmission.SEP.MedulaTakipNo;
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk takip no alan� dolu olmal�d�r!");
        //    // *protokolNo
        //    if (dispatchToOtherHospital.Episode != null && dispatchToOtherHospital.Episode.HospitalProtocolNo != null && dispatchToOtherHospital.Episode.HospitalProtocolNo.Value != null)
        //        sevkBildirimDVO.protokolNo = dispatchToOtherHospital.Episode.HospitalProtocolNo.Value.ToString();
        //    else throw new Exception("Medulaya e-sevk bildiriminde protokol numaras� alan� dolu olmal�d�r!");
        //    // *sevkEdilenIl

        //    if (dispatchToOtherHospital.DispatchCity != null && dispatchToOtherHospital.DispatchCity.KODU != null)
        //        sevkBildirimDVO.sevkEdilenIl = Convert.ToInt32(dispatchToOtherHospital.DispatchCity.KODU.ToString());
        //    else throw new Exception("Medulaya e-sevk bildiriminde gidece�i �ehir alan� dolu olmal�d�r!");
        //    // *sevkEdilenXXXXXX

        //    //if(dispatchToOtherHospital.MedulaSiteCode != null)
        //    sevkBildirimDVO.sevkEdilenTesis = Convert.ToInt32(dispatchToOtherHospital.MedulaSiteCode);
        //    //else
        //    //    throw new Exception("Medulaya e-sevk bildiriminde gidece�i tesis alan� dolu olmal�d�r!");

        //    // *sevkEdilenBrans
        //    if (dispatchToOtherHospital.DispatchedSpeciality != null && dispatchToOtherHospital.DispatchedSpeciality.Code != null)
        //        sevkBildirimDVO.sevkEdilenBrans = dispatchToOtherHospital.DispatchedSpeciality.Code;
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk edilen bran� alan� dolu olmal�d�r!");
        //    // *sevkVasitasi
        //    if (dispatchToOtherHospital.SevkVasitasi != null && dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null)
        //        sevkBildirimDVO.sevkVasitasi = Convert.ToInt32(dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu);
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk vas�tas� alan� dolu olmal�d�r!");
        //    // *sevkNedeni
        //    if (dispatchToOtherHospital.SevkNedeni != null && dispatchToOtherHospital.SevkNedeni.SevkNedeniKodu != null)
        //        sevkBildirimDVO.sevkNedeni = Convert.ToInt32(dispatchToOtherHospital.SevkNedeni.SevkNedeniKodu);
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alan� dolu olmal�d�r!");
        //    // *sevkNedeniAciklama (Sevk nedeni di�er ise dolu)
        //    if (dispatchToOtherHospital.SevkNedeni != null && dispatchToOtherHospital.SevkNedeni.SevkNedeniKodu != null)
        //    {
        //        if (dispatchToOtherHospital.SevkNedeni.SevkNedeniKodu.Equals("10"))
        //        {
        //            if (dispatchToOtherHospital.ReasonOfDispatch != null)
        //                sevkBildirimDVO.sevkNedeniAciklama = dispatchToOtherHospital.ReasonOfDispatch;
        //            else throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alan� Di�er se�ildi�inden sevk nedeni a��klama alan� dolu olmal�d�r!");
        //        }
        //        else
        //        {
        //            if (dispatchToOtherHospital.ReasonOfDispatch != null)
        //                sevkBildirimDVO.sevkNedeniAciklama = dispatchToOtherHospital.ReasonOfDispatch;
        //            else sevkBildirimDVO.sevkNedeniAciklama = "";
        //        }
        //    }
        //    // tedaviTipi
        //    if (dispatchToOtherHospital.SevkTedaviTipi != null && dispatchToOtherHospital.SevkTedaviTipi.sevkTedaviTipiKodu != null)
        //        sevkBildirimDVO.tedaviTipi = Convert.ToInt32(dispatchToOtherHospital.SevkTedaviTipi.sevkTedaviTipiKodu);
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk tedavi tipi alan� dolu olmal�d�r!");
        //    // *refakatci
        //    if (dispatchToOtherHospital.MedulaRefakatciDurumu != null && dispatchToOtherHospital.MedulaRefakatciDurumu.Equals(true))
        //    {
        //        sevkBildirimDVO.refakatci = "E";
        //        // refakakciGerekcesi
        //        if (dispatchToOtherHospital.CompanionReason != null)
        //            sevkBildirimDVO.refakakciGerekcesi = dispatchToOtherHospital.CompanionReason;
        //        else throw new Exception("Medulaya e-sevk bildiriminde refakat�i durumu Evet se�ildi�inden refakat�i gerek�esi alan� dolu olmal�d�r!");
        //    }
        //    else if (dispatchToOtherHospital.MedulaRefakatciDurumu == null || dispatchToOtherHospital.MedulaRefakatciDurumu.Equals(false))
        //    {
        //        sevkBildirimDVO.refakatci = "H";
        //    }
        //    else
        //    {
        //        sevkBildirimDVO.refakatci = "E";
        //        // refakakciGerekcesi
        //        if (dispatchToOtherHospital.CompanionReason != null && !String.Empty.Equals(dispatchToOtherHospital.CompanionReason.Trim()))
        //            sevkBildirimDVO.refakakciGerekcesi = dispatchToOtherHospital.CompanionReason;
        //        else
        //        {
        //            throw new Exception("Medulaya e-sevk bildiriminde refakat�i durumu var se�ildi�i zaman gerek�e alan� zorunludur!");
        //        }
        //    }

        //    // *sevkTani  -> SevkTaniDVO[]
        //    List<SevkIslemleri.sevkTaniDVO> sevkTaniList = new List<SevkIslemleri.sevkTaniDVO>();
        //    sevkTaniList = this.GetSevkTaniDVOList("Medulaya e-sevk bildiriminde", dispatchToOtherHospital).ToList<SevkIslemleri.sevkTaniDVO>();
        //    if (sevkTaniList != null)
        //        sevkBildirimDVO.sevkTani = sevkTaniList.ToArray();
        //    else throw new Exception("Medulaya e-sevk bildiriminde hastaya ait tan� girilmi� olmal�d�r!");

        //    // *sevkEdenDoktor   -> SevkDoktorDVO[]
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorList = new List<SevkIslemleri.sevkDoktorDVO>();
        //    sevkDoktorList = this.GetSevkDoktorDVOList("Medulaya e-sevk bildiriminde", dispatchToOtherHospital).ToList<SevkIslemleri.sevkDoktorDVO>();
        //    if (sevkDoktorList != null)
        //        sevkBildirimDVO.sevkEdenDoktor = sevkDoktorList.ToArray();
        //    else throw new Exception("Medulaya e-sevk bildiriminde sevk eden doktorlar�n bilgileri girilmi� olmal�d�r!");
        //    // raporId : Mutat d��� ara� rapor numaras�
        //    if (dispatchToOtherHospital.SevkVasitasi != null && dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null)
        //    {
        //        if (!dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu.Equals("1") && !dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu.Equals("12"))
        //        {
        //            if (this.MutatDisiAracRaporKaydetSync(dispatchToOtherHospital))
        //            {
        //                if (dispatchToOtherHospital.MutatDisiAracRaporId != null)
        //                    sevkBildirimDVO.raporId = Convert.ToInt64(dispatchToOtherHospital.MutatDisiAracRaporId);
        //                else throw new Exception("Medulaya e-sevk bildiriminde �ncelikle mutat d��� ara� rapor kayd�n�n yap�lmas� gerekmektedir!");
        //            }
        //            else
        //            {
        //                throw new Exception("Medulaya e-sevk bildiriminde �ncelikle mutat d��� ara� rapor kayd�n�n yap�lmas� gerekmektedir!");
        //            }
        //        }
        //        else
        //        {
        //            // Mutat ara� ise (Mutat Ara� kodlar�: 1 ve 12) rapor numaras� 0 yollan�yor.
        //            dispatchToOtherHospital.MutatDisiAracRaporId = (long)Convert.ToInt64("0");
        //            sevkBildirimDVO.raporId = Convert.ToInt64(dispatchToOtherHospital.MutatDisiAracRaporId);
        //        }
        //    }
        //    // *kullaniciTesisKodu
        //    sevkBildirimDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
        //    return sevkBildirimDVO;
        //}

        //public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type, DispatchToOtherHospital dispatchToOtherHospital)
        //{
        //    List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList = null;
        //    if (dispatchToOtherHospital.Episode != null)
        //    {
        //        sevkTaniDVOList = new List<SevkIslemleri.sevkTaniDVO>();
        //        foreach (var diagnose in (Episode.GetMyMedulaDiagnosisDefinitionICDCodes(dispatchToOtherHospital.Episode)))
        //        {
        //            SevkIslemleri.sevkTaniDVO sevkTaniDVO = new SevkIslemleri.sevkTaniDVO();
        //            sevkTaniDVO.sevkTaniKodu = diagnose;
        //            sevkTaniDVOList.Add(sevkTaniDVO);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(type + " hastaya ait tan� girilmi� olmal�d�r!");
        //    }
        //    return sevkTaniDVOList.ToArray();
        //}

        //public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type, DispatchToOtherHospital dispatchToOtherHospital)
        //{
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //    if (dispatchToOtherHospital.DoctorsGrid != null && dispatchToOtherHospital.DoctorsGrid.Count > 0)
        //    {
        //        sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
        //        foreach (var doctor in dispatchToOtherHospital.DoctorsGrid)
        //        {
        //            SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
        //            // *doktorTescilNo
        //            if (doctor.ResUser != null && doctor.ResUser.DiplomaRegisterNo != null)
        //                sevkDoktorDVO.doktorTescilNo = doctor.ResUser.DiplomaRegisterNo;
        //            else
        //            {
        //                throw new Exception(type + " sevk eden doktorun tescil numaras� dolu olmal�d�r!");
        //            }
        //            // *doktorTipi
        //            if (doctor.ResUser != null && doctor.ResUser.Title != null)
        //            {
        //                if (doctor.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
        //                    sevkDoktorDVO.doktorTipi = "2";
        //                else sevkDoktorDVO.doktorTipi = "1";
        //            }
        //            else
        //            {
        //                throw new Exception(type + " sevk eden doktorun tipi dolu olmal�d�r!");
        //            }
        //            // *bransKodu
        //            if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
        //            {
        //                string brans = getAnaUzmanlikBrans(doctor.ResUser, type);
        //                if (brans != null)
        //                    sevkDoktorDVO.bransKodu = brans;
        //            }
        //            else throw new Exception(type + " sevk eden doktor'un ana uzmanl�k dal� olan bran� bilgisi girilmi� olmal�d�r!");
        //            sevkDoktorDVOList.Add(sevkDoktorDVO);
        //        }
        //    }
        //    else throw new Exception(type + " sevk eden doktor bilgisi girilmi� olmal�d�r!");
        //    return sevkDoktorDVOList.ToArray();
        //}

        //public string getAnaUzmanlikBrans(ResUser user, string type)
        //{
        //    bool ctrl = false;
        //    foreach (var resource in user.ResourceSpecialities)
        //    {
        //        if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
        //        {
        //            if (resource.Speciality != null && resource.Speciality.Code != null)
        //            {
        //                ctrl = true;
        //                return resource.Speciality.Code;
        //            }
        //        }
        //    }
        //    if (!ctrl)
        //    {
        //        throw new Exception(type + " sevk eden doktor'un ana uzmanl�k dal� olan bran� bilgisi girilmi� olmal�d�r!");
        //    }
        //    return null;
        //}

        //public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO(DispatchToOtherHospital dispatchToOtherHospital)
        //{
        //    SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO = new SevkIslemleri.mutatDisiRaporDVO();
        //    // *haksahibiTCNO
        //    if (dispatchToOtherHospital.Episode != null && dispatchToOtherHospital.Episode.Patient != null && dispatchToOtherHospital.Episode.Patient.UniqueRefNo != null)
        //        mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(dispatchToOtherHospital.Episode.Patient.UniqueRefNo);
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken sevk edilen hasta TC kimlik no alan� dolu olmal�d�r!");
        //    //XXXXXX taraf�ndan verilen rapor no
        //    // *raporNo
        //    if (dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID != null && dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value == null)
        //        dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.GetNextValueFromDatabase(null, 0);
        //    if (dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID != null && dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value != null)
        //        mutatDisiRaporDVO.raporNo = dispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value.ToString();
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken XXXXXX taraf�ndan verilen rapor ID alan� dolu olmal�d�r!");
        //    // *protokolNo
        //    if (dispatchToOtherHospital.Episode != null && dispatchToOtherHospital.Episode.HospitalProtocolNo != null && dispatchToOtherHospital.Episode.HospitalProtocolNo.Value != null)
        //        mutatDisiRaporDVO.protokolNo = dispatchToOtherHospital.Episode.HospitalProtocolNo.Value.ToString();
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken protokol numaras� alan� dolu olmal�d�r!");
        //    // *sevkVasitasi
        //    if (dispatchToOtherHospital.SevkVasitasi != null && dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null)
        //        mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(dispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu);
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken sevk vas�tas� alan� dolu olmal�d�r!");
        //    // raporTarihi
        //    if (dispatchToOtherHospital.MutatDisiAracRaporTarihi != null)
        //        mutatDisiRaporDVO.raporTarihi = dispatchToOtherHospital.MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken rapor tarihi alan� dolu olmal�d�r!");
        //    // baslangicTarihi
        //    if (dispatchToOtherHospital.MutatDisiAracBaslangicTarihi != null)
        //        mutatDisiRaporDVO.baslangicTarihi = dispatchToOtherHospital.MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken ba�lang�� tarihi alan� dolu olmal�d�r!");
        //    // bitisTarihi
        //    if (dispatchToOtherHospital.MutatDisiAracBitisTarihi != null)
        //        mutatDisiRaporDVO.bitisTarihi = dispatchToOtherHospital.MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
        //    else throw new Exception("Medulaya mutat d��� rapor kayd� yap�l�rken biti� tarihi alan� dolu olmal�d�r!");
        //    // refakatciGerekcesi
        //    if (dispatchToOtherHospital.CompanionReason != null)
        //        mutatDisiRaporDVO.refakatciGerekcesi = dispatchToOtherHospital.CompanionReason;
        //    // mutatDisiGerekcesi
        //    if (dispatchToOtherHospital.MutatDisiGerekcesi != null)
        //        mutatDisiRaporDVO.mutatDisiGerekcesi = dispatchToOtherHospital.MutatDisiGerekcesi;
        //    // *sevkTani
        //    List<SevkIslemleri.sevkTaniDVO> sevkTaniList = this.GetSevkTaniDVOList("Medulaya mutat d��� ara� rapor bildiriminde", dispatchToOtherHospital).ToList<SevkIslemleri.sevkTaniDVO>();
        //    if (sevkTaniList != null)
        //        mutatDisiRaporDVO.sevkTani = sevkTaniList.ToArray();
        //    else throw new Exception("Medulaya mutat d��� ara� rapor bildiriminde hastaya ait tan� girilmi� olmal�d�r!");
        //    // sevkEdenDoktor
        //    List<SevkIslemleri.sevkDoktorDVO> sevkDoktorList = this.GetSevkDoktorDVOList("Medulaya mutat d��� ara� rapor bildiriminde", dispatchToOtherHospital).ToList<SevkIslemleri.sevkDoktorDVO>();
        //    if (sevkDoktorList != null)
        //        mutatDisiRaporDVO.sevkEdenDoktor = sevkDoktorList.ToArray();
        //    else throw new Exception("Medulaya mutat d��� ara� rapor bildiriminde sevk eden doktorlar�n bilgileri girilmi� olmal�d�r!");
        //    // *kullaniciTesisKodu
        //    mutatDisiRaporDVO.saglikTesisKodu = (TTObjectClasses.SystemParameter.GetSaglikTesisKodu());
        //    return mutatDisiRaporDVO;
        //}

        public SevkIslemleri.mutatDisiRaporIptalDVO GetMutatDisiRaporIptalDVO(DispatchToOtherHospital dispatchToOtherHospital)
        {
            SevkIslemleri.mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO = new SevkIslemleri.mutatDisiRaporIptalDVO();
            if (dispatchToOtherHospital.MutatDisiAracRaporId != null && !dispatchToOtherHospital.MutatDisiAracRaporId.Equals((long)(Convert.ToInt64('0'))))
                mutatDisiRaporIptalDVO.raporID = Convert.ToInt32(dispatchToOtherHospital.MutatDisiAracRaporId);
            else throw new Exception("Medulaya mutat d��� ara� rapor kayd� yap�lmam��. �ncelikle kay�t yapmal�s�n�z!");
            mutatDisiRaporIptalDVO.saglikTesisKodu = (TTObjectClasses.SystemParameter.GetSaglikTesisKodu());
            return mutatDisiRaporIptalDVO;
        }
        public SevkIslemleri.sevkBildirimIptalDVO GetSevkBildirimIptalDVO(DispatchToOtherHospital dispatchToOtherHospital)
        {
            SevkIslemleri.sevkBildirimIptalDVO sevkBildirimIptalDVO = new SevkIslemleri.sevkBildirimIptalDVO();
            if (dispatchToOtherHospital.MedulaSevkTakipNo != null)
                sevkBildirimIptalDVO.sevkTakipNo = dispatchToOtherHospital.MedulaSevkTakipNo;
            else throw new Exception("Medulaya sevk bildirimi yap�lmam��. �ncelikle bildirimi yapmal�s�n�z!");
            sevkBildirimIptalDVO.saglikTesisKodu = (TTObjectClasses.SystemParameter.GetSaglikTesisKodu());
            return sevkBildirimIptalDVO;
        }

        #endregion

    }
}

namespace Core.Models
{
    public partial class DispatchToOtherHospitalFormViewModel : BaseViewModel
    {
        public bool isSGK { get; set; }
        public bool isStartedByTreatmentDischarge { get; set; }

        public void AddToObjectContex(TTObjectContext objectContext)
        {
            DispatchToOtherHospital dispatch = (DispatchToOtherHospital)objectContext.AddObject(this._DispatchToOtherHospital);
            objectContext.Update();

        }

        public void SetState(TTObjectContext objectContext)
        {
            DispatchToOtherHospital dispatch = objectContext.GetObject<DispatchToOtherHospital>(this._DispatchToOtherHospital.ObjectID);
            dispatch.CurrentStateDefID = DispatchToOtherHospital.States.Completed;
        }
    }
}
