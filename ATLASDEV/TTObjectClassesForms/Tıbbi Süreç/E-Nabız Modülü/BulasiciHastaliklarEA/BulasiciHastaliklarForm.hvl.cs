
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
    public partial class BulasiciHastaliklarForm : TTForm
    {
    /// <summary>
    /// Bildirimi Zorunlu Bulaşıcı Hastalıklar
    /// </summary>
        protected TTObjectClasses.BulasiciHastaliklarEA _BulasiciHastaliklarEA
        {
            get { return (TTObjectClasses.BulasiciHastaliklarEA)_ttObject; }
        }

        protected ITTLabel labelVakaDurumBulasiciHastalikVeriSeti;
        protected ITTEnumComboBox VakaDurumBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_CSBMBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_CSBMBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_MahalleBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_MahalleBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_KoyBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_KoyBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_BucakBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_BucakBulasiciHastalikVeriSeti;
        protected ITTLabel labelIcKapiNoBeyanBulasiciHastalikVeriSeti;
        protected ITTTextBox IcKapiNoBeyanBulasiciHastalikVeriSeti;
        protected ITTTextBox DisKapiNoBeyanBulasiciHastalikVeriSeti;
        protected ITTTextBox IcKapiNoIkametBulasiciHastalikVeriSeti;
        protected ITTTextBox DisKapiNoIkametBulasiciHastalikVeriSeti;
        protected ITTLabel labelDisKapiNoBeyanBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_CSBMBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_CSBMBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_MahalleBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_MahalleBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_KoyBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_KoyBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_BucakBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_BucakBulasiciHastalikVeriSeti;
        protected ITTLabel labelIcKapiNoIkametBulasiciHastalikVeriSeti;
        protected ITTLabel labelDisKapiNoIkametBulasiciHastalikVeriSeti;
        protected ITTGrid BulasiciHastalikTelefonBulasiciHastalikTelefon;
        protected ITTListBoxColumn SKRSTelefonTipiBulasiciHastalikTelefon;
        protected ITTListBoxColumn BulasiciHastalikVeriSetiBulasiciHastalikTelefon;
        protected ITTTextBoxColumn TelefonNumarasiBulasiciHastalikTelefon;
        protected ITTLabel labelResponsibleDoctorBulasiciHastalikVeriSeti;
        protected ITTObjectListBox ResponsibleDoctorBulasiciHastalikVeriSeti;
        protected ITTLabel labelSKRSICDBulasiciHastalikVeriSeti;
        protected ITTObjectListBox SKRSICDBulasiciHastalikVeriSeti;
        protected ITTLabel labelSKRSVakaTipiBulasiciHastalikVeriSeti;
        protected ITTObjectListBox SKRSVakaTipiBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_IlceBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_IlceBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_IlceBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_IlceBulasiciHastalikVeriSeti;
        protected ITTLabel labelBeyan_IlBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Beyan_IlBulasiciHastalikVeriSeti;
        protected ITTLabel labelIkamet_IlBulasiciHastalikVeriSeti;
        protected ITTObjectListBox Ikamet_IlBulasiciHastalikVeriSeti;
        protected ITTLabel labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti;
        protected ITTDateTimePicker BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti;
        protected ITTLabel labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti;
        protected ITTDateTimePicker PaketeAitIslemZamaniBulasiciHastalikVeriSeti;
        override protected void InitializeControls()
        {
            labelVakaDurumBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("03f342ae-819d-4b02-8795-9fe1ab120ca9"));
            VakaDurumBulasiciHastalikVeriSeti = (ITTEnumComboBox)AddControl(new Guid("cd9b62fa-0b1f-47ad-9870-9d140a686bbf"));
            labelBeyan_CSBMBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("e672f081-e77e-4676-bbb6-8e376053668f"));
            Beyan_CSBMBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("31c7bf42-be94-4830-afaf-4e220685399c"));
            labelBeyan_MahalleBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("c22cdb89-4367-41b8-aa9b-28884031620c"));
            Beyan_MahalleBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("44ab8e51-8b9b-4fe5-8a71-43dd705c2ed9"));
            labelBeyan_KoyBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("2a04ab4c-e7c2-409a-81c9-15da4bc25adb"));
            Beyan_KoyBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("512a92ad-3582-4dc4-a56e-853a7723d811"));
            labelBeyan_BucakBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("1cf3ffdb-7952-4a21-873c-57c242c997ac"));
            Beyan_BucakBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("f8821214-4660-4014-9840-01ea2272161f"));
            labelIcKapiNoBeyanBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("8b98bb77-8d3a-45ff-842f-e082a2e4ddd7"));
            IcKapiNoBeyanBulasiciHastalikVeriSeti = (ITTTextBox)AddControl(new Guid("59fa265b-e0f7-4ebf-96e2-da7e1576b4c3"));
            DisKapiNoBeyanBulasiciHastalikVeriSeti = (ITTTextBox)AddControl(new Guid("7e4f6c1c-b9a8-4c17-8b34-c218839b5524"));
            IcKapiNoIkametBulasiciHastalikVeriSeti = (ITTTextBox)AddControl(new Guid("760109fc-3169-4940-99dc-36cc6549db75"));
            DisKapiNoIkametBulasiciHastalikVeriSeti = (ITTTextBox)AddControl(new Guid("82f1cf00-ca57-46d9-b10a-e8bb811fe4a9"));
            labelDisKapiNoBeyanBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("bcee5788-a273-47cc-bb89-a0823f4e6846"));
            labelIkamet_CSBMBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("0b4b364a-878a-43d5-9f5e-cde986c2e988"));
            Ikamet_CSBMBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("2a7ab478-39b2-400a-92f7-444832002917"));
            labelIkamet_MahalleBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("4dac69bf-eea8-4274-af0a-d52b0985fb94"));
            Ikamet_MahalleBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("aefd276b-d63c-4983-a6dd-f1ff55aa6ac3"));
            labelIkamet_KoyBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("c0cf1db8-65b9-48a3-8688-5a3ccb0c58fb"));
            Ikamet_KoyBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("e259fc81-0d47-41b4-b147-8787c54f8532"));
            labelIkamet_BucakBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("6316cf58-2dfc-4376-9749-517dbcb546c4"));
            Ikamet_BucakBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("f6a20596-3627-4a2d-b00f-646dea793991"));
            labelIcKapiNoIkametBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("f898ca0d-a963-4ace-b843-25dfd24a6aa9"));
            labelDisKapiNoIkametBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("5cf0c157-3368-4a03-8319-e76d6be3d9b6"));
            BulasiciHastalikTelefonBulasiciHastalikTelefon = (ITTGrid)AddControl(new Guid("36b1d963-a5be-4659-acc9-a1aed8eb928c"));
            SKRSTelefonTipiBulasiciHastalikTelefon = (ITTListBoxColumn)AddControl(new Guid("3f9d9ec3-5dc1-4e24-b10a-f73f6fa25dab"));
            BulasiciHastalikVeriSetiBulasiciHastalikTelefon = (ITTListBoxColumn)AddControl(new Guid("e3e583de-abb3-4610-9c2c-879ea7289bfb"));
            TelefonNumarasiBulasiciHastalikTelefon = (ITTTextBoxColumn)AddControl(new Guid("50fc52c3-e016-476b-82d4-833d8426854f"));
            labelResponsibleDoctorBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("aed88ba5-dcbd-4960-8c4b-776e396c510f"));
            ResponsibleDoctorBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("9875518e-a181-4477-9891-47483a0a0621"));
            labelSKRSICDBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("575ec6ba-60fc-435a-8366-38e344074366"));
            SKRSICDBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("8ad877eb-f28b-488b-8e94-f79abb52b51b"));
            labelSKRSVakaTipiBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("3e9dd8c2-75a3-4984-a854-c3d3ed205d8d"));
            SKRSVakaTipiBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("a1dc1a5d-1738-41e5-9c6c-69439887a8c4"));
            labelBeyan_IlceBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("a66c8754-19f3-41ed-b1ac-90f82a230a0b"));
            Beyan_IlceBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("e8f87d53-15c0-462e-8d00-ea5587ad1939"));
            labelIkamet_IlceBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("5bc9477f-1d56-460d-b15f-9b84aed6c657"));
            Ikamet_IlceBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("83e4a776-f79a-4a07-b2a9-8884bdb01cf1"));
            labelBeyan_IlBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("afbd05c8-c275-4874-95c0-eaddd574c731"));
            Beyan_IlBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("599cbd07-6cf9-4223-be40-23ced9e589cb"));
            labelIkamet_IlBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("91ec1092-056f-4923-83b5-afde5e182e94"));
            Ikamet_IlBulasiciHastalikVeriSeti = (ITTObjectListBox)AddControl(new Guid("31e16d2e-cf1a-403e-ac4a-f74ffa9186e1"));
            labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("1e6f6333-1318-4107-8d1e-5f868662b6a0"));
            BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti = (ITTDateTimePicker)AddControl(new Guid("8da1dd82-5577-4673-aadc-6cb7e0a58dec"));
            labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti = (ITTLabel)AddControl(new Guid("148d630d-fc8f-4cba-93e0-28ec6a19bd03"));
            PaketeAitIslemZamaniBulasiciHastalikVeriSeti = (ITTDateTimePicker)AddControl(new Guid("1d1286b2-c490-4c8a-ba17-1d41e9dbeb16"));
            base.InitializeControls();
        }

        public BulasiciHastaliklarForm() : base("BULASICIHASTALIKLAREA", "BulasiciHastaliklarForm")
        {
        }

        protected BulasiciHastaliklarForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}