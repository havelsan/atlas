
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
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresVoucherDistributingDocNewForm : BasePresVoucherDistributingDocForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresVoucherDistributingDoc _PresVoucherDistributingDoc
        {
            get { return (TTObjectClasses.PresVoucherDistributingDoc)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid PresVoucherDistDocMaterials;
        protected ITTListBoxColumn MaterialPresVoucherDistDocMaterial;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequireAmountPresVoucherDistDocMaterial;
        protected ITTListBoxColumn StockLevelTypePresVoucherDistDocMaterial;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("fe723205-0441-4580-9608-cc5b72c0c95a"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("3da31a19-ddca-4454-a24d-f3541b7ca6bd"));
            PresVoucherDistDocMaterials = (ITTGrid)AddControl(new Guid("feb898c1-fd84-4ef9-a70f-5377db7a6317"));
            MaterialPresVoucherDistDocMaterial = (ITTListBoxColumn)AddControl(new Guid("c69f3f7d-ca11-4881-8800-ac5dec8b081b"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("11a86934-3cae-4227-bdfc-ad605e18f85a"));
            RequireAmountPresVoucherDistDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("5712fe48-9b26-432f-9d12-371e3c5be14a"));
            StockLevelTypePresVoucherDistDocMaterial = (ITTListBoxColumn)AddControl(new Guid("b3be2387-f140-4631-9209-ae8cf8236104"));
            base.InitializeControls();
        }

        public PresVoucherDistributingDocNewForm() : base("PRESVOUCHERDISTRIBUTINGDOC", "PresVoucherDistributingDocNewForm")
        {
        }

        protected PresVoucherDistributingDocNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}