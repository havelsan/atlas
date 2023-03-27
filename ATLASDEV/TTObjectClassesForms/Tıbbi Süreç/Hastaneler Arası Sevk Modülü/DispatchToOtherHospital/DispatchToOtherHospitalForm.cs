
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
    /// XXXXXXler Arası Sevk 
    /// </summary>
    public partial class DispatchToOtherHospitalForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            saglikTesisiAra.Click += new TTControlEventDelegate(saglikTesisiAra_Click);
            RequestedReferableHospital.SelectedObjectChanged += new TTControlEventDelegate(RequestedReferableHospital_SelectedObjectChanged);
            RequestedExternalDepartment.SelectedObjectChanged += new TTControlEventDelegate(RequestedExternalDepartment_SelectedObjectChanged);
            RequestedReferableResource.SelectedObjectChanged += new TTControlEventDelegate(RequestedReferableResource_SelectedObjectChanged);
            RequestedExternalHospital.SelectedObjectChanged += new TTControlEventDelegate(RequestedExternalHospital_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            saglikTesisiAra.Click -= new TTControlEventDelegate(saglikTesisiAra_Click);
            RequestedReferableHospital.SelectedObjectChanged -= new TTControlEventDelegate(RequestedReferableHospital_SelectedObjectChanged);
            RequestedExternalDepartment.SelectedObjectChanged -= new TTControlEventDelegate(RequestedExternalDepartment_SelectedObjectChanged);
            RequestedReferableResource.SelectedObjectChanged -= new TTControlEventDelegate(RequestedReferableResource_SelectedObjectChanged);
            RequestedExternalHospital.SelectedObjectChanged -= new TTControlEventDelegate(RequestedExternalHospital_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void saglikTesisiAra_Click()
        {
#region DispatchToOtherHospitalForm_saglikTesisiAra_Click
   DispatchToOtherHospital_SaglikTesisiAraForm staf= new DispatchToOtherHospital_SaglikTesisiAraForm();
       staf.ShowEdit(this.FindForm(),_DispatchToOtherHospital);
#endregion DispatchToOtherHospitalForm_saglikTesisiAra_Click
        }

        private void RequestedReferableHospital_SelectedObjectChanged()
        {
#region DispatchToOtherHospitalForm_RequestedReferableHospital_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(this.RequestedReferableHospital.DataMember);
            ReferableHospital refHospital = (ReferableHospital)this.RequestedReferableHospital.SelectedObject;
            if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode))
            {
                if (refHospital.ResOtherHospital != null && refHospital.ResOtherHospital.Site != null && refHospital.ResOtherHospital.Site.MedulaSiteCode != null)
                    _DispatchToOtherHospital.MedulaSiteCode = refHospital.ResOtherHospital.Site.MedulaSiteCode;
                else
                    _DispatchToOtherHospital.MedulaSiteCode = null;
            }
#endregion DispatchToOtherHospitalForm_RequestedReferableHospital_SelectedObjectChanged
        }

        private void RequestedExternalDepartment_SelectedObjectChanged()
        {
#region DispatchToOtherHospitalForm_RequestedExternalDepartment_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(RequestedExternalDepartment.DataMember);
            
            if(this._DispatchToOtherHospital.RequestedExternalDepartment != null)
                this._DispatchToOtherHospital.DispatchedSpeciality = this._DispatchToOtherHospital.RequestedExternalDepartment;
#endregion DispatchToOtherHospitalForm_RequestedExternalDepartment_SelectedObjectChanged
        }

        private void RequestedReferableResource_SelectedObjectChanged()
        {
#region DispatchToOtherHospitalForm_RequestedReferableResource_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(this.RequestedReferableResource.DataMember);
#endregion DispatchToOtherHospitalForm_RequestedReferableResource_SelectedObjectChanged
        }

        private void RequestedExternalHospital_SelectedObjectChanged()
        {
#region DispatchToOtherHospitalForm_RequestedExternalHospital_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(RequestedExternalHospital.DataMember);

            ExternalHospitalDefinition extHospital = (ExternalHospitalDefinition)this.RequestedExternalHospital.SelectedObject;
            if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode))
            {
                if(extHospital.MedulaSiteCode != null)
                    _DispatchToOtherHospital.MedulaSiteCode = extHospital.MedulaSiteCode;
                else
                    _DispatchToOtherHospital.MedulaSiteCode = null;
            }
