
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
    public partial class IlDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.Il _Il
        {
            get { return (TTObjectClasses.Il)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ilcelerTabpage;
        protected ITTGrid Ilceler;
        protected ITTTextBoxColumn IlceKoduIlce;
        protected ITTTextBoxColumn IlceAdiIlce;
        protected ITTTextBox IlAdi;
        protected ITTTextBox IlKodu;
        protected ITTLabel labelIlAdi;
        protected ITTLabel labelIlKodu;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d2d7f2d3-52a3-49b8-b994-352cce1ffd11"));
            ilcelerTabpage = (ITTTabPage)AddControl(new Guid("32d719e4-cc79-47e7-a31f-cc983e0df969"));
            Ilceler = (ITTGrid)AddControl(new Guid("b24f44a8-5c20-4d35-8ab0-f6ba551508d0"));
            IlceKoduIlce = (ITTTextBoxColumn)AddControl(new Guid("3d4f387b-3b36-47ce-874c-f527ee5f15a1"));
            IlceAdiIlce = (ITTTextBoxColumn)AddControl(new Guid("cc913371-6674-4001-ab09-d846e5c5e681"));
            IlAdi = (ITTTextBox)AddControl(new Guid("35384a9a-d2e6-4d6d-987c-5e9a7053d7c8"));
            IlKodu = (ITTTextBox)AddControl(new Guid("e2560bc9-9fba-4224-86a4-52a01f2bef25"));
            labelIlAdi = (ITTLabel)AddControl(new Guid("30b5211b-911d-4ad0-904f-57f178b35e66"));
            labelIlKodu = (ITTLabel)AddControl(new Guid("577957cd-d90c-4075-8aeb-c50f43cd18e6"));
            base.InitializeControls();
        }

        public IlDefinitionForm() : base("IL", "IlDefinitionForm")
        {
        }

        protected IlDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}