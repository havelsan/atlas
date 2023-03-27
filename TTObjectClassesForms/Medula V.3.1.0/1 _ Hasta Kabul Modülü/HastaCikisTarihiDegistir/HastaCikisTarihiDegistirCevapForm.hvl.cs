
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
    /// Hasta Çıkış Tarihi Değiştir Cevap
    /// </summary>
    public partial class HastaCikisTarihiDegistirCevapForm : BaseHastaCikisIptalCevapForm
    {
    /// <summary>
    /// Hasta Çıkış Tarihi Değiştir
    /// </summary>
        protected TTObjectClasses.HastaCikisTarihiDegistir _HastaCikisTarihiDegistir
        {
            get { return (TTObjectClasses.HastaCikisTarihiDegistir)_ttObject; }
        }

        protected ITTDateTimePicker yeniHastaCikisTarihiDateTimePicker;
        protected ITTLabel labelyeniHastaCikisTarihi;
        protected ITTTextBox yeniHastaCikisTarihi;
        override protected void InitializeControls()
        {
            yeniHastaCikisTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("4f39fa89-94da-4723-9d8e-a86c9bf4fbc4"));
            labelyeniHastaCikisTarihi = (ITTLabel)AddControl(new Guid("ecd348e5-605a-49ad-9bb9-1041d2b08804"));
            yeniHastaCikisTarihi = (ITTTextBox)AddControl(new Guid("de74f829-a8c6-4f62-83b9-3f9ab03c4eda"));
            base.InitializeControls();
        }

        public HastaCikisTarihiDegistirCevapForm() : base("HASTACIKISTARIHIDEGISTIR", "HastaCikisTarihiDegistirCevapForm")
        {
        }

        protected HastaCikisTarihiDegistirCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}