#endregion DispatchToOtherHospitalForm_RequestedExternalHospital_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region DispatchToOtherHospitalForm_PreScript
    base.PreScript();
            
            if(this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.New)
            {
                this._DispatchToOtherHospital.RequesterSite = TTObjectClasses.SystemParameter.GetSite();
                if(this._DispatchToOtherHospital.RequesterSite != null)
                {
                    BindingList<ResOtherHospital> requesterHospitalList = ResOtherHospital.GetBySite(this._DispatchToOtherHospital.ObjectContext,this._DispatchToOtherHospital.RequesterSite.ObjectID);
                    foreach(ResOtherHospital requesterHospital in requesterHospitalList)
                    {
                        this._DispatchToOtherHospital.RequesterHospital = requesterHospital;
                        break;
                    }
                }
            }
            if (this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi == null)
                this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi = Common.RecTime();
            if (this._DispatchToOtherHospital.MutatDisiAracBitisTarihi == null)
                this._DispatchToOtherHospital.MutatDisiAracBitisTarihi = Common.RecTime();
            if (this._DispatchToOtherHospital.MutatDisiAracRaporTarihi == null)
                this._DispatchToOtherHospital.MutatDisiAracRaporTarihi = Common.RecTime();
            
            //   Sevk Eden Doktorlar eklendiğinden kaldırıldı.
            //            if (this.DispatcherDoctor.SelectedObject == null)
            //            {
            //                ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
            //                if (currentUser.UserType == UserTypeEnum.Doctor){
            //                    this.DispatcherDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
            //                }
            //            }
            
            if (this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.New)
            {
                if (this.RequestedReferableHospital.SelectedObject != null || this.RequestedReferableResource.SelectedObject != null)
                {
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                }
                else if (this.RequestedExternalHospital.SelectedObject != null || this.RequestedExternalDepartment.SelectedObject != null)
                {
                    this.RequestedReferableHospital.ReadOnly = true;
                    this.RequestedReferableResource.ReadOnly = true;
                }
            }
            
            
            if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode) == false)
            {
                this.TTListBoxMedulaSevkNedeni.Required = false;
                this.TTListBoxMedulaSevkVasitasi.Required = false;
                this.TTListBoxSevkTedaviTipi.Required = false;
                this.medulaRefakatciDurumu.Required = false;
                
                // this.ttpanelMedulaSevkBilgileri.ReadOnly = true;
                this.txtMedulaSiteCode.ReadOnly = true;
                this.TTListBoxMedulaSevkVasitasi.ReadOnly = true;
                this.TTListBoxSevkTedaviTipi.ReadOnly = true;
                this.medulaRefakatciDurumu.ReadOnly = true;
                this.RaporTarihi.ReadOnly = true;
                this.RaporBaslangicTarihi.ReadOnly = true;
                this.RaporBitisTarihi.ReadOnly = true;
                this.MutatDisiGerekcesi.ReadOnly = true;
                this.saglikTesisiAra.ReadOnly = true;
                this.TTListBoxMedulaSevkNedeni.ReadOnly = true;
                
                this.DropStateButton(DispatchToOtherHospital.States.SendMedula);
            }
            
            if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode) == true)
            {
                if(this._DispatchToOtherHospital.CurrentStateDefID != null && this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.New)
                    this.DropStateButton(DispatchToOtherHospital.States.Dispatched);
                if(this._DispatchToOtherHospital.CurrentStateDefID != null && this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.SendMedula)
                    this.DropStateButton(DispatchToOtherHospital.States.SendMedula);
            }
#endregion DispatchToOtherHospitalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DispatchToOtherHospitalForm_PostScript
    base.PostScript(transDef);
            
            if (this.RequestedReferableHospital.SelectedObject != null && this.RequestedReferableResource.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1160));
            if (this.RequestedReferableHospital.SelectedObject == null && this.RequestedReferableResource.SelectedObject != null)
                throw new Exception(SystemMessage.GetMessage(1161));
            if (this.RequestedExternalHospital.SelectedObject != null && this.RequestedExternalDepartment.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1162));
            if (this.RequestedExternalHospital.SelectedObject == null && this.RequestedExternalDepartment.SelectedObject != null)
                throw new Exception(SystemMessage.GetMessage(1163));
            if (this.RequestedReferableHospital.SelectedObject == null && this.RequestedReferableResource.SelectedObject == null &&
                this.RequestedExternalHospital.SelectedObject == null && this.RequestedExternalDepartment.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1164));
            
            if(transDef != null && transDef.ToStateDefID == DispatchToOtherHospital.States.Dispatched && transDef.FromStateDefID == DispatchToOtherHospital.States.SendMedula)
            {
                if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode) == true)
                {
                    try{
                        MedulaESevkBildirSync();
                    }catch(Exception e){
                        throw new Exception(e.Message);
                    }
                }
            }
            
            if( _DispatchToOtherHospital.DoctorsGrid != null && _DispatchToOtherHospital.DoctorsGrid.Count > 0 )
            {
                _DispatchToOtherHospital.DispatcherDoctor = _DispatchToOtherHospital.DoctorsGrid[0].ResUser;
            }
