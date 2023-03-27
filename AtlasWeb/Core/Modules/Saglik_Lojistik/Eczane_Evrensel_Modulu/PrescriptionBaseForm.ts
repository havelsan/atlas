//$E38231C7
import { Component, OnInit, NgZone } from '@angular/core';
import { PrescriptionBaseFormViewModel } from './PrescriptionBaseFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ActionForm } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/ActionForm';
import { Prescription } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'PrescriptionBaseForm',
    templateUrl: './PrescriptionBaseForm.html',
    providers: [MessageService]
})
export class PrescriptionBaseForm extends ActionForm implements OnInit {
    public prescriptionBaseFormViewModel: PrescriptionBaseFormViewModel = new PrescriptionBaseFormViewModel();
    public get _Prescription(): Prescription {
        return this._TTObject as Prescription;
    }
    private PrescriptionBaseForm_DocumentUrl: string = '/api/PrescriptionService/PrescriptionBaseForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.PrescriptionBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    /*  public static async GetEreceteSignedApprovalCancelRequest(pres: Prescription): Promise<Object> {
          //            EReceteIslemleri.ereceteOnayIptalIstekDVO eReceteApprovalCancelRequest = Prescription.GetEreceteApprovalCancelRequest(pres);
          //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalCancelRequest);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIptalIstekDVO", "imzaliEreceteOnayIptalBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-Reçete Onay İstek İptal İçeriği İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO eReceteSignedApprovalCancelRequest = new EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO();
          //            eReceteSignedApprovalCancelRequest.doktorTcKimlikNo = eReceteApprovalCancelRequest.doktorTcKimlikNo.ToString();
          //            eReceteSignedApprovalCancelRequest.imzaliEreceteOnayIptal = signedContent;
          //            eReceteSignedApprovalCancelRequest.surumNumarasi = "1";
          //            eReceteSignedApprovalCancelRequest.tesisKodu = eReceteApprovalCancelRequest.tesisKodu.ToString();
          //            return eReceteSignedApprovalCancelRequest;

