
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
    public partial class DrugOrderIntroductionNewUnbound : TTUnboundForm
    {
        protected ITTObjectListBox EtkinMaddeListBox;
        protected ITTObjectListBox DrugListBox;
        protected ITTTextBox DrugName;
        protected ITTButton CloseButton;
        protected ITTButton saveButton;
        protected ITTLabel IlacLabel;
        protected ITTListView DrugListview;
        protected ITTListView EtkinMaddeListview;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            EtkinMaddeListBox = (ITTObjectListBox)AddControl(new Guid("ad30407b-d725-4ead-9bb8-70f5d9e03ded"));
            DrugListBox = (ITTObjectListBox)AddControl(new Guid("7ecc2a16-7bf9-446b-b87a-4ad0e65cd0ca"));
            DrugName = (ITTTextBox)AddControl(new Guid("7a11cc22-c399-4e61-a196-a33616e614cc"));
            CloseButton = (ITTButton)AddControl(new Guid("241e96de-fa33-4c07-a35b-57ff57022ae9"));
            saveButton = (ITTButton)AddControl(new Guid("ec2b5fe8-4a96-48ff-9843-10227ce9ac4e"));
            IlacLabel = (ITTLabel)AddControl(new Guid("b26fab6a-e685-49a7-846d-b5c6d8ec1f45"));
            DrugListview = (ITTListView)AddControl(new Guid("8c1873cf-6d95-488f-90c4-a2e30f4c6bb6"));
            EtkinMaddeListview = (ITTListView)AddControl(new Guid("2404dbc7-fde8-4a59-9f32-8f41625e5dab"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ac629afd-4e26-4fd7-9f3c-d66d9c3fbdbe"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7dba5650-9e87-45cf-8530-ba1652fc59c8"));
            base.InitializeControls();
        }

        public DrugOrderIntroductionNewUnbound() : base("DrugOrderIntroductionNewUnbound")
        {
        }

        protected DrugOrderIntroductionNewUnbound(string formDefName) : base(formDefName)
        {
        }
    }
}