#endregion DispatchToOtherHospitalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DispatchToOtherHospitalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
               if(transDef != null)
            {
                if(transDef.FromStateDefID == DispatchToOtherHospital.States.Dispatched && transDef.ToStateDefID ==  DispatchToOtherHospital.States.SendMedula)
                {
                    if(this._DispatchToOtherHospital.Episode != null && SubEpisode.IsSGKSubEpisode(_DispatchToOtherHospital.SubEpisode) == true)
                    {
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Medulaya bildirilen sevk ve mutat dışı araç rapor kayıtları iptal edilecektir. Devam etmek istediğinize emin misiniz?") == "H")
                            throw new TTUtils.TTException("İşlemden vazgeçildi");
                    }
                }
            }
#endregion DispatchToOtherHospitalForm_ClientSidePostScript

        }

#region DispatchToOtherHospitalForm_Methods
        private void SetInternalOrExternalFieldsEnabling(string dataMember)
        {
            if (dataMember == this.RequestedReferableHospital.DataMember)
            {
                if(this.RequestedReferableHospital.SelectedObject != null)
                {
                    this.RequestedReferableResource.ReadOnly = false;
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                    this.RequestedReferableResource.SelectedObject = null;
                    this.RequestedExternalHospital.SelectedObject = null;
                    this.RequestedExternalDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedReferableResource.SelectedObject == null)
                    {
                        this.RequestedExternalHospital.ReadOnly = false;
                        this.RequestedExternalDepartment.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedReferableResource.DataMember)
            {
                if(this.RequestedReferableResource.SelectedObject != null)
                {
                    this.RequestedReferableHospital.ReadOnly = false;
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                    this.RequestedExternalHospital.SelectedObject = null;
                    this.RequestedExternalDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedReferableHospital.SelectedObject == null)
                    {
                        this.RequestedExternalHospital.ReadOnly = false;
                        this.RequestedExternalDepartment.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedExternalHospital.DataMember)
            {
                if(this.RequestedExternalHospital.SelectedObject != null)
                {
                    this.RequestedReferableHospital.ReadOnly = true;
                    this.RequestedReferableResource.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = false;
                    this.RequestedReferableHospital.SelectedObject = null;
                    this.RequestedReferableResource.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedExternalDepartment.SelectedObject == null)
                    {
                        this.RequestedReferableHospital.ReadOnly = false;
                        this.RequestedReferableResource.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedExternalDepartment.DataMember)
            {
                if(this.RequestedExternalDepartment.SelectedObject != null)
                {
                    this.RequestedReferableHospital.ReadOnly = true;
                    this.RequestedReferableResource.ReadOnly = true;
                    this.RequestedExternalHospital.ReadOnly = false;
                    this.RequestedReferableHospital.SelectedObject = null;
                    this.RequestedReferableResource.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedExternalHospital.SelectedObject == null)
                    {
                        this.RequestedReferableHospital.ReadOnly = false;
                        this.RequestedReferableResource.ReadOnly = false;
                    }
                }
            }
            else
            {
                throw new TTUtils.TTException("Tanımsız DataMember.(" + dataMember + "). Lütfen Bilgi İşlemi arayınız.");
            }
        }
        
        
      
        
        
        /*
         * MEDULA SEVK BILDIR METODU
         * */
        
        public void MedulaESevkBildirSync(){

            try
            {
                SevkIslemleri.sevkCevapDVO sevkCevapDVO= SevkIslemleri.WebMethods.sevkBildirSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkBildirimDVO());
                if(sevkCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
                    {
                        if(sevkCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Alert("E-sevk bildirim işlemi başarı ile sonuçlandı. Sevk Takip No: "+ sevkCevapDVO.sevkTakipNo, MessageIconEnum.InformationMessage);
                            this._DispatchToOtherHospital.MedulaSevkTakipNo = sevkCevapDVO.sevkTakipNo;
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                                throw new Exception("E-sevk bildiriminde hata var. Sonuç Mesajı :"+ sevkCevapDVO.sonucMesaji);
                            else
                                throw new Exception("E-sevk bildiriminde hata var");
                        }
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                            throw new Exception("Medula sevk bildiriminde hata var: "+ sevkCevapDVO.sonucMesaji);
                        else
                            throw new Exception("Medulaya e-sevk bildirimi yapılması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
                    }
                    
                }
                else
                    throw new Exception("Medulaya e-sevk bildirimi yapılamadı!");
                
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
        
        /*
         * MEDULA SEVK BILDIRIM DVO HAZIRLANMASI
         * */
        
        public SevkIslemleri.sevkBildirimDVO GetSevkBildirimDVO()
        {
            
            SevkIslemleri.sevkBildirimDVO sevkBildirimDVO= new SevkIslemleri.sevkBildirimDVO();
            // *sevkTakipNo : Sevke karar verilen takip numarası
            
            if(this._DispatchToOtherHospital.Episode != null && this._DispatchToOtherHospital.SubEpisode.PatientAdmission != null && this._DispatchToOtherHospital.SubEpisode.PatientAdmission.SEP != null && !string.IsNullOrEmpty(this._DispatchToOtherHospital.SubEpisode.PatientAdmission.SEP.MedulaTakipNo))
                sevkBildirimDVO.sevkTakipNo = this._DispatchToOtherHospital.SubEpisode.PatientAdmission.SEP.MedulaTakipNo;
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk takip no alanı dolu olmalıdır!");
            
            // *protokolNo
            if(this._DispatchToOtherHospital.Episode != null && this._DispatchToOtherHospital.Episode.HospitalProtocolNo != null && this._DispatchToOtherHospital.Episode.HospitalProtocolNo.Value != null)
                sevkBildirimDVO.protokolNo =  this._DispatchToOtherHospital.Episode.HospitalProtocolNo.Value.ToString();
            else
                throw new Exception("Medulaya e-sevk bildiriminde protokol numarası alanı dolu olmalıdır!");
            
            // *sevkEdilenIl
            
            if(this._DispatchToOtherHospital.DispatchCity != null && this._DispatchToOtherHospital.DispatchCity.KODU != null)
                sevkBildirimDVO.sevkEdilenIl = Convert.ToInt32(this._DispatchToOtherHospital.DispatchCity.KODU.ToString());
            else
                throw new Exception("Medulaya e-sevk bildiriminde gideceği şehir alanı dolu olmalıdır!");
            
            // *sevkEdilenXXXXXX
            
            //if(this._DispatchToOtherHospital.MedulaSiteCode != null)
                sevkBildirimDVO.sevkEdilenTesis = Convert.ToInt32(this._DispatchToOtherHospital.MedulaSiteCode);
            //else
            //    throw new Exception("Medulaya e-sevk bildiriminde gideceği tesis alanı dolu olmalıdır!");
            
            // *sevkEdilenBrans
            if(this._DispatchToOtherHospital.DispatchedSpeciality != null && this._DispatchToOtherHospital.DispatchedSpeciality.Code != null)
                sevkBildirimDVO.sevkEdilenBrans = this._DispatchToOtherHospital.DispatchedSpeciality.Code;
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk edilen branş alanı dolu olmalıdır!");
            
            
            // *sevkVasitasi
            if(this._DispatchToOtherHospital.SevkVasitasi != null && this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null)
                sevkBildirimDVO.sevkVasitasi = Convert.ToInt32(this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu);
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk vasıtası alanı dolu olmalıdır!");
            
            // *sevkNedeni
            if(this._DispatchToOtherHospital.SevkNedeni != null && this._DispatchToOtherHospital.SevkNedeni.SevkNedeniKodu != null)
                sevkBildirimDVO.sevkNedeni = Convert.ToInt32(this._DispatchToOtherHospital.SevkNedeni.SevkNedeniKodu);
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alanı dolu olmalıdır!");
            
            // *sevkNedeniAciklama (Sevk nedeni diğer ise dolu)
            if(this._DispatchToOtherHospital.SevkNedeni != null && this._DispatchToOtherHospital.SevkNedeni.SevkNedeniKodu != null){
                if(this._DispatchToOtherHospital.SevkNedeni.SevkNedeniKodu.Equals("10")){
                    if(this._DispatchToOtherHospital.ReasonOfDispatch != null)
                        sevkBildirimDVO.sevkNedeniAciklama = this._DispatchToOtherHospital.ReasonOfDispatch;
                    else
                        throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alanı Diğer seçildiğinden sevk nedeni açıklama alanı dolu olmalıdır!");
                }else{
                    if(this._DispatchToOtherHospital.ReasonOfDispatch != null)
                        sevkBildirimDVO.sevkNedeniAciklama = this._DispatchToOtherHospital.ReasonOfDispatch;
                    else
                        sevkBildirimDVO.sevkNedeniAciklama = "";
                }
            }
            
            // tedaviTipi
            if( this._DispatchToOtherHospital.SevkTedaviTipi !=null && this._DispatchToOtherHospital.SevkTedaviTipi.sevkTedaviTipiKodu!= null)
                sevkBildirimDVO.tedaviTipi = Convert.ToInt32(this._DispatchToOtherHospital.SevkTedaviTipi.sevkTedaviTipiKodu);
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk tedavi tipi alanı dolu olmalıdır!");
            
            // *refakatci
            if(this._DispatchToOtherHospital.MedulaRefakatciDurumu != null && this._DispatchToOtherHospital.MedulaRefakatciDurumu.Equals(true)){
                sevkBildirimDVO.refakatci = "E";
                // refakakciGerekcesi
                if(this._DispatchToOtherHospital.CompanionReason != null)
                    sevkBildirimDVO.refakakciGerekcesi = this._DispatchToOtherHospital.CompanionReason;
                else
                    throw new Exception("Medulaya e-sevk bildiriminde refakatçi durumu Evet seçildiğinden refakatçi gerekçesi alanı dolu olmalıdır!");
            }else if(this._DispatchToOtherHospital.MedulaRefakatciDurumu != null && this._DispatchToOtherHospital.MedulaRefakatciDurumu.Equals(false)){
                sevkBildirimDVO.refakatci = "H";
                // refakakciGerekcesi
                if(this._DispatchToOtherHospital.CompanionReason != null)
                    sevkBildirimDVO.refakakciGerekcesi = this._DispatchToOtherHospital.CompanionReason;
            }else
                throw new Exception("Medulaya e-sevk bildiriminde refakatçi alanı dolu olmalıdır!");
            
            // *sevkTani  -> SevkTaniDVO[]
            SevkIslemleri.sevkTaniDVO[] sevkTaniList= GetSevkTaniDVOList("Medulaya e-sevk bildiriminde");
            if(sevkTaniList != null)
                sevkBildirimDVO.sevkTani =sevkTaniList;
            else
                throw new Exception("Medulaya e-sevk bildiriminde hastaya ait tanı girilmiş olmalıdır!");
            
            
            // *sevkEdenDoktor   -> SevkDoktorDVO[]
            SevkIslemleri.sevkDoktorDVO[] sevkDoktorList= GetSevkDoktorDVOList("Medulaya e-sevk bildiriminde");
            if(sevkDoktorList != null)
                sevkBildirimDVO.sevkEdenDoktor =sevkDoktorList;
            else
                throw new Exception("Medulaya e-sevk bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");
            
            // raporId : Mutat dışı araç rapor numarası
            if(this._DispatchToOtherHospital.SevkVasitasi != null && this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null){
                if(!this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu.Equals("1") && !this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu.Equals("12")){
                    if(MutatDisiAracRaporKaydetSync()){
                        if(this._DispatchToOtherHospital.MutatDisiAracRaporId != null)
                            sevkBildirimDVO.raporId = Convert.ToInt64(this._DispatchToOtherHospital.MutatDisiAracRaporId);
                        else
                            throw new Exception("Medulaya e-sevk bildiriminde öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }else{
                        throw new Exception("Medulaya e-sevk bildiriminde öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }
                }else{
                    // Mutat araç ise (Mutat Araç kodları: 1 ve 12) rapor numarası 0 yollanıyor.
                    this._DispatchToOtherHospital.MutatDisiAracRaporId = (long)Convert.ToInt64("0");
                    sevkBildirimDVO.raporId = Convert.ToInt64(this._DispatchToOtherHospital.MutatDisiAracRaporId);
                }
            }

            // *kullaniciTesisKodu
            sevkBildirimDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return sevkBildirimDVO;
        }
        
        public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type)
        {
            List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList= null;
            if(this._DispatchToOtherHospital.Episode != null){
                sevkTaniDVOList= new List<SevkIslemleri.sevkTaniDVO>();
                
                foreach(String diagnose in Episode.GetMyMedulaDiagnosisDefinitionICDCodes(_DispatchToOtherHospital.Episode))
                {
                    SevkIslemleri.sevkTaniDVO sevkTaniDVO= new SevkIslemleri.sevkTaniDVO();
                    sevkTaniDVO.sevkTaniKodu= diagnose;
                    sevkTaniDVOList.Add(sevkTaniDVO);
                }
            }else{
                throw new Exception(type + " hastaya ait tanı girilmiş olmalıdır!");
            }
            return sevkTaniDVOList.ToArray();
        }
        /* 
        public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        {
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList=null;
            if(this._DispatchToOtherHospital.DispatcherDoctor != null){
                sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
                SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
                // *doktorTescilNo
                
                //Doktor bilgileri boş olduğundan geçici kaldırıldı.
                //if(this._DispatchToOtherHospital.DispatcherDoctor.DiplomaRegisterNo != null)
                  //  sevkDoktorDVO.doktorTescilNo = this._DispatchToOtherHospital.DispatcherDoctor.DiplomaRegisterNo;
               // else
                 //   throw new Exception(type +" sevk eden doktorun tescil numarası dolu olmalıdır!");
                 
                 
                sevkDoktorDVO.doktorTescilNo= "101730";
                // *doktorTipi
                if(this._DispatchToOtherHospital.DispatcherDoctor.Title != null && this._DispatchToOtherHospital.DispatcherDoctor.Title.Value != null ){
                    if(this._DispatchToOtherHospital.DispatcherDoctor.Title.Value.Equals(UserTitleEnum.DisDoctor) || this._DispatchToOtherHospital.DispatcherDoctor.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || this._DispatchToOtherHospital.DispatcherDoctor.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || this._DispatchToOtherHospital.DispatcherDoctor.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
                        sevkDoktorDVO.doktorTipi ="2";
                    else
                        sevkDoktorDVO.doktorTipi ="1";
                }else{
                    //throw new Exception(type +" sevk eden doktorun tipi dolu olmalıdır!");
                    //TODO veriler doldurulacak
                    sevkDoktorDVO.doktorTipi ="1";
                }

                // *bransKodu
                if(this._DispatchToOtherHospital.DispatcherDoctor.ResourceSpecialities != null){
                    String brans=getAnaUzmanlikBrans(this._DispatchToOtherHospital.DispatcherDoctor, type);
                    if(brans != null)
                        sevkDoktorDVO.bransKodu = brans;
                }else
                    throw new Exception(type +" sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                sevkDoktorDVOList.Add(sevkDoktorDVO);
            }else
                throw new Exception(type +" sevk eden doktor bilgisi girilmiş olmalıdır!");
            
            return sevkDoktorDVOList.ToArray();
        }
         */
        /*
         * Sevk Eden Doktorların Ekrandaki Listeden Alınması
         * */
        
        public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        {
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList=null;
            if(this._DispatchToOtherHospital.DoctorsGrid != null){
                sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
                
                foreach(DoctorGrid doctor in this._DispatchToOtherHospital.DoctorsGrid)
                {
                    SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
                    // *doktorTescilNo
                    if(doctor.ResUser  != null && doctor.ResUser.DiplomaRegisterNo != null)
                        sevkDoktorDVO.doktorTescilNo = doctor.ResUser.DiplomaRegisterNo;
                    else{
                        throw new Exception(type +" sevk eden doktorun tescil numarası dolu olmalıdır!");
                        //sevkDoktorDVO.doktorTescilNo= "101730";
                    }
                    
                    // *doktorTipi
                    if(doctor.ResUser != null && doctor.ResUser.Title != null ){
                        if(doctor.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
                            sevkDoktorDVO.doktorTipi ="2";
                        else
                            sevkDoktorDVO.doktorTipi ="1";
                    }else{
                        throw new Exception(type +" sevk eden doktorun tipi dolu olmalıdır!");
                        //TODO veriler doldurulacak
                        //sevkDoktorDVO.doktorTipi ="1";
                    }
                    
                    // *bransKodu
                    if(doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null){
                        String brans=getAnaUzmanlikBrans(doctor.ResUser, type);
                        if(brans != null)
                            sevkDoktorDVO.bransKodu = brans;
                    }else
                        throw new Exception(type +" sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                    
                    sevkDoktorDVOList.Add(sevkDoktorDVO);
                }
                
            }else
                throw new Exception(type +" sevk eden doktor bilgisi girilmiş olmalıdır!");
            
            return sevkDoktorDVOList.ToArray();
        }
        
        
        
        public String getAnaUzmanlikBrans(ResUser user, string type){
            bool ctrl=false;
            foreach(ResourceSpecialityGrid resource in user.ResourceSpecialities){
                if(resource.MainSpeciality != null && resource.MainSpeciality.Equals(true)){
                    if(resource.Speciality != null &&  resource.Speciality.Code != null){
                        ctrl=true;
                        return resource.Speciality.Code;
                    }
                }
            }
            if(!ctrl){
                throw new Exception(type +" sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
            }
            return null;
        }
        
        /*
         * MEDULA MUTAT DIŞI ARAÇ RAPOR KAYDET METODU
         * */
        
        public bool MutatDisiAracRaporKaydetSync()
        {
            try
            {
                SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO= SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporDVO());
                if(mutatDisiRaporCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
                    {
                        if(mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Alert("Mutat dışı araç rapor bildirim işlemi başarı ile sonuçlandı. Rapor id: "+ mutatDisiRaporCevapDVO.raporId, MessageIconEnum.InformationMessage);
                            this._DispatchToOtherHospital.MutatDisiAracRaporId= mutatDisiRaporCevapDVO.raporId;
                            return true;
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                                throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :"+ mutatDisiRaporCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Mutat dışı araç rapor bildiriminde hata var.Sonuç mesajı alanı boş.");
                        }
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                            throw new Exception(mutatDisiRaporCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
                    }
                }
                else
                    throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılamadı.Cevap dönmedi!");
                
            }
            catch(Exception e){
                throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! "+ e.Message);
            }
            //return false;
        }
        
        
        /*
         * MEDULA MUTAT DIŞI RAPOR DVO HAZIRLANMASI
         * */
        
        public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO()
        {

            SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO= new SevkIslemleri.mutatDisiRaporDVO();
            // *haksahibiTCNO
            if(this._DispatchToOtherHospital.Episode != null  && this._DispatchToOtherHospital.Episode.Patient != null && this._DispatchToOtherHospital.Episode.Patient.UniqueRefNo != null)
                mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(this._DispatchToOtherHospital.Episode.Patient.UniqueRefNo);
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk edilen hasta TC kimlik no alanı dolu olmalıdır!");
            
            //XXXXXX tarafından verilen rapor no
            // *raporNo
            if(this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID != null &&  this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value == null)
                this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.GetNextValueFromDatabase(null,0);
            
            if(this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID != null && this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value != null)
                mutatDisiRaporDVO.raporNo = this._DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID.Value.ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken XXXXXX tarafından verilen rapor ID alanı dolu olmalıdır!");
            
            // *protokolNo
            if(this._DispatchToOtherHospital.Episode != null && this._DispatchToOtherHospital.Episode.HospitalProtocolNo != null && this._DispatchToOtherHospital.Episode.HospitalProtocolNo.Value != null)
                mutatDisiRaporDVO.protokolNo =  this._DispatchToOtherHospital.Episode.HospitalProtocolNo.Value.ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken protokol numarası alanı dolu olmalıdır!");
            
            // *sevkVasitasi
            if(this._DispatchToOtherHospital.SevkVasitasi != null && this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != null)
                mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu);
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk vasıtası alanı dolu olmalıdır!");
            
            // raporTarihi
            if(this._DispatchToOtherHospital.MutatDisiAracRaporTarihi != null)
                mutatDisiRaporDVO.raporTarihi = this._DispatchToOtherHospital.MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken rapor tarihi alanı dolu olmalıdır!");
            
            // baslangicTarihi
            if(this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi != null)
                mutatDisiRaporDVO.baslangicTarihi = this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken başlangıç tarihi alanı dolu olmalıdır!");
            
            // bitisTarihi
            if(this._DispatchToOtherHospital.MutatDisiAracBitisTarihi != null)
                mutatDisiRaporDVO.bitisTarihi = this._DispatchToOtherHospital.MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken bitiş tarihi alanı dolu olmalıdır!");
            
            // refakatciGerekcesi
            if(this._DispatchToOtherHospital.CompanionReason != null)
                mutatDisiRaporDVO.refakatciGerekcesi = this._DispatchToOtherHospital.CompanionReason;
            
            // mutatDisiGerekcesi
            if(this._DispatchToOtherHospital.MutatDisiGerekcesi != null)
                mutatDisiRaporDVO.mutatDisiGerekcesi = this._DispatchToOtherHospital.MutatDisiGerekcesi;
            
            // *sevkTani
            SevkIslemleri.sevkTaniDVO[] sevkTaniList= GetSevkTaniDVOList("Medulaya mutat dışı araç rapor bildiriminde");
            if(sevkTaniList != null)
                mutatDisiRaporDVO.sevkTani =sevkTaniList;
            else
                throw new Exception("Medulaya mutat dışı araç rapor bildiriminde hastaya ait tanı girilmiş olmalıdır!");
            
            // sevkEdenDoktor
            SevkIslemleri.sevkDoktorDVO[] sevkDoktorList= GetSevkDoktorDVOList("Medulaya mutat dışı araç rapor bildiriminde");
            if(sevkDoktorList != null)
                mutatDisiRaporDVO.sevkEdenDoktor =sevkDoktorList;
            else
                throw new Exception("Medulaya mutat dışı araç rapor bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");
            
            // *kullaniciTesisKodu
            mutatDisiRaporDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return mutatDisiRaporDVO;
        }
        
        /*
         * MEDULA MUTAT DIŞI ARAÇ RAPOR SIL METODU
         * */
        
        public bool MutatDisiAracRaporSilSync(){
            
            try
            {
                SevkIslemleri.mutatDisiIptalCevapDVO mutatDisiIptalCevapDVO= SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporIptalDVO());
                if(mutatDisiIptalCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucKodu) == false)
                    {
                        if(mutatDisiIptalCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Alert("Mutat dışı araç rapor id: "+ this._DispatchToOtherHospital.MutatDisiAracRaporId + " olan raporun silme işlemi başarı ile sonuçlandı.", MessageIconEnum.InformationMessage);
                            this._DispatchToOtherHospital.MutatDisiAracRaporId= null;
                            return true;
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception("Mutat dışı araç rapor  silme işleminde hata var:Sonuç Mesajı :"+ mutatDisiIptalCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Mutat dışı araç rapor silme işleminde hata var.Sonuç mesajı alanı boş.");
                        }
                    }
                    else
                    {
                         if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                             throw new Exception(mutatDisiIptalCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya mutat dışı araç rapor silme işlemi sırasında hata oluştu! Sonuç Kodu alanı boş!");
                    }
                }
                else
                    throw new Exception("Medulaya mutat dışı araç rapor silme işlemi yapılamadı.Cevap dönmedi!");
                
            }
            catch(Exception e)
            {
                throw new Exception("Medulaya mutat dışı araç rapor silme işlemi sırasında hata oluştu! "+ e.Message);
            }
            //return false;
        }
        
        /*
         * MEDULA MUTAT DIŞI RAPOR IPTAL DVO HAZIRLANMASI
         * */
        public SevkIslemleri.mutatDisiRaporIptalDVO GetMutatDisiRaporIptalDVO()
        {
            SevkIslemleri.mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO= new SevkIslemleri.mutatDisiRaporIptalDVO();
            
            if(this._DispatchToOtherHospital.MutatDisiAracRaporId != null && !this._DispatchToOtherHospital.MutatDisiAracRaporId.Equals((long)(Convert.ToInt64("0"))))
                mutatDisiRaporIptalDVO.raporID = Convert.ToInt32(this._DispatchToOtherHospital.MutatDisiAracRaporId);
            else
                throw new Exception("Medulaya mutat dışı araç rapor kaydı yapılmamış. Öncelikle kayıt yapmalısınız!");
            
            mutatDisiRaporIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return mutatDisiRaporIptalDVO;
        }
        
        
        /*
         * MEDULA SEVK BILDIRIM IPTAL METODU
         * */
        
        public bool MedulaESevkBildirimIptalSync(){
            
            try
            {
                SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO= SevkIslemleri.WebMethods.sevkBildirimIptalSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkBildirimIptalDVO());
                if(sevkIptalCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucKodu) == false)
                    {
                        if(sevkIptalCevapDVO.sonucKodu.Equals("0000")){
                            InfoBox.Alert("Sevk Takip No: "+ this._DispatchToOtherHospital.MedulaSevkTakipNo + " olan sevkin ipta işlemi başarı ile sonuçlandı.", MessageIconEnum.InformationMessage);
                            this._DispatchToOtherHospital.MedulaSevkTakipNo= null;
                            return true;
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                                 throw new Exception("Sevk bildirimi ipta işleminde hata var:Sonuç Mesajı :"+ sevkIptalCevapDVO.sonucMesaji);
                            else
                                 throw new Exception("Sevk bildirimi iptal işleminde hata var.Sonuç mesajı alanı boş!");
                        }
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(sevkIptalCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya sevk bildirimi iptali yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
                    }
                }
                else
                    throw new Exception("Medulaya sevk bildirimi iptal işlemi yapılamadı.Cevap dönmedi!");
                
            }
            catch(Exception e)
            {
                throw new Exception("Medula sevk bildirimi iptal işlemi sırasında hata oluştu! "+ e.Message);
            }
            
            //return false;
        }
        
        /*
         * MEDULA SEVK BILDIRIM IPTAL METODU
         * */
        
        public SevkIslemleri.sevkBildirimIptalDVO GetSevkBildirimIptalDVO()
        {
            SevkIslemleri.sevkBildirimIptalDVO sevkBildirimIptalDVO= new SevkIslemleri.sevkBildirimIptalDVO();
            
            if(this._DispatchToOtherHospital.MedulaSevkTakipNo != null)
                sevkBildirimIptalDVO.sevkTakipNo = this._DispatchToOtherHospital.MedulaSevkTakipNo ;
            else
                throw new Exception("Medulaya sevk bildirimi yapılmamış. Öncelikle bildirimi yapmalısınız!");
            
            sevkBildirimIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return sevkBildirimIptalDVO;
        }
        
#endregion DispatchToOtherHospitalForm_Methods
    }
}