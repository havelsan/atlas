
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
    /// BaseHastaYatisOkuForm
    /// </summary>
    public partial class BaseHastaYatisOkuForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hasta Yatış Oku
    /// </summary>
        protected TTObjectClasses.HastaYatisOku _HastaYatisOku
        {
            get { return (TTObjectClasses.HastaYatisOku)_ttObject; }
        }

        protected ITTTextBox hastaBasvuruNo;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("418e242c-d4d6-4298-8282-e8aed9ee0618"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("dc32fdbd-e72c-44aa-8b61-28921b8bcc59"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("9da19009-ef9d-429d-b251-85e526fe3f05"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("125fae77-a282-4cba-b433-f130ff9b2fe3"));
            base.InitializeControls();
        }

        public BaseHastaYatisOkuForm() : base("HASTAYATISOKU", "BaseHastaYatisOkuForm")
        {
        }

        protected BaseHastaYatisOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}