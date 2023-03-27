
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
    public partial class FTRVucutBolgesiDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.FTRVucutBolgesi _FTRVucutBolgesi
        {
            get { return (TTObjectClasses.FTRVucutBolgesi)_ttObject; }
        }

        protected ITTLabel labelftrVucutBolgesiAdi;
        protected ITTTextBox ftrVucutBolgesiAdi;
        protected ITTLabel labelftrVucutBolgesiKodu;
        protected ITTTextBox ftrVucutBolgesiKodu;
        override protected void InitializeControls()
        {
            labelftrVucutBolgesiAdi = (ITTLabel)AddControl(new Guid("9a60e16a-acdf-449f-af65-6a7e467345a0"));
            ftrVucutBolgesiAdi = (ITTTextBox)AddControl(new Guid("0655ea8e-8b66-4980-8abe-a7197e5c31a2"));
            labelftrVucutBolgesiKodu = (ITTLabel)AddControl(new Guid("778b310a-ec7a-4d60-ad46-e73519fd8ed4"));
            ftrVucutBolgesiKodu = (ITTTextBox)AddControl(new Guid("3ed7731d-d42e-4232-966b-50b6ef11587a"));
            base.InitializeControls();
        }

        public FTRVucutBolgesiDefinitionForm() : base("FTRVUCUTBOLGESI", "FTRVucutBolgesiDefinitionForm")
        {
        }

        protected FTRVucutBolgesiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}