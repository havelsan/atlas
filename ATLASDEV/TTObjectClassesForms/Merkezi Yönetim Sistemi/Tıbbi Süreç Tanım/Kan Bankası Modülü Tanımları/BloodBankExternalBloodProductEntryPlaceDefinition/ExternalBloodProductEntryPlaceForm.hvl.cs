
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
    /// Hastaya Dışarıdan Kan Girişi Yapılacak Yerler
    /// </summary>
    public partial class ExternalBloodProductEntryPlaceForm : TTForm
    {
    /// <summary>
    /// Hastaya Dışarıdan Kan Girişi Yapılacak Yerler
    /// </summary>
        protected TTObjectClasses.BloodBankExternalBloodProductEntryPlaceDefinition _BloodBankExternalBloodProductEntryPlaceDefinition
        {
            get { return (TTObjectClasses.BloodBankExternalBloodProductEntryPlaceDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        protected ITTGrid ttgrid1;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("527cfea8-c190-4e00-b299-3a40a05c8ac1"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("cea0db64-57ad-48be-83b8-1a44bd9ff445"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("9730b58a-b2eb-4a91-bc27-3c9828718755"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("62b43a63-5013-4650-b993-6d36e6682d71"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f6e6c113-8551-4ec1-ba78-05363b5af5ee"));
            Name = (ITTTextBox)AddControl(new Guid("3723616f-dde6-4b33-b4ad-6c0616c12a72"));
            Description = (ITTTextBox)AddControl(new Guid("6a233165-25c0-4e1a-855a-c99bc577795d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("38136627-bfbd-420a-a1d1-3c8d916a09b8"));
            labelDescription = (ITTLabel)AddControl(new Guid("016e971f-8260-435e-bc5c-a4a475b0bb8e"));
            labelName = (ITTLabel)AddControl(new Guid("3f6a817a-9d3c-481a-a24f-b96400e1baa8"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("f8e8a093-5af1-4267-b660-bdf71d64cb60"));
            IsActive = (ITTCheckBox)AddControl(new Guid("b864bb92-e2a0-4ca6-b580-bca3ce10471e"));
            base.InitializeControls();
        }

        public ExternalBloodProductEntryPlaceForm() : base("BLOODBANKEXTERNALBLOODPRODUCTENTRYPLACEDEFINITION", "ExternalBloodProductEntryPlaceForm")
        {
        }

        protected ExternalBloodProductEntryPlaceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}