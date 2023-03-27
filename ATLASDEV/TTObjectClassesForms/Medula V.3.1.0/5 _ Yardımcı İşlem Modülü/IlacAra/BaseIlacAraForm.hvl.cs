
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
    /// BaseIlacAraForm
    /// </summary>
    public partial class BaseIlacAraForm : BaseMedulaDefinitionActionForm
    {
    /// <summary>
    /// İlaç Ara
    /// </summary>
        protected TTObjectClasses.IlacAra _IlacAra
        {
            get { return (TTObjectClasses.IlacAra)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKoduIlacAraGirisDVO;
        protected ITTValueListBox saglikTesisKoduIlacAraGirisDVO;
        protected ITTLabel labelilacAdiIlacAraGirisDVO;
        protected ITTTextBox ilacAdiIlacAraGirisDVO;
        protected ITTLabel labelbarkodIlacAraGirisDVO;
        protected ITTTextBox barkodIlacAraGirisDVO;
        override protected void InitializeControls()
        {
            labelsaglikTesisKoduIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("7b14c9aa-c64c-4c86-9fff-c297e7b3772f"));
            saglikTesisKoduIlacAraGirisDVO = (ITTValueListBox)AddControl(new Guid("6bb1fbf9-8b99-4e83-b035-7954cf4237b2"));
            labelilacAdiIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("98d07d5b-581c-4952-9f22-fc32f43bc8f7"));
            ilacAdiIlacAraGirisDVO = (ITTTextBox)AddControl(new Guid("50e5e2a4-0b9a-4270-94c2-f090ff9cd867"));
            labelbarkodIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("4268d2bb-3da1-4f7a-9723-b99c6c5f38f4"));
            barkodIlacAraGirisDVO = (ITTTextBox)AddControl(new Guid("ed1c8746-6074-4904-92e4-326766c354b5"));
            base.InitializeControls();
        }

        public BaseIlacAraForm() : base("ILACARA", "BaseIlacAraForm")
        {
        }

        protected BaseIlacAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}