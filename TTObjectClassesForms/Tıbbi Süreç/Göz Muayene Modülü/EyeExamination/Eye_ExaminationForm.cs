
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
    public partial class Eye_Examination : SpecialityBasedObjectForm
    {
        override protected void BindControlEvents()
        {
            AutorefLeftEyeMeasureSPH.TextChanged += new TTControlEventDelegate(AutorefLeftEyeMeasureSPH_TextChanged);
            AutorefLeftEyeMeasureCYL.TextChanged += new TTControlEventDelegate(AutorefLeftEyeMeasureCYL_TextChanged);
            AutorefLeftEyeMeasureAxis.TextChanged += new TTControlEventDelegate(AutorefLeftEyeMeasureAxis_TextChanged);
            AutorefRightEyeMeasureSPH.TextChanged += new TTControlEventDelegate(AutorefRightEyeMeasureSPH_TextChanged);
            AutorefRightEyeMeasureCYL.TextChanged += new TTControlEventDelegate(AutorefRightEyeMeasureCYL_TextChanged);
            AutorefRightEyeMeasureAxis.TextChanged += new TTControlEventDelegate(AutorefRightEyeMeasureAxis_TextChanged);
            CyclAutorefLeftEyeMeasureSPH.TextChanged += new TTControlEventDelegate(CyclAutorefLeftEyeMeasureSPH_TextChanged);
            CyclAutorefLeftEyeMeasureCYL.TextChanged += new TTControlEventDelegate(CyclAutorefLeftEyeMeasureCYL_TextChanged);
            CyclAutorefLeftEyeMeasureAxis.TextChanged += new TTControlEventDelegate(CyclAutorefLeftEyeMeasureAxis_TextChanged);
            CyclAutorefRightEyeMeasureSPH.TextChanged += new TTControlEventDelegate(CyclAutorefRightEyeMeasureSPH_TextChanged);
            CyclAutorefRightEyeMeasureCYL.TextChanged += new TTControlEventDelegate(CyclAutorefRightEyeMeasureCYL_TextChanged);
            CyclAutorefRightEyeMeasureAxis.TextChanged += new TTControlEventDelegate(CyclAutorefRightEyeMeasureAxis_TextChanged);
            NoGlassVisSharpLeftNearSPH.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftNearSPH_TextChanged);
            NoGlassVisSharpLeftNearCYL.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftNearCYL_TextChanged);
            NoGlassVisSharpLeftNearAxis.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftNearAxis_TextChanged);
            NoGlassVisSharpRightNearSPH.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightNearSPH_TextChanged);
            NoGlassVisSharpRightNearCYL.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightNearCYL_TextChanged);
            NoGlassVisSharpRightNearAxis.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightNearAxis_TextChanged);
            NoGlassVisSharpLeftFarSPH.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftFarSPH_TextChanged);
            NoGlassVisSharpLeftFarCYL.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftFarCYL_TextChanged);
            NoGlassVisSharpLeftFarAxis.TextChanged += new TTControlEventDelegate(NoGlassVisSharpLeftFarAxis_TextChanged);
            NoGlassVisSharpRightFarSPH.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightFarSPH_TextChanged);
            NoGlassVisSharpRightFarCYL.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightFarCYL_TextChanged);
            NoGlassVisSharpRightFarAxis.TextChanged += new TTControlEventDelegate(NoGlassVisSharpRightFarAxis_TextChanged);
            GlassVisSharpLeftNearSPH.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftNearSPH_TextChanged);
            GlassVisSharpLeftNearCYL.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftNearCYL_TextChanged);
            GlassVisSharpLeftNearAxis.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftNearAxis_TextChanged);
            GlassVisSharpRightNearSPH.TextChanged += new TTControlEventDelegate(GlassVisSharpRightNearSPH_TextChanged);
            GlassVisSharpRightNearCYL.TextChanged += new TTControlEventDelegate(GlassVisSharpRightNearCYL_TextChanged);
            GlassVisSharpRightNearAxis.TextChanged += new TTControlEventDelegate(GlassVisSharpRightNearAxis_TextChanged);
            GlassVisSharpLeftFarSPH.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftFarSPH_TextChanged);
            GlassVisSharpLeftFarCYL.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftFarCYL_TextChanged);
            GlassVisSharpLeftFarAxis.TextChanged += new TTControlEventDelegate(GlassVisSharpLeftFarAxis_TextChanged);
            GlassVisSharpRightFarSPH.TextChanged += new TTControlEventDelegate(GlassVisSharpRightFarSPH_TextChanged);
            GlassVisSharpRightFarCYL.TextChanged += new TTControlEventDelegate(GlassVisSharpRightFarCYL_TextChanged);
            GlassVisSharpRightFarAxis.TextChanged += new TTControlEventDelegate(GlassVisSharpRightFarAxis_TextChanged);
            PatientGlassesLeftNearSPH.TextChanged += new TTControlEventDelegate(PatientGlassesLeftNearSPH_TextChanged);
            PatientGlassesLeftNearCYL.TextChanged += new TTControlEventDelegate(PatientGlassesLeftNearCYL_TextChanged);
            PatientGlassesLeftNearAxis.TextChanged += new TTControlEventDelegate(PatientGlassesLeftNearAxis_TextChanged);
            PatientGlassesRightNearSPH.TextChanged += new TTControlEventDelegate(PatientGlassesRightNearSPH_TextChanged);
            PatientGlassesRightNearCYL.TextChanged += new TTControlEventDelegate(PatientGlassesRightNearCYL_TextChanged);
            PatientGlassesRightNearAxis.TextChanged += new TTControlEventDelegate(PatientGlassesRightNearAxis_TextChanged);
            PatientGlassesLeftFarSPH.TextChanged += new TTControlEventDelegate(PatientGlassesLeftFarSPH_TextChanged);
            PatientGlassesLeftFarCYL.TextChanged += new TTControlEventDelegate(PatientGlassesLeftFarCYL_TextChanged);
            PatientGlassesLeftFarAxis.TextChanged += new TTControlEventDelegate(PatientGlassesLeftFarAxis_TextChanged);
            PatientGlassesRightFarSPH.TextChanged += new TTControlEventDelegate(PatientGlassesRightFarSPH_TextChanged);
            PatientGlassesRightFarCYL.TextChanged += new TTControlEventDelegate(PatientGlassesRightFarCYL_TextChanged);
            PatientGlassesRightFarAxis.TextChanged += new TTControlEventDelegate(PatientGlassesRightFarAxis_TextChanged);
            LeftEyePressure.TextChanged += new TTControlEventDelegate(LeftEyePressure_TextChanged);
            RightEyePressure.TextChanged += new TTControlEventDelegate(RightEyePressure_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AutorefLeftEyeMeasureSPH.TextChanged -= new TTControlEventDelegate(AutorefLeftEyeMeasureSPH_TextChanged);
            AutorefLeftEyeMeasureCYL.TextChanged -= new TTControlEventDelegate(AutorefLeftEyeMeasureCYL_TextChanged);
            AutorefLeftEyeMeasureAxis.TextChanged -= new TTControlEventDelegate(AutorefLeftEyeMeasureAxis_TextChanged);
            AutorefRightEyeMeasureSPH.TextChanged -= new TTControlEventDelegate(AutorefRightEyeMeasureSPH_TextChanged);
            AutorefRightEyeMeasureCYL.TextChanged -= new TTControlEventDelegate(AutorefRightEyeMeasureCYL_TextChanged);
            AutorefRightEyeMeasureAxis.TextChanged -= new TTControlEventDelegate(AutorefRightEyeMeasureAxis_TextChanged);
            CyclAutorefLeftEyeMeasureSPH.TextChanged -= new TTControlEventDelegate(CyclAutorefLeftEyeMeasureSPH_TextChanged);
            CyclAutorefLeftEyeMeasureCYL.TextChanged -= new TTControlEventDelegate(CyclAutorefLeftEyeMeasureCYL_TextChanged);
            CyclAutorefLeftEyeMeasureAxis.TextChanged -= new TTControlEventDelegate(CyclAutorefLeftEyeMeasureAxis_TextChanged);
            CyclAutorefRightEyeMeasureSPH.TextChanged -= new TTControlEventDelegate(CyclAutorefRightEyeMeasureSPH_TextChanged);
            CyclAutorefRightEyeMeasureCYL.TextChanged -= new TTControlEventDelegate(CyclAutorefRightEyeMeasureCYL_TextChanged);
            CyclAutorefRightEyeMeasureAxis.TextChanged -= new TTControlEventDelegate(CyclAutorefRightEyeMeasureAxis_TextChanged);
            NoGlassVisSharpLeftNearSPH.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftNearSPH_TextChanged);
            NoGlassVisSharpLeftNearCYL.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftNearCYL_TextChanged);
            NoGlassVisSharpLeftNearAxis.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftNearAxis_TextChanged);
            NoGlassVisSharpRightNearSPH.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightNearSPH_TextChanged);
            NoGlassVisSharpRightNearCYL.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightNearCYL_TextChanged);
            NoGlassVisSharpRightNearAxis.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightNearAxis_TextChanged);
            NoGlassVisSharpLeftFarSPH.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftFarSPH_TextChanged);
            NoGlassVisSharpLeftFarCYL.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftFarCYL_TextChanged);
            NoGlassVisSharpLeftFarAxis.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpLeftFarAxis_TextChanged);
            NoGlassVisSharpRightFarSPH.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightFarSPH_TextChanged);
            NoGlassVisSharpRightFarCYL.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightFarCYL_TextChanged);
            NoGlassVisSharpRightFarAxis.TextChanged -= new TTControlEventDelegate(NoGlassVisSharpRightFarAxis_TextChanged);
            GlassVisSharpLeftNearSPH.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftNearSPH_TextChanged);
            GlassVisSharpLeftNearCYL.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftNearCYL_TextChanged);
            GlassVisSharpLeftNearAxis.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftNearAxis_TextChanged);
            GlassVisSharpRightNearSPH.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightNearSPH_TextChanged);
            GlassVisSharpRightNearCYL.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightNearCYL_TextChanged);
            GlassVisSharpRightNearAxis.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightNearAxis_TextChanged);
            GlassVisSharpLeftFarSPH.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftFarSPH_TextChanged);
            GlassVisSharpLeftFarCYL.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftFarCYL_TextChanged);
            GlassVisSharpLeftFarAxis.TextChanged -= new TTControlEventDelegate(GlassVisSharpLeftFarAxis_TextChanged);
            GlassVisSharpRightFarSPH.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightFarSPH_TextChanged);
            GlassVisSharpRightFarCYL.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightFarCYL_TextChanged);
            GlassVisSharpRightFarAxis.TextChanged -= new TTControlEventDelegate(GlassVisSharpRightFarAxis_TextChanged);
            PatientGlassesLeftNearSPH.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftNearSPH_TextChanged);
            PatientGlassesLeftNearCYL.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftNearCYL_TextChanged);
            PatientGlassesLeftNearAxis.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftNearAxis_TextChanged);
            PatientGlassesRightNearSPH.TextChanged -= new TTControlEventDelegate(PatientGlassesRightNearSPH_TextChanged);
            PatientGlassesRightNearCYL.TextChanged -= new TTControlEventDelegate(PatientGlassesRightNearCYL_TextChanged);
            PatientGlassesRightNearAxis.TextChanged -= new TTControlEventDelegate(PatientGlassesRightNearAxis_TextChanged);
            PatientGlassesLeftFarSPH.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftFarSPH_TextChanged);
            PatientGlassesLeftFarCYL.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftFarCYL_TextChanged);
            PatientGlassesLeftFarAxis.TextChanged -= new TTControlEventDelegate(PatientGlassesLeftFarAxis_TextChanged);
            PatientGlassesRightFarSPH.TextChanged -= new TTControlEventDelegate(PatientGlassesRightFarSPH_TextChanged);
            PatientGlassesRightFarCYL.TextChanged -= new TTControlEventDelegate(PatientGlassesRightFarCYL_TextChanged);
            PatientGlassesRightFarAxis.TextChanged -= new TTControlEventDelegate(PatientGlassesRightFarAxis_TextChanged);
            LeftEyePressure.TextChanged -= new TTControlEventDelegate(LeftEyePressure_TextChanged);
            RightEyePressure.TextChanged -= new TTControlEventDelegate(RightEyePressure_TextChanged);
            base.UnBindControlEvents();
        }

        private bool checkMultiplicity(string enteredValue)
        {
            double checkVal = Double.Parse(enteredValue);
            if(checkVal % 0.25 == 0){
                return true;
            }else{
                return false;
            }
        }
        private bool checkAxisBoundary(string enteredValue)
        {
            double checkVal = Double.Parse(enteredValue);
            if (checkVal >=0 && checkVal < 181 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string changeCommaToDot(string enteredValue)
        {
            if (enteredValue.Contains(","))
            {
                enteredValue = enteredValue.Replace(",", ".");
            }
            return enteredValue;
        }

        private void AutorefLeftEyeMeasureSPH_TextChanged()
        {
            AutorefLeftEyeMeasureSPH.Text = changeCommaToDot(AutorefLeftEyeMeasureSPH.Text);
        }
        private void AutorefLeftEyeMeasureCYL_TextChanged()
        {
            AutorefLeftEyeMeasureCYL.Text = changeCommaToDot(AutorefLeftEyeMeasureCYL.Text);
        }
        private void AutorefLeftEyeMeasureAxis_TextChanged()
        {
            if (!checkAxisBoundary(AutorefLeftEyeMeasureAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void AutorefRightEyeMeasureSPH_TextChanged()
        {
            AutorefRightEyeMeasureSPH.Text = changeCommaToDot(AutorefRightEyeMeasureSPH.Text);
        }
        private void AutorefRightEyeMeasureCYL_TextChanged()
        {
            AutorefRightEyeMeasureCYL.Text = changeCommaToDot(AutorefRightEyeMeasureCYL.Text);
        }
        private void AutorefRightEyeMeasureAxis_TextChanged()
        {
            if (!checkAxisBoundary(AutorefRightEyeMeasureAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void CyclAutorefLeftEyeMeasureSPH_TextChanged()
        {
            CyclAutorefLeftEyeMeasureSPH.Text = changeCommaToDot(CyclAutorefLeftEyeMeasureSPH.Text);
        }
        private void CyclAutorefLeftEyeMeasureCYL_TextChanged()
        {
            CyclAutorefLeftEyeMeasureCYL.Text = changeCommaToDot(CyclAutorefLeftEyeMeasureCYL.Text);
        }
        private void CyclAutorefLeftEyeMeasureAxis_TextChanged()
        {
            if (!checkAxisBoundary(CyclAutorefLeftEyeMeasureAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void CyclAutorefRightEyeMeasureSPH_TextChanged()
        {
            CyclAutorefRightEyeMeasureSPH.Text = changeCommaToDot(CyclAutorefRightEyeMeasureSPH.Text);
        }
        private void CyclAutorefRightEyeMeasureCYL_TextChanged()
        {
            CyclAutorefRightEyeMeasureCYL.Text = changeCommaToDot(CyclAutorefRightEyeMeasureCYL.Text);
        }
        private void CyclAutorefRightEyeMeasureAxis_TextChanged()
        {
            if (!checkAxisBoundary(CyclAutorefRightEyeMeasureAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void NoGlassVisSharpLeftNearSPH_TextChanged()
        {
            NoGlassVisSharpLeftNearSPH.Text = changeCommaToDot(NoGlassVisSharpLeftNearSPH.Text);
        }
        private void NoGlassVisSharpLeftNearCYL_TextChanged()
        {
            NoGlassVisSharpLeftNearCYL.Text = changeCommaToDot(NoGlassVisSharpLeftNearCYL.Text);
        }
        private void NoGlassVisSharpLeftNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(NoGlassVisSharpLeftNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void NoGlassVisSharpRightNearSPH_TextChanged()
        {
            NoGlassVisSharpRightNearSPH.Text = changeCommaToDot(NoGlassVisSharpRightNearSPH.Text);
        }
        private void NoGlassVisSharpRightNearCYL_TextChanged()
        {
            NoGlassVisSharpRightNearCYL.Text = changeCommaToDot(NoGlassVisSharpRightNearCYL.Text);
        }
        private void NoGlassVisSharpRightNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(NoGlassVisSharpRightNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void NoGlassVisSharpLeftFarSPH_TextChanged()
        {
            NoGlassVisSharpLeftFarSPH.Text = changeCommaToDot(NoGlassVisSharpLeftFarSPH.Text);
        }
        private void NoGlassVisSharpLeftFarCYL_TextChanged()
        {
            NoGlassVisSharpLeftFarCYL.Text = changeCommaToDot(NoGlassVisSharpLeftFarCYL.Text);
        }
        private void NoGlassVisSharpLeftFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(NoGlassVisSharpLeftFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void NoGlassVisSharpRightFarSPH_TextChanged()
        {
            NoGlassVisSharpRightFarSPH.Text = changeCommaToDot(NoGlassVisSharpRightFarSPH.Text);
        }
        private void NoGlassVisSharpRightFarCYL_TextChanged()
        {
            NoGlassVisSharpRightFarCYL.Text = changeCommaToDot(NoGlassVisSharpRightFarCYL.Text);
        }
        private void NoGlassVisSharpRightFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(NoGlassVisSharpRightFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void GlassVisSharpLeftNearSPH_TextChanged()
        {
            GlassVisSharpLeftNearSPH.Text = changeCommaToDot(GlassVisSharpLeftNearSPH.Text);
        }
        private void GlassVisSharpLeftNearCYL_TextChanged()
        {
            GlassVisSharpLeftNearCYL.Text = changeCommaToDot(GlassVisSharpLeftNearCYL.Text);
        }
        private void GlassVisSharpLeftNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(GlassVisSharpLeftNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void GlassVisSharpRightNearSPH_TextChanged()
        {
            GlassVisSharpRightNearSPH.Text = changeCommaToDot(GlassVisSharpRightNearSPH.Text);
        }
        private void GlassVisSharpRightNearCYL_TextChanged()
        {
            GlassVisSharpRightNearCYL.Text = changeCommaToDot(GlassVisSharpRightNearCYL.Text);
        }
        private void GlassVisSharpRightNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(GlassVisSharpRightNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void GlassVisSharpLeftFarSPH_TextChanged()
        {
            GlassVisSharpLeftFarSPH.Text = changeCommaToDot(GlassVisSharpLeftFarSPH.Text);
        }
        private void GlassVisSharpLeftFarCYL_TextChanged()
        {
            GlassVisSharpLeftFarCYL.Text = changeCommaToDot(GlassVisSharpLeftFarCYL.Text);
        }
        private void GlassVisSharpLeftFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(GlassVisSharpLeftFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void GlassVisSharpRightFarSPH_TextChanged()
        {
            GlassVisSharpRightFarSPH.Text = changeCommaToDot(GlassVisSharpRightFarSPH.Text);
        }
        private void GlassVisSharpRightFarCYL_TextChanged()
        {
            GlassVisSharpRightFarCYL.Text = changeCommaToDot(GlassVisSharpRightFarCYL.Text);
        }
        private void GlassVisSharpRightFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(GlassVisSharpRightFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        //
        private void PatientGlassesLeftNearSPH_TextChanged()
        {
            PatientGlassesLeftNearSPH.Text = changeCommaToDot(PatientGlassesLeftNearSPH.Text);
        }
        private void PatientGlassesLeftNearCYL_TextChanged()
        {
            PatientGlassesLeftNearCYL.Text = changeCommaToDot(PatientGlassesLeftNearCYL.Text);
        }
        private void PatientGlassesLeftNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(PatientGlassesLeftNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void PatientGlassesRightNearSPH_TextChanged()
        {
            PatientGlassesRightNearSPH.Text = changeCommaToDot(PatientGlassesRightNearSPH.Text);
        }
        private void PatientGlassesRightNearCYL_TextChanged()
        {
            PatientGlassesRightNearCYL.Text = changeCommaToDot(PatientGlassesRightNearCYL.Text);
        }
        private void PatientGlassesRightNearAxis_TextChanged()
        {
            if (!checkAxisBoundary(PatientGlassesRightNearAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void PatientGlassesLeftFarSPH_TextChanged()
        {
            PatientGlassesLeftFarSPH.Text = changeCommaToDot(PatientGlassesLeftFarSPH.Text);
        }
        private void PatientGlassesLeftFarCYL_TextChanged()
        {
            PatientGlassesLeftFarCYL.Text = changeCommaToDot(PatientGlassesLeftFarCYL.Text);
        }
        private void PatientGlassesLeftFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(PatientGlassesLeftFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void PatientGlassesRightFarSPH_TextChanged()
        {
            PatientGlassesRightFarSPH.Text = changeCommaToDot(PatientGlassesRightFarSPH.Text);
        }
        private void PatientGlassesRightFarCYL_TextChanged()
        {
            PatientGlassesRightFarCYL.Text = changeCommaToDot(PatientGlassesRightFarCYL.Text);
        }
        private void PatientGlassesRightFarAxis_TextChanged()
        {
            if (!checkAxisBoundary(PatientGlassesRightFarAxis.Text))
                InfoBox.Alert("AKS deðeri 0 ile 180 arasýnda olmalýdýr!");
        }
        private void LeftEyePressure_TextChanged()
        {
            LeftEyePressure.Text = changeCommaToDot(LeftEyePressure.Text);
        }
        private void RightEyePressure_TextChanged()
        {
            RightEyePressure.Text = changeCommaToDot(RightEyePressure.Text);
        }
    }
}