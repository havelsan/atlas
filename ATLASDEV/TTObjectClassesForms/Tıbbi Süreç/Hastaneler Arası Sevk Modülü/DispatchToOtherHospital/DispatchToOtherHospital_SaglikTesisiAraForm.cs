
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
    public partial class DispatchToOtherHospital_SaglikTesisiAraForm : TTForm
    {
        override protected void BindControlEvents()
        {
            buttonSaglikTesisiAra.Click += new TTControlEventDelegate(buttonSaglikTesisiAra_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            buttonSaglikTesisiAra.Click -= new TTControlEventDelegate(buttonSaglikTesisiAra_Click);
            base.UnBindControlEvents();
        }

        private void buttonSaglikTesisiAra_Click()
        {
#region DispatchToOtherHospital_SaglikTesisiAraForm_buttonSaglikTesisiAra_Click
   ((ITTGrid) this.ttgridSaglikTesisleri).Rows.Clear();
            MedulaYardimciIslemler.saglikTesisiAraCevapDVO saglikTesisiAraCevapDVO=MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(TTObjectClasses.Sites.SiteLocalHost,GetSaglikTesisiAraGirisDVO());
            if(saglikTesisiAraCevapDVO != null){
                if(string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucKodu)== false){
                    this.tttextboxSonucKodu.Text = saglikTesisiAraCevapDVO.sonucKodu;
                    if (saglikTesisiAraCevapDVO.sonucKodu.Equals("0000") == true)
                    {
                        if(saglikTesisiAraCevapDVO.tesisler == null)
                        {
                            InfoBox.Show("Sonuç bulunamadı!");
                            return;
                        }
                        
                        this.tttextboxSonucKodu.Text = "Başarılı";
                        for (int i = 0; i < saglikTesisiAraCevapDVO.tesisler.Length; i++)
                        {
                            MedulaYardimciIslemler.saglikTesisiListDVO saglikTesisiListDVO = saglikTesisiAraCevapDVO.tesisler[i];
                            ITTGridRow row = this.ttgridSaglikTesisleri.Rows.Add();
                            row.Cells[TesisIl.Name].Value = saglikTesisiListDVO.tesisIl;
                            row.Cells[TesisAdi.Name].Value = saglikTesisiListDVO.tesisAdi;
                            row.Cells[TesisKodu.Name].Value = saglikTesisiListDVO.tesisKodu.ToString();
                            row.Cells[TesisSinifKodu.Name].Value = saglikTesisiListDVO.tesisSinifKodu;
                            row.Cells[TesisTuru.Name].Value = saglikTesisiListDVO.tesisTuru;

                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji) == false)
                        {
                            this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                        }
                    }
                }
                if(string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji)== false){
                    this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                }
            }
            else{
                this.tttextboxSonucMesaji.Text = "İşlem gerçekleştirilemedi.";
                if (string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji) == false)
                {
                    this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                }
            }
#endregion DispatchToOtherHospital_SaglikTesisiAraForm_buttonSaglikTesisiAra_Click
        }

        protected override void PreScript()
        {
#region DispatchToOtherHospital_SaglikTesisiAraForm_PreScript
    base.PreScript();
            
            this.DropStateButton(DispatchToOtherHospital.States.Dispatched);
            this.DropStateButton(DispatchToOtherHospital.States.SendMedula);
#endregion DispatchToOtherHospital_SaglikTesisiAraForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DispatchToOtherHospital_SaglikTesisiAraForm_PostScript
    base.PostScript(transDef);
#endregion DispatchToOtherHospital_SaglikTesisiAraForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DispatchToOtherHospital_SaglikTesisiAraForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            string codeString = ttgridSaglikTesisleri.CurrentCell.OwningRow.Cells[TesisKodu.Name].Value.ToString();
            if(ttgridSaglikTesisleri.CurrentCell != null && string.IsNullOrEmpty(codeString) == false)
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Bilgi", "Sevk Edilen Tesis", "Seçili tesis kodunu işleme kopyalamak İstiyor musunuz?");
                if (result == "E" && Common.IsNumeric(codeString))
                {
                    _DispatchToOtherHospital.MedulaSiteCode = Convert.ToInt32(codeString);
                }
            }
#endregion DispatchToOtherHospital_SaglikTesisiAraForm_ClientSidePostScript

        }

#region DispatchToOtherHospital_SaglikTesisiAraForm_Methods
        public MedulaYardimciIslemler.saglikTesisiAraGirisDVO GetSaglikTesisiAraGirisDVO(){
            MedulaYardimciIslemler.saglikTesisiAraGirisDVO saglikTesisiAraGirisDVO= new MedulaYardimciIslemler.saglikTesisiAraGirisDVO();
            if (string.IsNullOrEmpty(this.tesisAdiSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisAdi = this.tesisAdiSaglikTesisiAraGirisDVO.Text;
            else
                throw new Exception("Tesis Adı boş olamaz!");
            if (string.IsNullOrEmpty(this.tesisIlKoduSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisIlKodu= this.tesisIlKoduSaglikTesisiAraGirisDVO.Text;
            if (string.IsNullOrEmpty(this.tesisKoduSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisKodu = this.tesisKoduSaglikTesisiAraGirisDVO.Text;
            if (string.IsNullOrEmpty(this.tesisTuruSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisTuru = this.tesisTuruSaglikTesisiAraGirisDVO.Text;
            
            saglikTesisiAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return saglikTesisiAraGirisDVO;
        }
        
#endregion DispatchToOtherHospital_SaglikTesisiAraForm_Methods
    }
}