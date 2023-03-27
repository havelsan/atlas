
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
    /// MKYS Malzeme Detay Form
    /// </summary>
    public partial class MalzemeGetDataForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// MKYS Malzeme Eşleştirme
    /// </summary>
        protected TTObjectClasses.MalzemeGetData _MalzemeGetData
        {
            get { return (TTObjectClasses.MalzemeGetData)_ttObject; }
        }

        protected ITTCheckBox aktif;
        protected ITTLabel labeleskiMalzemeKodu;
        protected ITTTextBox eskiMalzemeKodu;
        protected ITTTextBox malzemeTurID;
        protected ITTTextBox olcuBirimiID;
        protected ITTTextBox malzemeAdi;
        protected ITTTextBox malzemeKodu;
        protected ITTTextBox malzemeKayitID;
        protected ITTLabel labelmalzemeTurID;
        protected ITTLabel labelolcuBirimiID;
        protected ITTLabel labeldegisiklikTarihi;
        protected ITTDateTimePicker degisiklikTarihi;
        protected ITTLabel labelmalzemeAdi;
        protected ITTLabel labelmalzemeKodu;
        protected ITTLabel labelmalzemeKayitID;
        override protected void InitializeControls()
        {
            aktif = (ITTCheckBox)AddControl(new Guid("f0414c49-1b26-491d-8568-1fde83f99753"));
            labeleskiMalzemeKodu = (ITTLabel)AddControl(new Guid("89bf298c-4f16-4cb6-ac8c-cc0e94568403"));
            eskiMalzemeKodu = (ITTTextBox)AddControl(new Guid("0a0f606c-58b3-42fe-9223-e590cf3afd30"));
            malzemeTurID = (ITTTextBox)AddControl(new Guid("5c1b9cad-4def-4196-81ff-7b43a502d1a5"));
            olcuBirimiID = (ITTTextBox)AddControl(new Guid("40146d61-2277-4398-bf36-66f7180aa3bb"));
            malzemeAdi = (ITTTextBox)AddControl(new Guid("f8dfdb25-ba51-4471-8639-a4773289e7e0"));
            malzemeKodu = (ITTTextBox)AddControl(new Guid("e288ccca-cac5-4f22-8be6-d515ddb8cbe5"));
            malzemeKayitID = (ITTTextBox)AddControl(new Guid("a59cc478-8833-4ddc-80bd-916980d0e335"));
            labelmalzemeTurID = (ITTLabel)AddControl(new Guid("ebeaa777-10bc-4d9c-9660-cc2cd449c09b"));
            labelolcuBirimiID = (ITTLabel)AddControl(new Guid("7058ba37-f148-499e-b0a9-a13ca1f34690"));
            labeldegisiklikTarihi = (ITTLabel)AddControl(new Guid("51ec4624-8131-4e87-9c25-a6085aee6c04"));
            degisiklikTarihi = (ITTDateTimePicker)AddControl(new Guid("05672353-08db-47e3-b1c8-af0315da2813"));
            labelmalzemeAdi = (ITTLabel)AddControl(new Guid("08636800-355c-4ad2-a9e3-557024d97770"));
            labelmalzemeKodu = (ITTLabel)AddControl(new Guid("f5069fa5-80e3-4e28-b6e8-496c8a2790fd"));
            labelmalzemeKayitID = (ITTLabel)AddControl(new Guid("a296aa9f-4241-4a7e-82c5-6bcf2e3be7a6"));
            base.InitializeControls();
        }

        public MalzemeGetDataForm() : base("MALZEMEGETDATA", "MalzemeGetDataForm")
        {
        }

        protected MalzemeGetDataForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}