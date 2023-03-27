
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
    /// Giden Evrak Bilgileri
    /// </summary>
    public partial class NewOutgoingDocumentForm : TTForm
    {
    /// <summary>
    /// Giden Evrak
    /// </summary>
        protected TTObjectClasses.MPBSOutgoingDocument _MPBSOutgoingDocument
        {
            get { return (TTObjectClasses.MPBSOutgoingDocument)_ttObject; }
        }

        protected ITTTextBox DailyDocumentNo;
        protected ITTDateTimePicker WearLifeDate;
        protected ITTEnumComboBox InternalExternal;
        protected ITTLabel labelDocumentNo;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelWhichCupboardIn;
        protected ITTDateTimePicker RegisterDate;
        protected ITTTextBox SecurityLevel;
        protected ITTDateTimePicker DistributionDate;
        protected ITTLabel labelIdentifier;
        protected ITTLabel labelSubject;
        protected ITTTextBox DocumentNo;
        protected ITTTextBox WhichCupboardIn;
        protected ITTLabel labelDistributionDate;
        protected ITTLabel labelInternalExternal;
        protected ITTTextBox To;
        protected ITTTextBox PresentationType;
        protected ITTLabel labelRegisterDate;
        protected ITTLabel labelTo;
        protected ITTLabel labelWhichFileIn;
        protected ITTTextBox Subject;
        protected ITTTextBox Identifier;
        protected ITTLabel labelSecurityLevel;
        protected ITTTextBox WhichFileIn;
        protected ITTLabel labelAdditionalNumber;
        protected ITTLabel labelConcernedPosition;
        protected ITTLabel labelPresentationType;
        protected ITTTextBox ConcernedPosition;
        protected ITTLabel labelDailyDocumentNo;
        protected ITTTextBox AdditionalNumber;
        protected ITTLabel labelWearLifeDate;
        protected ITTLabel labelDate;
        override protected void InitializeControls()
        {
            DailyDocumentNo = (ITTTextBox)AddControl(new Guid("65ca649c-73c6-4f46-82ab-05422a1cb1c5"));
            WearLifeDate = (ITTDateTimePicker)AddControl(new Guid("a4abc5b2-af84-468c-8b85-ff5eb6f42463"));
            InternalExternal = (ITTEnumComboBox)AddControl(new Guid("78d60c12-7313-4cb2-bc26-fa58b7a6a7b4"));
            labelDocumentNo = (ITTLabel)AddControl(new Guid("23e1c9e0-b3a1-41f7-85a9-d1f57eb53de1"));
            Date = (ITTDateTimePicker)AddControl(new Guid("4d192fe4-072a-4783-9603-fb0bffb2ee3d"));
            labelWhichCupboardIn = (ITTLabel)AddControl(new Guid("f3296882-b4a3-48c4-98c4-fbdcf4b2037c"));
            RegisterDate = (ITTDateTimePicker)AddControl(new Guid("b4b83887-a2f5-45ad-939c-e8d49d7190b8"));
            SecurityLevel = (ITTTextBox)AddControl(new Guid("7492919f-68f2-42a5-8397-9d5e5c90348c"));
            DistributionDate = (ITTDateTimePicker)AddControl(new Guid("475940fa-a7ac-4198-9717-958add7c054f"));
            labelIdentifier = (ITTLabel)AddControl(new Guid("93a6b7fa-aec8-43d4-8cea-a2bb08a9778e"));
            labelSubject = (ITTLabel)AddControl(new Guid("1cee120b-d11e-4692-917f-9d7e5a70202f"));
            DocumentNo = (ITTTextBox)AddControl(new Guid("86848b21-361b-4d3e-91a6-80fae398801a"));
            WhichCupboardIn = (ITTTextBox)AddControl(new Guid("16841040-3273-4fe5-98eb-a8935f4d0d5b"));
            labelDistributionDate = (ITTLabel)AddControl(new Guid("ec6d3360-43c0-46ab-bab3-a86064ecc710"));
            labelInternalExternal = (ITTLabel)AddControl(new Guid("d7962629-f2be-461b-b48d-7cefe9ec7970"));
            To = (ITTTextBox)AddControl(new Guid("47199e3c-5dda-4e89-8199-68f8785349ae"));
            PresentationType = (ITTTextBox)AddControl(new Guid("d3656ae2-d5a1-420b-9695-6e2e5ff3bc27"));
            labelRegisterDate = (ITTLabel)AddControl(new Guid("b25834b3-f85c-40f3-840f-73f520572977"));
            labelTo = (ITTLabel)AddControl(new Guid("e06285ed-7ec1-4b37-9195-71e6cbc6955f"));
            labelWhichFileIn = (ITTLabel)AddControl(new Guid("dbf732f0-e418-4a39-b228-3507f5cea410"));
            Subject = (ITTTextBox)AddControl(new Guid("c927e322-2c1e-43c0-b5e0-33462b9c9e9d"));
            Identifier = (ITTTextBox)AddControl(new Guid("9e20e858-8bc4-4cc4-b751-4f78bed4241c"));
            labelSecurityLevel = (ITTLabel)AddControl(new Guid("ce4a46e4-6253-45fd-ae0a-4b3891855965"));
            WhichFileIn = (ITTTextBox)AddControl(new Guid("2a04fdb3-bec4-4065-a5e7-609d85aadda8"));
            labelAdditionalNumber = (ITTLabel)AddControl(new Guid("bce3971d-d40e-45c9-8e9e-3a8a19944152"));
            labelConcernedPosition = (ITTLabel)AddControl(new Guid("52a8a239-a612-4057-9b90-1931c2951f4e"));
            labelPresentationType = (ITTLabel)AddControl(new Guid("b2efe1fd-deb7-44d1-953a-1fb99665c650"));
            ConcernedPosition = (ITTTextBox)AddControl(new Guid("64b07f7c-6934-4206-9937-26ba337cdae7"));
            labelDailyDocumentNo = (ITTLabel)AddControl(new Guid("d8a70c30-9e57-4779-b97e-2276a45f2da7"));
            AdditionalNumber = (ITTTextBox)AddControl(new Guid("c04299a6-c97a-4200-b690-26cfa3466ec3"));
            labelWearLifeDate = (ITTLabel)AddControl(new Guid("6879afc7-7f0b-4492-b19e-f1229191b3bc"));
            labelDate = (ITTLabel)AddControl(new Guid("76b66007-fc04-433a-8503-fae0ec126500"));
            base.InitializeControls();
        }

        public NewOutgoingDocumentForm() : base("MPBSOUTGOINGDOCUMENT", "NewOutgoingDocumentForm")
        {
        }

        protected NewOutgoingDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}