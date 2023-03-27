
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
    public partial class LaboratoryTabOrderForm : TTUnboundForm
    {
        protected ITTButton btnSave;
        protected ITTLabel lblTab;
        protected ITTButton btnDown;
        protected ITTButton btnUp;
        protected ITTListView TabsListView;
        protected ITTObjectListBox TabList;
        override protected void InitializeControls()
        {
            btnSave = (ITTButton)AddControl(new Guid("e5fe8829-ea3e-469a-bff1-c4d513272d3b"));
            lblTab = (ITTLabel)AddControl(new Guid("ec5991fb-c7ae-41dd-bdfa-ee575919ac5e"));
            btnDown = (ITTButton)AddControl(new Guid("c36409c0-8abf-4852-b38a-749e38b8f159"));
            btnUp = (ITTButton)AddControl(new Guid("c11e7f0c-ef19-4c8f-b6eb-e02df91b835b"));
            TabsListView = (ITTListView)AddControl(new Guid("39a33546-6e99-4d8f-94ac-7760f39d8b5a"));
            TabList = (ITTObjectListBox)AddControl(new Guid("e8c2167b-167e-4f8c-aa7a-5cd37a8a9fb3"));
            base.InitializeControls();
        }

        public LaboratoryTabOrderForm() : base("LaboratoryTabOrderForm")
        {
        }

        protected LaboratoryTabOrderForm(string formDefName) : base(formDefName)
        {
        }
    }
}