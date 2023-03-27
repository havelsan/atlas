
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
    public partial class CompleteBloodProductsForm : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.CompleteBloodProducts _CompleteBloodProducts
        {
            get { return (TTObjectClasses.CompleteBloodProducts)_ttObject; }
        }

        protected ITTButton ttbutton2;
        protected ITTTextBox tttextbox1;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ttbutton2 = (ITTButton)AddControl(new Guid("d4cde482-40ea-4a7d-8cec-a6c1696d48e5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6b42ec4d-0c83-440e-a30d-596b1f8e6b73"));
            ttbutton3 = (ITTButton)AddControl(new Guid("fe5eae44-8df1-4e95-a71c-e4e9e579e3e4"));
            ttbutton1 = (ITTButton)AddControl(new Guid("fbf4fed6-2f8f-42bd-9334-b9813b1a1536"));
            base.InitializeControls();
        }

        public CompleteBloodProductsForm() : base("COMPLETEBLOODPRODUCTS", "CompleteBloodProductsForm")
        {
        }

        protected CompleteBloodProductsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}