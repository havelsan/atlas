
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
    /// BaseHastaCikisKayitForm
    /// </summary>
    public partial class BaseHastaCikisKayitForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hasta Çıkış Kayıt
    /// </summary>
        protected TTObjectClasses.HastaCikisKayit _HastaCikisKayit
        {
            get { return (TTObjectClasses.HastaCikisKayit)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKodu;
        protected ITTLabel labelhastaCikisTarihi;
        protected ITTTextBox hastaCikisTarihi;
        protected ITTTextBox hastaBasvuruNo;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTDateTimePicker hastaCikisTarihiDateTimePicker;
        protected ITTValueListBox saglikTesisKodu;
        override protected void InitializeControls()
        {
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("febe95c5-0e51-4f5e-b334-2f5de3283d94"));
            labelhastaCikisTarihi = (ITTLabel)AddControl(new Guid("bca1ac3d-d321-44fa-ab34-5a4ef1509a60"));
            hastaCikisTarihi = (ITTTextBox)AddControl(new Guid("4d89408f-c5c7-477b-becd-156c96de1cd0"));
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("1bc3f4d5-832d-4834-80ba-301b473df13d"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("b8605862-ac5c-4a57-81bc-4d7f81489341"));
            hastaCikisTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("1dee5a6a-8bfb-4f78-8ed6-de81a812ee04"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("7c8e8674-f97b-4492-84ac-30bbb27ca454"));
            base.InitializeControls();
        }

        public BaseHastaCikisKayitForm() : base("HASTACIKISKAYIT", "BaseHastaCikisKayitForm")
        {
        }

        protected BaseHastaCikisKayitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}