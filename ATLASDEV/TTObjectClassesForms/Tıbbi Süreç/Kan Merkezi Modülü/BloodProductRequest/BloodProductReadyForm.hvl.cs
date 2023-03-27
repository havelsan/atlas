
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
    /// Kan Bankası Kan Ürünü Hazır
    /// </summary>
    public partial class BloodProductReadyForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid grdProducts;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn ISBTUnitNumber;
        protected ITTTextBoxColumn ISBTElementCode;
        protected ITTTextBoxColumn txtProductNo;
        protected ITTTextBoxColumn txtNotes;
        protected ITTButtonColumn btnCancel;
        protected ITTTextBoxColumn txtBloodProductState;
        protected ITTCheckBoxColumn chkUsed;
        protected ITTCheckBoxColumn chkReturn;
        protected ITTCheckBoxColumn chkIsinlanmis;
        protected ITTCheckBoxColumn chkFiltrelenmis;
        protected ITTTextBoxColumn txtAmount;
        protected ITTListBoxColumn OzelDurum;
        protected ITTGroupBox ttgroupbox1;
        protected ITTPanel pnlUrgent;
        protected ITTCheckBox chkWithTest;
        protected ITTCheckBox chkWithoutTests;
        protected ITTCheckBox chkUrgentCross;
        protected ITTCheckBox chkWithoutCross;
        protected ITTCheckBox chkNormal;
        protected ITTDateTimePicker dtTransfused;
        protected ITTDateTimePicker dtPregnancy;
        protected ITTCheckBox chkBlock;
        protected ITTCheckBox chkOther;
        protected ITTCheckBox chkHB;
        protected ITTCheckBox chkPrepare;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox chkSurgery;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox chkPregnancy;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox chkTransfused;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkUrgent;
        protected ITTCheckBox ttcheckbox4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTDateTimePicker dtRequirement;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a1ef1497-a7bf-4678-9a37-54d62311272e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1caf02b0-215e-4071-8151-60076a953d96"));
            grdProducts = (ITTGrid)AddControl(new Guid("5c9eaecc-1ea4-4235-bafc-2048a7da9a29"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("6d705a20-985d-458c-bf59-836a94f1cc16"));
            ISBTUnitNumber = (ITTTextBoxColumn)AddControl(new Guid("9027ba22-75a4-47c5-99f3-fd4a7f028853"));
            ISBTElementCode = (ITTTextBoxColumn)AddControl(new Guid("1c7eda9a-ee8a-49a7-9f9a-96389ea82172"));
            txtProductNo = (ITTTextBoxColumn)AddControl(new Guid("c28f3b8c-78b4-45c8-92ae-b97134723ab0"));
            txtNotes = (ITTTextBoxColumn)AddControl(new Guid("b0f49eab-14d1-4923-aa73-0ea49fb5907b"));
            btnCancel = (ITTButtonColumn)AddControl(new Guid("b885d04b-5d96-4f8d-a26c-b85c3189142c"));
            txtBloodProductState = (ITTTextBoxColumn)AddControl(new Guid("e1a35e20-fb3f-4ded-bef4-dc70711cfc34"));
            chkUsed = (ITTCheckBoxColumn)AddControl(new Guid("33d7d5c3-d699-42be-835a-9037e4d404c0"));
            chkReturn = (ITTCheckBoxColumn)AddControl(new Guid("93555c84-b0ee-44ad-9ff3-f63e1d4c9e2b"));
            chkIsinlanmis = (ITTCheckBoxColumn)AddControl(new Guid("1b17770b-91f0-4a6e-a24c-62a942b17d3f"));
            chkFiltrelenmis = (ITTCheckBoxColumn)AddControl(new Guid("a74e4b09-a912-432c-b5f5-dfd59ebc5ecc"));
            txtAmount = (ITTTextBoxColumn)AddControl(new Guid("46818fec-6dd8-4266-a721-c374d753f398"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("aa7d193e-c1f2-4ca9-8f5c-a31481a5027c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1351e131-a18b-422c-be47-fbedd108a4ac"));
            pnlUrgent = (ITTPanel)AddControl(new Guid("cfc69f89-9835-4ccb-a89c-7fb94c052e5e"));
            chkWithTest = (ITTCheckBox)AddControl(new Guid("014c6095-141e-4b8d-b6e6-cb48af9eb68b"));
            chkWithoutTests = (ITTCheckBox)AddControl(new Guid("a296c973-8bde-4f60-a980-7080c3cda0ab"));
            chkUrgentCross = (ITTCheckBox)AddControl(new Guid("9721d3f7-428b-4c2a-a07a-bb84403a2e08"));
            chkWithoutCross = (ITTCheckBox)AddControl(new Guid("6d372875-0d90-4163-ab70-f2340b50edfd"));
            chkNormal = (ITTCheckBox)AddControl(new Guid("e9b59467-87e0-4ca0-8de7-cbfb0750d72e"));
            dtTransfused = (ITTDateTimePicker)AddControl(new Guid("a0773ee9-a57c-4ff1-8671-8374ecc84d44"));
            dtPregnancy = (ITTDateTimePicker)AddControl(new Guid("d4c7e8a8-0829-492d-a507-8f237b6e3edc"));
            chkBlock = (ITTCheckBox)AddControl(new Guid("0cacd0ba-c5a6-471e-8d46-bdb103064a9f"));
            chkOther = (ITTCheckBox)AddControl(new Guid("9856e9e6-2f58-4589-9b0b-898706aa14a4"));
            chkHB = (ITTCheckBox)AddControl(new Guid("50076222-e42c-4c21-a5ad-f728de636187"));
            chkPrepare = (ITTCheckBox)AddControl(new Guid("2cab85ea-41c0-4488-9f6d-0a271704d458"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c7b5ed58-9f3e-4275-ad2c-c561a0f6e7a3"));
            chkSurgery = (ITTCheckBox)AddControl(new Guid("12a68a04-6b88-4a7c-8d7d-30b25272d987"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("8b536754-b97d-4004-9bc3-5f27be7267e6"));
            chkPregnancy = (ITTCheckBox)AddControl(new Guid("f149e28b-b8f2-4db2-82a8-9ec2fa2e3e6e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7a80ca56-f9e7-4b00-86d8-e11c49ccfe2c"));
            chkTransfused = (ITTCheckBox)AddControl(new Guid("ae4d6d71-16f6-4420-9821-9f99dad7f003"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4375e218-a193-42bf-882c-37f452ca1e8f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0e86b74a-2914-412c-b707-efee5ac05df4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("90c5b504-07b3-4bbb-b54a-2398481cb298"));
            chkUrgent = (ITTCheckBox)AddControl(new Guid("d9fa2722-3a23-4f68-8ea0-13345fa4c87f"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("f1747b3e-615f-47bc-a5d8-6e56ccf5273b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("91a1100a-fbb9-4e85-bd92-b5c318d0a32a"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("6b687a2b-e07a-4028-8494-1d1ee526dc88"));
            dtRequirement = (ITTDateTimePicker)AddControl(new Guid("41eaa6c5-f70e-49f6-b910-b23a326a78e1"));
            base.InitializeControls();
        }

        public BloodProductReadyForm() : base("BLOODPRODUCTREQUEST", "BloodProductReadyForm")
        {
        }

        protected BloodProductReadyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}