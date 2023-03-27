
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
    /// Hasta Çıkış Tarihi Değiştir
    /// </summary>
    public partial class HastaCikisTarihiDegistirForm : BaseHastaCikisIptalForm
    {
    /// <summary>
    /// Hasta Çıkış Tarihi Değiştir
    /// </summary>
        protected TTObjectClasses.HastaCikisTarihiDegistir _HastaCikisTarihiDegistir
        {
            get { return (TTObjectClasses.HastaCikisTarihiDegistir)_ttObject; }
        }

        protected ITTLabel labelyeniHastaCikisTarihi;
        protected ITTTextBox yeniHastaCikisTarihi;
        protected ITTDateTimePicker yeniHastaCikisTarihiDateTimePicker;
        override protected void InitializeControls()
        {
            labelyeniHastaCikisTarihi = (ITTLabel)AddControl(new Guid("0316070f-395c-4010-8b57-8a4cc12ff7f0"));
            yeniHastaCikisTarihi = (ITTTextBox)AddControl(new Guid("9b52f4a1-2cba-4b36-9b72-eb73dbf8cd5a"));
            yeniHastaCikisTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("3a14260a-7a05-4318-a116-b3bbd1aee714"));
            base.InitializeControls();
        }

        public HastaCikisTarihiDegistirForm() : base("HASTACIKISTARIHIDEGISTIR", "HastaCikisTarihiDegistirForm")
        {
        }

        protected HastaCikisTarihiDegistirForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}