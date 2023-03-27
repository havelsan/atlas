
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
    /// BaseSevkBildirForm
    /// </summary>
    public partial class BaseSevkBildirForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Sevk Bildir
    /// </summary>
        protected TTObjectClasses.SevkBildir _SevkBildir
        {
            get { return (TTObjectClasses.SevkBildir)_ttObject; }
        }

        protected ITTLabel labeltakipNo;
        protected ITTTextBox takipNo;
        protected ITTTextBox sevkEdilisTarihi;
        protected ITTLabel labelsevkEdilisTarihi;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTDateTimePicker sevkEdilisTarihiDateTimePicker;
        override protected void InitializeControls()
        {
            labeltakipNo = (ITTLabel)AddControl(new Guid("e8ded43a-90c8-476d-be81-6896930d6584"));
            takipNo = (ITTTextBox)AddControl(new Guid("fda3ada9-319e-48d4-8d73-18990c19fe76"));
            sevkEdilisTarihi = (ITTTextBox)AddControl(new Guid("09047caa-df29-4bc1-a1f9-546a24be4002"));
            labelsevkEdilisTarihi = (ITTLabel)AddControl(new Guid("172e5132-0990-4b8f-b7d7-683169a08803"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("7346616d-1e6d-4c48-aaf0-5e2ea8e256cf"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("cd6319be-7965-49db-91f9-8c879a72701a"));
            sevkEdilisTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("aeb5433e-05bb-4dd7-ac34-1577d08303b6"));
            base.InitializeControls();
        }

        public BaseSevkBildirForm() : base("SEVKBILDIR", "BaseSevkBildirForm")
        {
        }

        protected BaseSevkBildirForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}