          //throw new NotImplementedException();
      }
      public static async GetEreceteSignedApprovalRequest(pres: Prescription): Promise<Object> {
          //            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = Prescription.GetEreceteApprovalRequest(pres);
          //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalRequest);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-reçete Onay İstek İçeriği İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-reçete onay istek içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
          //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
          //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
          //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
          //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
          //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
          //            eReceteSignedApprovalRequest.surumNumarasi = "1";
          //            return eReceteSignedApprovalRequest;
          //
         // throw new NotImplementedException();
      }
      public static async GetEreceteSignedDailyPresApprovalRequest(pres: Prescription, UniqueRefNo: number): Promise<Object> {
          //            EReceteIslemleri.ereceteOnayIstekDVO ereceteDailyPresApprovalRequest = Prescription.GetEreceteDailyPresApprovalRequest(pres, UniqueRefNo);
          //            string imzalanacakXml = Common.SerializeObjectToXml(ereceteDailyPresApprovalRequest);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-Reçete Onay İstek İçeriği İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
          //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
          //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
          //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
          //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
          //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
          //            eReceteSignedApprovalRequest.surumNumarasi = "1";
          //            return eReceteSignedApprovalRequest;
        //  throw new NotImplementedException();
      }
      public static async GetEReceteSignedDelete(pres: Prescription): Promise<Object> {
          //            EReceteIslemleri.ereceteSilIstekDVO eReceteDelete = Prescription.GetEReceteDelete(pres);
          //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteDelete);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-Reçete Sil İçerik İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-Reçete silme içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteSilIstekDVO eReceteSignedDelete = new EReceteIslemleri.imzaliEreceteSilIstekDVO();
          //            eReceteSignedDelete.doktorTcKimlikNo = eReceteDelete.doktorTcKimlikNo.ToString();
          //            eReceteSignedDelete.imzaliEreceteSil = signedContent;
          //            eReceteSignedDelete.surumNumarasi = "1";
          //            eReceteSignedDelete.tesisKodu = eReceteDelete.tesisKodu.ToString();
          //            return eReceteSignedDelete;

          throw new NotImplementedException();
      }
      public static async GetEreceteSignedEHUApprovalRequest(pres: Prescription, UniqueRefNo: number): Promise<Object> {
          //            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = Prescription.GetEreceteEHUApprovalRequest(pres, UniqueRefNo);
          //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalRequest);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-Reçete EHU Onay İstek İçeriği İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
          //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
          //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
          //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
          //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
          //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
          //            eReceteSignedApprovalRequest.surumNumarasi = "1";
          //            return eReceteSignedApprovalRequest;
          throw new NotImplementedException();
      }
      public static async GetEreceteSignedEHUCancelRequest(pres: Prescription, UniqueRefNo: number): Promise<Object> {
          //            EReceteIslemleri.ereceteOnayIptalIstekDVO ereceteEHUCancelRequest = Prescription.GetEreceteEHUCancelRequest(pres, UniqueRefNo);
          //            string imzalanacakXml = Common.SerializeObjectToXml(ereceteEHUCancelRequest);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIptalIstekDVO", "imzaliEreceteOnayIptalBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-Reçete EHU Onay İstek İçeriği İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
          //
          //            EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO ereceteSignedEHUCancelRequest = new EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO();
          //            ereceteSignedEHUCancelRequest.doktorTcKimlikNo = ereceteEHUCancelRequest.doktorTcKimlikNo.ToString();
          //            ereceteSignedEHUCancelRequest.imzaliEreceteOnayIptal = signedContent;
          //            ereceteSignedEHUCancelRequest.surumNumarasi = "1";
          //            ereceteSignedEHUCancelRequest.tesisKodu = ereceteEHUCancelRequest.tesisKodu.ToString();
          //            return ereceteSignedEHUCancelRequest;
          throw new NotImplementedException();
      }
      public static async GetEReceteSignedInputRequest(pres: Prescription): Promise<Object> {
          // Medula imzalı ereçete giriş bilgisi olarak
          // normal e-reçete giriş istek DVO'sunu kabul etmiyor
          // Gerekli değişiklikler aşağıdaki gibi olmalı
          //            TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO istekGiris = Prescription.GetEReceteInputRequest(pres);
          //            string imzalanacakXml = Common.SerializeObjectToXml(istekGiris.ereceteDVO);
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteDVO", "ereceteBilgisi");
          //            imzalanacakXml = imzalanacakXml.Replace("kisiDVO", "kisiBilgisi");
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaListesi", "ereceteAciklamaBilgisi");
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacListesi", "ereceteIlacBilgisi");
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteTaniListesi", "ereceteTaniBilgisi");
          //            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaListesi", "ereceteIlacAciklamaBilgisi");
          //
          //            byte[] signedContent = CommonForm.SignContent("E-reçete İçerik İmzalama", imzalanacakXml);
          //            if ( signedContent == null )
          //                throw new TTException("E-Reçete giriş içeriği imzalanamadı");
          //
          //            pres.IsSigned = true;
          //            pres.SignedData = signedContent;
          //
          //            TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO istekImzali = new TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO();
          //            istekImzali.doktorTcKimlikNo = istekGiris.doktorTcKimlikNo;
          //            istekImzali.tesisKodu = istekGiris.tesisKodu;
          //            istekImzali.imzaliErecete = signedContent;
          //            istekImzali.surumNumarasi = 1;
          //            return istekImzali;
          throw new NotImplementedException();
      }*/

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Prescription();
        this.prescriptionBaseFormViewModel = new PrescriptionBaseFormViewModel();
        this._ViewModel = this.prescriptionBaseFormViewModel;
        this.prescriptionBaseFormViewModel._Prescription = this._TTObject as Prescription;
    }

    protected loadViewModel() {
        let that = this;

        that.prescriptionBaseFormViewModel = this._ViewModel as PrescriptionBaseFormViewModel;
        that._TTObject = this.prescriptionBaseFormViewModel._Prescription;
        if (this.prescriptionBaseFormViewModel == null)
            this.prescriptionBaseFormViewModel = new PrescriptionBaseFormViewModel();
        if (this.prescriptionBaseFormViewModel._Prescription == null)
            this.prescriptionBaseFormViewModel._Prescription = new Prescription();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(PrescriptionBaseFormViewModel);
  
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
