
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
    public partial class AnesteziDoktorTescilNoDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.AnesteziDoktorTescilNo _AnesteziDoktorTescilNo
        {
            get { return (TTObjectClasses.AnesteziDoktorTescilNo)_ttObject; }
        }

        protected ITTLabel labelanesteziDoktorTescilNo;
        protected ITTTextBox anesteziDoktorTescilNo;
        protected ITTTextBox anesteziDoktorAdi;
        protected ITTLabel labelanesteziDoktorAdi;
        override protected void InitializeControls()
        {
            labelanesteziDoktorTescilNo = (ITTLabel)AddControl(new Guid("6e7a5dba-91a5-40f2-8b29-fd1df5146fd3"));
            anesteziDoktorTescilNo = (ITTTextBox)AddControl(new Guid("38c90e48-ae85-4520-a1ad-b4b7b995d5e7"));
            anesteziDoktorAdi = (ITTTextBox)AddControl(new Guid("47e139e5-1195-4069-89f6-5b395bbaa4cd"));
            labelanesteziDoktorAdi = (ITTLabel)AddControl(new Guid("5f55d825-cc96-4401-a05f-251fd025f522"));
            base.InitializeControls();
        }

        public AnesteziDoktorTescilNoDefinitionForm() : base("ANESTEZIDOKTORTESCILNO", "AnesteziDoktorTescilNoDefinitionForm")
        {
        }

        protected AnesteziDoktorTescilNoDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}