
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
    /// Hasta Kabul Oku
    /// </summary>
    public partial class BaseHastaKabulOkuForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.BaseHastaKabulOku _BaseHastaKabulOku
        {
            get { return (TTObjectClasses.BaseHastaKabulOku)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labeltakipNo;
        protected ITTTextBox takipNo;
        override protected void InitializeControls()
        {
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("9e4bd637-63fa-4810-b124-5eafbbec0957"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("8b6e808e-9276-4a7d-8ab4-f561eebd3d8a"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("48141b52-6583-4e0b-925c-7626809ed2ae"));
            takipNo = (ITTTextBox)AddControl(new Guid("480bee0c-fd26-43fd-97ea-6f102220a418"));
            base.InitializeControls();
        }

        public BaseHastaKabulOkuForm() : base("BASEHASTAKABULOKU", "BaseHastaKabulOkuForm")
        {
        }

        protected BaseHastaKabulOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}