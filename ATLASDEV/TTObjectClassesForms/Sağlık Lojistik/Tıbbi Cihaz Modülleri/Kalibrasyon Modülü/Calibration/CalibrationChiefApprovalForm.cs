
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
    /// Amir Onayı
    /// </summary>
    public partial class CalibrationChiefApprovalForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            CalibrationTests.CellContentClick += new TTGridCellEventDelegate(CalibrationTests_CellContentClick);
            NotCalibration.CheckedChanged += new TTControlEventDelegate(NotCalibration_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CalibrationTests.CellContentClick -= new TTGridCellEventDelegate(CalibrationTests_CellContentClick);
            NotCalibration.CheckedChanged -= new TTControlEventDelegate(NotCalibration_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void CalibrationTests_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region CalibrationChiefApprovalForm_CalibrationTests_CellContentClick
   if (CalibrationTests.CurrentCell.OwningColumn.Name == "cmdReport")
            {
                //string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //string filePath = appPath + @"\ProcedureMeansurmentReport.doc";
                //CalibrationTest calibrationTest = (CalibrationTest)CalibrationTests.CurrentCell.OwningRow.TTObject;
                //Byte[] memoryStream = (byte[])calibrationTest.MeasurementReport;
                //const int myBufferSize = 1024;
                //System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                //System.IO.Stream myOutputStream = System.IO.File.OpenWrite(filePath);
                //byte[] buffer = new Byte[myBufferSize];
                //int numbytes;
                //while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
                //{
                //    myOutputStream.Write(buffer, 0, numbytes);
                //}
                //myInputStream.Close();
                //myOutputStream.Close();

                //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //proc.EnableRaisingEvents = false;
                //proc.StartInfo.FileName = filePath ;
                //proc.StartInfo.Arguments = "WINWORD.EXE";
                //proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                //proc.Start();
                //proc.WaitForExit();

                //System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                //long len;
                //len = fileStream.Length;
                //Byte[] fileAsByte = new Byte[len];
                //fileStream.Read(fileAsByte, 0, fileAsByte.Length);
                //System.IO.MemoryStream newMemoryStream = new System.IO.MemoryStream(fileAsByte);
                //calibrationTest.MeasurementReport = newMemoryStream.ToArray();
                //fileStream.Close();
                var a = 1;
            }
#endregion CalibrationChiefApprovalForm_CalibrationTests_CellContentClick
        }

        private void NotCalibration_CheckedChanged()
        {
#region CalibrationChiefApprovalForm_NotCalibration_CheckedChanged
   if ((bool)this.NotCalibration.Value)
            {
                this.CalibrationTests.Required = false;
            }
#endregion CalibrationChiefApprovalForm_NotCalibration_CheckedChanged
        }

        protected override void PreScript()
        {
#region CalibrationChiefApprovalForm_PreScript
    if (_Calibration.FixedAssetMaterialDefinition != null)
            {
                CalibrationStatusLabel.Text = _Calibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
            }
            if(_Calibration.MaintenanceOrderObjectID != null )
            {
                this.DropStateButton(Calibration.States.ToRepair);
            }
#endregion CalibrationChiefApprovalForm_PreScript

            }
                }
}