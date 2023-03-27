
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
    /// New Form
    /// </summary>
    public partial class NewRationForm : TTForm
    {
        protected TTObjectClasses.MLRRation _MLRRation
        {
            get { return (TTObjectClasses.MLRRation)_ttObject; }
        }

        protected ITTLabel labelDietician;
        protected ITTLabel labelOrganizerService;
        protected ITTObjectListBox OrganizerService;
        protected ITTDateTimePicker Date;
        protected ITTObjectListBox OrganizerPerson;
        protected ITTObjectListBox Dietician;
        protected ITTButton buttonCreateRegimeGroup;
        protected ITTLabel labelOrganizerPerson;
        protected ITTLabel labelDate;
        protected ITTLabel labelApprovedBy;
        protected ITTLabel labelApprovalDietician;
        protected ITTObjectListBox ApprovalDietician;
        protected ITTObjectListBox ApprovedBy;
        override protected void InitializeControls()
        {
            labelDietician = (ITTLabel)AddControl(new Guid("cb914c8d-86f8-4614-9835-034d1d500e2f"));
            labelOrganizerService = (ITTLabel)AddControl(new Guid("dacdf21f-44e6-45bb-ba49-2e6777952fa8"));
            OrganizerService = (ITTObjectListBox)AddControl(new Guid("bebfb3f8-6b30-4a8f-b91f-127d6ead1f1b"));
            Date = (ITTDateTimePicker)AddControl(new Guid("8abfe62f-1729-4522-bf0d-3bd161936fdd"));
            OrganizerPerson = (ITTObjectListBox)AddControl(new Guid("edd1b14f-c5fe-468a-b157-41f1c3b9b895"));
            Dietician = (ITTObjectListBox)AddControl(new Guid("615f1dd0-e6c1-492f-9862-3684acb0a792"));
            buttonCreateRegimeGroup = (ITTButton)AddControl(new Guid("b932d203-884a-469d-80c9-5f4733f8842c"));
            labelOrganizerPerson = (ITTLabel)AddControl(new Guid("fa5b964a-38ba-462b-90d4-6f79631efdad"));
            labelDate = (ITTLabel)AddControl(new Guid("ecc0742c-8a2f-4462-97e3-856ad14738a7"));
            labelApprovedBy = (ITTLabel)AddControl(new Guid("bcd776b3-c0e8-47f1-b03d-afd4357474ff"));
            labelApprovalDietician = (ITTLabel)AddControl(new Guid("35ad3464-d25e-43e2-bf9f-bc25a560f86f"));
            ApprovalDietician = (ITTObjectListBox)AddControl(new Guid("9a8de7d8-32f5-4795-9989-dd6293145992"));
            ApprovedBy = (ITTObjectListBox)AddControl(new Guid("7ac1546a-3c4c-490e-b0b9-e6457026c4b5"));
            base.InitializeControls();
        }

        public NewRationForm() : base("MLRRATION", "NewRationForm")
        {
        }

        protected NewRationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}