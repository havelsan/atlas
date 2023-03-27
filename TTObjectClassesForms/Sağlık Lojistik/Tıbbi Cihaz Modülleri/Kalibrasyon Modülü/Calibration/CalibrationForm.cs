
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            FullCalibration.CheckedChanged += new TTControlEventDelegate(FullCalibration_CheckedChanged);
            LimitedCalibration.CheckedChanged += new TTControlEventDelegate(LimitedCalibration_CheckedChanged);
            NotCalibration.CheckedChanged += new TTControlEventDelegate(NotCalibration_CheckedChanged);
            CalibrationTests.CellValueChanged += new TTGridCellEventDelegate(CalibrationTests_CellValueChanged);
            CalibrationTests.CellContentClick += new TTGridCellEventDelegate(CalibrationTests_CellContentClick);
            cmdForkDemand.Click += new TTControlEventDelegate(cmdForkDemand_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FullCalibration.CheckedChanged -= new TTControlEventDelegate(FullCalibration_CheckedChanged);
            LimitedCalibration.CheckedChanged -= new TTControlEventDelegate(LimitedCalibration_CheckedChanged);
            NotCalibration.CheckedChanged -= new TTControlEventDelegate(NotCalibration_CheckedChanged);
            CalibrationTests.CellValueChanged -= new TTGridCellEventDelegate(CalibrationTests_CellValueChanged);
            CalibrationTests.CellContentClick -= new TTGridCellEventDelegate(CalibrationTests_CellContentClick);
            cmdForkDemand.Click -= new TTControlEventDelegate(cmdForkDemand_Click);
            base.UnBindControlEvents();
        }

        private void FullCalibration_CheckedChanged()
        {
#region CalibrationForm_FullCalibration_CheckedChanged
   if((bool)this.FullCalibration.Value)
            {
                _Calibration.LimitedCalibration = false ;
                _Calibration.NotCalibration = false ;
                this.TemperatureDeviationText.Required = true;
                this.TemperatureText.Required = true;
                this.HumidityDeviationText.Required = true;
                this.RelativeHumidityText.Required = true;
                this.CalibrationTests.Required = true;
            }
#endregion CalibrationForm_FullCalibration_CheckedChanged
        }

        private void LimitedCalibration_CheckedChanged()
        {
#region CalibrationForm_LimitedCalibration_CheckedChanged
   if((bool)this.LimitedCalibration.Value)
            {
                _Calibration.FullCalibration = false ;
                _Calibration.NotCalibration = false ;
                this.TemperatureDeviationText.Required = true;
                this.TemperatureText.Required = true;
                this.HumidityDeviationText.Required = true;
                this.RelativeHumidityText.Required = true;
                this.CalibrationTests.Required = true;
            }
#endregion CalibrationForm_LimitedCalibration_CheckedChanged
        }

        private void NotCalibration_CheckedChanged()
        {
#region CalibrationForm_NotCalibration_CheckedChanged
   //mca
            if((bool)this.NotCalibration.Value)
            {
                _Calibration.FullCalibration = false ;
                _Calibration.LimitedCalibration = false ;
                this.TemperatureDeviationText.Required = false;
                this.TemperatureText.Required = false;
                this.HumidityDeviationText.Required = false;
                this.RelativeHumidityText.Required = false;
                this.CalibrationTests.Required = false;
            }

            if ((bool)this.NotCalibration.Value)
            {
                this.CalibrationTests.Required = false;
            }
#endregion CalibrationForm_NotCalibration_CheckedChanged
        }

        private void CalibrationTests_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region CalibrationForm_CalibrationTests_CellValueChanged
   if (CalibrationTests.CurrentCell.OwningColumn.Name == "CalibrationTestDefinition")
            {
                int CurRow = CalibrationTests.CurrentCell.RowIndex;
                if (CalibrationTests.CurrentCell.Value != null)
                {
                    CalibrationTestDefinition procedure =((CalibrationTestDefinition)((CalibrationTest)CalibrationTests.Rows[CurRow].TTObject).CalibrationTestDefinition) ;
                    CalibrationTest calibrationTest = ((CalibrationTest)CalibrationTests.CurrentCell.OwningRow.TTObject);
                    calibrationTest.MeasurementReport = procedure.Report;
                }
            }
