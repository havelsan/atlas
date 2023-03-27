
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
    /// BaseDoktorAraForm
    /// </summary>
    public partial class BaseDoktorAraForm : BaseMedulaDefinitionActionForm
    {
    /// <summary>
    /// Doktor Ara
    /// </summary>
        protected TTObjectClasses.DoktorAra _DoktorAra
        {
            get { return (TTObjectClasses.DoktorAra)_ttObject; }
        }

        protected ITTLabel labeldrBransKoduDoktorAraGirisDVO;
        protected ITTValueListBox drBransKoduDoktorAraGirisDVO;
        protected ITTLabel labelsaglikTesisiKoduDoktorAraGirisDVO;
        protected ITTValueListBox saglikTesisiKoduDoktorAraGirisDVO;
        protected ITTLabel labeldrTescilNoDoktorAraGirisDVO;
        protected ITTTextBox drTescilNoDoktorAraGirisDVO;
        protected ITTTextBox drSoyadiDoktorAraGirisDVO;
        protected ITTTextBox drDiplomaNoDoktorAraGirisDVO;
        protected ITTTextBox drAdiDoktorAraGirisDVO;
        protected ITTLabel labeldrSoyadiDoktorAraGirisDVO;
        protected ITTLabel labeldrDiplomaNoDoktorAraGirisDVO;
        protected ITTLabel labeldrAdiDoktorAraGirisDVO;
        override protected void InitializeControls()
        {
            labeldrBransKoduDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("b8f22c89-4afa-4926-9817-a68d6bdf8553"));
            drBransKoduDoktorAraGirisDVO = (ITTValueListBox)AddControl(new Guid("d42079d3-23fb-46e6-8787-036a2fa5d47f"));
            labelsaglikTesisiKoduDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("5bb7f9cf-83ba-45f7-ba44-85a9e0f85f88"));
            saglikTesisiKoduDoktorAraGirisDVO = (ITTValueListBox)AddControl(new Guid("e8eee980-6fa7-47d9-b82e-e7854d23c09c"));
            labeldrTescilNoDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("04a38f7f-08ff-4c57-9d34-58bd2133be9e"));
            drTescilNoDoktorAraGirisDVO = (ITTTextBox)AddControl(new Guid("627577c4-37c0-4d06-93ed-a1ee4f0f35bc"));
            drSoyadiDoktorAraGirisDVO = (ITTTextBox)AddControl(new Guid("9a238aaf-3422-4bb6-913c-e7e62ed788ed"));
            drDiplomaNoDoktorAraGirisDVO = (ITTTextBox)AddControl(new Guid("c18edef1-4446-4230-b5c9-32917f8978b9"));
            drAdiDoktorAraGirisDVO = (ITTTextBox)AddControl(new Guid("655e932c-7d4a-4f0d-95ff-24a2677d7420"));
            labeldrSoyadiDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("a6bc0045-985e-4887-907b-09d5d244e7da"));
            labeldrDiplomaNoDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("de7d02d9-4e87-4561-a99a-9ea732601978"));
            labeldrAdiDoktorAraGirisDVO = (ITTLabel)AddControl(new Guid("31d69bbb-dc57-413f-b023-623767aeb0ba"));
            base.InitializeControls();
        }

        public BaseDoktorAraForm() : base("DOKTORARA", "BaseDoktorAraForm")
        {
        }

        protected BaseDoktorAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}