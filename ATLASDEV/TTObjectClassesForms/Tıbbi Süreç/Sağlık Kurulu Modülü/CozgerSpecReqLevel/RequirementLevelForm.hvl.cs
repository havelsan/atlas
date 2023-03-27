
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
    public partial class RequirementLevelForm : TTDefinitionForm
    {
    /// <summary>
    /// Çözger Special Requirement Level (Özel Gereksinim Seviyesi)
    /// </summary>
        protected TTObjectClasses.CozgerSpecReqLevel _CozgerSpecReqLevel
        {
            get { return (TTObjectClasses.CozgerSpecReqLevel)_ttObject; }
        }

        protected ITTLabel labelGereksinimYuzdeBitis;
        protected ITTTextBox GereksinimYuzdeBitis;
        protected ITTTextBox GereksinimYuzdeBaslangic;
        protected ITTTextBox Aciklama;
        protected ITTTextBox Id;
        protected ITTLabel labelGereksinimYuzdeBaslangic;
        protected ITTLabel labelAciklama;
        protected ITTLabel labelId;
        override protected void InitializeControls()
        {
            labelGereksinimYuzdeBitis = (ITTLabel)AddControl(new Guid("efb09448-4647-49b4-884e-b2a27d722e8d"));
            GereksinimYuzdeBitis = (ITTTextBox)AddControl(new Guid("bd746ead-9c16-4b0a-b27c-e631b862ede5"));
            GereksinimYuzdeBaslangic = (ITTTextBox)AddControl(new Guid("94c55d8e-fbf9-46ab-a8db-7577163ddd49"));
            Aciklama = (ITTTextBox)AddControl(new Guid("209a55ee-7a3c-4723-bd40-fb78852d018c"));
            Id = (ITTTextBox)AddControl(new Guid("4b32e9c0-dfcf-484f-b2a3-9336476bc894"));
            labelGereksinimYuzdeBaslangic = (ITTLabel)AddControl(new Guid("76a88620-ee8a-4825-92c7-3752320017ee"));
            labelAciklama = (ITTLabel)AddControl(new Guid("bcf8592a-78db-4e26-ac9a-cba5a921962c"));
            labelId = (ITTLabel)AddControl(new Guid("4a6208dd-0def-4c9a-ba29-e6e853c47437"));
            base.InitializeControls();
        }

        public RequirementLevelForm() : base("COZGERSPECREQLEVEL", "RequirementLevelForm")
        {
        }

        protected RequirementLevelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}