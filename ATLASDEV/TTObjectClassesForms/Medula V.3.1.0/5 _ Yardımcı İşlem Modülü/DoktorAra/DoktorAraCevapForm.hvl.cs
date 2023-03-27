
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
    /// Doktor Ara Cevap
    /// </summary>
    public partial class DoktorAraCevapForm : BaseDoktorAraForm
    {
    /// <summary>
    /// Doktor Ara
    /// </summary>
        protected TTObjectClasses.DoktorAra _DoktorAra
        {
            get { return (TTObjectClasses.DoktorAra)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid doktorlarDoktorListDVO;
        protected ITTTextBoxColumn drAdiDoktorListDVO;
        protected ITTTextBoxColumn drSoyadiDoktorListDVO;
        protected ITTTextBoxColumn drTescilNoDoktorListDVO;
        protected ITTTextBoxColumn drDiplomaNoDoktorListDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("2f66dc01-87b7-449e-822a-59a46de39982"));
            doktorlarDoktorListDVO = (ITTGrid)AddControl(new Guid("643150ee-da72-4ab8-aaa9-17a8c67c02bd"));
            drAdiDoktorListDVO = (ITTTextBoxColumn)AddControl(new Guid("ab139110-4f62-44d0-8be7-7c23de25582c"));
            drSoyadiDoktorListDVO = (ITTTextBoxColumn)AddControl(new Guid("98c97562-8d96-4a57-b0eb-aa8a13a7ddc8"));
            drTescilNoDoktorListDVO = (ITTTextBoxColumn)AddControl(new Guid("5f0c9510-6727-4d85-a8f3-cff5d57f5d31"));
            drDiplomaNoDoktorListDVO = (ITTTextBoxColumn)AddControl(new Guid("fafd6caa-0651-4733-ae11-9bd10883adbf"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("c3fea8ed-00cb-4b85-aca2-7d001b6bb804"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("006efcd9-b041-4f0b-8d61-896b29625ac3"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("9e086b7c-c159-45c9-9b3b-e2fdcfc50adb"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("f633df36-7b69-4c4f-a3eb-9af0e1865265"));
            base.InitializeControls();
        }

        public DoktorAraCevapForm() : base("DOKTORARA", "DoktorAraCevapForm")
        {
        }

        protected DoktorAraCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}