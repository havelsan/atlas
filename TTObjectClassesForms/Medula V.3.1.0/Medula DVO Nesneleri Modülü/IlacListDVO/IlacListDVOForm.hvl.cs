
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
    public partial class IlacListDVOForm : TTForm
    {
        protected TTObjectClasses.IlacListDVO _IlacListDVO
        {
            get { return (TTObjectClasses.IlacListDVO)_ttObject; }
        }

        protected ITTGrid ilacFiyatlari;
        protected ITTTextBoxColumn fiyatFiyatListDVO;
        protected ITTTextBoxColumn gecerlilikTarihiFiyatListDVO;
        protected ITTLabel labelkullanimBirimi;
        protected ITTTextBox kullanimBirimi;
        protected ITTTextBox ilacAdi;
        protected ITTTextBox barkod;
        protected ITTLabel labelilacAdi;
        protected ITTLabel labelbarkod;
        override protected void InitializeControls()
        {
            ilacFiyatlari = (ITTGrid)AddControl(new Guid("820bdb82-77f0-4a09-854e-7a68da4f1fb2"));
            fiyatFiyatListDVO = (ITTTextBoxColumn)AddControl(new Guid("f0e0e06a-31a5-49c0-9221-0e0b52ac42a6"));
            gecerlilikTarihiFiyatListDVO = (ITTTextBoxColumn)AddControl(new Guid("0fd6ab49-eae5-4f12-a433-8f8a9743559a"));
            labelkullanimBirimi = (ITTLabel)AddControl(new Guid("ce7e363b-d60c-48a4-a239-e63c0e94463b"));
            kullanimBirimi = (ITTTextBox)AddControl(new Guid("63eb9479-b65d-40a7-af2a-b754d89d7ccb"));
            ilacAdi = (ITTTextBox)AddControl(new Guid("d7fd0d7a-f027-4907-8b9d-ea42ffa8324b"));
            barkod = (ITTTextBox)AddControl(new Guid("b1d5ce3e-8782-434c-a3d2-aebe0439d1b6"));
            labelilacAdi = (ITTLabel)AddControl(new Guid("893055d7-ca5d-49bf-b582-0094158f4002"));
            labelbarkod = (ITTLabel)AddControl(new Guid("6fbe78a8-231b-445e-80a9-73b5b4fd4260"));
            base.InitializeControls();
        }

        public IlacListDVOForm() : base("ILACLISTDVO", "IlacListDVOForm")
        {
        }

        protected IlacListDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}