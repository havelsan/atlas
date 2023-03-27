
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
    public partial class DentalCommitmentForm : TTForm
    {
    /// <summary>
    /// Diş Taahhüt İşlemlerinin Tutulduğu Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalCommitment _DentalCommitment
        {
            get { return (TTObjectClasses.DentalCommitment)_ttObject; }
        }

        protected ITTLabel labelCommitmentResultMessage;
        protected ITTTextBox CommitmentResultMessage;
        protected ITTTextBox CommitmentResultCode;
        protected ITTTextBox CommitmentProtocolNo;
        protected ITTTextBox CommitmentNo;
        protected ITTTextBox InnerDoorNo;
        protected ITTTextBox CommitmentTakenBySurname;
        protected ITTTextBox CommitmentTakenByName;
        protected ITTTextBox EMail;
        protected ITTTextBox PhoneNumber;
        protected ITTTextBox OuterDoorNo;
        protected ITTTextBox StreetName;
        protected ITTTextBox PostCode;
        protected ITTLabel labelCommitmentResultCode;
        protected ITTLabel labelCommitmentProtocolNo;
        protected ITTLabel labelCommitmentNo;
        protected ITTGrid DentalCommitmentProstethises;
        protected ITTTextBoxColumn DentalProsthesisDefinitionName;
        protected ITTTextBoxColumn ToothNoDentalCommitmentProsthesis;
        protected ITTListBoxColumn DentalProsthesisDefinitionDentalCommitmentProsthesis;
        protected ITTLabel labelTown;
        protected ITTObjectListBox Town;
        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelInnerDoorNo;
        protected ITTLabel labelCommitmentTakenBySurname;
        protected ITTLabel labelCommitmentTakenByName;
        protected ITTLabel labelEMail;
        protected ITTLabel labelPhoneNumber;
        protected ITTLabel labelOuterDoorNo;
        protected ITTLabel labelStreetName;
        protected ITTLabel labelPostCode;
        override protected void InitializeControls()
        {
            labelCommitmentResultMessage = (ITTLabel)AddControl(new Guid("05766ebe-647f-4f9a-97f9-d48c15ae5bb5"));
            CommitmentResultMessage = (ITTTextBox)AddControl(new Guid("76ff2f31-b99c-4ce4-8ec5-ab00ac4142d4"));
            CommitmentResultCode = (ITTTextBox)AddControl(new Guid("5e14288d-6ea3-4608-8055-fea6e4aa5452"));
            CommitmentProtocolNo = (ITTTextBox)AddControl(new Guid("962d2efb-9620-4432-8729-e8ba53ef5b98"));
            CommitmentNo = (ITTTextBox)AddControl(new Guid("32283f2a-ad59-4093-a224-be866f7ab80d"));
            InnerDoorNo = (ITTTextBox)AddControl(new Guid("87b9bd0c-eed5-4891-939d-cc738ab67ad7"));
            CommitmentTakenBySurname = (ITTTextBox)AddControl(new Guid("abe3b95c-a344-4dfa-b517-56f8bc493f54"));
            CommitmentTakenByName = (ITTTextBox)AddControl(new Guid("9aaaea80-354b-4586-9162-b66db4dc4f76"));
            EMail = (ITTTextBox)AddControl(new Guid("95bb3714-432e-4039-917d-44d0d25888bf"));
            PhoneNumber = (ITTTextBox)AddControl(new Guid("d43a4ffc-0ea9-42c2-b607-3047972bddb5"));
            OuterDoorNo = (ITTTextBox)AddControl(new Guid("138b2ca6-ed43-47c7-b4c3-22ea3392129a"));
            StreetName = (ITTTextBox)AddControl(new Guid("9e4b9dc4-7a6c-477d-9003-30ef4e8e40ed"));
            PostCode = (ITTTextBox)AddControl(new Guid("1d2b5815-5f17-43de-88b6-dce61a9b974a"));
            labelCommitmentResultCode = (ITTLabel)AddControl(new Guid("e641b1c4-9043-400e-a82b-000ecf0caae8"));
            labelCommitmentProtocolNo = (ITTLabel)AddControl(new Guid("95f484aa-6904-48f3-91ea-467291c21873"));
            labelCommitmentNo = (ITTLabel)AddControl(new Guid("7ccdef5d-3433-4c50-a4d2-fe172c408de7"));
            DentalCommitmentProstethises = (ITTGrid)AddControl(new Guid("df65b1cd-2a76-4005-9191-b1101601b486"));
            DentalProsthesisDefinitionName = (ITTTextBoxColumn)AddControl(new Guid("6bce024f-1572-4b92-9152-dfc337c6d2c3"));
            ToothNoDentalCommitmentProsthesis = (ITTTextBoxColumn)AddControl(new Guid("f3fdd5b2-5cbb-4d57-a56e-5b35fcbd262a"));
            DentalProsthesisDefinitionDentalCommitmentProsthesis = (ITTListBoxColumn)AddControl(new Guid("ec197d7f-e9d3-4d17-8b2c-baed8ccd0408"));
            labelTown = (ITTLabel)AddControl(new Guid("10d69abf-ad76-4ba1-baf3-fbb7d4b7b75a"));
            Town = (ITTObjectListBox)AddControl(new Guid("55f311bf-6c39-4a96-9653-c70256d92815"));
            labelCity = (ITTLabel)AddControl(new Guid("09d35524-18e4-47a5-896d-89902b64bca7"));
            City = (ITTObjectListBox)AddControl(new Guid("9cd68775-c557-413e-8d2e-41c9209aee77"));
            labelInnerDoorNo = (ITTLabel)AddControl(new Guid("d2fb470e-675c-47f3-9444-5eca660b2a29"));
            labelCommitmentTakenBySurname = (ITTLabel)AddControl(new Guid("d0a6ae1c-fbd4-4f2b-a8d4-46a8eaee82f3"));
            labelCommitmentTakenByName = (ITTLabel)AddControl(new Guid("4c8892d0-2d20-4665-925f-f8e70603aac4"));
            labelEMail = (ITTLabel)AddControl(new Guid("72e56f8d-1969-424c-94d9-73181ab477c8"));
            labelPhoneNumber = (ITTLabel)AddControl(new Guid("59bdc0e3-fe86-49f5-86be-e8629f8acd7d"));
            labelOuterDoorNo = (ITTLabel)AddControl(new Guid("072a2bc7-ae1e-42b5-b9f1-39eff099311c"));
            labelStreetName = (ITTLabel)AddControl(new Guid("07d8d48e-5e73-417c-8620-6ac76eaf0b92"));
            labelPostCode = (ITTLabel)AddControl(new Guid("9f4f7137-407d-4e89-b76c-61e19e8e9926"));
            base.InitializeControls();
        }

        public DentalCommitmentForm() : base("DENTALCOMMITMENT", "DentalCommitmentForm")
        {
        }

        protected DentalCommitmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}