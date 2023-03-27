
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
    /// Kurum Faturası
    /// </summary>
    public partial class PayerInvoiceForm : TTForm
    {
    /// <summary>
    /// Kurum Faturası İşlemi
    /// </summary>
        protected TTObjectClasses.PayerInvoice _PayerInvoice
        {
            get { return (TTObjectClasses.PayerInvoice)_ttObject; }
        }

        protected ITTButton CHECKBUTTON;
        protected ITTTextBox GENERALTOTALPRICE;
        protected ITTTextBox TOTALDISCOUNTPRICE;
        protected ITTTextBox TOTALDISCOUNTENTRY;
        protected ITTTextBox DOCUMENTNO;
        protected ITTTextBox TAXOFFICE;
        protected ITTTextBox NUMBEROFSENT;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox TAXNUMBER;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel19;
        protected ITTLabel ttlabel17;
        protected ITTButton BUTTONDISCOUNT;
        protected ITTObjectListBox DISCOUNTTYPE;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTEnumComboBox PROCEDUREGROUPENUM;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker DATEOFSENT;
        protected ITTObjectListBox PROTOCOLNAME;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel6;
        protected ITTTabControl TabProcedureMaterialPackage;
        protected ITTTabPage TabProcedure;
        protected ITTGrid GRIDInvoiceProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBoxColumn PTOTALDISCOUNTEDPRICE;
        protected ITTCheckBoxColumn PPAID;
        protected ITTTextBoxColumn PTOTALDISCOUNTPRICE;
        protected ITTTabPage TabMaterial;
        protected ITTGrid GRIDInvoiceMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTTextBoxColumn MAMOUNT;
        protected ITTTextBoxColumn MUNITPRICE;
        protected ITTTextBoxColumn MTOTALPRICE;
        protected ITTTextBoxColumn MTOTALDISCOUNTEDPRICE;
        protected ITTCheckBoxColumn MPAID;
        protected ITTTextBoxColumn MTOTALDISCOUNTPRICE;
        protected ITTTabPage TabPackage;
        protected ITTGrid GRIDInvoicePackages;
        protected ITTDateTimePickerColumn PACACTIONDATE;
        protected ITTTextBoxColumn PACKAGECODE;
        protected ITTTextBoxColumn PACKAGENAME;
        protected ITTTextBoxColumn PACAMOUNT;
        protected ITTTextBoxColumn PACKAGEPRICE;
        protected ITTTextBoxColumn PACTOTALPRICE;
        protected ITTTextBoxColumn PACTOTALDISCOUNTEDPRICE;
        protected ITTCheckBoxColumn PACPAID;
        protected ITTTextBoxColumn PACTOTALDISCOUNTPRICE;
        protected ITTTextBox PAYERADDRESS;
        protected ITTTextBox Description;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox tttextbox10;
        protected ITTTextBox CASHIERNAME;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox PAYERNAME;
        protected ITTButton BTNLIST;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox PISUBEPISODE;
        protected ITTLabel ttlabel20;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel LblHastaDurumu;
        protected ITTValueListBox CancelReasonLabel;
        protected ITTLabel CancelReasonText;
        override protected void InitializeControls()
        {
            CHECKBUTTON = (ITTButton)AddControl(new Guid("cab58682-2080-4f4a-8553-4f667fbf1f69"));
            GENERALTOTALPRICE = (ITTTextBox)AddControl(new Guid("3d314abf-7840-4316-9523-9080eeb221a9"));
            TOTALDISCOUNTPRICE = (ITTTextBox)AddControl(new Guid("c5c21bb5-5784-415a-ae78-c38896fea3aa"));
            TOTALDISCOUNTENTRY = (ITTTextBox)AddControl(new Guid("e039a49a-ba6d-4095-8757-b20014d5b882"));
            DOCUMENTNO = (ITTTextBox)AddControl(new Guid("cbe0ec3d-ee5b-4a7d-b3ec-038da94a1eb0"));
            TAXOFFICE = (ITTTextBox)AddControl(new Guid("df6be292-ee68-4862-a4c8-29957d704845"));
            NUMBEROFSENT = (ITTTextBox)AddControl(new Guid("d7533175-3b8d-472f-a230-46ffe703bfcf"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("677963a8-47c5-4cec-995b-4746099fb72d"));
            TAXNUMBER = (ITTTextBox)AddControl(new Guid("4b2d72e5-bdf7-4e6f-8957-47cb766e6d59"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("fb73e17d-1828-4d93-b303-6545b6d47af8"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("665de217-11cf-4a40-950e-bfb21da28479"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("f553cced-766d-4cf1-9f04-4c7046aaef73"));
            BUTTONDISCOUNT = (ITTButton)AddControl(new Guid("c5380ee7-1b8b-460f-ad6d-251d0ec9b0d7"));
            DISCOUNTTYPE = (ITTObjectListBox)AddControl(new Guid("bcb0d8f9-a9cd-434a-9ea7-32777ace3f75"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("e9900d95-3701-4856-8975-c7ceb5ae60d0"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("602fbd83-5a39-4dbc-bf55-0360263a60c1"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("de217f85-dcca-48f7-9350-0689c8ba87b2"));
            PROCEDUREGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("667427cc-0d32-45d1-a511-1b0482fbcc47"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ce16f519-288e-4a35-924c-301dfd16b644"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("c0ed4525-8d74-44b0-81f6-44e72b4d7459"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e1a1b67d-b74f-43c0-8bf0-4674860802f8"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("0c32e715-03fd-457c-b2cf-472bb259a8c3"));
            DATEOFSENT = (ITTDateTimePicker)AddControl(new Guid("7c72a75f-18b5-4e50-85e6-47a68ee75c6d"));
            PROTOCOLNAME = (ITTObjectListBox)AddControl(new Guid("66b82219-4c98-4fff-8c49-487df9ff8e69"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("a46e50ef-de99-4dae-93db-507756d3f30b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a8b5b9f0-1af5-4268-a8e0-596b6f764173"));
            TabProcedureMaterialPackage = (ITTTabControl)AddControl(new Guid("74c72c37-3172-4950-9fe0-6a0fccdb3921"));
            TabProcedure = (ITTTabPage)AddControl(new Guid("b788ad12-19b4-4872-83ba-d8950879d4c1"));
            GRIDInvoiceProcedures = (ITTGrid)AddControl(new Guid("7d6c189d-30c9-4eb0-b811-db1a28fa5b1e"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("8fd70c58-2dfb-47a8-b861-6acc5165e351"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("a81862f0-f646-48c5-84cc-3ee99b4c09e4"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("1a766376-d686-4f17-8b7e-6ff1fbd28532"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("e784cdde-c39f-4c8d-83eb-90dceb945912"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("330e849a-3904-4caf-9aac-4af37d928a5c"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("6c276762-e22c-43d3-99da-15e08b1a94fd"));
            PTOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("a2219db6-d9d2-4eec-ab58-2d318899fc56"));
            PPAID = (ITTCheckBoxColumn)AddControl(new Guid("b7e85a0b-2be4-4b61-bbdc-e2e34fa3c93e"));
            PTOTALDISCOUNTPRICE = (ITTTextBoxColumn)AddControl(new Guid("777f8f9a-65a1-4313-8b99-0e945a80711d"));
            TabMaterial = (ITTTabPage)AddControl(new Guid("b0842bf6-507c-4e27-91f3-35b6c400115a"));
            GRIDInvoiceMaterials = (ITTGrid)AddControl(new Guid("041e3dbd-9ede-44b1-a6f0-844803b59e97"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("32a82eaf-7983-4217-9a86-f0a2d8877b51"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("b6afe815-a9ff-40b5-9b90-60c94279f86a"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("7acf289d-1ab4-4f3d-beb4-fb15a1f891bf"));
            MAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("41f297af-f481-40c9-9a1d-a69a1e604d6b"));
            MUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("4780619a-97c2-45b9-9111-5d4eac9645cb"));
            MTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("ab25e129-6222-47f8-9b86-f609395bf06d"));
            MTOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("49d3a132-c5a1-482b-88da-c33eed6d9739"));
            MPAID = (ITTCheckBoxColumn)AddControl(new Guid("8c0ff6f8-3e86-49d9-888b-b7134a650586"));
            MTOTALDISCOUNTPRICE = (ITTTextBoxColumn)AddControl(new Guid("795e860d-7964-4529-aeb3-481ff06f6d20"));
            TabPackage = (ITTTabPage)AddControl(new Guid("86b3437c-535a-4854-9006-627aeb3c27a5"));
            GRIDInvoicePackages = (ITTGrid)AddControl(new Guid("6cab2fc5-5a3b-45ad-9404-68187f3f145d"));
            PACACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("73451943-163e-4a35-85c2-c98e9acf5c5c"));
            PACKAGECODE = (ITTTextBoxColumn)AddControl(new Guid("1a7a78d7-4ac3-42a1-aa09-8b816f6c2957"));
            PACKAGENAME = (ITTTextBoxColumn)AddControl(new Guid("df65d1aa-b259-483c-9b68-b37b40e08cab"));
            PACAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("6250a7e9-c28d-44c7-ac30-82c370fa2839"));
            PACKAGEPRICE = (ITTTextBoxColumn)AddControl(new Guid("63889093-ba47-4187-8e21-fbf74d4b917b"));
            PACTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("6c3b7e35-27c9-4859-97b1-c408a20ea25e"));
            PACTOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("af3740e0-abb8-4acc-99a2-3cd66f996552"));
            PACPAID = (ITTCheckBoxColumn)AddControl(new Guid("6e438b92-d9c4-4134-9d1f-57540cd3ca3d"));
            PACTOTALDISCOUNTPRICE = (ITTTextBoxColumn)AddControl(new Guid("0bd15fd0-b07b-4f58-bbbc-4a8a2e772b1b"));
            PAYERADDRESS = (ITTTextBox)AddControl(new Guid("d601c2ad-486e-40c0-bea0-6ac439a5082b"));
            Description = (ITTTextBox)AddControl(new Guid("3e8de76f-5988-4a07-b2d0-a8ddd42f54d1"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("f4712188-8837-4257-926a-a960ec7bcd87"));
            tttextbox10 = (ITTTextBox)AddControl(new Guid("3e26584d-b8a9-4094-be6d-c6d1897b65f4"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("82e6ce21-cfc2-4add-92c5-e3138e29e6c7"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("8d428df3-05eb-44ad-9d43-6bb12472b247"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("20ec8142-8e8c-4045-adc2-889902a2b374"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("dbe1bcf4-bca5-4105-906c-8d976fa2dcdc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ddbc3594-d334-413b-8aee-901910d54ee4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("fd0cbcbd-41bd-441c-a480-b271756583dc"));
            PAYERNAME = (ITTObjectListBox)AddControl(new Guid("0d67e6a5-6a4b-467f-b3a7-bb4c4c58d2da"));
            BTNLIST = (ITTButton)AddControl(new Guid("0c72d2ba-6eb3-4c77-8b47-c90e42853908"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("d5cfe8c8-e86b-4df4-9066-d930fb907aa6"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("59eeac18-db9d-4fd9-a89f-f914344f8446"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8f620d15-f717-4f97-aa18-fd7a9944274d"));
            PISUBEPISODE = (ITTObjectListBox)AddControl(new Guid("3baf8aa5-d88f-4438-b50b-e08ae8ab4b42"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("410de000-1a52-4c03-8142-fa7259008fde"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("9beae59e-5643-464b-94a9-d099af12a60f"));
            LblHastaDurumu = (ITTLabel)AddControl(new Guid("433f684e-bd33-4222-a9ca-fb89fdf49360"));
            CancelReasonLabel = (ITTValueListBox)AddControl(new Guid("6d5ac661-9c09-4232-b730-0b53d32d4326"));
            CancelReasonText = (ITTLabel)AddControl(new Guid("eb653c0a-a6f6-4410-973e-f61e5117b691"));
            base.InitializeControls();
        }

        public PayerInvoiceForm() : base("PAYERINVOICE", "PayerInvoiceForm")
        {
        }

        protected PayerInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}