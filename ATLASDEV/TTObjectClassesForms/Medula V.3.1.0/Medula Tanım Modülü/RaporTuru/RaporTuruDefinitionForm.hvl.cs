
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
    public partial class RaporTuruDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.RaporTuru _RaporTuru
        {
            get { return (TTObjectClasses.RaporTuru)_ttObject; }
        }

        protected ITTLabel labelraporTuruAdi;
        protected ITTTextBox raporTuruAdi;
        protected ITTTextBox raporTuruKodu;
        protected ITTLabel labelraporTuruKodu;
        override protected void InitializeControls()
        {
            labelraporTuruAdi = (ITTLabel)AddControl(new Guid("7d9f201f-2f2e-4439-9a31-b9a1c969ad06"));
            raporTuruAdi = (ITTTextBox)AddControl(new Guid("2e2d0ac2-ffd7-4e5a-b9dd-42f0cccd7f14"));
            raporTuruKodu = (ITTTextBox)AddControl(new Guid("357dbb39-fc56-4cce-9512-492ae58ecf75"));
            labelraporTuruKodu = (ITTLabel)AddControl(new Guid("b0e33ac2-4006-41b0-8bd1-f10dcd398342"));
            base.InitializeControls();
        }

        public RaporTuruDefinitionForm() : base("RAPORTURU", "RaporTuruDefinitionForm")
        {
        }

        protected RaporTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}