
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
    /// BaseHastaKabulProvizyonDegistirForm
    /// </summary>
    public partial class BaseHastaKabulProvizyonDegistirForm : TTForm
    {
    /// <summary>
    /// Hasta Kabul Provizyon Degiştir
    /// </summary>
        protected TTObjectClasses.HastaKabulProvizyonDegistir _HastaKabulProvizyonDegistir
        {
            get { return (TTObjectClasses.HastaKabulProvizyonDegistir)_ttObject; }
        }

        protected ITTTextBox takipNo;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTLabel labeltakipNo;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelyeniProvizyonTipi;
        protected ITTListDefComboBox yeniProvizyonTipi;
        override protected void InitializeControls()
        {
            takipNo = (ITTTextBox)AddControl(new Guid("76737767-a653-44f4-b7e7-b0e4f1a01342"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("6db891a4-468e-4551-9e6b-388c58087fb3"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("3ceade3c-38c8-496f-9055-e5179ca784d9"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("affefc71-e630-4ed0-823d-23178d20401a"));
            labelyeniProvizyonTipi = (ITTLabel)AddControl(new Guid("a96e5cb0-1740-4a41-b2ba-8f6b7ebe8613"));
            yeniProvizyonTipi = (ITTListDefComboBox)AddControl(new Guid("08a2197d-c1f8-4ca8-a0e9-b1fd82229491"));
            base.InitializeControls();
        }

        public BaseHastaKabulProvizyonDegistirForm() : base("HASTAKABULPROVIZYONDEGISTIR", "BaseHastaKabulProvizyonDegistirForm")
        {
        }

        protected BaseHastaKabulProvizyonDegistirForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}