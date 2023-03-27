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



namespace TTObjectClasses
{
    /// <summary>
    /// Gözlük Reçetesi
    /// </summary>
    public partial class GlassesReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class GetGlassesReport_Class : TTReportNqlObject
        {
        }

        #region Methods
        public GlassesReport(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = GlassesReport.States.New;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Gozluk_Recetesi_Yeni, TTRoleNames.SorumluDoktorTamamlanmisIslemGorme, TTRoleNames.Gozluk_Recetesi_Tamam)]
        public static void ReceteKaydet(GlassesReport _GlassesReport, bool? vitrumFar, bool? vitrumNear, bool? vitrumCloseReading, string username, string password)
        {
            if (_GlassesReport.PrescriptionType == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26761", "Reçete türünü seçmediniz!"));
            if (_GlassesReport.ReportDate == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26752", "Rapor Tarihi boş geçilemez!"));
            if (_GlassesReport.SubEpisode.SGKSEP == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25822", "Hastanın aktif takibi bulunamamıştır !"));
            OptikReceteIslemleri.receteTesisDVO _receteTesisDVO = new OptikReceteIslemleri.receteTesisDVO();
            _receteTesisDVO.receteTipi = _GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal ? "N" : _GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik ? "T" : _GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens ? "L" : _GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens ? "N" : null;
            _receteTesisDVO.protokolNo = _GlassesReport.Episode.HospitalProtocolNo.ToString();
            _receteTesisDVO.receteTarihi = _GlassesReport.ReportDate != null ? ((DateTime)_GlassesReport.ReportDate).ToString("dd.MM.yyyy") : null;
            _receteTesisDVO.tcKimlikNo = _GlassesReport.Episode.Patient.UniqueRefNo != null ? _GlassesReport.Episode.Patient.UniqueRefNo.ToString() : null;
            _receteTesisDVO.takipNo = _GlassesReport.SubEpisode.SGKSEP.MedulaTakipNo;
            _receteTesisDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
            _receteTesisDVO.doktorTcKimlikNo = username != null ? username : _GlassesReport.ProcedureDoctor.Person.UniqueRefNo.ToString();
            _receteTesisDVO.drTescilNo = _GlassesReport.ProcedureDoctor.DiplomaRegisterNo;
            _receteTesisDVO.eReceteNo = null;
            _receteTesisDVO.provizyonTipi = _GlassesReport.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "I" ? "I" : _GlassesReport.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "D" ? "D" : _GlassesReport.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "N" ? "N" : _GlassesReport.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "T" ? "T" : _GlassesReport.SubEpisode.SGKSEP.MedulaYupassNo != null ? "Y" : null;
            if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal)
            {
                if (vitrumFar == true)
                {
                    _receteTesisDVO.gozlukTuru1 = "U";
                    if (_GlassesReport.SphRightFar != null || _GlassesReport.CylRightFar != null || _GlassesReport.AxRightFar != null || _GlassesReport.GlassColorRightFar != null || _GlassesReport.GlassRightTypeFar != null)
                    {
                        if (_GlassesReport.SphRightFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                        if (_GlassesReport.CylRightFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26789", "Sağ Silenderik alanı boş geçilemez!"));
                        if (_GlassesReport.AxRightFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26781", "Sağ Aks alanı boş geçilemez!"));

                        _receteTesisDVO.sagCam1 = "E";
                        _receteTesisDVO.sagSferik1 = _GlassesReport.SphRightFar;
                        _receteTesisDVO.sagSilendirik1 = _GlassesReport.CylRightFar;
                        _receteTesisDVO.sagAks1 = _GlassesReport.AxRightFar;
                    }
                    if (_GlassesReport.SphLeftFar != null || _GlassesReport.CylLeftFar != null || _GlassesReport.AxLeftFar != null || _GlassesReport.GlassColorLeftFar != null || _GlassesReport.GlassLeftTypeFar != null)
                    {
                        if (_GlassesReport.SphLeftFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26908", "Sol Sferik alanı boş geçilemez!"));
                        if (_GlassesReport.CylLeftFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26909", "Sol Silenderik alanı boş geçilemez!"));
                        if (_GlassesReport.AxLeftFar == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26902", "Sol Aks alanı boş geçilemez!"));

                        _receteTesisDVO.solCam1 = "E";
                        _receteTesisDVO.solSferik1 = _GlassesReport.SphLeftFar;
                        _receteTesisDVO.solSilendirik1 = _GlassesReport.CylLeftFar;
                        _receteTesisDVO.solAks1 = _GlassesReport.AxLeftFar;
                    }
                    if (_GlassesReport.GlassLeftTypeFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25740", "Gözlük Tipi alanı boş geçilemez!"));
                    if (_GlassesReport.GlassColorLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25355", "Cam Rengi alanı boş geçilemez!"));
                    _receteTesisDVO.camTipi1 = _GlassesReport.GlassLeftTypeFar == GlassTypeEnum.Duz ? "D" : _GlassesReport.GlassLeftTypeFar == GlassTypeEnum.Organik ? "O" : _GlassesReport.GlassLeftTypeFar == GlassTypeEnum.BifocalProgresif ? "B" : null;
                    _receteTesisDVO.camRengi1 = _GlassesReport.GlassColorLeftFar == GlassColorEnum.Seciniz ? "S" : _GlassesReport.GlassColorLeftFar == GlassColorEnum.Colormatik ? "C" : _GlassesReport.GlassColorLeftFar == GlassColorEnum.Beyaz ? "B" : null;
                }
                if (vitrumNear == true)
                {
                    if (vitrumFar == true)
                    {
                        _receteTesisDVO.gozlukTuru2 = "Y";
                        if (_GlassesReport.SphRightNear != null || _GlassesReport.CylRightNear != null || _GlassesReport.AxRightNear != null || _GlassesReport.GlassColorRightNear != null || _GlassesReport.GlassRightTypeNear != null)
                        {
                            if (_GlassesReport.SphRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                            if (_GlassesReport.CylRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26789", "Sağ Silenderik alanı boş geçilemez!"));
                            if (_GlassesReport.AxRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26781", "Sağ Aks alanı boş geçilemez!"));
                            _receteTesisDVO.sagCam2 = "E";
                            _receteTesisDVO.sagSferik2 = _GlassesReport.SphRightNear;
                            _receteTesisDVO.sagSilendirik2 = _GlassesReport.CylRightNear;
                            _receteTesisDVO.sagAks2 = _GlassesReport.AxRightNear;
                        }
                        if (_GlassesReport.SphLeftNear != null || _GlassesReport.CylLeftNear != null || _GlassesReport.AxLeftNear != null || _GlassesReport.GlassColorLeftNear != null || _GlassesReport.GlassLeftTypeNear != null)
                        {
                            if (_GlassesReport.SphLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26908", "Sol Sferik alanı boş geçilemez!"));
                            if (_GlassesReport.CylLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26909", "Sol Silenderik alanı boş geçilemez!"));
                            if (_GlassesReport.AxLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26902", "Sol Aks alanı boş geçilemez!"));
                            _receteTesisDVO.solCam2 = "E";
                            _receteTesisDVO.solSferik2 = _GlassesReport.SphLeftNear;
                            _receteTesisDVO.solSilendirik2 = _GlassesReport.CylLeftNear;
                            _receteTesisDVO.solAks2 = _GlassesReport.AxLeftNear;

                        }
                        if (_GlassesReport.GlassColorLeftNear == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25740", "Gözlük Tipi alanı boş geçilemez!"));
                        if (_GlassesReport.GlassLeftTypeNear == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25355", "Cam Rengi alanı boş geçilemez!"));
                        _receteTesisDVO.camTipi2 = _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.Duz ? "D" : _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.Organik ? "O" : _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.BifocalProgresif ? "B" : null;
                        _receteTesisDVO.camRengi2 = _GlassesReport.GlassColorLeftNear == GlassColorEnum.Seciniz ? "S" : _GlassesReport.GlassColorLeftNear == GlassColorEnum.Colormatik ? "C" : _GlassesReport.GlassColorLeftNear == GlassColorEnum.Beyaz ? "B" : null;
                    }
                    else
                    {
                        _receteTesisDVO.gozlukTuru1 = "Y";
                        if (_GlassesReport.SphRightNear != null || _GlassesReport.CylRightNear != null || _GlassesReport.AxRightNear != null || _GlassesReport.GlassColorRightNear != null || _GlassesReport.GlassRightTypeNear != null)
                        {
                            if (_GlassesReport.SphRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                            if (_GlassesReport.CylRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26789", "Sağ Silenderik alanı boş geçilemez!"));
                            if (_GlassesReport.AxRightNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26781", "Sağ Aks alanı boş geçilemez!"));
                            _receteTesisDVO.sagCam1 = "E";
                            _receteTesisDVO.sagSferik1 = _GlassesReport.SphRightNear;
                            _receteTesisDVO.sagSilendirik1 = _GlassesReport.CylRightNear;
                            _receteTesisDVO.sagAks1 = _GlassesReport.AxRightNear;
                        }

                        if (_GlassesReport.SphLeftNear != null || _GlassesReport.CylLeftNear != null || _GlassesReport.AxLeftNear != null || _GlassesReport.GlassColorLeftNear != null || _GlassesReport.GlassLeftTypeNear != null)
                        {
                            if (_GlassesReport.SphLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26908", "Sol Sferik alanı boş geçilemez!"));
                            if (_GlassesReport.CylLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26909", "Sol Silenderik alanı boş geçilemez!"));
                            if (_GlassesReport.AxLeftNear == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26902", "Sol Aks alanı boş geçilemez!"));
                            _receteTesisDVO.solCam1 = "E";
                            _receteTesisDVO.solSferik1 = _GlassesReport.SphLeftNear;
                            _receteTesisDVO.solSilendirik1 = _GlassesReport.CylLeftNear;
                            _receteTesisDVO.solAks1 = _GlassesReport.AxLeftNear;

                        }
                        if (_GlassesReport.GlassColorLeftNear == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26904", "Sol Gözlük Tipi alanı boş geçilemez!"));
                        if (_GlassesReport.GlassLeftTypeNear == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26903", "Sol Cam Rengi alanı boş geçilemez!"));
                        _receteTesisDVO.camTipi1 = _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.Duz ? "D" : _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.Organik ? "O" : _GlassesReport.GlassLeftTypeNear == GlassTypeEnum.BifocalProgresif ? "B" : null;
                        _receteTesisDVO.camRengi1 = _GlassesReport.GlassColorLeftNear == GlassColorEnum.Seciniz ? "S" : _GlassesReport.GlassColorLeftNear == GlassColorEnum.Colormatik ? "C" : _GlassesReport.GlassColorLeftNear == GlassColorEnum.Beyaz ? "B" : null;

                    }
                }
            }

            if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
            {
                if (_GlassesReport.TemporaryLens == true)
                    _receteTesisDVO.lensGeciciMadde = "E";
                else
                    _receteTesisDVO.lensGeciciMadde = "H";
                if (vitrumFar == true && (_GlassesReport.SphRightFar != null || _GlassesReport.CylRightFar != null || _GlassesReport.AxRightFar != null || _GlassesReport.DiameterRightFar != null || _GlassesReport.GradientRightFar != null))
                {
                    if (_GlassesReport.SphRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                    if (_GlassesReport.CylRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26789", "Sağ Silenderik alanı boş geçilemez!"));
                    if (_GlassesReport.AxRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26781", "Sağ Aks alanı boş geçilemez!"));
                    if (_GlassesReport.DiameterRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26784", "Sağ Eğim alanı boş geçilemez!"));
                    if (_GlassesReport.GradientRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26783", "Sağ Çap alanı boş geçilemez!"));
                    _receteTesisDVO.lensSagCam = "E";
                    _receteTesisDVO.lensSagCamSferik = _GlassesReport.SphRightFar;
                    _receteTesisDVO.lensSagCamSilendirik = _GlassesReport.CylRightFar;
                    _receteTesisDVO.lensSagCamAks = _GlassesReport.AxRightFar;
                    _receteTesisDVO.lensSagCamEgim = _GlassesReport.DiameterRightFar;
                    _receteTesisDVO.lensSagCamCap = _GlassesReport.GradientRightFar;
                }

                if (vitrumFar == true && (_GlassesReport.SphLeftFar != null || _GlassesReport.CylLeftFar != null || _GlassesReport.AxLeftFar != null || _GlassesReport.DiameterLeftFar != null || _GlassesReport.GradientLeftFar != null))
                {
                    if (_GlassesReport.SphLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                    if (_GlassesReport.CylLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26789", "Sağ Silenderik alanı boş geçilemez!"));
                    if (_GlassesReport.AxLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26781", "Sağ Aks alanı boş geçilemez!"));
                    if (_GlassesReport.DiameterLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26784", "Sağ Eğim alanı boş geçilemez!"));
                    if (_GlassesReport.GradientLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26783", "Sağ Çap alanı boş geçilemez!"));
                    _receteTesisDVO.lensSolCam = "E";
                    _receteTesisDVO.lensSolCamSferik = _GlassesReport.SphLeftFar;
                    _receteTesisDVO.lensSolCamSilendirik = _GlassesReport.CylLeftFar;
                    _receteTesisDVO.lensSolCamAks = _GlassesReport.AxLeftFar;
                    _receteTesisDVO.lensSolCamEgim = _GlassesReport.DiameterLeftFar;
                    _receteTesisDVO.lensSolCamCap = _GlassesReport.GradientLeftFar;
                }
            }

            if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens)
            {
                if (vitrumFar == true && (_GlassesReport.SphRightFar != null || _GlassesReport.GradientRightFar != null))
                {
                    if (_GlassesReport.SphRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                    if (_GlassesReport.GradientRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26783", "Sağ Çap alanı boş geçilemez!"));
                    _receteTesisDVO.keratakonusSagCam = "E";
                    _receteTesisDVO.keratakonusSagCamSferik = _GlassesReport.SphRightFar;
                    _receteTesisDVO.keratakonusSagCamSilendirik = _GlassesReport.CylRightFar;
                    _receteTesisDVO.keratakonusSagCamAks = _GlassesReport.AxRightFar;
                    _receteTesisDVO.keratakonusSagCamCap = _GlassesReport.GradientRightFar;
                    _receteTesisDVO.keratakonusSagCamEgim = _GlassesReport.DiameterRightFar;
                }

                if (vitrumFar == true && (_GlassesReport.SphLeftFar != null || _GlassesReport.GradientLeftFar != null))
                {
                    if (_GlassesReport.SphLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26788", "Sağ Sferik alanı boş geçilemez!"));
                    if (_GlassesReport.GradientLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26783", "Sağ Çap alanı boş geçilemez!"));
                    _receteTesisDVO.keratakonusSolCam = "E";
                    _receteTesisDVO.keratakonusSolCamSferik = _GlassesReport.SphLeftFar;
                    _receteTesisDVO.keratakonusSolCamSilendirik = _GlassesReport.CylLeftFar;
                    _receteTesisDVO.keratakonusSolCamAks = _GlassesReport.AxLeftFar;
                    _receteTesisDVO.keratakonusSolCamEgim = _GlassesReport.DiameterLeftFar;
                    _receteTesisDVO.keratakonusSolCamCap = _GlassesReport.GradientLeftFar;
                }
            }

            if (_GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik)
            {
                if (vitrumFar == true && _GlassesReport.TeleskopikGlassesTypeRightFar != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeRightFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26790", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru1 = "U";
                    _receteTesisDVO.teleskopikSagSol1 = "R";
                    _receteTesisDVO.teleskobikSagCam1 = "E";
                    _receteTesisDVO.teleskobikSolCam1 = "H";
                    _receteTesisDVO.teleskopikGozlukTipi1 = _GlassesReport.TeleskopikGlassesTypeRightFar == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeRightFar == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeRightFar == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }

                if (vitrumFar == true && _GlassesReport.TeleskopikGlassesTypeLeftFar != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeLeftFar == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26910", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru1 = "U";
                    _receteTesisDVO.teleskopikSagSol1 = "L";
                    _receteTesisDVO.teleskobikSagCam1 = "H";
                    _receteTesisDVO.teleskobikSolCam1 = "E";
                    _receteTesisDVO.teleskopikGozlukTipi1 = _GlassesReport.TeleskopikGlassesTypeLeftFar == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeLeftFar == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeLeftFar == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }

                if (vitrumNear == true && _GlassesReport.TeleskopikGlassesTypeRighNear != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeRighNear == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26790", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru2 = "Y";
                    _receteTesisDVO.teleskopikSagSol2 = "R";
                    _receteTesisDVO.teleskobikSagCam2 = "E";
                    _receteTesisDVO.teleskobikSolCam2 = "H";
                    _receteTesisDVO.teleskopikGozlukTipi2 = _GlassesReport.TeleskopikGlassesTypeRighNear == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeRightFar == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeRightFar == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }

                if (vitrumNear == true && _GlassesReport.TeleskopikGlassesTypeLeftNear != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeLeftNear == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26910", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru2 = "Y";
                    _receteTesisDVO.teleskopikSagSol2 = "L";
                    _receteTesisDVO.teleskobikSagCam2 = "H";
                    _receteTesisDVO.teleskobikSolCam2 = "E";
                    _receteTesisDVO.teleskopikGozlukTipi2 = _GlassesReport.TeleskopikGlassesTypeLeftNear == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeLeftNear == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeLeftNear == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }

                if (vitrumCloseReading == true && _GlassesReport.TeleskopikGlassesTypeRighRead != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeRighRead == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26790", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru2 = "YOK";
                    _receteTesisDVO.teleskopikSagSol2 = "R";
                    _receteTesisDVO.teleskobikSagCam2 = "E";
                    _receteTesisDVO.teleskobikSolCam2 = "H";
                    _receteTesisDVO.teleskopikGozlukTipi2 = _GlassesReport.TeleskopikGlassesTypeRighRead == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeRighRead == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeRighRead == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }

                if (vitrumCloseReading == true && _GlassesReport.TeleskopikGlassesTypeLeftRead != null)
                {
                    if (_GlassesReport.TeleskopikGlassesTypeLeftRead == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26910", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    _receteTesisDVO.teleskobikGozlukTuru2 = "YOK";
                    _receteTesisDVO.teleskopikSagSol2 = "L";
                    _receteTesisDVO.teleskobikSagCam2 = "H";
                    _receteTesisDVO.teleskobikSolCam2 = "E";
                    _receteTesisDVO.teleskopikGozlukTipi2 = _GlassesReport.TeleskopikGlassesTypeLeftRead == TeleskopikGlassesTypeEnum.Tek ? "T" : _GlassesReport.TeleskopikGlassesTypeLeftRead == TeleskopikGlassesTypeEnum.Cift ? "C" : _GlassesReport.TeleskopikGlassesTypeLeftRead == TeleskopikGlassesTypeEnum.TekKarekod ? "TK" : null;
                }
            }

            List<OptikReceteIslemleri.ereceteTaniDVO> _ereceteTaniDVOList = new List<OptikReceteIslemleri.ereceteTaniDVO>();
            foreach (DiagnosisGrid diagnose in _GlassesReport.SecDiagnosis)
            {
                OptikReceteIslemleri.ereceteTaniDVO _ereceteTaniDVO = new OptikReceteIslemleri.ereceteTaniDVO();
                _ereceteTaniDVO.taniAdi = diagnose.Diagnose.Name;
                _ereceteTaniDVO.taniKodu = diagnose.DiagnoseCode;
                _ereceteTaniDVOList.Add(_ereceteTaniDVO);
                _receteTesisDVO.receteTeshis += diagnose.Diagnose.Name + " ";
            }

            if (_ereceteTaniDVOList != null && _ereceteTaniDVOList.Count == 0 && _GlassesReport.Episode.Diagnosis != null)
            {
                foreach (DiagnosisGrid diagnose in _GlassesReport.Episode.Diagnosis)
                {
                    OptikReceteIslemleri.ereceteTaniDVO _ereceteTaniDVO = new OptikReceteIslemleri.ereceteTaniDVO();
                    _ereceteTaniDVO.taniAdi = diagnose.Diagnose.Name;
                    _ereceteTaniDVO.taniKodu = diagnose.DiagnoseCode;
                    _ereceteTaniDVOList.Add(_ereceteTaniDVO);
                    _receteTesisDVO.receteTeshis += diagnose.Diagnose.Name + " ";
                }
            }

            _receteTesisDVO.ereceteTaniListesi = _ereceteTaniDVOList.ToArray();
            OptikReceteIslemleri.sonucDVO response = OptikReceteIslemleri.WebMethods.ereceteKaydet(Sites.SiteLocalHost, username, password, _receteTesisDVO);
            if (response != null)
            {
                if (response.sonucKodu == "0")
                {
                    try
                    {
                        UserMessage um = new UserMessage();
                        List<Patient> patients = new List<Patient> { _GlassesReport.Episode.Patient };
                        um.SendSMSPatient(patients, Common.RecTime().ToString("dd.MM.yyyy") + " tarihinde XXXXXXmizde yazılmış olan gözlük reçetenize ait reçete numarası: " + response.eReceteNo, SMSTypeEnum.GlassReportSMSForPatient);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                _GlassesReport.EReceteNo = response.eReceteNo;
                _GlassesReport.SonucKodu = response.sonucKodu;
                _GlassesReport.SonucAciklamasi = response.sonucMesaji + " " + response.uyariMesaji;
            }
        }

        public static void ReceteSil(GlassesReport _GlassesReport, string username, string password)
        {
            if (_GlassesReport.EReceteNo != null)
            {
                OptikReceteIslemleri.ereceteSilDVO ereceteSil = new OptikReceteIslemleri.ereceteSilDVO();
                ereceteSil.eReceteNo = _GlassesReport.EReceteNo;
                ereceteSil.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                ereceteSil.doktorTcKimlikNo = username != null ? username : _GlassesReport.ProcedureDoctor.Person.UniqueRefNo.ToString();
                OptikReceteIslemleri.sonucDVO response = OptikReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, username, password, ereceteSil);

                if (response != null)
                {
                    _GlassesReport.EReceteNo = response.sonucKodu == "0" ? string.Empty : _GlassesReport.EReceteNo;
                    _GlassesReport.SonucKodu = response.sonucKodu;
                    _GlassesReport.SonucAciklamasi = response.sonucMesaji + " " + response.uyariMesaji;
                }
            }
        }

        public static OptikReceteIslemleri.receteTesisDVO[] GecmisReceteleriListele(EpisodeAction episodeAction, string medulaUsername, string medulaPassword)
        {
            OptikReceteIslemleri.ereceteListeSorguIstekDVO ereceteListeSorguIstek = new OptikReceteIslemleri.ereceteListeSorguIstekDVO();
            ereceteListeSorguIstek.doktorTcKimlikNo = medulaUsername != null ? Convert.ToInt64(medulaUsername) : Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
            ereceteListeSorguIstek.hastaTcKimlikNo = Convert.ToInt64(episodeAction.Episode.Patient.UniqueRefNo); //10000000000;
            ereceteListeSorguIstek.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(); /*; 11069941*/
            OptikReceteIslemleri.ereceteListeSorguCevapDVO response = OptikReceteIslemleri.WebMethods.ereceteListeSorgu(Sites.SiteLocalHost, medulaUsername, medulaPassword, ereceteListeSorguIstek);
            if (response.ereceteListesi != null)
            {
                foreach (OptikReceteIslemleri.receteTesisDVO gozlukRecetesi in response.ereceteListesi)
                {
                    if (gozlukRecetesi.receteTipi == "N")
                    {
                        gozlukRecetesi.receteTipi = "Normal";
                    }
                    else if (gozlukRecetesi.receteTipi == "T")
                    {
                        gozlukRecetesi.receteTipi = TTUtils.CultureService.GetText("M27090", "Teleskopik");
                    }
                    else if (gozlukRecetesi.receteTipi == "L")
                    {
                        gozlukRecetesi.receteTipi = TTUtils.CultureService.GetText("M26378", "Lens");
                    }
                    else
                    {
                        gozlukRecetesi.receteTipi = "Keratakonuslens";
                    }
                    using (var objectContext = new TTObjectContext(true))
                    {
                        IBindingList details = objectContext.QueryObjects("PERSON", "UNIQUEREFNO=" + gozlukRecetesi.doktorTcKimlikNo);
                        if (details != null)
                        {
                            foreach (Person person in details)
                            {
                                gozlukRecetesi.doktorTcKimlikNo = person.Name + " " + person.Surname;
                            }
                        }
                    }
                    gozlukRecetesi.gozlukTuru1 = gozlukRecetesi.gozlukTuru1 == "U" ? TTUtils.CultureService.GetText("M27148", "Uzak") : gozlukRecetesi.gozlukTuru1 == "Y" ? TTUtils.CultureService.GetText("M24243", "Yakın") : null;
                    gozlukRecetesi.gozlukTuru2 = gozlukRecetesi.gozlukTuru2 == "U" ? TTUtils.CultureService.GetText("M27148", "Uzak") : gozlukRecetesi.gozlukTuru2 == "Y" ? TTUtils.CultureService.GetText("M24243", "Yakın") : null;
                    gozlukRecetesi.camTipi1 = gozlukRecetesi.camTipi1 == "D" ? TTUtils.CultureService.GetText("M25560", "Düz") : gozlukRecetesi.camTipi1 == "O" ? TTUtils.CultureService.GetText("M26640", "Organik") : gozlukRecetesi.camTipi1 == "B" ? TTUtils.CultureService.GetText("M25273", "Bifocal-Progresif") : null;
                    gozlukRecetesi.camTipi2 = gozlukRecetesi.camTipi2 == "D" ? TTUtils.CultureService.GetText("M25560", "Düz") : gozlukRecetesi.camTipi2 == "O" ? TTUtils.CultureService.GetText("M26640", "Organik") : gozlukRecetesi.camTipi2 == "B" ? TTUtils.CultureService.GetText("M25273", "Bifocal-Progresif") : null;
                    gozlukRecetesi.camRengi1 = gozlukRecetesi.camRengi1 == "S" ? TTUtils.CultureService.GetText("M26832", "Seçiniz") : gozlukRecetesi.camRengi1 == "B" ? TTUtils.CultureService.GetText("M25272", "Beyaz") : gozlukRecetesi.camRengi1 == "C" ? TTUtils.CultureService.GetText("M25371", "Colormatik") : null;
                    gozlukRecetesi.camRengi2 = gozlukRecetesi.camRengi2 == "S" ? TTUtils.CultureService.GetText("M26832", "Seçiniz") : gozlukRecetesi.camRengi2 == "B" ? TTUtils.CultureService.GetText("M25272", "Beyaz") : gozlukRecetesi.camRengi2 == "C" ? TTUtils.CultureService.GetText("M25371", "Colormatik") : null;

                }
                return response.ereceteListesi;
            }
            return null;
        }
        #endregion Methods
    }
}