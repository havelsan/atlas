
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

using SmartCardWrapper;

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
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region HastaCikisTarihiDegistirCevapForm_PreScript
    base.PreScript();

            if (string.IsNullOrEmpty(yeniHastaCikisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(yeniHastaCikisTarihi.Text);
                ((ITTDateTimePicker)yeniHastaCikisTarihiDateTimePicker).ControlValue = dateTime;
            }
#endregion HastaCikisTarihiDegistirCevapForm_PreScript

            }
                }
}