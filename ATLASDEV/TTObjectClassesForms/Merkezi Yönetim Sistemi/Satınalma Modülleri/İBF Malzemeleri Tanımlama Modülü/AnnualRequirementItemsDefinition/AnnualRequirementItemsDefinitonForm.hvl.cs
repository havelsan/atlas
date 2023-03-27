
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
    /// İBF Malzemeleri Tanımlama
    /// </summary>
    public partial class AnnualRequirementItemsDefiniton : TerminologyManagerDefForm
    {
    /// <summary>
    /// İBF Malzemeleri
    /// </summary>
        protected TTObjectClasses.AnnualRequirementItemsDefinition _AnnualRequirementItemsDefinition
        {
            get { return (TTObjectClasses.AnnualRequirementItemsDefinition)_ttObject; }
        }

        protected ITTGrid ARItemsGrid;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTEnumComboBox IBFType;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ARItemsGrid = (ITTGrid)AddControl(new Guid("74a9a443-7a31-47bb-b059-c9c65b1bd3ec"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("6b422840-fd48-4c9d-9090-c6f70714a6d8"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("50c6ce0c-8865-4b05-965a-bb19fad248d5"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("a3dd65e8-5351-4092-98c6-0642b71c350a"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("7e8b178e-50fa-4ab5-8a18-a76b7cc476ab"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("142c9fe0-9337-4fe3-a370-9d994b168081"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("643584ec-9eb2-4c60-a7bc-197e4830fc43"));
            base.InitializeControls();
        }

        public AnnualRequirementItemsDefiniton() : base("ANNUALREQUIREMENTITEMSDEFINITION", "AnnualRequirementItemsDefiniton")
        {
        }

        protected AnnualRequirementItemsDefiniton(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}