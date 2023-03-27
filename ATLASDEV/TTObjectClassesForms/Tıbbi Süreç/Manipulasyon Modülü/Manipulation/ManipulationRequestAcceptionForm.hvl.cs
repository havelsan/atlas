
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManipulationRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTTextBox IDEpisode;
        protected ITTLabel labelProcedureDoctorEpisodeAction;
        protected ITTObjectListBox ProcedureDoctorEpisodeAction;
        protected ITTCheckBox GunuBirlikTakip;
        protected ITTRichTextBoxControl PreInformation;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTabPage;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage MedulaTakipBilgileriTabPage;
        protected ITTLabel labeltedaviTipi;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTLabel labeltakipTipi;
        protected ITTListDefComboBox takipTipi;
        protected ITTLabel labelbransKodu;
        protected ITTValueListBox bransKodu;
        protected ITTTabPage MedulaRaporBilgileriTabPage;
        protected ITTButton btnMedulayaKaydet;
        protected ITTGrid MedulaReportResults;
        protected ITTTextBoxColumn ReportChasingNoMedulaReportResult;
        protected ITTTextBoxColumn ReportNumberMedulaReportResult;
        protected ITTTextBoxColumn ReportRowNumberMedulaReportResult;
        protected ITTTextBoxColumn ResultCodeMedulaReportResult;
        protected ITTTextBoxColumn ResultExplanationMedulaReportResult;
        protected ITTDateTimePickerColumn SendReportDateMedulaReportResult;
        protected ITTButtonColumn btnMeduladanSil;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTCheckBox ApprovalFormGiven;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
        protected ITTLabel lblSorumluDoktor;
        protected ITTGrid GridReturnReasons;
        protected ITTDateTimePickerColumn ReturnDate;
        protected ITTTextBoxColumn ReturnReason;
        override protected void InitializeControls()
        {
            IDEpisode = (ITTTextBox)AddControl(new Guid("ddebb8df-c443-4728-b974-1dca94e59e70"));
            labelProcedureDoctorEpisodeAction = (ITTLabel)AddControl(new Guid("9b7b807e-a358-4fd2-87c9-4160600bf665"));
            ProcedureDoctorEpisodeAction = (ITTObjectListBox)AddControl(new Guid("34638f22-4c1a-4b26-b84c-9c174b29548b"));
            GunuBirlikTakip = (ITTCheckBox)AddControl(new Guid("c089999a-d723-4a82-bbd2-0394c1838a31"));
            PreInformation = (ITTRichTextBoxControl)AddControl(new Guid("facf1a9d-8909-4294-bd7e-c883dc8a60f0"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("b221c290-b07b-40a8-a31c-2a20f429739b"));
            ManipulationTabPage = (ITTTabPage)AddControl(new Guid("699c7997-eb1c-4608-ab97-473f81623e7a"));
            GridManipulations = (ITTGrid)AddControl(new Guid("b0b55c5a-dca0-4e11-bdde-343345c332d0"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("16c2e25f-51e0-475a-b546-fc48952a791d"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("f94ee499-e6c3-4685-9fee-6f2eeebb955f"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("1cf32564-afa1-4572-adcb-b577b4a76d72"));
            Department = (ITTListBoxColumn)AddControl(new Guid("29503d7b-5de8-425a-92af-14e78bc0fa7f"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("2afa7d0e-0408-40b2-b568-cb6656276638"));
            MedulaTakipBilgileriTabPage = (ITTTabPage)AddControl(new Guid("be2dd30f-768a-42de-96b2-b27d53b1ae45"));
            labeltedaviTipi = (ITTLabel)AddControl(new Guid("72713cc0-4a27-4181-b0eb-5d4b518e8200"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("6ed3f496-cc1e-45ea-a6a6-b09d24c0b443"));
            labeltakipTipi = (ITTLabel)AddControl(new Guid("a0313f99-d779-4a6b-a016-66385992802a"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("46f22591-6c1c-4de7-ae52-438dc05d317b"));
            labelbransKodu = (ITTLabel)AddControl(new Guid("db9e5a09-a517-4f96-a8e0-947628ad074c"));
            bransKodu = (ITTValueListBox)AddControl(new Guid("cd1de66c-1eff-44fe-bb36-56937f8a90aa"));
            MedulaRaporBilgileriTabPage = (ITTTabPage)AddControl(new Guid("362652a2-eda7-4ce2-bd89-36b8b3e21bad"));
            btnMedulayaKaydet = (ITTButton)AddControl(new Guid("cd19833b-d87d-4dbf-8829-b89f18905d35"));
            MedulaReportResults = (ITTGrid)AddControl(new Guid("2c8d2def-ffe6-4a98-89dc-7e423b6ada8f"));
            ReportChasingNoMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("5a2f2ffb-8773-4809-86f5-b001f74f6bde"));
            ReportNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("c6bef33e-dbfd-4a01-8ecc-24d86378f910"));
            ReportRowNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("87c22478-ff92-43bf-b957-4e64296b9b8a"));
            ResultCodeMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("003b84a4-b301-4a7d-a5b4-d95da0cd9cd8"));
            ResultExplanationMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("4db3a641-c287-4748-af82-7de45b4b31ee"));
            SendReportDateMedulaReportResult = (ITTDateTimePickerColumn)AddControl(new Guid("4b2ccbaf-a7c6-42ef-b43b-1c6bd9cf484d"));
            btnMeduladanSil = (ITTButtonColumn)AddControl(new Guid("f69ee5e8-ada5-449b-a652-b4729a6b9d01"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("0b19a384-9943-4838-96c4-097e164f3b07"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("e59b038b-f7ae-4786-a993-99047f76a645"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ab831346-1025-40f7-9750-dad60f8b3336"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("7960f344-280b-4802-b3cb-5db213859afc"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("61f631ff-30c4-4614-b3ed-ef30c5d34e01"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("0ec64cb6-0563-4bac-889e-e61426c7d6e2"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("a2b7ea9e-b4a2-4933-b48b-6789b22aabdb"));
            GridReturnReasons = (ITTGrid)AddControl(new Guid("407ab0ad-db8b-4ccb-b962-053a4e05249b"));
            ReturnDate = (ITTDateTimePickerColumn)AddControl(new Guid("c079078e-3998-44b8-80d1-c2b455f8c673"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("694c494a-ce42-4c59-bbcd-91508818d701"));
            base.InitializeControls();
        }

        public ManipulationRequestAcceptionForm() : base("MANIPULATION", "ManipulationRequestAcceptionForm")
        {
        }

        protected ManipulationRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}