//$F6D0828D
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientPresEReceteDetailFormViewModel } from './InpatientPresEReceteDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Yatan_Hasta_Recetesi_Modulu/InpatientPrescriptionBaseForm";


@Component({
    selector: 'InpatientPresEReceteDetailForm',
    templateUrl: './InpatientPresEReceteDetailForm.html',
    providers: [MessageService]
})
export class InpatientPresEReceteDetailForm extends InpatientPrescriptionBaseForm implements OnInit {
    Barcode: TTVisual.ITTTextBoxColumn;
    cmdAddDiag: TTVisual.ITTButton;
    cmdAddDrugDetail: TTVisual.ITTButton;
    cmdAddPresDesc: TTVisual.ITTButton;
    cmdAddSignedDiag: TTVisual.ITTButton;
    cmdAddSignedDrugDetail: TTVisual.ITTButton;
    cmdAddSignedPresDesc: TTVisual.ITTButton;
    descriptionType: TTVisual.ITTEnumComboBox;
    Diag: TTVisual.ITTObjectListBox;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugDescription: TTVisual.ITTTextBox;
    DrugGrid: TTVisual.ITTGrid;
    EReceteNo: TTVisual.ITTTextBox;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    labelEReceteNo: TTVisual.ITTLabel;
    PresDesc: TTVisual.ITTTextBox;
    presDescriptionType: TTVisual.ITTEnumComboBox;
    Select: TTVisual.ITTCheckBoxColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    public DrugGridColumns = [];
    public inpatientPresEReceteDetailFormViewModel: InpatientPresEReceteDetailFormViewModel = new InpatientPresEReceteDetailFormViewModel();
    public get _InpatientPrescription(): InpatientPrescription {
        return this._TTObject as InpatientPrescription;
    }
    private InpatientPresEReceteDetailForm_DocumentUrl: string = '/api/InpatientPrescriptionService/InpatientPresEReceteDetailForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InpatientPresEReceteDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdAddDiag_Click(): Promise<void> {
      /*  if (this.Diag.SelectedObjectID !== null) {
            let diagnosis: DiagnosisDefinition = <DiagnosisDefinition>this.Diag.SelectedObject;
            let ereceteTaniDVO: EReceteIslemleri.ereceteTaniDVO = new EReceteIslemleri.ereceteTaniDVO();
            ereceteTaniDVO.taniAdi = diagnosis.Name;
            if (diagnosis.Code.Length > 5)
                ereceteTaniDVO.taniKodu = diagnosis.Code.substring(0, 5);
            else ereceteTaniDVO.taniKodu = diagnosis.Code;
            let ereceteTaniEkleIstekDVO: EReceteIslemleri.ereceteTaniEkleIstekDVO = new EReceteIslemleri.ereceteTaniEkleIstekDVO();
            ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
            ereceteTaniEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
            ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
            ereceteTaniEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
            let response: EReceteIslemleri.ereceteTaniEkleCevapDVO = EReceteIslemleri.WebMethods.ereceteTaniEkle(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), ereceteTaniEkleIstekDVO);
            if (response !== null) {
                if (response.sonucKodu.Equals("0000")) {
                    TTVisual.InfoBox.Show("Tanı eklenmiştir.", MessageIconEnum.InformationMessage);
                    this.Close();
                }
                else TTVisual.InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
            }
        }
        else TTVisual.InfoBox.Show("Tanı seçmediniz.", MessageIconEnum.ErrorMessage);*/
    }
    public async cmdAddDrugDetail_Click(): Promise<void> {
      /*  let error: boolean = false;
        if (String.isNullOrEmpty(this.DrugDescription.Text)) {
            TTVisual.InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (this.descriptionType.SelectedItem === null) {
            TTVisual.InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (error === false) {
            let ereceteAciklamaDVO: EReceteIslemleri.ereceteIlacAciklamaDVO = new EReceteIslemleri.ereceteIlacAciklamaDVO();
            ereceteAciklamaDVO.aciklama = this.DrugDescription.Text;
            ereceteAciklamaDVO.aciklamaTuru = <number>this.descriptionType.SelectedItem.Value;
            let count: number = 0;
            let barcode: string = "\"\"";
            for (let i: number = 0; i < this.DrugGrid.Rows.length; i++) {
                if (Convert.ToBoolean(this.DrugGrid.Rows[i].Cells["Select"].Value)) {
                    barcode = this.DrugGrid.Rows[i].Cells["Barcode"].Value.toString();
                    count++;
                }
            }
            if (count === 1) {
                let ereceteIlacAciklamaEkleIstekDVO: EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteIlacAciklamaEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
                ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
                ereceteIlacAciklamaEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
                let response: EReceteIslemleri.ereceteIlacAciklamaEkleCevapDVO = EReceteIslemleri.WebMethods.ereceteIlacAciklamaEkle(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), ereceteIlacAciklamaEkleIstekDVO);
                if (response !== null) {
                    if (response.sonucKodu.Equals("0000"))
                        TTVisual.InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else TTVisual.InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
            else if (count === 0)
                TTVisual.InfoBox.Show("Açıklama eklenecek ilaç seçmediniz", MessageIconEnum.ErrorMessage);
            else TTVisual.InfoBox.Show("Sadece bir ilaç seçebilirsiniz.", MessageIconEnum.ErrorMessage);
        }*/
    }
    public async cmdAddPresDesc_Click(): Promise<void> {
      /*  let error: boolean = false;
        if (String.isNullOrEmpty(this.PresDesc.Text)) {
            TTVisual.InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (this.presDescriptionType.SelectedItem === null) {
            TTVisual.InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (error === false) {
            let ereceteAciklamaDVO: EReceteIslemleri.ereceteAciklamaDVO = new EReceteIslemleri.ereceteAciklamaDVO();
            ereceteAciklamaDVO.aciklama = this.PresDesc.Text;
            ereceteAciklamaDVO.aciklamaTuru = <number>this.presDescriptionType.SelectedItem.Value;
            let ereceteAciklamaEkleIstekDVO: EReceteIslemleri.ereceteAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteAciklamaEkleIstekDVO();
            ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
            ereceteAciklamaEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
            ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
            ereceteAciklamaEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
            let response: EReceteIslemleri.ereceteAciklamaEkleCevapDVO = EReceteIslemleri.WebMethods.ereceteAciklamaEkle(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), ereceteAciklamaEkleIstekDVO);
            if (response !== null) {
                if (response.sonucKodu.Equals("0000"))
                    TTVisual.InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                else TTVisual.InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
            }
        }*/
    }
    public async cmdAddSignedDiag_Click(): Promise<void> {
       /* if (this.Diag.SelectedObjectID !== null) {
            let diagnosis: DiagnosisDefinition = <DiagnosisDefinition>this.Diag.SelectedObject;
            let ereceteTaniDVO: EReceteIslemleri.ereceteTaniDVO = new EReceteIslemleri.ereceteTaniDVO();
            ereceteTaniDVO.taniAdi = diagnosis.Name;
            if (diagnosis.Code.Length > 5)
                ereceteTaniDVO.taniKodu = diagnosis.Code.substring(0, 5);
            else ereceteTaniDVO.taniKodu = diagnosis.Code;
            let ereceteTaniEkleIstekDVO: EReceteIslemleri.ereceteTaniEkleIstekDVO = new EReceteIslemleri.ereceteTaniEkleIstekDVO();
            ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
            ereceteTaniEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
            ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
            ereceteTaniEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
            let imzalanacakXml: string = (await CommonService.SerializeObjectToXml(ereceteTaniEkleIstekDVO));
            imzalanacakXml = imzalanacakXml.replace("ereceteTaniEkleIstekDVO", "imzaliEreceteTaniBilgisi");
            imzalanacakXml = imzalanacakXml.replace("ereceteTaniDVO", "ereceteTaniBilgisi");
            let signedContent: number[] = CommonForm.SignContent("E-reçete Tanı Bilgisi İçerik İmzalama", imzalanacakXml);
            if (signedContent === null)
                throw new TTException("E-reçete giriş içeriği imzalanamadı");
            let imzaliEreceteTaniEkleIstekDVO: EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO = new EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO();
            imzaliEreceteTaniEkleIstekDVO.doktorTcKimlikNo = ereceteTaniEkleIstekDVO.doktorTcKimlikNo.toString();
            imzaliEreceteTaniEkleIstekDVO.imzaliEreceteTani = signedContent;
            imzaliEreceteTaniEkleIstekDVO.surumNumarasi = "1";
            imzaliEreceteTaniEkleIstekDVO.tesisKodu = ereceteTaniEkleIstekDVO.tesisKodu.toString();
            let response: EReceteIslemleri.imzaliEreceteTaniEkleCevapDVO = EReceteIslemleri.WebMethods.imzaliEreceteTaniEkleSync(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), imzaliEreceteTaniEkleIstekDVO);
            if (response !== null) {
                if (response.sonucKodu.Equals("0000")) {
                    TTVisual.InfoBox.Show("Tanı eklenmiştir.", MessageIconEnum.InformationMessage);
                    this.Close();
                }
                else TTVisual.InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
            }
        }
        else TTVisual.InfoBox.Show("Tanı seçmediniz.", MessageIconEnum.ErrorMessage);*/
    }
    public async cmdAddSignedDrugDetail_Click(): Promise<void> {
        /*
        let error: boolean = false;
        if (String.isNullOrEmpty(this.DrugDescription.Text)) {
            TTVisual.InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (this.descriptionType.SelectedItem === null) {
            TTVisual.InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (error === false) {
            let ereceteAciklamaDVO: EReceteIslemleri.ereceteIlacAciklamaDVO = new EReceteIslemleri.ereceteIlacAciklamaDVO();
            ereceteAciklamaDVO.aciklama = this.DrugDescription.Text;
            ereceteAciklamaDVO.aciklamaTuru = <number>this.descriptionType.SelectedItem.Value;
            let count: number = 0;
            let barcode: string = "\"\"";
            for (let i: number = 0; i < this.DrugGrid.Rows.length; i++) {
                if (Convert.ToBoolean(this.DrugGrid.Rows[i].Cells["Select"].Value)) {
                    barcode = this.DrugGrid.Rows[i].Cells["Barcode"].Value.toString();
                    count++;
                }
            }
            if (count === 1) {
                let ereceteIlacAciklamaEkleIstekDVO: EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteIlacAciklamaEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
                ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
                ereceteIlacAciklamaEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
                let imzalanacakXml: string = (await CommonService.SerializeObjectToXml(ereceteIlacAciklamaEkleIstekDVO));
                imzalanacakXml = imzalanacakXml.replace("ereceteIlacAciklamaEkleIstekDVO", "imzaliEreceteIlacAciklamaBilgisi");
                imzalanacakXml = imzalanacakXml.replace("ereceteIlacAciklamaDVO", "ereceteIlacAciklamaBilgisi");
                let signedContent: number[] = CommonForm.SignContent("E-reçete İlaç Açıklama İçerik İmzalama", imzalanacakXml);
                if (signedContent === null)
                    throw new TTException("E-reçete giriş içeriği imzalanamadı");
                let imzaliEreceteIlacAciklamaEkleIstekDVO: EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO();
                imzaliEreceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo.toString();
                imzaliEreceteIlacAciklamaEkleIstekDVO.imzaliEreceteIlacAciklama = signedContent;
                imzaliEreceteIlacAciklamaEkleIstekDVO.surumNumarasi = "1";
                imzaliEreceteIlacAciklamaEkleIstekDVO.tesisKodu = ereceteIlacAciklamaEkleIstekDVO.tesisKodu.toString();
                let response: EReceteIslemleri.imzaliEreceteIlacAciklamaEkleCevapDVO = EReceteIslemleri.WebMethods.imzaliEreceteIlacAciklamaEkleSync(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), imzaliEreceteIlacAciklamaEkleIstekDVO);
                if (response !== null) {
                    if (response.sonucKodu.Equals("0000"))
                        TTVisual.InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else TTVisual.InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
            else if (count === 0)
                TTVisual.InfoBox.Show("Açıklama eklenecek ilaç seçmediniz", MessageIconEnum.ErrorMessage);
            else TTVisual.InfoBox.Show("Sadece bir ilaç seçebilirsiniz.", MessageIconEnum.ErrorMessage);
        }*/
    }
    public async cmdAddSignedPresDesc_Click(): Promise<void> {
      /*  let error: boolean = false;
        if (String.isNullOrEmpty(this.PresDesc.Text)) {
            TTVisual.InfoBox.Alert("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (this.presDescriptionType.SelectedItem === null) {
            TTVisual.InfoBox.Alert("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
            error = true;
        }
        if (error === false) {
            let ereceteAciklamaDVO: EReceteIslemleri.ereceteAciklamaDVO = new EReceteIslemleri.ereceteAciklamaDVO();
            ereceteAciklamaDVO.aciklama = this.PresDesc.Text;
            ereceteAciklamaDVO.aciklamaTuru = <number>this.presDescriptionType.SelectedItem.Value;
            let ereceteAciklamaEkleIstekDVO: EReceteIslemleri.ereceteAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteAciklamaEkleIstekDVO();
            ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this._InpatientPrescription.ProcedureDoctor.UniqueNo);
            ereceteAciklamaEkleIstekDVO.ereceteNo = this._InpatientPrescription.EReceteNo;
            ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
            ereceteAciklamaEkleIstekDVO.tesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
            let imzalanacakXml: string = (await CommonService.SerializeObjectToXml(ereceteAciklamaEkleIstekDVO));
            imzalanacakXml = imzalanacakXml.replace("ereceteAciklamaEkleIstekDVO", "imzaliEreceteAciklamaBilgisi");
            imzalanacakXml = imzalanacakXml.replace("ereceteAciklamaDVO", "ereceteAciklamaBilgisi");
            let signedContent: number[] = CommonForm.SignContent("E-reçete Açıklama Ekleme İçerik İmzalama", imzalanacakXml);
            if (signedContent === null)
                throw new TTException("E-reçete giriş içeriği imzalanamadı");
            let imzaliEreceteAciklamaEkleIstekDVO: EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO();
            imzaliEreceteAciklamaEkleIstekDVO.doktorTcKimlikNo = ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo.toString();
            imzaliEreceteAciklamaEkleIstekDVO.imzaliEreceteAciklama = signedContent;
            imzaliEreceteAciklamaEkleIstekDVO.surumNumarasi = "1";
            imzaliEreceteAciklamaEkleIstekDVO.tesisKodu = ereceteAciklamaEkleIstekDVO.tesisKodu.toString();
            let response: EReceteIslemleri.imzaliEreceteAciklamaEkleCevapDVO = EReceteIslemleri.WebMethods.imzaliEreceteAciklamaEkleSync(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), imzaliEreceteAciklamaEkleIstekDVO);
            if (response !== null) {
                if (response.sonucKodu.Equals("0000"))
                    TTVisual.InfoBox.Alert("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                else TTVisual.InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
            }
        }*/
    }
    protected async PreScript() {
        super.PreScript();
        this.DrugGrid.ReadOnly = false;
        this.descriptionType.ReadOnly = false;
        this.Diag.ReadOnly = false;
        this.DrugDescription.ReadOnly = false;
        this.PresDesc.ReadOnly = false;
        this.presDescriptionType.ReadOnly = false;
        this.Select.ReadOnly = false;
        this.ttgroupbox1.ReadOnly = false;
        this.ttgroupbox2.ReadOnly = false;
        this.ttgroupbox3.ReadOnly = false;
        for (let inpatientDrugOrder of this._InpatientPrescription.InpatientDrugOrders) {
            let addedRow: TTVisual.ITTGridRow = this.DrugGrid.Rows.push() as TTVisual.ITTGridRow;
            addedRow.Cells["Select"].Value = false;
            addedRow.Cells["Drug"].Value = inpatientDrugOrder.Material.ObjectID;
            addedRow.Cells["Frequency"].Value = inpatientDrugOrder.Frequency;
            if (inpatientDrugOrder.DoseAmount != null)
                addedRow.Cells["DoseAmount"].Value = inpatientDrugOrder.DoseAmount.toString();
            addedRow.Cells["Barcode"].Value = inpatientDrugOrder.Material.Barcode;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientPrescription();
        this.inpatientPresEReceteDetailFormViewModel = new InpatientPresEReceteDetailFormViewModel();
        this._ViewModel = this.inpatientPresEReceteDetailFormViewModel;
        this.inpatientPresEReceteDetailFormViewModel._InpatientPrescription = this._TTObject as InpatientPrescription;
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientPresEReceteDetailFormViewModel = this._ViewModel as InpatientPresEReceteDetailFormViewModel;
        that._TTObject = this.inpatientPresEReceteDetailFormViewModel._InpatientPrescription;
        if (this.inpatientPresEReceteDetailFormViewModel == null)
            this.inpatientPresEReceteDetailFormViewModel = new InpatientPresEReceteDetailFormViewModel();
        if (this.inpatientPresEReceteDetailFormViewModel._InpatientPrescription == null)
            this.inpatientPresEReceteDetailFormViewModel._InpatientPrescription = new InpatientPrescription();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(InpatientPresEReceteDetailFormViewModel);
  
    }


    public onEReceteNoChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.EReceteNo != event) {
                this._InpatientPrescription.EReceteNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EReceteNo, "Text", this.__ttObject, "EReceteNo");
    }

    public initFormControls(): void {
        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M20927", "Reçete Açıklama Ekleme");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 15;

        this.cmdAddSignedPresDesc = new TTVisual.TTButton();
        this.cmdAddSignedPresDesc.Text = i18n("M13817", "E-Reçete İmzalı Açıklama Ekleme");
        this.cmdAddSignedPresDesc.Name = "cmdAddSignedPresDesc";
        this.cmdAddSignedPresDesc.TabIndex = 17;

        this.cmdAddPresDesc = new TTVisual.TTButton();
        this.cmdAddPresDesc.Text = i18n("M13811", "E-Reçete Açıklama Ekleme");
        this.cmdAddPresDesc.Name = "cmdAddPresDesc";
        this.cmdAddPresDesc.TabIndex = 16;

        this.PresDesc = new TTVisual.TTTextBox();
        this.PresDesc.Multiline = true;
        this.PresDesc.Name = "PresDesc";
        this.PresDesc.TabIndex = 12;

        this.presDescriptionType = new TTVisual.TTEnumComboBox();
        this.presDescriptionType.DataTypeName = "DescriptionTypeEnum";
        this.presDescriptionType.Name = "presDescriptionType";
        this.presDescriptionType.TabIndex = 10;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M20928", "Reçete Açıklama Türü");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 11;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M22745", "Tanı Ekleme");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 14;

        this.cmdAddSignedDiag = new TTVisual.TTButton();
        this.cmdAddSignedDiag.Text = i18n("M13819", "E-Reçete İmzalı Tanı Ekleme");
        this.cmdAddSignedDiag.Name = "cmdAddSignedDiag";
        this.cmdAddSignedDiag.TabIndex = 9;

        this.Diag = new TTVisual.TTObjectListBox();
        this.Diag.ListDefName = "DiagnosisListDefinition";
        this.Diag.Name = "Diag";
        this.Diag.TabIndex = 2;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M13556", "Eklenecek Tanı");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 8;

        this.cmdAddDiag = new TTVisual.TTButton();
        this.cmdAddDiag.Text = i18n("M13829", "E-Reçete Tanı Ekleme");
        this.cmdAddDiag.Name = "cmdAddDiag";
        this.cmdAddDiag.TabIndex = 5;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M16293", "İlaç Açıklama Ekleme");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 13;

        this.cmdAddSignedDrugDetail = new TTVisual.TTButton();
        this.cmdAddSignedDrugDetail.Text = i18n("M13818", "E-Reçete İmzalı İlaç Açıklama Ekleme ");
        this.cmdAddSignedDrugDetail.Name = "cmdAddSignedDrugDetail";
        this.cmdAddSignedDrugDetail.TabIndex = 12;

        this.DrugGrid = new TTVisual.TTGrid();
        this.DrugGrid.Name = "DrugGrid";
        this.DrugGrid.TabIndex = 4;

        this.Select = new TTVisual.TTCheckBoxColumn();
        this.Select.DisplayIndex = 0;
        this.Select.HeaderText = i18n("M21507", "Seç");
        this.Select.Name = "Select";
        this.Select.Width = 80;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DisplayIndex = 1;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 300;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DisplayIndex = 2;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.ReadOnly = true;
        this.Frequency.Width = 100;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DisplayIndex = 3;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Width = 100;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DisplayIndex = 4;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Visible = false;
        this.Barcode.Width = 100;

        this.DrugDescription = new TTVisual.TTTextBox();
        this.DrugDescription.Multiline = true;
        this.DrugDescription.Name = "DrugDescription";
        this.DrugDescription.TabIndex = 3;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10479", "Açıklama Türü");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.cmdAddDrugDetail = new TTVisual.TTButton();
        this.cmdAddDrugDetail.Text = i18n("M13816", "E-Reçete İlaç Açıklama Ekleme ");
        this.cmdAddDrugDetail.Name = "cmdAddDrugDetail";
        this.cmdAddDrugDetail.TabIndex = 6;

        this.descriptionType = new TTVisual.TTEnumComboBox();
        this.descriptionType.DataTypeName = "DescriptionTypeEnum";
        this.descriptionType.Name = "descriptionType";
        this.descriptionType.TabIndex = 10;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M13553", "Eklenecek Açıklama");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 7;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Yazılan İlaçlar";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 9;

        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = "#F0F0F0";
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Name = "EReceteNo";
        this.EReceteNo.TabIndex = 0;

        this.labelEReceteNo = new TTVisual.TTLabel();
        this.labelEReceteNo.Text = i18n("M20954", "Reçete Numarası");
        this.labelEReceteNo.Name = "labelEReceteNo";
        this.labelEReceteNo.TabIndex = 1;

        this.DrugGridColumns = [this.Select, this.Drug, this.Frequency, this.DoseAmount, this.Barcode];
        this.ttgroupbox3.Controls = [this.cmdAddSignedPresDesc, this.cmdAddPresDesc, this.PresDesc, this.presDescriptionType, this.ttlabel5];
        this.ttgroupbox2.Controls = [this.cmdAddSignedDiag, this.Diag, this.ttlabel3, this.cmdAddDiag];
        this.ttgroupbox1.Controls = [this.cmdAddSignedDrugDetail, this.DrugGrid, this.DrugDescription, this.ttlabel1, this.cmdAddDrugDetail, this.descriptionType, this.ttlabel2, this.ttlabel4];
        this.Controls = [this.ttgroupbox3, this.cmdAddSignedPresDesc, this.cmdAddPresDesc, this.PresDesc, this.presDescriptionType, this.ttlabel5, this.ttgroupbox2, this.cmdAddSignedDiag, this.Diag, this.ttlabel3, this.cmdAddDiag, this.ttgroupbox1, this.cmdAddSignedDrugDetail, this.DrugGrid, this.Select, this.Drug, this.Frequency, this.DoseAmount, this.Barcode, this.DrugDescription, this.ttlabel1, this.cmdAddDrugDetail, this.descriptionType, this.ttlabel2, this.ttlabel4, this.EReceteNo, this.labelEReceteNo];

    }


}
