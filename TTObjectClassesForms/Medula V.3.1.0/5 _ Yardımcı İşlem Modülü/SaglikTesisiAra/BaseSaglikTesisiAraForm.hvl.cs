
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
    /// BaseSaglikTesisiAraForm
    /// </summary>
    public partial class BaseSaglikTesisiAraForm : BaseMedulaDefinitionActionForm
    {
    /// <summary>
    /// Sağlık Tesisi Ara
    /// </summary>
        protected TTObjectClasses.SaglikTesisiAra _SaglikTesisiAra
        {
            get { return (TTObjectClasses.SaglikTesisiAra)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKoduSaglikTesisiAraGirisDVO;
        protected ITTValueListBox saglikTesisKoduSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisTuruSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisTuruSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisKoduSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisAdiSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisAdiSaglikTesisiAraGirisDVO;
        override protected void InitializeControls()
        {
            labelsaglikTesisKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("5fcd4e6c-a286-4748-a404-15fb4eaccd61"));
            saglikTesisKoduSaglikTesisiAraGirisDVO = (ITTValueListBox)AddControl(new Guid("0a1b13c6-b5e4-48b7-b884-d0c612977077"));
            labeltesisTuruSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("46c90f14-64fc-468b-8fda-2f997a30a4fa"));
            tesisTuruSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("4c3b0712-cc74-4e24-a00f-3ddc894fc5fb"));
            labeltesisKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("961663d0-e6c5-456f-ad6f-c191605aa423"));
            tesisKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("6d062ffd-ad4c-4e9f-886e-844b6a5b11c4"));
            labeltesisIlKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("9147fc2f-9b5a-43cd-a188-87f0053d7360"));
            tesisIlKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("2a80dfc1-5257-4e6f-8e56-b61ade8506f1"));
            labeltesisAdiSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("a0b70bda-f42f-4194-b7ea-04ea6bd2d10c"));
            tesisAdiSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("244908b4-b9bf-475b-8fbc-de48677f7e76"));
            base.InitializeControls();
        }

        public BaseSaglikTesisiAraForm() : base("SAGLIKTESISIARA", "BaseSaglikTesisiAraForm")
        {
        }

        protected BaseSaglikTesisiAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}