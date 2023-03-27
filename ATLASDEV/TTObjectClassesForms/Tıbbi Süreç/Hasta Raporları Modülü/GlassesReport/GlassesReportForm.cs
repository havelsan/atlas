
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
    public partial class GlassesReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            CylLeftNear.TextChanged += new TTControlEventDelegate(CylLeftNear_TextChanged);
            CylLeftFar.TextChanged += new TTControlEventDelegate(CylLeftFar_TextChanged);
            SphLeftNear.TextChanged += new TTControlEventDelegate(SphLeftNear_TextChanged);
            SphLeftFar.TextChanged += new TTControlEventDelegate(SphLeftFar_TextChanged);
            CylRightNear.TextChanged += new TTControlEventDelegate(CylRightNear_TextChanged);
            SphRightNear.TextChanged += new TTControlEventDelegate(SphRightNear_TextChanged);
            CylRightFar.TextChanged += new TTControlEventDelegate(CylRightFar_TextChanged);
            SphRightFar.TextChanged += new TTControlEventDelegate(SphRightFar_TextChanged);
            btnReceteSil.Click += new TTControlEventDelegate(btnReceteSil_Click);
            btnReceteKaydet.Click += new TTControlEventDelegate(btnReceteKaydet_Click);
            PrescriptionType.SelectedIndexChanged += new TTControlEventDelegate(PrescriptionType_SelectedIndexChanged);
            cbxVitrumNear.CheckedChanged += new TTControlEventDelegate(cbxVitrumNear_CheckedChanged);
            cbxVitrumCloseReading.CheckedChanged += new TTControlEventDelegate(cbxVitrumCloseReading_CheckedChanged);
            cbxVitrumFar.CheckedChanged += new TTControlEventDelegate(cbxVitrumFar_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CylLeftNear.TextChanged -= new TTControlEventDelegate(CylLeftNear_TextChanged);
            CylLeftFar.TextChanged -= new TTControlEventDelegate(CylLeftFar_TextChanged);
            SphLeftNear.TextChanged -= new TTControlEventDelegate(SphLeftNear_TextChanged);
            SphLeftFar.TextChanged -= new TTControlEventDelegate(SphLeftFar_TextChanged);
            CylRightNear.TextChanged -= new TTControlEventDelegate(CylRightNear_TextChanged);
            SphRightNear.TextChanged -= new TTControlEventDelegate(SphRightNear_TextChanged);
            CylRightFar.TextChanged -= new TTControlEventDelegate(CylRightFar_TextChanged);
            SphRightFar.TextChanged -= new TTControlEventDelegate(SphRightFar_TextChanged);
            btnReceteSil.Click -= new TTControlEventDelegate(btnReceteSil_Click);
            btnReceteKaydet.Click -= new TTControlEventDelegate(btnReceteKaydet_Click);
            PrescriptionType.SelectedIndexChanged -= new TTControlEventDelegate(PrescriptionType_SelectedIndexChanged);
            cbxVitrumNear.CheckedChanged -= new TTControlEventDelegate(cbxVitrumNear_CheckedChanged);
            cbxVitrumCloseReading.CheckedChanged -= new TTControlEventDelegate(cbxVitrumCloseReading_CheckedChanged);
            cbxVitrumFar.CheckedChanged -= new TTControlEventDelegate(cbxVitrumFar_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void CylLeftNear_TextChanged()
        {
#region GlassesReportForm_CylLeftNear_TextChanged
   if (_GlassesReport.CylLeftNear != null)
            {
                this.CommaControl(_GlassesReport.CylLeftNear);
            }
#endregion GlassesReportForm_CylLeftNear_TextChanged
        }

        private void CylLeftFar_TextChanged()
        {
#region GlassesReportForm_CylLeftFar_TextChanged
   if (_GlassesReport.CylLeftFar != null)
            {
                this.CommaControl(_GlassesReport.CylLeftFar);
            }
#endregion GlassesReportForm_CylLeftFar_TextChanged
        }

        private void SphLeftNear_TextChanged()
        {
#region GlassesReportForm_SphLeftNear_TextChanged
   if (_GlassesReport.SphLeftNear != null)
            {
                this.CommaControl(_GlassesReport.SphLeftNear);
            }
#endregion GlassesReportForm_SphLeftNear_TextChanged
        }

        private void SphLeftFar_TextChanged()
        {
#region GlassesReportForm_SphLeftFar_TextChanged
   if (_GlassesReport.SphLeftFar != null)
            {
                this.CommaControl(_GlassesReport.SphLeftFar);
            }
#endregion GlassesReportForm_SphLeftFar_TextChanged
        }

        private void CylRightNear_TextChanged()
        {
#region GlassesReportForm_CylRightNear_TextChanged
   if (_GlassesReport.CylRightNear != null)
            {
                this.CommaControl(_GlassesReport.CylRightNear);
            }
#endregion GlassesReportForm_CylRightNear_TextChanged
        }

        private void SphRightNear_TextChanged()
        {
#region GlassesReportForm_SphRightNear_TextChanged
   if (_GlassesReport.SphRightNear != null)
            {
                this.CommaControl(_GlassesReport.SphRightNear);
            }
#endregion GlassesReportForm_SphRightNear_TextChanged
        }

        private void CylRightFar_TextChanged()
        {
#region GlassesReportForm_CylRightFar_TextChanged
   if (_GlassesReport.CylRightFar != null)
            {
                this.CommaControl(_GlassesReport.CylRightFar);
            }
#endregion GlassesReportForm_CylRightFar_TextChanged
        }

        private void SphRightFar_TextChanged()
        {
#region GlassesReportForm_SphRightFar_TextChanged
   if (_GlassesReport.SphRightFar != null)
            {
                this.CommaControl(_GlassesReport.SphRightFar);
            }
#endregion GlassesReportForm_SphRightFar_TextChanged
        }

        private void btnReceteSil_Click()
        {
#region GlassesReportForm_btnReceteSil_Click
   if( _GlassesReport.EReceteNo != null)
            {
                OptikReceteIslemleri.ereceteSilDVO ereceteSil = new OptikReceteIslemleri.ereceteSilDVO();
                ereceteSil.eReceteNo =  _GlassesReport.EReceteNo;
                ereceteSil.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                ereceteSil.doktorTcKimlikNo = _GlassesReport.ProcedureDoctor.Person.UniqueRefNo.ToString();

                OptikReceteIslemleri.sonucDVO response = OptikReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, _GlassesReport.ProcedureDoctor.Person.UniqueRefNo.ToString(), _GlassesReport.ProcedureDoctor.ErecetePassword, ereceteSil);
                
                if(response != null)
                {
                    _GlassesReport.EReceteNo = response.sonucKodu == "0" ? String.Empty : _GlassesReport.EReceteNo;
                    _GlassesReport.SonucKodu = response.sonucKodu;
                    _GlassesReport.SonucAciklamasi = response.sonucMesaji + " " + response.uyariMesaji;
                }
            }
#endregion GlassesReportForm_btnReceteSil_Click
        }

        private void btnReceteKaydet_Click()
        {
            #region GlassesReportForm_btnReceteKaydet_Click
            //GlassesReport.ReceteKaydet(this._GlassesReport,cbxVitrumFar.Value,cbxVitrumNear.Value,cbxVitrumCloseReading.Value);
#endregion GlassesReportForm_btnReceteKaydet_Click
        }

        private void PrescriptionType_SelectedIndexChanged()
        {
#region GlassesReportForm_PrescriptionType_SelectedIndexChanged
   if(_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik)
            {
                this.cbxVitrumCloseReading.Enabled =true;
                // this.cbxVitrumNear.Value = false;
                this.cbxVitrumNear.Enabled = true;
                
                this.TemporaryLens.Enabled = false;
                this.TemporaryLens.Value = false;
                
                if(this.cbxVitrumFar.Value == true)
                {
                    this.TeleskopikGlassesTypeRightFar.Enabled = true;
                    this.TeleskopikGlassesTypeLeftFar.Enabled = true;
                    
                    this.SphRightFar.Enabled = false;
                    this.SphLeftFar.Enabled = false;
                    
                    this.CylRightFar.Enabled = false;
                    this.CylLeftFar.Enabled = false;
                    
                    this.AxRightFar.Enabled = false;
                    this.AxLeftFar.Enabled = false;
                    
                    this.GlassRightTypeFar.Enabled = false;
                    this.GlassLeftTypeFar.Enabled = false;
                    
                    this.GlassColorRightFar.Enabled = false;
                    this.GlassColorLeftFar.Enabled = false;
                    
                    this.DiameterRightFar.Enabled = false;
                    this.DiameterLeftFar.Enabled = false;
                    
                    this.GradientRightFar.Enabled = false;
                    this.GradientLeftFar.Enabled = false;
                    
                }
                if(this.cbxVitrumNear.Value == true)
                {
                    this.TeleskopikGlassesTypeRighNear.Enabled = true;
                    this.TeleskopikGlassesTypeLeftNear.Enabled = true;
                    
                    this.SphRightNear.Enabled = false;
                    this.SphLeftNear.Enabled = false;
                    
                    this.CylRightNear.Enabled = false;
                    this.CylLeftNear.Enabled = false;
                    
                    this.AxRightNear.Enabled = false;
                    this.AxLeftNear.Enabled = false;
                    
                    this.GlassRightTypeNear.Enabled = false;
                    this.GlassLeftTypeNear.Enabled = false;
                    
                    this.GlassColorRightNear.Enabled = false;
                    this.GlassColorLeftNear.Enabled = false;
                    
                    this.DiameterRightNear.Enabled = false;
                    this.DiameterLeftNear.Enabled = false;
                    
                    this.GradientRightNear.Enabled = false;
                    this.GradientLeftNear.Enabled = false;
                }
            }
            else if(_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens || _GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens)
            {
                if(_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
                    this.TemporaryLens.Enabled = true;
                else
                {
                    this.TemporaryLens.Enabled = false;
                    this.TemporaryLens.Value = false;
                }
                this.cbxVitrumNear.Enabled =false;
                this.cbxVitrumFar.Enabled = true;
                this.cbxVitrumCloseReading.Enabled = false;
                this.cbxVitrumNear.Value = false;
                this.cbxVitrumCloseReading.Value = false;
                this.TeleskopikGlassesTypeRighRead.Enabled = false;
                this.TeleskopikGlassesTypeLeftRead.Enabled = false;
                
                
                this.SphRightNear.Enabled = false;
                this.SphLeftNear.Enabled = false;
                
                this.CylRightNear.Enabled = false;
                this.CylLeftNear.Enabled = false;
                
                this.AxRightNear.Enabled = false;
                this.AxLeftNear.Enabled = false;
                
                this.DiameterRightNear.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                
                this.GradientRightNear.Enabled = false;
                this.GradientLeftNear.Enabled = false;
                
                this.GlassRightTypeNear.Enabled = false;
                this.GlassLeftTypeNear.Enabled = false;
                
                this.GlassColorRightNear.Enabled = false;
                this.GlassColorLeftNear.Enabled = false;
                
                this.TeleskopikGlassesTypeRighNear.Enabled = false;
                this.TeleskopikGlassesTypeLeftNear.Enabled = false;
                
                this.TeleskopikGlassesTypeRightFar.Enabled = false;
                this.TeleskopikGlassesTypeLeftFar.Enabled = false;
                
                this.GlassRightTypeFar.Enabled = true;
                this.GlassLeftTypeFar.Enabled = true;
                
                this.GlassColorRightFar.Enabled = false;
                this.GlassColorLeftFar.Enabled = false;
                
                this.SphRightFar.Enabled = true;
                this.SphLeftFar.Enabled = true;
                
                this.CylRightFar.Enabled = true;
                this.CylLeftFar.Enabled = true;
                
                this.AxRightFar.Enabled = true;
                this.AxLeftFar.Enabled = true;
                
                this.DiameterRightFar.Enabled = true;
                this.DiameterLeftFar.Enabled = true;
                
                this.GradientRightFar.Enabled = true;
                this.GradientLeftFar.Enabled = true;
            }
            else if(_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal)
            {
                this.cbxVitrumNear.Enabled = true;
                this.cbxVitrumFar.Enabled = true;
                
                this.cbxVitrumCloseReading.Value = false;
                this.cbxVitrumCloseReading.Enabled = false;
                
                this.TeleskopikGlassesTypeRighRead.Enabled = false;
                this.TeleskopikGlassesTypeLeftRead.Enabled = false;
                
                this.TeleskopikGlassesTypeRightFar.Enabled = false;
                this.TeleskopikGlassesTypeLeftFar.Enabled = false;
                
                this.TeleskopikGlassesTypeRighNear.Enabled = false;
                this.TeleskopikGlassesTypeLeftNear.Enabled = false;
                
                this.GradientRightFar.Enabled = false;
                this.GradientLeftFar.Enabled = false;
                
                this.DiameterRightFar.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                
                this.TemporaryLens.Enabled = false;
                this.TemporaryLens.Value = false;
                
                if(this.cbxVitrumFar.Value == true)
                {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    
                    this.GlassRightTypeFar.Enabled = true;
                    this.GlassLeftTypeFar.Enabled = true;
                    
                    this.GlassColorRightFar.Enabled = true;
                    this.GlassColorLeftFar.Enabled = true;
                }
                if(this.cbxVitrumNear.Value == true)
                {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    
                    this.GlassRightTypeNear.Enabled = true;
                    this.GlassLeftTypeNear.Enabled = true;
                    
                    this.GlassColorRightNear.Enabled = true;
                    this.GlassColorLeftNear.Enabled = true;
                }
            }
#endregion GlassesReportForm_PrescriptionType_SelectedIndexChanged
        }

        private void cbxVitrumNear_CheckedChanged()
        {
#region GlassesReportForm_cbxVitrumNear_CheckedChanged
   if(cbxVitrumNear.Value == true)
            {
                if(_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal)
                {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    
                    this.GlassRightTypeNear.Enabled = true;
                    this.GlassLeftTypeNear.Enabled = true;
                    
                    this.GlassColorRightNear.Enabled = true;
                    this.GlassColorLeftNear.Enabled = true;
                    
                    //    this.PrisRightNear.Enabled = true;
                    //    this.PrisLeftNear.Enabled = true;
                    
                    //    this.BasisRightNear.Enabled = true;
                    //    this.BasisLeftNear.Enabled = true;
                    
                    //    this.GlassColorAndTypeNear.Enabled = true;
                   
                    
                    /*
                    //NE geçici olarak eklendi.
                        this.PupillerDistanceNear.Enabled = true;
                        this.cbxBorderNear.Enabled = true;
                        //
                        */
                    
                }

                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
                {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    
                    this.GradientRightNear.Enabled = true;
                    this.GradientLeftNear.Enabled = true;
                }
                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens)
                {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    
                    //this.cbxVitrumFar.Enabled = false;
                    this.cbxVitrumCloseReading.Enabled = false;
                }
                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik)
                {
                    this.TeleskopikGlassesTypeRighNear.Enabled = true;
                    this.TeleskopikGlassesTypeLeftNear.Enabled = true;
                    
                    this.cbxVitrumCloseReading.Enabled = true;
                }
                
            }
            else
            {
                this.SphRightNear.Enabled = false;
                this.SphLeftNear.Enabled = false;
                
                this.CylRightNear.Enabled = false;
                this.CylLeftNear.Enabled = false;
                
                this.AxRightNear.Enabled = false;
                this.AxLeftNear.Enabled = false;
                
                this.DiameterRightNear.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                
                this.GradientRightNear.Enabled = false;
                this.GradientRightNear.Enabled = false;
                
                this.GlassRightTypeNear.Enabled = false;
                this.GlassLeftTypeNear.Enabled = false;
                
                this.GlassColorRightNear.Enabled = false;
                this.GlassColorLeftNear.Enabled = false;
                
                this.TeleskopikGlassesTypeRighNear.Enabled = false;
                this.TeleskopikGlassesTypeLeftNear.Enabled = false;
                
                //this.PrisRightNear.Enabled = false;
                //this.PrisLeftNear.Enabled = false;
                
                //this.BasisRightNear.Enabled = false;
                //this.BasisLeftNear.Enabled = false;
                
                //this.GlassColorAndTypeNear.Enabled = false;
                
                /*
                //NE geçici olarak eklendi.
                this.PupillerDistanceNear.Enabled = false;
                this.cbxBorderNear.Enabled = false;
                
                //
                */
            }
#endregion GlassesReportForm_cbxVitrumNear_CheckedChanged
        }

        private void cbxVitrumCloseReading_CheckedChanged()
        {
#region GlassesReportForm_cbxVitrumCloseReading_CheckedChanged
   if(cbxVitrumCloseReading.Value == true)
            {
                this.TeleskopikGlassesTypeRighRead.Enabled = true;
                this.TeleskopikGlassesTypeLeftRead.Enabled = true;
            }
            else
            {
                 this.TeleskopikGlassesTypeRighRead.Enabled = false;
                this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            }
            
            
            //if(cbxVitrumPerminent.Value == true)
            //         {
            //             this.SphRightPerminent.Enabled = true;
            //             this.SphLeftPerminent.Enabled = true;
            
            //             this.CylRightPerminent.Enabled = true;
            //             this.CylLeftPerminent.Enabled = true;
            
            //             this.AxRightPerminent.Enabled = true;
            //             this.AxLeftPerminent.Enabled = true;
            
            //             this.PrisRightPerminent.Enabled = true;
            //             this.PrisLeftPerminent.Enabled = true;
            
            //             this.BasisRightPerminent.Enabled = true;
            //             this.BasisLeftPerminent.Enabled = true;
            
            //             this.GlassColorAndTypePerminent.Enabled = true;
            //             this.PupillerDistancePerminent.Enabled = true;
            //             this.cbxBorderPerminent.Enabled = true;
            //         }
            //         else
            //         {
            //             this.SphRightPerminent.Enabled = false;
            //             this.SphLeftPerminent.Enabled = false;
            
            //             this.CylRightPerminent.Enabled = false;
            //             this.CylLeftPerminent.Enabled = false;
            
            //             this.AxRightPerminent.Enabled = false;
            //             this.AxLeftPerminent.Enabled = false;
            
            //             this.PrisRightPerminent.Enabled = false;
            //             this.PrisLeftPerminent.Enabled = false;
            
            //             this.BasisRightPerminent.Enabled = false;
            //             this.BasisLeftPerminent.Enabled = false;
            
            //             this.GlassColorAndTypePerminent.Enabled = false;
            //             this.PupillerDistancePerminent.Enabled = false;
            //             this.cbxBorderPerminent.Enabled = false;
            //         }
#endregion GlassesReportForm_cbxVitrumCloseReading_CheckedChanged
        }

        private void cbxVitrumFar_CheckedChanged()
        {
#region GlassesReportForm_cbxVitrumFar_CheckedChanged
   if(cbxVitrumFar.Value == true)
            {
                if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal)
                {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    
                    this.GlassRightTypeFar.Enabled = true;
                    this.GlassLeftTypeFar.Enabled = true;
                    
                    this.GlassColorRightFar.Enabled = true;
                    this.GlassColorLeftFar.Enabled = true;
                    
                    //this.PrisRightFar.Enabled = true;
                    //this.PrisLeftFar.Enabled = true;
                    
                    //this.BasisRightFar.Enabled = true;
                    //this.BasisLeftFar.Enabled = true;
                    
                    //this.GlassColorAndTypeFar.Enabled = true;
                  /*  
                    //NE geçici olarak eklendi.
                    this.PupillerDistanceFar.Enabled = true;
                    this.cbxBorderFar.Enabled = true;
                    
                    ///NE
                    */
                }
                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
                {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                }
                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens)
                {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                    
                    cbxVitrumNear.Enabled = false;
                    cbxVitrumCloseReading.Enabled = false;
                }
                else if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik)
                {
                    TeleskopikGlassesTypeRightFar.Enabled = true;
                    TeleskopikGlassesTypeLeftFar.Enabled = true;
                }
                
            }
            else
            {
                this.SphRightFar.Enabled = false;
                this.SphLeftFar.Enabled = false;
                
                this.CylRightFar.Enabled = false;
                this.CylLeftFar.Enabled = false;
                
                this.AxRightFar.Enabled = false;
                this.AxLeftFar.Enabled = false;
                
                this.DiameterRightFar.Enabled = false;
                this.DiameterLeftFar.Enabled = false;
                
                this.GradientRightFar.Enabled = false;
                this.GradientRightFar.Enabled = false;
                
                this.GlassRightTypeFar.Enabled = false;
                this.GlassLeftTypeFar.Enabled = false;
                
                this.GlassColorRightFar.Enabled = false;
                this.GlassColorLeftFar.Enabled = false;
                
                this.TeleskopikGlassesTypeRightFar.Enabled = false;
                this.TeleskopikGlassesTypeLeftFar.Enabled = false;
                
                //this.PrisRightFar.Enabled = false;
                //this.PrisLeftFar.Enabled = false;
                
                //this.BasisRightFar.Enabled = false;
                //this.BasisLeftFar.Enabled = false;
                
                //this.GlassColorAndTypeFar.Enabled = false;
                
                /*
                //NE geçici olarak eklendi.
                this.PupillerDistanceFar.Enabled = false;
                this.cbxBorderFar.Enabled = false;
                //
                */
            }
