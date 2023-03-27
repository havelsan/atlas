
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
    /// Cinsiyet Tanımlama
    /// </summary>
    public partial class CinsiyetDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Cinsiyet
    /// </summary>
        protected TTObjectClasses.Cinsiyet _Cinsiyet
        {
            get { return (TTObjectClasses.Cinsiyet)_ttObject; }
        }

        protected ITTLabel labelcinsiyetKodu;
        protected ITTTextBox cinsiyetKodu;
        protected ITTLabel labelcinsiyetAdi;
        protected ITTTextBox cinsiyetAdi;
        override protected void InitializeControls()
        {
            labelcinsiyetKodu = (ITTLabel)AddControl(new Guid("d1dd1df7-4262-4076-a10f-bf950149ec6e"));
            cinsiyetKodu = (ITTTextBox)AddControl(new Guid("ae1880ec-36dd-4ec4-9a8e-628a0a66ad35"));
            labelcinsiyetAdi = (ITTLabel)AddControl(new Guid("b4552db9-2d19-49ff-a4a2-7053ae90d1d1"));
            cinsiyetAdi = (ITTTextBox)AddControl(new Guid("701b34bb-3118-46b8-aca6-18daa00c64ba"));
            base.InitializeControls();
        }

        public CinsiyetDefinitionForm() : base("CINSIYET", "CinsiyetDefinitionForm")
        {
        }

        protected CinsiyetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}