
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Fatura Bilgisi Kaydet Cevap
    /// </summary>
    public partial class FaturaBilgisiKaydetCevapForm : TTForm
    {
    /// <summary>
    /// Fatura Bilgisi Kaydet
    /// </summary>
        protected TTObjectClasses.FaturaBilgisiKaydet _FaturaBilgisiKaydet
        {
            get { return (TTObjectClasses.FaturaBilgisiKaydet)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage hataliKayitlarTabpage;
        protected ITTGrid hataliKayitlarFaturaHataDVO;
        protected ITTTextBoxColumn hataKoduFaturaHataDVO;
        protected ITTTextBoxColumn hataMesajiFaturaHataDVO;
        protected ITTTextBoxColumn takipNoFaturaHataDVO;
        protected ITTDateTimePickerColumn CreationDateFaturaHataDVO;
        protected ITTTabPage faturaDetaylariTabpage;
        protected ITTGrid faturaDetaylariFaturaDetayDVO;
        protected ITTTextBoxColumn takipNoFaturaDetayDVO;
        protected ITTTextBoxColumn takipToplamTutarFaturaDetayDVO;
        protected ITTDateTimePickerColumn CreationDateFaturaDetayDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        protected ITTLabel labelhastaBasvuruNoFaturaCevapDVO;
        protected ITTTextBox hastaBasvuruNoFaturaCevapDVO;
        protected ITTLabel labelfaturaTutariFaturaCevapDVO;
        protected ITTTextBox faturaTutariFaturaCevapDVO;
        protected ITTLabel labelfaturaTeslimNoFaturaCevapDVO;
        protected ITTTextBox faturaTeslimNoFaturaCevapDVO;
        protected ITTLabel labelfaturaRefNoFaturaCevapDVO;
        protected ITTTextBox faturaRefNoFaturaCevapDVO;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2cddc0ac-22f9-4ec2-a924-c934a23224e5"));
            hataliKayitlarTabpage = (ITTTabPage)AddControl(new Guid("65bb2410-8396-49b9-a624-8cb992450cf5"));
            hataliKayitlarFaturaHataDVO = (ITTGrid)AddControl(new Guid("6ffd0526-32fb-41d1-afa3-dfb1a311a952"));
            hataKoduFaturaHataDVO = (ITTTextBoxColumn)AddControl(new Guid("bf7e04d4-1591-43e0-bdde-0378ccc477e1"));
            hataMesajiFaturaHataDVO = (ITTTextBoxColumn)AddControl(new Guid("dd5f513b-564e-4872-8805-d258b80dd7d0"));
            takipNoFaturaHataDVO = (ITTTextBoxColumn)AddControl(new Guid("9cc52422-206a-43ba-938d-06e2cec7dbb7"));
            CreationDateFaturaHataDVO = (ITTDateTimePickerColumn)AddControl(new Guid("75461a7c-004a-4dad-866d-96a77339e57a"));
            faturaDetaylariTabpage = (ITTTabPage)AddControl(new Guid("febed3d5-a89c-4bf6-b801-73858363bf1c"));
            faturaDetaylariFaturaDetayDVO = (ITTGrid)AddControl(new Guid("a0493d15-9532-4bda-ade3-9c007602771d"));
            takipNoFaturaDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("f9ea0726-fb73-46c3-a771-d408a5f68565"));
            takipToplamTutarFaturaDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("f8ee1a33-883a-43aa-ba7c-58d903942534"));
            CreationDateFaturaDetayDVO = (ITTDateTimePickerColumn)AddControl(new Guid("9d5cce7c-460c-4cf1-b65b-3978849ac402"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("40bc01f8-cecb-49f1-b130-044357a338b9"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("9b39d3f7-9cec-4412-84b8-b8cff7f18139"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("11e98b16-048b-4378-bf11-601c2ab89a66"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("a5007824-4830-4d70-8005-e4ffd6ccc1b1"));
            labelhastaBasvuruNoFaturaCevapDVO = (ITTLabel)AddControl(new Guid("60566b04-d0fb-4f34-ab8a-2920338efac1"));
            hastaBasvuruNoFaturaCevapDVO = (ITTTextBox)AddControl(new Guid("29915c76-c7bc-468d-b8ec-c344d93a2dda"));
            labelfaturaTutariFaturaCevapDVO = (ITTLabel)AddControl(new Guid("26de02f7-f2a5-462e-a593-3f62b0ca7111"));
            faturaTutariFaturaCevapDVO = (ITTTextBox)AddControl(new Guid("562a2d04-92a6-42b2-9ab7-7303f6895607"));
            labelfaturaTeslimNoFaturaCevapDVO = (ITTLabel)AddControl(new Guid("a46cb711-e1d9-4e27-a20a-007fe9a7db89"));
            faturaTeslimNoFaturaCevapDVO = (ITTTextBox)AddControl(new Guid("3869de64-3314-49bd-85cc-f7515a33b1a3"));
            labelfaturaRefNoFaturaCevapDVO = (ITTLabel)AddControl(new Guid("60ecd4b4-aaf4-4008-a616-ed80ca8e0f16"));
            faturaRefNoFaturaCevapDVO = (ITTTextBox)AddControl(new Guid("57b9a865-4733-40c9-9de6-5f8e38be0cb4"));
            base.InitializeControls();
        }

        public FaturaBilgisiKaydetCevapForm() : base("FATURABILGISIKAYDET", "FaturaBilgisiKaydetCevapForm")
        {
        }

        protected FaturaBilgisiKaydetCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}