
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
    public partial class KullanimPeriyotBirimDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.KullanimPeriyotBirim _KullanimPeriyotBirim
        {
            get { return (TTObjectClasses.KullanimPeriyotBirim)_ttObject; }
        }

        protected ITTLabel labelkullanimPeriyotBirimAdi;
        protected ITTTextBox kullanimPeriyotBirimAdi;
        protected ITTTextBox kullanimPeriyotBirimKodu;
        protected ITTLabel labelkullanimPeriyotBirimKodu;
        override protected void InitializeControls()
        {
            labelkullanimPeriyotBirimAdi = (ITTLabel)AddControl(new Guid("5f907475-4623-4a66-9353-6bd3409cca2c"));
            kullanimPeriyotBirimAdi = (ITTTextBox)AddControl(new Guid("3cd65ccb-11c8-47db-8c2c-0083528bce7c"));
            kullanimPeriyotBirimKodu = (ITTTextBox)AddControl(new Guid("267e7bca-eb0a-46a2-afd1-c80eb6c85728"));
            labelkullanimPeriyotBirimKodu = (ITTLabel)AddControl(new Guid("4f1902e7-f2e3-48f1-afeb-a092d0bf9bec"));
            base.InitializeControls();
        }

        public KullanimPeriyotBirimDefinitionForm() : base("KULLANIMPERIYOTBIRIM", "KullanimPeriyotBirimDefinitionForm")
        {
        }

        protected KullanimPeriyotBirimDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}