
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
    public partial class MedulaTesisYatakSorguIslemleri : TTUnboundForm
    {
        protected ITTTabControl tabcontrolTesisYatakSorgu;
        protected ITTTabPage tttabpageTesisYatakSorgu;
        protected ITTTabControl tabcontrolYataklar;
        protected ITTTabPage tttabpageYataklar;
        protected ITTGrid gridYataklar;
        protected ITTTextBoxColumn yatakKodu;
        protected ITTTextBoxColumn turu;
        protected ITTTextBoxColumn tescilTuru;
        protected ITTTextBoxColumn seviye;
        protected ITTTextBoxColumn gecerlilikBaslangicTarihi;
        protected ITTTextBoxColumn gecerlilikBitisTarihi;
        protected ITTTextBox txtSonucMesaji;
        protected ITTLabel lblSonucMesaji;
        protected ITTLabel lblSonucKodu;
        protected ITTTextBox txtSonucKodu;
        protected ITTButton btnSorgula;
        protected ITTLabel lblTarih;
        protected ITTDateTimePicker dtpTarih;
        override protected void InitializeControls()
        {
            tabcontrolTesisYatakSorgu = (ITTTabControl)AddControl(new Guid("c7985a2b-386f-465b-bf51-7ccbd2fc4838"));
            tttabpageTesisYatakSorgu = (ITTTabPage)AddControl(new Guid("6068efcb-5805-4dbe-a014-36d1254c031b"));
            tabcontrolYataklar = (ITTTabControl)AddControl(new Guid("d85597d7-5ce4-4478-8138-a99c71f15761"));
            tttabpageYataklar = (ITTTabPage)AddControl(new Guid("dbbb02ca-d0d3-4b3c-b65b-74e2d509bade"));
            gridYataklar = (ITTGrid)AddControl(new Guid("1b4beaaa-c799-4378-bd09-94ee802b1460"));
            yatakKodu = (ITTTextBoxColumn)AddControl(new Guid("eb0d1936-380b-44b0-be64-e730da37e4d4"));
            turu = (ITTTextBoxColumn)AddControl(new Guid("74625ab9-513e-4ed0-8283-081f15c2bf70"));
            tescilTuru = (ITTTextBoxColumn)AddControl(new Guid("76bef4fa-dc6e-44d0-bf2c-fa6b10c92d7c"));
            seviye = (ITTTextBoxColumn)AddControl(new Guid("001f695a-b746-4bfc-bf72-7f9d0b377074"));
            gecerlilikBaslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("7b141fc6-b11f-4a2a-9efd-a5165238066f"));
            gecerlilikBitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("9f54b24a-17d2-4fca-9c70-e71e7ebb1c56"));
            txtSonucMesaji = (ITTTextBox)AddControl(new Guid("ccfe68c8-81fd-4b68-b617-aacc0455042c"));
            lblSonucMesaji = (ITTLabel)AddControl(new Guid("bd6dc08e-8de4-4a56-9033-053860fec989"));
            lblSonucKodu = (ITTLabel)AddControl(new Guid("06017e35-868d-4f9e-90ce-747a8b770a36"));
            txtSonucKodu = (ITTTextBox)AddControl(new Guid("87438696-bdc8-40d5-8902-89e6cc109914"));
            btnSorgula = (ITTButton)AddControl(new Guid("ece122fa-eb01-4a9e-8820-2baa0e1fe482"));
            lblTarih = (ITTLabel)AddControl(new Guid("ab9e3129-5b52-4bd8-ab2e-631f9b3196b1"));
            dtpTarih = (ITTDateTimePicker)AddControl(new Guid("3cfbc545-8c1b-4699-89a0-9eb9131a146c"));
            base.InitializeControls();
        }

        public MedulaTesisYatakSorguIslemleri() : base("MedulaTesisYatakSorguIslemleri")
        {
        }

        protected MedulaTesisYatakSorguIslemleri(string formDefName) : base(formDefName)
        {
        }
    }
}