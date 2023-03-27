
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
    public partial class InvoiceForm : TTUnboundForm
    {
        protected ITTGrid grdMedulaTransactions;
        protected ITTTextBoxColumn grdMT_SubEpisode;
        protected ITTTextBoxColumn grdMT_TTObject;
        protected ITTTextBoxColumn grdMT_ObjectID;
        protected ITTTextBoxColumn grdMT_StateName;
        protected ITTTextBoxColumn grdMT_ExternalCode;
        protected ITTTextBoxColumn grdMT_BaseType;
        protected ITTTextBoxColumn grdMT_Description;
        protected ITTTextBoxColumn grdMT_TransactionDate;
        protected ITTTextBoxColumn grdMT_UnitPrice;
        protected ITTTextBoxColumn grdMT_Amount;
        protected ITTTextBoxColumn grdMT_PackageDefinition;
        protected ITTTextBoxColumn grdMT_Medulatype;
        protected ITTTextBoxColumn grdMT_StateText;
        protected ITTTextBoxColumn grdMT_MedulaServiceProviderRefNo;
        protected ITTTextBoxColumn grdMT_MedulaProcessNo;
        protected ITTTextBoxColumn grdMT_TotalPrice;
        protected ITTTextBoxColumn grdMT_MedulaPrice;
        protected ITTTextBoxColumn grdMT_MedulaResultMessage;
        protected ITTTextBoxColumn grdMT_MedulaResultCode;
        protected ITTTextBoxColumn SpecialCase;
        protected ITTTextBoxColumn grdMT_UserNote;
        protected ITTButtonColumn grdMT_EditRow;
        protected ITTGrid grdSubEpisodeList;
        protected ITTTextBoxColumn grdSep_ObjectID;
        protected ITTTextBoxColumn grdSep_Episode;
        protected ITTTextBoxColumn grdSep_SubEpisode;
        protected ITTTextBoxColumn grdSep_TTObject;
        protected ITTTextBoxColumn grdSep_HospitalProtocolNo;
        protected ITTTextBoxColumn grdSep_OrderNo;
        protected ITTTextBoxColumn grdSep_ProvisionNo;
        protected ITTTextBoxColumn grdSep_RelatedProvisionNo;
        protected ITTTextBoxColumn grdSep_ProvisionDate;
        protected ITTTextBoxColumn grdSep_ApplicationNo;
        protected ITTTextBoxColumn grdSep_SpecialityName;
        protected ITTTextBoxColumn grdSep_SpecialityCode;
        protected ITTTextBoxColumn grdSep_CureType;
        protected ITTTextBoxColumn grdSep_Status;
        protected ITTToolStrip tttoolstrip1;
        protected ITTGroupBox grpBoxMedula;
        protected ITTLabel lblMedulaInvoicePriceValue;
        protected ITTLabel lblMedulaInvoicePrice;
        protected ITTLabel lblMedulaEntryPriceValue;
        protected ITTLabel lblMedulaEntryPrice;
        protected ITTLabel lblTotalPriceValue;
        protected ITTLabel lblTotalPrice;
        protected ITTLabel lblBagliTakipBilgisiValue;
        protected ITTLabel lblBagliTakipBilgisi;
        protected ITTLabel lblFaturaTeslimNoValue;
        protected ITTLabel lblFaturaTeslimNo;
        protected ITTLabel lblYupassIDValue;
        protected ITTLabel lblYupassID;
        protected ITTLabel lblInfoValue;
        protected ITTLabel lblInfo;
        protected ITTLabel lblInvoicedUserValue;
        protected ITTLabel lblInvoicedUser;
        protected ITTTextBox txtResultMessage;
        protected ITTLabel lblResultMessage;
        protected ITTTextBox txtPersonelNote;
        protected ITTLabel lblBasvuruNo;
        protected ITTLabel lblSubEpisodeStatusValue;
        protected ITTLabel lblSubEpisodeStatus;
        protected ITTLabel lblResultCodeValue;
        protected ITTLabel lblTakipTipi;
        protected ITTLabel lblTakipTipiValue;
        protected ITTLabel lblResultCode;
        protected ITTLabel lblBasvuruNoValue;
        protected ITTLabel lblDevredilenKurumValue;
        protected ITTLabel lblPersonelNote;
        protected ITTLabel lblProvizyonTipiValue;
        protected ITTLabel lblDevredilenKurum;
        protected ITTLabel lblProvizyonTipi;
        protected ITTLabel lblTedaviTipiVaue;
        protected ITTLabel lblTedaviTuruValue;
        protected ITTLabel lblTedaviTuru;
        protected ITTLabel lblTedaviTipi;
        protected ITTLabel lblTakipNoValue;
        protected ITTLabel lblTakipNo;
        protected ITTGroupBox grpBoxPatientEpisode;
        protected ITTButton btnPatientEpisode;
        protected ITTLabel lblResSectionValue;
        protected ITTLabel lblResSection;
        protected ITTLabel lblServiceValue;
        protected ITTLabel lblService;
        protected ITTLabel lblLeavingDateTimeValue;
        protected ITTLabel lblLeavingDateTime;
        protected ITTLabel lblFirstHospitalizationDateValue;
        protected ITTLabel lblFirstHospitalizationDate;
        protected ITTLabel lblPatientStatusValue;
        protected ITTLabel lblPatientStatus;
        protected ITTLabel lblSupEpisodeNoValue;
        protected ITTLabel lblSubEpisodeNo;
        protected ITTLabel lblEpisodeDateValue;
        protected ITTLabel lblEpisodeDate;
        protected ITTLabel lblEpisodeNoValue;
        protected ITTLabel lblEpisodeNo;
        protected ITTLabel ttlabel8;
        protected ITTLabel lblBirthDate;
        protected ITTLabel lblYupassNoValue;
        protected ITTLabel lblYupassNo;
        protected ITTLabel lblTCNoValue;
        protected ITTLabel lblTCNo;
        protected ITTLabel lblFullNameValue;
        protected ITTLabel lblFullName;
        protected ITTGrid grdDiagnosises;
        protected ITTTextBoxColumn grdDiag_ObjectID;
        protected ITTTextBoxColumn grdDiag_TTObject;
        protected ITTTextBoxColumn grdDiag_MedulaStatus;
        protected ITTTextBoxColumn grdDiag_DiagnoseDate;
        protected ITTTextBoxColumn grdDiag_DiagnoseName;
        protected ITTTextBoxColumn grdDiag_DiagnoseCode;
        protected ITTTextBoxColumn grdDiag_DiagnosisType;
        protected ITTTextBoxColumn grdDiag_MedulaServiceProviderRefNo;
        protected ITTTextBoxColumn grdDiag_MedulaProcessNo;
        protected ITTTextBoxColumn grdDiag_MedulaStatusText;
        protected ITTTextBoxColumn grdDiag_MedulaResultCode;
        protected ITTTextBoxColumn grdDiag_MedulaResultMessage;
        protected ITTTextBoxColumn grdDiag_SpecialCase;
        override protected void InitializeControls()
        {
            grdMedulaTransactions = (ITTGrid)AddControl(new Guid("5fd8a19b-f6ee-4212-8b03-b8999b29a17b"));
            grdMT_SubEpisode = (ITTTextBoxColumn)AddControl(new Guid("6d6adcbf-beb6-46de-9337-5bcca5287b0c"));
            grdMT_TTObject = (ITTTextBoxColumn)AddControl(new Guid("1973dcfc-a52c-4efa-ac8e-739755b2e565"));
            grdMT_ObjectID = (ITTTextBoxColumn)AddControl(new Guid("854853d7-c6dd-423a-98fe-3a67ada19190"));
            grdMT_StateName = (ITTTextBoxColumn)AddControl(new Guid("0f3c7d4c-0d21-4ff8-985c-35992f4f2a9d"));
            grdMT_ExternalCode = (ITTTextBoxColumn)AddControl(new Guid("fc57f970-eea6-42bb-b45a-42648db49c3d"));
            grdMT_BaseType = (ITTTextBoxColumn)AddControl(new Guid("f697cbe5-38fd-4a8d-87d3-3c3e8e9b3c99"));
            grdMT_Description = (ITTTextBoxColumn)AddControl(new Guid("267cba35-518e-453f-9697-4c23e84080cb"));
            grdMT_TransactionDate = (ITTTextBoxColumn)AddControl(new Guid("bd0ecf52-4679-4a8f-a1b9-1536a95bd1d1"));
            grdMT_UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("66bf7669-235a-4186-b121-3490d8c1f989"));
            grdMT_Amount = (ITTTextBoxColumn)AddControl(new Guid("df34fed2-20d0-450b-a79f-9126d1b909fa"));
            grdMT_PackageDefinition = (ITTTextBoxColumn)AddControl(new Guid("8120d91e-f479-4663-ab17-6f4293cc1c84"));
            grdMT_Medulatype = (ITTTextBoxColumn)AddControl(new Guid("50fc5265-d1d2-4d80-a230-330592dc9707"));
            grdMT_StateText = (ITTTextBoxColumn)AddControl(new Guid("8d851497-eac4-4a35-ab69-06da5b5342f9"));
            grdMT_MedulaServiceProviderRefNo = (ITTTextBoxColumn)AddControl(new Guid("97f0746d-f6d5-4a73-b117-187af1d3268a"));
            grdMT_MedulaProcessNo = (ITTTextBoxColumn)AddControl(new Guid("7a41be80-d22d-44d4-bd88-764031d48c8c"));
            grdMT_TotalPrice = (ITTTextBoxColumn)AddControl(new Guid("d6ebcaab-e1bf-4afa-b972-098890231d5a"));
            grdMT_MedulaPrice = (ITTTextBoxColumn)AddControl(new Guid("f6ea685f-2005-4052-b351-d67af121e1aa"));
            grdMT_MedulaResultMessage = (ITTTextBoxColumn)AddControl(new Guid("0c18f3fa-baec-4b79-b3cb-b07f5f369fa2"));
            grdMT_MedulaResultCode = (ITTTextBoxColumn)AddControl(new Guid("c75b4f88-254f-4436-a8fd-e1a7023d377a"));
            SpecialCase = (ITTTextBoxColumn)AddControl(new Guid("dab7513a-c920-4960-b7a5-606857b3e8b0"));
            grdMT_UserNote = (ITTTextBoxColumn)AddControl(new Guid("47bcf313-1b8d-4a25-af9d-9aabb39f01ff"));
            grdMT_EditRow = (ITTButtonColumn)AddControl(new Guid("d79a3476-4ae5-4928-90fc-67a9b1d55981"));
            grdSubEpisodeList = (ITTGrid)AddControl(new Guid("2444ecf7-0acd-4c09-9e4d-03d7a030bacc"));
            grdSep_ObjectID = (ITTTextBoxColumn)AddControl(new Guid("837d3ec8-1947-4e9b-a250-9d1a92342bdf"));
            grdSep_Episode = (ITTTextBoxColumn)AddControl(new Guid("498f65ec-3b35-4d84-b90b-1d3d91566ab0"));
            grdSep_SubEpisode = (ITTTextBoxColumn)AddControl(new Guid("87399ff5-d5c0-490f-8ffb-650b3d498cca"));
            grdSep_TTObject = (ITTTextBoxColumn)AddControl(new Guid("e8848e5e-efc1-4230-853b-e69f36f304d5"));
            grdSep_HospitalProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("66b50c8d-8859-4729-9555-46765c73a613"));
            grdSep_OrderNo = (ITTTextBoxColumn)AddControl(new Guid("24cc9dfb-dc42-4578-a309-e2f9f2611020"));
            grdSep_ProvisionNo = (ITTTextBoxColumn)AddControl(new Guid("0b70a933-2702-4997-85d7-9e7995c04459"));
            grdSep_RelatedProvisionNo = (ITTTextBoxColumn)AddControl(new Guid("ff9dd798-39a6-4c8c-b2df-52dfe3540023"));
            grdSep_ProvisionDate = (ITTTextBoxColumn)AddControl(new Guid("d368a12b-aab9-4a16-b106-2e1ee2cc7343"));
            grdSep_ApplicationNo = (ITTTextBoxColumn)AddControl(new Guid("5bac806f-577d-4047-82ba-c6bf32bba01b"));
            grdSep_SpecialityName = (ITTTextBoxColumn)AddControl(new Guid("9738f11c-e94d-4667-8902-f9b668b72ec0"));
            grdSep_SpecialityCode = (ITTTextBoxColumn)AddControl(new Guid("3f482ea7-a125-401e-94ca-3c91d98e0633"));
            grdSep_CureType = (ITTTextBoxColumn)AddControl(new Guid("0c33c9a8-fa47-47d1-9f8f-3e825acfcb43"));
            grdSep_Status = (ITTTextBoxColumn)AddControl(new Guid("f114bb56-70f6-4524-9ace-1db5031f4ad3"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("45f0e0f6-5ca5-4780-b4a7-af8996092a75"));
            grpBoxMedula = (ITTGroupBox)AddControl(new Guid("5e6709e7-e3ca-4e4c-8b83-cfec0a0a90aa"));
            lblMedulaInvoicePriceValue = (ITTLabel)AddControl(new Guid("48d08828-670d-4b5b-9ea1-bf3a346fb59c"));
            lblMedulaInvoicePrice = (ITTLabel)AddControl(new Guid("b6a73207-e99a-4815-8bfb-c45491d02c47"));
            lblMedulaEntryPriceValue = (ITTLabel)AddControl(new Guid("38a80a08-9345-4ff8-b1d4-d16e917d6129"));
            lblMedulaEntryPrice = (ITTLabel)AddControl(new Guid("6f1ad429-a69e-40f6-a458-8631be30de6d"));
            lblTotalPriceValue = (ITTLabel)AddControl(new Guid("aeb50fee-52fc-4545-bce4-2520afef3159"));
            lblTotalPrice = (ITTLabel)AddControl(new Guid("4d4ecbf1-4e59-4701-b5b1-a8362b92e5dc"));
            lblBagliTakipBilgisiValue = (ITTLabel)AddControl(new Guid("f55f0475-d1f6-4828-880f-ffbc11f105e5"));
            lblBagliTakipBilgisi = (ITTLabel)AddControl(new Guid("014c7383-0dd2-4109-aac8-9979de3926d5"));
            lblFaturaTeslimNoValue = (ITTLabel)AddControl(new Guid("b4d98c0d-ced5-4d97-a895-ad31d974a941"));
            lblFaturaTeslimNo = (ITTLabel)AddControl(new Guid("a4ded657-d026-479f-b37e-ab532ac3cb00"));
            lblYupassIDValue = (ITTLabel)AddControl(new Guid("e4ba6f54-f486-4369-8d84-05cd371a0a8c"));
            lblYupassID = (ITTLabel)AddControl(new Guid("25323968-94a5-482d-9ade-e1a27e62dc61"));
            lblInfoValue = (ITTLabel)AddControl(new Guid("f3ed4d69-b7c3-4b6a-94cb-7510e48ce2d5"));
            lblInfo = (ITTLabel)AddControl(new Guid("8ad4b987-6079-49c1-9965-cb64dc9f7ba2"));
            lblInvoicedUserValue = (ITTLabel)AddControl(new Guid("6573a834-5242-49cb-9baa-fe8b85ed3d27"));
            lblInvoicedUser = (ITTLabel)AddControl(new Guid("833619d9-df04-4182-9ee5-73a28c6d35eb"));
            txtResultMessage = (ITTTextBox)AddControl(new Guid("f18959b1-89b2-4242-af7f-5ecadd19163f"));
            lblResultMessage = (ITTLabel)AddControl(new Guid("bb41c981-efdb-4321-bf30-d4c79f24decb"));
            txtPersonelNote = (ITTTextBox)AddControl(new Guid("ca062d5f-bf3a-4bbb-abb3-ea859419e613"));
            lblBasvuruNo = (ITTLabel)AddControl(new Guid("aec8b39e-bc86-4846-a24b-3247052130be"));
            lblSubEpisodeStatusValue = (ITTLabel)AddControl(new Guid("2f4f8930-d30e-4401-8100-a01fc8c2e9ae"));
            lblSubEpisodeStatus = (ITTLabel)AddControl(new Guid("39763974-bf88-445e-ac03-b3804607ac7b"));
            lblResultCodeValue = (ITTLabel)AddControl(new Guid("70c09292-2566-4a6a-85aa-daa44fe05ab6"));
            lblTakipTipi = (ITTLabel)AddControl(new Guid("e832849a-cd89-4d0e-aa73-2d67e994a129"));
            lblTakipTipiValue = (ITTLabel)AddControl(new Guid("ca43070e-e2cd-48cb-a464-2a17991e8017"));
            lblResultCode = (ITTLabel)AddControl(new Guid("01647846-1f5f-4c4d-84b0-a6410fd1e61d"));
            lblBasvuruNoValue = (ITTLabel)AddControl(new Guid("1951304a-c263-4ac6-8cad-4149b34879fe"));
            lblDevredilenKurumValue = (ITTLabel)AddControl(new Guid("7ed8665b-c1ce-49dd-99cb-2726b6b07d73"));
            lblPersonelNote = (ITTLabel)AddControl(new Guid("8b3e7752-bf90-43ea-b291-427f38be2af1"));
            lblProvizyonTipiValue = (ITTLabel)AddControl(new Guid("928b8eba-218b-439d-90c0-f10aea064cc0"));
            lblDevredilenKurum = (ITTLabel)AddControl(new Guid("bd57f8a7-1e28-4a4a-94e7-0345cecef0c0"));
            lblProvizyonTipi = (ITTLabel)AddControl(new Guid("057daf4c-7a1f-482a-a0b1-87ff0f3a2f67"));
            lblTedaviTipiVaue = (ITTLabel)AddControl(new Guid("0da3af1a-9160-4275-bd7d-8d84db3d026f"));
            lblTedaviTuruValue = (ITTLabel)AddControl(new Guid("71eb3af1-42f3-459c-a046-b3801e5ff0b7"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("3da3f168-f8d0-44ca-811d-15f8c590ef5b"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("81d801cb-8ef7-4881-b450-f99174231c86"));
            lblTakipNoValue = (ITTLabel)AddControl(new Guid("aa25029b-39b8-41ec-b333-9c3a2c01d677"));
            lblTakipNo = (ITTLabel)AddControl(new Guid("3f98bae9-0753-4c6b-84e6-a415ab27ceba"));
            grpBoxPatientEpisode = (ITTGroupBox)AddControl(new Guid("0eb6c005-febb-4843-8f13-ece1638a2835"));
            btnPatientEpisode = (ITTButton)AddControl(new Guid("df683035-d5f9-4d78-95e1-9c45fb16b881"));
            lblResSectionValue = (ITTLabel)AddControl(new Guid("7c8357f8-884c-4c9e-a1ce-5bf99f14c940"));
            lblResSection = (ITTLabel)AddControl(new Guid("e28466c7-859a-4dd5-8fab-7024f4fa7e4d"));
            lblServiceValue = (ITTLabel)AddControl(new Guid("44d47b19-c6cf-49b8-bf90-e690b4ec3734"));
            lblService = (ITTLabel)AddControl(new Guid("d655aec4-36ba-4fa1-ad57-149a7c43a763"));
            lblLeavingDateTimeValue = (ITTLabel)AddControl(new Guid("6311955d-aa32-423f-b4f0-3a2f37bb6ddc"));
            lblLeavingDateTime = (ITTLabel)AddControl(new Guid("c0204a15-cb6d-4c16-a2d4-f472668e5642"));
            lblFirstHospitalizationDateValue = (ITTLabel)AddControl(new Guid("c1dd15db-2ced-4c96-97cc-353f9b15f5b8"));
            lblFirstHospitalizationDate = (ITTLabel)AddControl(new Guid("6304d111-ccc9-4631-89ba-e3ebbf4c5516"));
            lblPatientStatusValue = (ITTLabel)AddControl(new Guid("b986d94b-b603-4fdd-9244-1ef6604a4ab0"));
            lblPatientStatus = (ITTLabel)AddControl(new Guid("d6696b68-12b6-4ff6-b5a3-df3dac51648e"));
            lblSupEpisodeNoValue = (ITTLabel)AddControl(new Guid("0280a194-2958-464e-b514-c88b00e41069"));
            lblSubEpisodeNo = (ITTLabel)AddControl(new Guid("5a5bb796-2474-4b0d-ae83-e071c7ba9d75"));
            lblEpisodeDateValue = (ITTLabel)AddControl(new Guid("ace92c50-e913-4dc5-aca5-a151e65eae1a"));
            lblEpisodeDate = (ITTLabel)AddControl(new Guid("429b27ed-48a3-4940-aa02-eca59e48e9e4"));
            lblEpisodeNoValue = (ITTLabel)AddControl(new Guid("f407d54f-25b2-4404-8821-b9740a918d51"));
            lblEpisodeNo = (ITTLabel)AddControl(new Guid("0edf9e86-0719-4469-b0ce-70861a51bfca"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1acec4d1-3e94-498d-b798-af406d4c9972"));
            lblBirthDate = (ITTLabel)AddControl(new Guid("d0eba543-f582-4818-9ca7-8b96d0d4f1d3"));
            lblYupassNoValue = (ITTLabel)AddControl(new Guid("7c372b45-7be7-4f7d-bce4-e02abcb90dfd"));
            lblYupassNo = (ITTLabel)AddControl(new Guid("4a0be49a-63eb-4223-97c4-543972ceda51"));
            lblTCNoValue = (ITTLabel)AddControl(new Guid("c643508b-78bc-49ce-afa4-7ad7f6614971"));
            lblTCNo = (ITTLabel)AddControl(new Guid("d2746c7f-35a9-4e67-b071-ef0124f7139a"));
            lblFullNameValue = (ITTLabel)AddControl(new Guid("49078a56-c4f9-45c3-8363-6b836da20430"));
            lblFullName = (ITTLabel)AddControl(new Guid("76e1945c-094e-4b26-8680-965e44b2f4ad"));
            grdDiagnosises = (ITTGrid)AddControl(new Guid("600e9d51-4574-4b34-b457-7c41bda279a0"));
            grdDiag_ObjectID = (ITTTextBoxColumn)AddControl(new Guid("1502111a-b369-4874-ac58-3e0322fe899a"));
            grdDiag_TTObject = (ITTTextBoxColumn)AddControl(new Guid("412e508e-1ba3-44cb-8bae-7708a1c6574a"));
            grdDiag_MedulaStatus = (ITTTextBoxColumn)AddControl(new Guid("a236788c-0a27-4c55-aad6-5a52520521f0"));
            grdDiag_DiagnoseDate = (ITTTextBoxColumn)AddControl(new Guid("e0839b23-3b25-45d0-a525-52f2f91d2ee0"));
            grdDiag_DiagnoseName = (ITTTextBoxColumn)AddControl(new Guid("b15f1fd5-f62c-46fd-b321-83edd6d50bce"));
            grdDiag_DiagnoseCode = (ITTTextBoxColumn)AddControl(new Guid("9905c103-e736-4372-b527-e568bcaed2aa"));
            grdDiag_DiagnosisType = (ITTTextBoxColumn)AddControl(new Guid("3d5cdaa0-d164-466d-9356-6345fc058827"));
            grdDiag_MedulaServiceProviderRefNo = (ITTTextBoxColumn)AddControl(new Guid("80ed94b2-de9a-44a5-bc65-3ccb45fa4971"));
            grdDiag_MedulaProcessNo = (ITTTextBoxColumn)AddControl(new Guid("76ec16a7-1822-4071-b741-251e8b38a9cb"));
            grdDiag_MedulaStatusText = (ITTTextBoxColumn)AddControl(new Guid("986aedbc-576a-4dff-a407-252a139cac4a"));
            grdDiag_MedulaResultCode = (ITTTextBoxColumn)AddControl(new Guid("4666b410-bde7-4621-98b3-b935d4bb51b2"));
            grdDiag_MedulaResultMessage = (ITTTextBoxColumn)AddControl(new Guid("b14e612e-14d8-4c7f-80cc-6f64317a7632"));
            grdDiag_SpecialCase = (ITTTextBoxColumn)AddControl(new Guid("efd1f87e-9121-4712-88d9-47f18e9e97d8"));
            base.InitializeControls();
        }

        public InvoiceForm() : base("InvoiceForm")
        {
        }

        protected InvoiceForm(string formDefName) : base(formDefName)
        {
        }
    }
}