#endregion CalibrationForm_CalibrationTests_CellValueChanged
        }

        private void CalibrationTests_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region CalibrationForm_CalibrationTests_CellContentClick
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
#endregion CalibrationForm_CalibrationTests_CellContentClick
        }

        private void cmdForkDemand_Click()
        {
#region CalibrationForm_cmdForkDemand_Click
   if(_Calibration.DetailDescription  != null)
            {
                Demand demand = new Demand(_Calibration.ObjectContext);
                demand.Description = _Calibration.FixedAssetMaterialDefinition.Mark.ToString() + " Marka " + _Calibration.FixedAssetMaterialDefinition.Model.ToString() + " Model " + _Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + " Cihaz için Hizmet Alımı";
                demand.DemandType = DemandTypeEnum.ServicePurchase;
                demand.DemandDate = DateTime.Now.Date;
                demand.MasterResource = _Calibration.Section as ResSection;
                demand.CurrentStateDefID = Demand.States.New;
                DemandDetail demandDetail = new DemandDetail(_Calibration.ObjectContext);
                demandDetail.Demand = demand;
                demandDetail.PurchaseItemDef = _Calibration.PurchaseItemDef;
                demandDetail.DetailDescription = this.DetailDescription.Text ;
                demandDetail.RequestAmount = 1;
                _Calibration.Demand = demand;
                this.DropStateButton(Calibration.States.ChiefApproval);
                this.DropStateButton(Calibration.States.ToRepair);
                this.DropStateButton(Calibration.States.Completed );
                this.cmdOK.Visible = false;
                this.cmdForkDemand.Enabled = false;
                this.PurchaseItem.Enabled = false;
                this.DetailDescription.Enabled = false;
//                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
//                objectID.Add("VALUE", _Calibration.ObjectID.ToString());
//                parameter.Add("TTOBJECTID", objectID);
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HizmetAlimiTalepFisi), true, 1, parameter);
            }
            else
            {
                throw new TTUtils.TTException("Cihaz arıza açıklaması girmeden hizmet almı başlatamazsınız.");
            }
#endregion CalibrationForm_cmdForkDemand_Click
        }

        protected override void PreScript()
        {
#region CalibrationForm_PreScript
    base.PreScript();

            //_Calibration.ResponsibleWorkShopUser = _Calibration.ResponsibleUser;
            if (_Calibration.PrevState == null)
            {
                this.FullCalibration.Value = false;
                this.LimitedCalibration.Value = false;
                this.NoNeedCalibration.Value = false;
                this.NotCalibration.Value = false;
                this.NotCalibreReason1.Value = false;
                this.NotCalibreReason2.Value = false;
                this.NotCalibreReason3.Value = false;
                this.NotCalibreReason4.Value = false;
                this.NotCalibreReason5.Value = false;


                foreach (CalibrationProcedure procedure in _Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationProcedures)
                {
                    CalibrationTest calibrationTest = new CalibrationTest(_Calibration.ObjectContext);
                    calibrationTest.CalibrationTestDefinition = (CalibrationTestDefinition)procedure.CalibrationTestDefinition;
                    calibrationTest.MeasurementReport = procedure.CalibrationTestDefinition.Report;
                    calibrationTest.Calibration = _Calibration;
                }

                if (_Calibration.FixedAssetMaterialDefinition != null)
                {
                    CalibrationStatusLabel.Text = _Calibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
                }
                if (_Calibration.MaintenanceOrderObjectID != null)
                {
                    this.DropStateButton(Calibration.States.ToRepair);
                    this.DropStateButton(Calibration.States.Completed);
                }
            }
            else if (_Calibration.PrevState.StateDefID != Calibration.States.ChiefApproval)
            {
                this.FullCalibration.Value = false;
                this.LimitedCalibration.Value = false;
                this.NoNeedCalibration.Value = false;
                this.NotCalibration.Value = false;
                this.NotCalibreReason1.Value = false;
                this.NotCalibreReason2.Value = false;
                this.NotCalibreReason3.Value = false;
                this.NotCalibreReason4.Value = false;
                this.NotCalibreReason5.Value = false;

                foreach (CalibrationProcedure procedure in _Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationProcedures)
                {
                    CalibrationTest calibrationTest = new CalibrationTest(_Calibration.ObjectContext);
                    calibrationTest.CalibrationTestDefinition = procedure.CalibrationTestDefinition;
                    calibrationTest.MeasurementReport = procedure.CalibrationTestDefinition.Report;
                    calibrationTest.Calibration = _Calibration;
                }

                if (_Calibration.FixedAssetMaterialDefinition != null)
                {
                    CalibrationStatusLabel.Text = _Calibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
                }
                if (_Calibration.MaintenanceOrderObjectID != null)
                {
                    this.DropStateButton(Calibration.States.ToRepair);
                    this.DropStateButton(Calibration.States.Completed);
                }
                
            }
            
            if(this.NotCalibration.Value == false)
            {
                this.TemperatureDeviationText.Required = true;
                this.TemperatureText.Required = true;
                this.HumidityDeviationText.Required = true;
                this.RelativeHumidityText.Required = true;
                this.CalibrationTests.Required = true;
            }
#endregion CalibrationForm_PreScript

            }
                }
}