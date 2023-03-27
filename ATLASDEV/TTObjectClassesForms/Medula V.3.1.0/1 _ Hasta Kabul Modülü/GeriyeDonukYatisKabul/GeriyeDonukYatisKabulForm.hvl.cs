
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
    /// Geriye Dönük Yatış Kabul
    /// </summary>
    public partial class GeriyeDonukYatisKabulForm : BaseHastaKabulForm
    {
    /// <summary>
    /// Geriye Dönük Yatış Kabul
    /// </summary>
        protected TTObjectClasses.GeriyeDonukYatisKabul _GeriyeDonukYatisKabul
        {
            get { return (TTObjectClasses.GeriyeDonukYatisKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxYatisBilgisi;
        protected ITTTextBox yatisBitisTarihi;
        protected ITTLabel labelyatisBitisTarihi;
        protected ITTDateTimePicker yatisBitisTarihiDatetimepicker;
        override protected void InitializeControls()
        {
            groupboxYatisBilgisi = (ITTGroupBox)AddControl(new Guid("c8e7954d-5792-4652-b6c2-b4a3d38b6c7d"));
            yatisBitisTarihi = (ITTTextBox)AddControl(new Guid("f65872f7-637f-49c7-91bd-d89a56aff516"));
            labelyatisBitisTarihi = (ITTLabel)AddControl(new Guid("edfb96a1-e915-4959-b7a2-5ac134be96c4"));
            yatisBitisTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("69ad08b3-d7eb-437c-8e43-17aa3e0cd461"));
            base.InitializeControls();
        }

        public GeriyeDonukYatisKabulForm() : base("GERIYEDONUKYATISKABUL", "GeriyeDonukYatisKabulForm")
        {
        }

        protected GeriyeDonukYatisKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}