
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Ortez-Protez 3 İmza Raporu
    /// </summary>
    public partial class OrthesisProsthesisThreeSpecialistReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public OrthesisProsthesisThreeSpecialistReport MyParentReport
            {
                get { return (OrthesisProsthesisThreeSpecialistReport)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR { get {return Header().RAPOR;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField NewField145 { get {return Header().NewField145;} }
            public TTReportField NewField146 { get {return Header().NewField146;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField NewField28 { get {return Header().NewField28;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine10 { get {return Header().NewLine10;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField41 { get {return Header().NewField41;} }
            public TTReportField NewField43 { get {return Header().NewField43;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField BASHEKIM { get {return Header().BASHEKIM;} }
            public TTReportField DIPSIC { get {return Header().DIPSIC;} }
            public TTReportField UZ { get {return Header().UZ;} }
            public TTReportField ADSOYADDOC { get {return Header().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Header().SINRUT;} }
            public TTReportField XXXXXXBASLIK2 { get {return Header().XXXXXXBASLIK2;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>("GetOrthesisProsthesisRequest", OrthesisProsthesisRequest.GetOrthesisProsthesisRequest((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANIGroupHeader(this);
                _footer = new TANIGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANIGroupHeader : TTReportSection
            {
                public OrthesisProsthesisThreeSpecialistReport MyParentReport
                {
                    get { return (OrthesisProsthesisThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField RAPOR;
                public TTReportField XXXXXXBASLIK;
                public TTReportField ADISOYADI;
                public TTReportField NewField141;
                public TTReportField ACTIONDATE;
                public TTReportField RAPORNO;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField NewField144;
                public TTReportField NewField145;
                public TTReportField NewField146;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField SICILNO;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportField NewField41;
                public TTReportField NewField43;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField BASHEKIM;
                public TTReportField DIPSIC;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField XXXXXXBASLIK2;
                public TTReportField XXXXXXIL;
                public TTReportField NewField21;
                public TTReportField NAME;
                public TTReportField SURNAME; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 261;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 29, 121, 34, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR.TextFont.Size = 12;
                    RAPOR.TextFont.Bold = true;
                    RAPOR.Value = @"ÜÇ İMZA RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 8, 155, 25, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%XXXXXXBASLIK%}
{%XXXXXXIL%}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 62, 138, 66, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.Value = @"{%NAME%} {%SURNAME%}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 40, 46, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @"RAPOR NO     :";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 46, 76, 50, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"Short Date";
                    ACTIONDATE.Value = @"{#ISLEMTARIHI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 42, 76, 46, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 40, 50, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @"RAPOR TARİHİ :";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 62, 66, false);
                    NewField143.Name = "NewField143";
                    NewField143.Value = @"HASTANIN KİMLİĞİ";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 66, 62, 70, false);
                    NewField144.Name = "NewField144";
                    NewField144.Value = @"DOĞUM YERİ- TARİHİ";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 70, 62, 74, false);
                    NewField145.Name = "NewField145";
                    NewField145.Value = @"ADRESİ / GÖNDEREN MAKAM";

                    NewField146 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 74, 62, 78, false);
                    NewField146.Name = "NewField146";
                    NewField146.Value = @"EMEKLİ SİCİL NO";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 66, 194, 66, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 70, 194, 70, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 74, 194, 74, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 78, 194, 78, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 62, 194, 62, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 104, 62, 108, false);
                    NewField19.Name = "NewField19";
                    NewField19.Value = @"KLİNİK";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 206, 47, 211, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.Underline = true;
                    NewField20.Value = @"DÜZENLEYEN TABİP";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 74, 133, 78, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SICILNO.Value = @"";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 81, 88, 86, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Bold = true;
                    NewField26.TextFont.Underline = true;
                    NewField26.Value = @"ŞİKAYETİ :";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 105, 88, 110, false);
                    NewField27.Name = "NewField27";
                    NewField27.TextFont.Bold = true;
                    NewField27.TextFont.Underline = true;
                    NewField27.Value = @"HİKAYESİ :";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 143, 99, 148, false);
                    NewField28.Name = "NewField28";
                    NewField28.TextFont.Bold = true;
                    NewField28.TextFont.Underline = true;
                    NewField28.Value = @"HAREKET SİSTEMİ :";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 62, 11, 182, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 165, 194, 165, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 62, 194, 182, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 182, 194, 182, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 62, 63, 182, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 186, 194, 200, false);
                    NewField41.Name = "NewField41";
                    NewField41.MultiLine = EvetHayirEnum.ehEvet;
                    NewField41.NoClip = EvetHayirEnum.ehEvet;
                    NewField41.WordBreak = EvetHayirEnum.ehEvet;
                    NewField41.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField41.Value = @"1. BU RAPOR XXXXXX AKADEMİ KURULUNUN 24.11.1992 GÜN VE 19 SAYILI OTURUMUNDA ALINAN KARAR GEREĞİNCE HEYET RAPORU YERİNE GEÇERLİDİR.                                          
2. KURUMLARINCA ÖDEME YAPILABİLMESİ İÇİN İLAÇ VE MALZEME KULLANILDI.";

                    NewField43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 206, 107, 211, false);
                    NewField43.Name = "NewField43";
                    NewField43.TextFont.Bold = true;
                    NewField43.TextFont.Underline = true;
                    NewField43.Value = @"İMZA";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 206, 164, 211, false);
                    NewField44.Name = "NewField44";
                    NewField44.TextFont.Bold = true;
                    NewField44.TextFont.Underline = true;
                    NewField44.Value = @"İMZA";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 229, 118, 234, false);
                    NewField45.Name = "NewField45";
                    NewField45.TextFont.Bold = true;
                    NewField45.TextFont.Underline = true;
                    NewField45.Value = @"BAŞTABİP ONAYI";

                    BASHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 235, 126, 255, false);
                    BASHEKIM.Name = "BASHEKIM";
                    BASHEKIM.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    BASHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    BASHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASHEKIM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"","""")";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 219, 68, 225, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.Value = @"";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 224, 68, 229, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 211, 68, 215, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 215, 68, 219, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.Value = @"";

                    XXXXXXBASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 20, 237, 25, false);
                    XXXXXXBASLIK2.Name = "XXXXXXBASLIK2";
                    XXXXXXBASLIK2.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK2.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK2.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 25, 237, 30, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 166, 62, 170, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @"KARAR";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 47, 238, 52, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "Patient";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{#PID#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 52, 238, 57, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.Value = @"{#PID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class dataset_GetOrthesisProsthesisRequest = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(0);
                    RAPOR.CalcValue = RAPOR.Value;
                    XXXXXXBASLIK.CalcValue = MyParentReport.TANI.XXXXXXBASLIK.CalcValue + @"
" + MyParentReport.TANI.XXXXXXIL.CalcValue;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    NAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    SURNAME.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = MyParentReport.TANI.NAME.CalcValue + @" " + MyParentReport.TANI.SURNAME.CalcValue;
                    NewField141.CalcValue = NewField141.Value;
                    ACTIONDATE.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Islemtarihi) : "");
                    RAPORNO.CalcValue = RAPORNO.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField145.CalcValue = NewField145.Value;
                    NewField146.CalcValue = NewField146.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    SICILNO.CalcValue = @"";
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField41.CalcValue = NewField41.Value;
                    NewField43.CalcValue = NewField43.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    DIPSIC.CalcValue = @"";
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    NewField21.CalcValue = NewField21.Value;
                    BASHEKIM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");
                    XXXXXXBASLIK2.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { RAPOR,XXXXXXBASLIK,XXXXXXIL,NAME,SURNAME,ADISOYADI,NewField141,ACTIONDATE,RAPORNO,NewField142,NewField143,NewField144,NewField145,NewField146,NewField19,NewField20,SICILNO,NewField26,NewField27,NewField28,NewField41,NewField43,NewField44,NewField45,DIPSIC,UZ,ADSOYADDOC,SINRUT,NewField21,BASHEKIM,XXXXXXBASLIK2};
                }
                public override void RunPreScript()
                {
#region TANI HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((OrthesisProsthesisThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            OrthesisProsthesisRequest pRequest = (OrthesisProsthesisRequest)context.GetObject(new Guid(sObjectID),"OrthesisProsthesisRequest");
            
            if(pRequest == null)
                throw new Exception("Rapor Ortez Protez işlemi üzerinden alınmalıdır.\r\nReason: OrthesisProsthesisRequest is null");
            
            if(pRequest.ProcedureDoctor != null)
            {
                this.ADSOYADDOC.Value = pRequest.ProcedureDoctor.Name;
                string sClassRank = pRequest.ProcedureDoctor.MilitaryClass == null ? "": pRequest.ProcedureDoctor.MilitaryClass.Name;
                sClassRank += " " + pRequest.ProcedureDoctor.Rank == null ? "" : pRequest.ProcedureDoctor.Rank.Name;
                this.SINRUT.Value = sClassRank;
                this.DIPSIC.Value = pRequest.ProcedureDoctor.DiplomaNo;
                this.UZ.Value = pRequest.ProcedureDoctor.Title.ToString();
            }
#endregion TANI HEADER_PreScript
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public OrthesisProsthesisThreeSpecialistReport MyParentReport
                {
                    get { return (OrthesisProsthesisThreeSpecialistReport)ParentReport; }
                }
                 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisThreeSpecialistReport MyParentReport
            {
                get { return (OrthesisProsthesisThreeSpecialistReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public OrthesisProsthesisThreeSpecialistReport MyParentReport
                {
                    get { return (OrthesisProsthesisThreeSpecialistReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OrthesisProsthesisThreeSpecialistReport()
        {
            TANI = new TANIGroup(this,"TANI");
            MAIN = new MAINGroup(TANI,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISTHREESPECIALISTREPORT";
            Caption = "Ortez-Protez 3 İmza Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}