#endregion GlassesReportForm_cbxVitrumFar_CheckedChanged
        }

        protected override void PreScript()
        {
#region GlassesReportForm_PreScript
    base.PreScript();
            
            if(this.ProcedureDoctor.SelectedObject == null)
            {
                ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                if (currentUser.UserType == UserTypeEnum.Doctor)
                {
                    this.ProcedureDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                }
            }
            
            bool diagnoseControl = false;
            if(_GlassesReport.Episode != null &&   _GlassesReport.Episode.Diagnosis != null)
            {
                foreach(DiagnosisGrid diagnosis in _GlassesReport.Episode.Diagnosis)
                {
                    foreach (DiagnosisGrid glassesDiagnosis in _GlassesReport.Diagnosis)
                    {
                        if (glassesDiagnosis.ObjectID == diagnosis.ObjectID)
                            diagnoseControl = true;                        
                    }
                    if( _GlassesReport.Diagnosis == null ||  _GlassesReport.Diagnosis.Count == 0)
                        diagnoseControl = true;
                    if (diagnoseControl == false)
                        _GlassesReport.Diagnosis.Add(diagnosis);
                }
            }
            
        //    this.ReasonForAdmission.Text = this._GlassesReport.Episode.ReasonForAdmission.Description;
           // this.PatientGroup.Text = Common.GetEnumValueDefOfEnumValue(this._GlassesReport.Episode.Patient.PatientGroup.Value).DisplayText;
//            this.RecordID.Text = this._GlassesReport.Episode.RetirementFundID; //SGK Sicil No
            
            if(this._GlassesReport.CurrentStateDefID == GlassesReport.States.New)
                this.ReportDate.ControlValue = DateTime.Now;
            
            this.SphRightFar.Enabled = false;
            this.SphRightNear.Enabled = false;
            // this.SphRightPerminent.Enabled = false;
            this.SphLeftFar.Enabled = false;
            this.SphLeftNear.Enabled = false;
            // this.SphLeftPerminent.Enabled = false;
            
            this.CylRightFar.Enabled = false;
            this.CylRightNear.Enabled = false;
            // this.CylRightPerminent.Enabled = false;
            this.CylLeftFar.Enabled = false;
            this.CylLeftNear.Enabled = false;
            //this.CylLeftPerminent.Enabled = false;
            
            this.AxRightFar.Enabled = false;
            this.AxRightNear.Enabled = false;
            //this.AxRightPerminent.Enabled = false;
            this.AxLeftFar.Enabled = false;
            this.AxLeftNear.Enabled = false;
            // this.AxLeftPerminent.Enabled = false;
            
            this.DiameterRightFar.Enabled = false;
            this.DiameterRightNear.Enabled = false;
            this.DiameterLeftFar.Enabled = false;
            this.DiameterLeftNear.Enabled = false;
            
            this.GradientRightFar.Enabled = false;
            this.GradientRightNear.Enabled = false;
            this.GradientLeftFar.Enabled = false;
            this.GradientLeftNear.Enabled = false;
            
            this.GlassRightTypeFar.Enabled = false;
            this.GlassRightTypeNear.Enabled = false;
            this.GlassLeftTypeFar.Enabled = false;
            this.GlassLeftTypeNear.Enabled = false;
            
            this.GlassColorRightFar.Enabled = false;
            this.GlassColorRightNear.Enabled = false;
            this.GlassColorLeftFar.Enabled = false;
            this.GlassColorLeftNear.Enabled = false;
            
            this.TeleskopikGlassesTypeRightFar.Enabled = false;
            this.TeleskopikGlassesTypeRighNear.Enabled = false;
            this.TeleskopikGlassesTypeLeftFar.Enabled = false;
            this.TeleskopikGlassesTypeLeftNear.Enabled = false;
            
            this.cbxVitrumCloseReading.Enabled = false;
            this.TeleskopikGlassesTypeRighRead.Enabled = false;
            this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            
            
            //this.PrisRightFar.Enabled = false;
            //this.PrisRightNear.Enabled = false;
            //this.PrisRightPerminent.Enabled = false;
            //this.PrisLeftFar.Enabled = false;
            //this.PrisLeftNear.Enabled = false;
            //this.PrisLeftPerminent.Enabled = false;
            
            //this.BasisRightFar.Enabled = false;
            //this.BasisRightNear.Enabled = false;
            //this.BasisRightPerminent.Enabled = false;
            //this.BasisLeftFar.Enabled = false;
            //this.BasisLeftNear.Enabled = false;
            //this.BasisLeftPerminent.Enabled = false;
            
            //this.GlassColorAndTypeFar.Enabled = false;
            //this.GlassColorAndTypeNear.Enabled = false;
            //this.GlassColorAndTypePerminent.Enabled = false;
            
            /*
            //NE geçici olarak eklendi.
            this.PupillerDistanceFar.Enabled = false;
            this.PupillerDistanceNear.Enabled = false;
            //
            
            //this.PupillerDistancePerminent.Enabled = false;
            
            //NE geçici olarak eklendi.
            this.cbxBorderFar.Enabled = false;
            this.cbxBorderNear.Enabled = false;
            
            this.cbxVitrumFar.Enabled = true;
            this.cbxVitrumNear.Enabled = true;
            //
             */
            //this.cbxBorderPerminent.Enabled = false;
#endregion GlassesReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GlassesReportForm_PostScript
    base.PostScript(transDef);
#endregion GlassesReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region GlassesReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == GlassesReport.States.Completed && _GlassesReport.EReceteNo == null )
                {
                    if(MedulaEpisodeControl(_GlassesReport))
                    {
                        //                    throw new TTUtils.TTException("Hastanın Reçetesini Medulaya Bildirmediniz !");
//
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Hastanın Reçetesini Medulaya Bildirmediniz!\nDevam etmek istediğinize emin misiniz?") == "H")
                        {
                            throw new TTUtils.TTException("İşlemden vazgeçildi");
                        }
                    }
                }
            }
#endregion GlassesReportForm_ClientSidePostScript

        }

#region GlassesReportForm_Methods
        private void CommaControl(string text)
        {
            char subChar;
            for (int i = 0; i <= text.Length - 1; i++)
            {
                subChar = text.Substring(i, 1).ToCharArray(0, 1)[0];
                if (subChar == ',')
                {
                    InfoBox.Alert("Virgül (,) yerine nokta (.) işareti kullanmalısınız ! ");
                    break;
                }
            }
        }
        
        static bool MedulaEpisodeControl(GlassesReport glassesReport)
        {
           return SubEpisode.IsSGKSubEpisode(glassesReport.SubEpisode);
        }
        
#endregion GlassesReportForm_Methods
    }
}