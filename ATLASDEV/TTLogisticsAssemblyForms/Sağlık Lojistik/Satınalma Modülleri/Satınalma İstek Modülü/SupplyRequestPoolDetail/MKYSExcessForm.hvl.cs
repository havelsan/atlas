
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
    /// İhtiyaç Fazlası Sorgulama Formu
    /// </summary>
    public partial class MKYSExcessForm : TTForm
    {
    /// <summary>
    /// Tedarik Talepleri Havuz Detayı
    /// </summary>
        protected TTObjectClasses.SupplyRequestPoolDetail _SupplyRequestPoolDetail
        {
            get { return (TTObjectClasses.SupplyRequestPoolDetail)_ttObject; }
        }

        protected ITTTextBox NamePurchaseGroup;
        protected ITTTextBox CodePurchaseGroup;
        protected ITTTextBox birimTextBox;
        protected ITTObjectListBox CityListBox;
        protected ITTGrid ihtiyacFazlasiItemsGrid;
        protected ITTTextBoxColumn siraNo;
        protected ITTTextBoxColumn malzemeKodu;
        protected ITTTextBoxColumn malzemeAdi;
        protected ITTTextBoxColumn malzemeDigerAciklama;
        protected ITTTextBoxColumn adeti;
        protected ITTTextBoxColumn vergiliBirimFiyat;
        protected ITTDateTimePickerColumn tarih;
        protected ITTTextBoxColumn ilAdi;
        protected ITTTextBoxColumn ilKodu;
        protected ITTTextBoxColumn birimAdi;
        protected ITTButton btnExcessQuery;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTButton btnHospitalExcessQuery;
        override protected void InitializeControls()
        {
            NamePurchaseGroup = (ITTTextBox)AddControl(new Guid("060cac8a-2289-46e7-ae39-9a4ee219edeb"));
            CodePurchaseGroup = (ITTTextBox)AddControl(new Guid("af8639dd-2701-4497-b85d-92dda3688378"));
            birimTextBox = (ITTTextBox)AddControl(new Guid("7a50b9ed-8e98-4134-b1b2-7de21beaeb17"));
            CityListBox = (ITTObjectListBox)AddControl(new Guid("be08d800-44f1-4fa2-8d4b-93b7295d4e72"));
            ihtiyacFazlasiItemsGrid = (ITTGrid)AddControl(new Guid("99f75395-37c1-4aa0-bf03-bb04b080557b"));
            siraNo = (ITTTextBoxColumn)AddControl(new Guid("f786d0d5-505c-4b50-9a6c-027a961069a3"));
            malzemeKodu = (ITTTextBoxColumn)AddControl(new Guid("8c2ff828-86d3-49ab-9d1a-108aaeaf3212"));
            malzemeAdi = (ITTTextBoxColumn)AddControl(new Guid("35fd7523-7e56-49c1-bd57-bacfe73d2ee3"));
            malzemeDigerAciklama = (ITTTextBoxColumn)AddControl(new Guid("bea7dcad-3663-4fb5-9f48-2f2235ac9e13"));
            adeti = (ITTTextBoxColumn)AddControl(new Guid("79790301-3d1a-4aff-ba34-a9620aea62ab"));
            vergiliBirimFiyat = (ITTTextBoxColumn)AddControl(new Guid("cb8420d1-62aa-4373-a8fd-6bd1ca9cf450"));
            tarih = (ITTDateTimePickerColumn)AddControl(new Guid("1038805c-5311-4356-8950-e3a72fa9ba98"));
            ilAdi = (ITTTextBoxColumn)AddControl(new Guid("c11cfbe4-6f1e-44b8-b82a-c6735c83880f"));
            ilKodu = (ITTTextBoxColumn)AddControl(new Guid("d7100a33-4ebf-4d8e-8553-401a6096f9f3"));
            birimAdi = (ITTTextBoxColumn)AddControl(new Guid("94c9554d-2fa6-45bb-946f-dad272a373fb"));
            btnExcessQuery = (ITTButton)AddControl(new Guid("b34137e0-dce6-4694-a2b1-ebd99ff9de91"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5e8e1379-5a74-44e1-bdc6-48326dd63a25"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("76490f18-e1df-4239-b7f5-119de2bbb04e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("710aa963-4252-44b0-b7e3-a5f48310403c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("252e0ca5-f3d1-4237-b0aa-645d2439277b"));
            btnHospitalExcessQuery = (ITTButton)AddControl(new Guid("833eecd1-edf1-4cea-b694-a246778991ad"));
            base.InitializeControls();
        }

        public MKYSExcessForm() : base("SUPPLYREQUESTPOOLDETAIL", "MKYSExcessForm")
        {
        }

        protected MKYSExcessForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}