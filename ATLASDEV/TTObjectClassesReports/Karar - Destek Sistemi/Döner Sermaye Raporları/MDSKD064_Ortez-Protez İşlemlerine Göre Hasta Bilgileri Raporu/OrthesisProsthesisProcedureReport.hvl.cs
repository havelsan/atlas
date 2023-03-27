
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
    /// Ortez-Protez İşlemlerine Göre Hasta Bilgileri Raporu
    /// </summary>
    public partial class OrthesisProsthesisProcedureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> PROCEDURE = new List<string>();
            public int? PROCEDUREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public AccountTrnsMedulaDontSendAndInvoicedState? STATE = (AccountTrnsMedulaDontSendAndInvoicedState?)(int?)TTObjectDefManager.Instance.DataTypes["AccountTrnsMedulaDontSendAndInvoicedState"].ConvertValue("");
            public List<string> STATEID = new List<string>();
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 38, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 3, 64, 8, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    List<String> stateList= new List<String>();
            ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if (((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.PROCEDURE == null)
                ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.PROCEDUREFLAG = 0;
            else
                ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.PROCEDUREFLAG = 1;
           
            if (((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == AccountTrnsMedulaDontSendAndInvoicedState.MedulaDontSend || ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == null)
            {
                stateList.Add("33784c3f-d601-49c4-b8da-6fa502f6a9cf");  //Medulaya Gönderilmeyecek
            }
            else
                stateList.Add("1234567890");
            ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATEID = stateList;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 273, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 2, 181, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 3, 273, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 44, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField122211 { get {return Header().NewField122211;} }
            public TTReportField STATESTRING { get {return Header().STATESTRING;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField NewField1121;
                public TTReportField ENDDATE;
                public TTReportField NewField11221;
                public TTReportField NewField112211;
                public TTReportField NewField11211;
                public TTReportField NewField122211;
                public TTReportField STATESTRING; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 17, 272, 23, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ORTEZ PROTEZ İŞLEMLERİNE GÖRE HASTA BİLGİLERİ RAPORU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 24, 40, 29, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 24, 80, 29, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 40, 34, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 29, 80, 34, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 29, 43, 34, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Size = 8;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 24, 43, 29, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Name = "Arial";
                    NewField112211.TextFont.Size = 8;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 34, 40, 39, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"İşlem Durumu";

                    NewField122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 34, 43, 39, false);
                    NewField122211.Name = "NewField122211";
                    NewField122211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122211.TextFont.Name = "Arial";
                    NewField122211.TextFont.Size = 8;
                    NewField122211.TextFont.Bold = true;
                    NewField122211.TextFont.CharSet = 162;
                    NewField122211.Value = @":";

                    STATESTRING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 34, 183, 39, false);
                    STATESTRING.Name = "STATESTRING";
                    STATESTRING.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATESTRING.TextFont.Name = "Arial";
                    STATESTRING.TextFont.Size = 8;
                    STATESTRING.TextFont.CharSet = 162;
                    STATESTRING.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1121.CalcValue = NewField1121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField122211.CalcValue = NewField122211.Value;
                    STATESTRING.CalcValue = @"";
                    return new TTReportObject[] { NewField111,NewField121,STARTDATE,NewField1121,ENDDATE,NewField11221,NewField112211,NewField11211,NewField122211,STATESTRING};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == AccountTrnsMedulaDontSendAndInvoicedState.MedulaDontSend)
            {
                STATESTRING.CalcValue = "Medulaya Gönderilmeyecek";
            }
            else if (((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == AccountTrnsMedulaDontSendAndInvoicedState.Invoiced)
            {
                STATESTRING.CalcValue = "Faturalandı";
            }
            else
                STATESTRING.CalcValue = "Medulaya Gönderilmeyecek, Faturalandı";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    List<String> stateList= new List<String>();                        
            if (((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == AccountTrnsMedulaDontSendAndInvoicedState.Invoiced || ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE == null)
            {
                stateList.Add("c768babf-2db6-422a-b06f-e1c5cc52c63b");  //Ödendi
                stateList.Add("19603fe9-1a60-4891-9a01-566c99eb3d84");  //Gönderildi
                stateList.Add("d0260db4-5e26-4c68-80ec-569cdbf346e0");  //Faturalandı
            }
            else
                stateList.Add("1234567890");
            ((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATEID = stateList;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField NewFieldb1 { get {return Header().NewFieldb1;} }
            public TTReportField NewFielda1 { get {return Header().NewFielda1;} }
            public TTReportField NewFieldc1 { get {return Header().NewFieldc1;} }
            public TTReportField NewFieldd1 { get {return Header().NewFieldd1;} }
            public TTReportField NewFieldc11 { get {return Header().NewFieldc11;} }
            public TTReportField NewFieldc111 { get {return Header().NewFieldc111;} }
            public TTReportField NewFieldc113 { get {return Header().NewFieldc113;} }
            public TTReportField NewFielda11 { get {return Header().NewFielda11;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewFieldc112 { get {return Header().NewFieldc112;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField FIYAT { get {return Footer().FIYAT;} }
            public TTReportField NewFieldc1211 { get {return Footer().NewFieldc1211;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField113211;
                public TTReportField NewFieldb1;
                public TTReportField NewFielda1;
                public TTReportField NewFieldc1;
                public TTReportField NewFieldd1;
                public TTReportField NewFieldc11;
                public TTReportField NewFieldc111;
                public TTReportField NewFieldc113;
                public TTReportField NewFielda11;
                public TTReportShape NewLine1;
                public TTReportField NewFieldc112;
                public TTReportShape NewLine3; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 23, 12, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Name = "Arial";
                    NewField113211.TextFont.Size = 8;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"Sıra No";

                    NewFieldb1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 8, 75, 12, false);
                    NewFieldb1.Name = "NewFieldb1";
                    NewFieldb1.TextFont.Name = "Arial";
                    NewFieldb1.TextFont.Size = 8;
                    NewFieldb1.TextFont.Bold = true;
                    NewFieldb1.TextFont.CharSet = 162;
                    NewFieldb1.Value = @"Hasta Adı";

                    NewFielda1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 8, 44, 12, false);
                    NewFielda1.Name = "NewFielda1";
                    NewFielda1.TextFont.Name = "Arial";
                    NewFielda1.TextFont.Size = 8;
                    NewFielda1.TextFont.Bold = true;
                    NewFielda1.TextFont.CharSet = 162;
                    NewFielda1.Value = @"TC Kimlik No";

                    NewFieldc1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 8, 96, 12, false);
                    NewFieldc1.Name = "NewFieldc1";
                    NewFieldc1.TextFont.Name = "Arial";
                    NewFieldc1.TextFont.Size = 8;
                    NewFieldc1.TextFont.Bold = true;
                    NewFieldc1.TextFont.CharSet = 162;
                    NewFieldc1.Value = @"H.Protokol No";

                    NewFieldd1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 8, 235, 12, false);
                    NewFieldd1.Name = "NewFieldd1";
                    NewFieldd1.TextFont.Name = "Arial";
                    NewFieldd1.TextFont.Size = 8;
                    NewFieldd1.TextFont.Bold = true;
                    NewFieldd1.TextFont.CharSet = 162;
                    NewFieldd1.Value = @"İşlem Adı";

                    NewFieldc11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 8, 142, 12, false);
                    NewFieldc11.Name = "NewFieldc11";
                    NewFieldc11.TextFont.Name = "Arial";
                    NewFieldc11.TextFont.Size = 8;
                    NewFieldc11.TextFont.Bold = true;
                    NewFieldc11.TextFont.CharSet = 162;
                    NewFieldc11.Value = @"İşlem Kodu";

                    NewFieldc111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 8, 119, 12, false);
                    NewFieldc111.Name = "NewFieldc111";
                    NewFieldc111.TextFont.Name = "Arial";
                    NewFieldc111.TextFont.Size = 8;
                    NewFieldc111.TextFont.Bold = true;
                    NewFieldc111.TextFont.CharSet = 162;
                    NewFieldc111.Value = @"İşlem Tarihi";

                    NewFieldc113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 8, 272, 12, false);
                    NewFieldc113.Name = "NewFieldc113";
                    NewFieldc113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldc113.TextFont.Name = "Arial";
                    NewFieldc113.TextFont.Size = 8;
                    NewFieldc113.TextFont.Bold = true;
                    NewFieldc113.TextFont.CharSet = 162;
                    NewFieldc113.Value = @"Fiyat";

                    NewFielda11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 56, 6, false);
                    NewFielda11.Name = "NewFielda11";
                    NewFielda11.TextFont.Name = "Arial";
                    NewFielda11.TextFont.Size = 8;
                    NewFielda11.TextFont.Bold = true;
                    NewFielda11.TextFont.CharSet = 162;
                    NewFielda11.Value = @"Medulaya Gönderilmeyecek";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 13, 273, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewFieldc112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 8, 249, 12, false);
                    NewFieldc112.Name = "NewFieldc112";
                    NewFieldc112.TextFont.Name = "Arial";
                    NewFieldc112.TextFont.Size = 8;
                    NewFieldc112.TextFont.Bold = true;
                    NewFieldc112.TextFont.CharSet = 162;
                    NewFieldc112.Value = @"Adet";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 6, 56, 6, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113211.CalcValue = NewField113211.Value;
                    NewFieldb1.CalcValue = NewFieldb1.Value;
                    NewFielda1.CalcValue = NewFielda1.Value;
                    NewFieldc1.CalcValue = NewFieldc1.Value;
                    NewFieldd1.CalcValue = NewFieldd1.Value;
                    NewFieldc11.CalcValue = NewFieldc11.Value;
                    NewFieldc111.CalcValue = NewFieldc111.Value;
                    NewFieldc113.CalcValue = NewFieldc113.Value;
                    NewFielda11.CalcValue = NewFielda11.Value;
                    NewFieldc112.CalcValue = NewFieldc112.Value;
                    return new TTReportObject[] { NewField113211,NewFieldb1,NewFielda1,NewFieldc1,NewFieldd1,NewFieldc11,NewFieldc111,NewFieldc113,NewFielda11,NewFieldc112};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.Invoiced)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField ADET;
                public TTReportField FIYAT;
                public TTReportField NewFieldc1211;
                public TTReportShape NewLine2; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 23;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 10, 249, 14, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{@sumof(ADET)@}";

                    FIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 10, 272, 14, false);
                    FIYAT.Name = "FIYAT";
                    FIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIYAT.TextFormat = @"#,##0.#0";
                    FIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT.NoClip = EvetHayirEnum.ehEvet;
                    FIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIYAT.TextFont.Name = "Arial";
                    FIYAT.TextFont.Size = 8;
                    FIYAT.TextFont.CharSet = 162;
                    FIYAT.Value = @"{@sumof(FIYAT)@}";

                    NewFieldc1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 10, 235, 14, false);
                    NewFieldc1211.Name = "NewFieldc1211";
                    NewFieldc1211.TextFont.Name = "Arial";
                    NewFieldc1211.TextFont.Size = 8;
                    NewFieldc1211.TextFont.Bold = true;
                    NewFieldc1211.TextFont.CharSet = 162;
                    NewFieldc1211.Value = @"Toplam";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 213, 15, 273, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADET.CalcValue = ParentGroup.FieldSums["ADET"].Value.ToString();;
                    FIYAT.CalcValue = ParentGroup.FieldSums["FIYAT"].Value.ToString();;
                    NewFieldc1211.CalcValue = NewFieldc1211.Value;
                    return new TTReportObject[] { ADET,FIYAT,NewFieldc1211};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.Invoiced)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO1 { get {return Body().SIRANO1;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField ISLEMADI { get {return Body().ISLEMADI;} }
            public TTReportField KOD { get {return Body().KOD;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField FIYAT { get {return Body().FIYAT;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>("GetOrthesisProsthesisByProcedureAndDate", AccountTransaction.GetOrthesisProsthesisByProcedureAndDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.PROCEDURE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDUREFLAG),(List<string>) MyParentReport.RuntimeParameters.STATEID));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField SIRANO1;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAADI;
                public TTReportField PROTOCOLNO;
                public TTReportField ISLEMADI;
                public TTReportField KOD;
                public TTReportField TARIH;
                public TTReportField ADET;
                public TTReportField FIYAT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 23, 5, false);
                    SIRANO1.Name = "SIRANO1";
                    SIRANO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO1.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO1.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO1.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO1.TextFont.Name = "Arial";
                    SIRANO1.TextFont.Size = 8;
                    SIRANO1.TextFont.CharSet = 162;
                    SIRANO1.Value = @"{@groupcounter@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 44, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 75, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#NAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 1, 96, 5, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    ISLEMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 235, 5, false);
                    ISLEMADI.Name = "ISLEMADI";
                    ISLEMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMADI.MultiLine = EvetHayirEnum.ehEvet;
                    ISLEMADI.NoClip = EvetHayirEnum.ehEvet;
                    ISLEMADI.WordBreak = EvetHayirEnum.ehEvet;
                    ISLEMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISLEMADI.TextFont.Name = "Arial";
                    ISLEMADI.TextFont.Size = 8;
                    ISLEMADI.TextFont.CharSet = 162;
                    ISLEMADI.Value = @"{#DESCRIPTION#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 142, 5, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Name = "Arial";
                    KOD.TextFont.Size = 8;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#EXTERNALCODE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 119, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TRANSACTIONDATE#}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 249, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{#AMOUNT#}";

                    FIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 1, 272, 5, false);
                    FIYAT.Name = "FIYAT";
                    FIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIYAT.TextFormat = @"#,##0.#0";
                    FIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT.NoClip = EvetHayirEnum.ehEvet;
                    FIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIYAT.TextFont.Name = "Arial";
                    FIYAT.TextFont.Size = 8;
                    FIYAT.TextFont.CharSet = 162;
                    FIYAT.Value = @"{#TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class dataset_GetOrthesisProsthesisByProcedureAndDate = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>(0);
                    SIRANO1.CalcValue = ParentGroup.GroupCounter.ToString();
                    TCKIMLIKNO.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.UniqueRefNo) : "");
                    HASTAADI.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.Name) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.HospitalProtocolNo) : "");
                    ISLEMADI.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.Description) : "");
                    KOD.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.ExternalCode) : "");
                    TARIH.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.TransactionDate) : "");
                    ADET.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.Amount) : "");
                    FIYAT.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate.Totalprice) : "");
                    return new TTReportObject[] { SIRANO1,TCKIMLIKNO,HASTAADI,PROTOCOLNO,ISLEMADI,KOD,TARIH,ADET,FIYAT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.Invoiced)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTEGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField NewField11132111 { get {return Header().NewField11132111;} }
            public TTReportField NewFieldb111 { get {return Header().NewFieldb111;} }
            public TTReportField NewFielda111 { get {return Header().NewFielda111;} }
            public TTReportField NewFieldc111 { get {return Header().NewFieldc111;} }
            public TTReportField NewFieldd111 { get {return Header().NewFieldd111;} }
            public TTReportField NewFieldc1111 { get {return Header().NewFieldc1111;} }
            public TTReportField NewFieldc11111 { get {return Header().NewFieldc11111;} }
            public TTReportField NewFieldc11121 { get {return Header().NewFieldc11121;} }
            public TTReportField NewFieldc11131 { get {return Header().NewFieldc11131;} }
            public TTReportField NewFielda1111 { get {return Header().NewFielda1111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField FIYAT { get {return Footer().FIYAT;} }
            public TTReportField NewFieldc112111 { get {return Footer().NewFieldc112111;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField11132111;
                public TTReportField NewFieldb111;
                public TTReportField NewFielda111;
                public TTReportField NewFieldc111;
                public TTReportField NewFieldd111;
                public TTReportField NewFieldc1111;
                public TTReportField NewFieldc11111;
                public TTReportField NewFieldc11121;
                public TTReportField NewFieldc11131;
                public TTReportField NewFielda1111;
                public TTReportShape NewLine111;
                public TTReportShape NewLine13; 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 23, 12, false);
                    NewField11132111.Name = "NewField11132111";
                    NewField11132111.TextFont.Name = "Arial";
                    NewField11132111.TextFont.Size = 8;
                    NewField11132111.TextFont.Bold = true;
                    NewField11132111.TextFont.CharSet = 162;
                    NewField11132111.Value = @"Sıra No";

                    NewFieldb111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 8, 75, 12, false);
                    NewFieldb111.Name = "NewFieldb111";
                    NewFieldb111.TextFont.Name = "Arial";
                    NewFieldb111.TextFont.Size = 8;
                    NewFieldb111.TextFont.Bold = true;
                    NewFieldb111.TextFont.CharSet = 162;
                    NewFieldb111.Value = @"Hasta Adı";

                    NewFielda111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 8, 44, 12, false);
                    NewFielda111.Name = "NewFielda111";
                    NewFielda111.TextFont.Name = "Arial";
                    NewFielda111.TextFont.Size = 8;
                    NewFielda111.TextFont.Bold = true;
                    NewFielda111.TextFont.CharSet = 162;
                    NewFielda111.Value = @"TC Kimlik No";

                    NewFieldc111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 8, 96, 12, false);
                    NewFieldc111.Name = "NewFieldc111";
                    NewFieldc111.TextFont.Name = "Arial";
                    NewFieldc111.TextFont.Size = 8;
                    NewFieldc111.TextFont.Bold = true;
                    NewFieldc111.TextFont.CharSet = 162;
                    NewFieldc111.Value = @"H.Protokol No";

                    NewFieldd111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 8, 235, 12, false);
                    NewFieldd111.Name = "NewFieldd111";
                    NewFieldd111.TextFont.Name = "Arial";
                    NewFieldd111.TextFont.Size = 8;
                    NewFieldd111.TextFont.Bold = true;
                    NewFieldd111.TextFont.CharSet = 162;
                    NewFieldd111.Value = @"İşlem Adı";

                    NewFieldc1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 8, 142, 12, false);
                    NewFieldc1111.Name = "NewFieldc1111";
                    NewFieldc1111.TextFont.Name = "Arial";
                    NewFieldc1111.TextFont.Size = 8;
                    NewFieldc1111.TextFont.Bold = true;
                    NewFieldc1111.TextFont.CharSet = 162;
                    NewFieldc1111.Value = @"İşlem Kodu";

                    NewFieldc11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 8, 119, 12, false);
                    NewFieldc11111.Name = "NewFieldc11111";
                    NewFieldc11111.TextFont.Name = "Arial";
                    NewFieldc11111.TextFont.Size = 8;
                    NewFieldc11111.TextFont.Bold = true;
                    NewFieldc11111.TextFont.CharSet = 162;
                    NewFieldc11111.Value = @"İşlem Tarihi";

                    NewFieldc11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 8, 249, 12, false);
                    NewFieldc11121.Name = "NewFieldc11121";
                    NewFieldc11121.TextFont.Name = "Arial";
                    NewFieldc11121.TextFont.Size = 8;
                    NewFieldc11121.TextFont.Bold = true;
                    NewFieldc11121.TextFont.CharSet = 162;
                    NewFieldc11121.Value = @"Adet";

                    NewFieldc11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 8, 272, 12, false);
                    NewFieldc11131.Name = "NewFieldc11131";
                    NewFieldc11131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldc11131.TextFont.Name = "Arial";
                    NewFieldc11131.TextFont.Size = 8;
                    NewFieldc11131.TextFont.Bold = true;
                    NewFieldc11131.TextFont.CharSet = 162;
                    NewFieldc11131.Value = @"Fiyat";

                    NewFielda1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 33, 6, false);
                    NewFielda1111.Name = "NewFielda1111";
                    NewFielda1111.TextFont.Name = "Arial";
                    NewFielda1111.TextFont.Size = 8;
                    NewFielda1111.TextFont.Bold = true;
                    NewFielda1111.TextFont.CharSet = 162;
                    NewFielda1111.Value = @"Faturalandı";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 13, 273, 13, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 6, 33, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11132111.CalcValue = NewField11132111.Value;
                    NewFieldb111.CalcValue = NewFieldb111.Value;
                    NewFielda111.CalcValue = NewFielda111.Value;
                    NewFieldc111.CalcValue = NewFieldc111.Value;
                    NewFieldd111.CalcValue = NewFieldd111.Value;
                    NewFieldc1111.CalcValue = NewFieldc1111.Value;
                    NewFieldc11111.CalcValue = NewFieldc11111.Value;
                    NewFieldc11121.CalcValue = NewFieldc11121.Value;
                    NewFieldc11131.CalcValue = NewFieldc11131.Value;
                    NewFielda1111.CalcValue = NewFielda1111.Value;
                    return new TTReportObject[] { NewField11132111,NewFieldb111,NewFielda111,NewFieldc111,NewFieldd111,NewFieldc1111,NewFieldc11111,NewFieldc11121,NewFieldc11131,NewFielda1111};
                }

                public override void RunScript()
                {
#region PARTE HEADER_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.MedulaDontSend)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTE HEADER_Script
                }
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField ADET;
                public TTReportField FIYAT;
                public TTReportField NewFieldc112111;
                public TTReportShape NewLine12; 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 11, 249, 15, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{@sumof(ADET)@}";

                    FIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 11, 272, 15, false);
                    FIYAT.Name = "FIYAT";
                    FIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIYAT.TextFormat = @"#,##0.#0";
                    FIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT.NoClip = EvetHayirEnum.ehEvet;
                    FIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIYAT.TextFont.Name = "Arial";
                    FIYAT.TextFont.Size = 8;
                    FIYAT.TextFont.CharSet = 162;
                    FIYAT.Value = @"{@sumof(FIYAT)@}";

                    NewFieldc112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 11, 235, 15, false);
                    NewFieldc112111.Name = "NewFieldc112111";
                    NewFieldc112111.TextFont.Name = "Arial";
                    NewFieldc112111.TextFont.Size = 8;
                    NewFieldc112111.TextFont.Bold = true;
                    NewFieldc112111.TextFont.CharSet = 162;
                    NewFieldc112111.Value = @"Toplam";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 213, 16, 273, 16, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADET.CalcValue = ParentGroup.FieldSums["ADET"].Value.ToString();;
                    FIYAT.CalcValue = ParentGroup.FieldSums["FIYAT"].Value.ToString();;
                    NewFieldc112111.CalcValue = NewFieldc112111.Value;
                    return new TTReportObject[] { ADET,FIYAT,NewFieldc112111};
                }

                public override void RunScript()
                {
#region PARTE FOOTER_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.MedulaDontSend)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTE FOOTER_Script
                }
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTDGroup : TTReportGroup
        {
            public OrthesisProsthesisProcedureReport MyParentReport
            {
                get { return (OrthesisProsthesisProcedureReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField ISLEMADI { get {return Body().ISLEMADI;} }
            public TTReportField KOD { get {return Body().KOD;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField FIYAT { get {return Body().FIYAT;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>("GetOrthesisProsthesisByProcedureAndDate2", AccountTransaction.GetOrthesisProsthesisByProcedureAndDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.PROCEDURE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDUREFLAG),(List<string>) MyParentReport.RuntimeParameters.STATEID));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public OrthesisProsthesisProcedureReport MyParentReport
                {
                    get { return (OrthesisProsthesisProcedureReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAADI;
                public TTReportField PROTOCOLNO;
                public TTReportField ISLEMADI;
                public TTReportField KOD;
                public TTReportField TARIH;
                public TTReportField ADET;
                public TTReportField FIYAT; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 23, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 44, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 75, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#NAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 1, 96, 5, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    ISLEMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 235, 5, false);
                    ISLEMADI.Name = "ISLEMADI";
                    ISLEMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMADI.MultiLine = EvetHayirEnum.ehEvet;
                    ISLEMADI.NoClip = EvetHayirEnum.ehEvet;
                    ISLEMADI.WordBreak = EvetHayirEnum.ehEvet;
                    ISLEMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISLEMADI.TextFont.Name = "Arial";
                    ISLEMADI.TextFont.Size = 8;
                    ISLEMADI.TextFont.CharSet = 162;
                    ISLEMADI.Value = @"{#DESCRIPTION#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 142, 5, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Name = "Arial";
                    KOD.TextFont.Size = 8;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#EXTERNALCODE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 119, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TRANSACTIONDATE#}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 249, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{#AMOUNT#}";

                    FIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 1, 272, 5, false);
                    FIYAT.Name = "FIYAT";
                    FIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIYAT.TextFormat = @"#,##0.#0";
                    FIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT.NoClip = EvetHayirEnum.ehEvet;
                    FIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIYAT.TextFont.Name = "Arial";
                    FIYAT.TextFont.Size = 8;
                    FIYAT.TextFont.CharSet = 162;
                    FIYAT.Value = @"{#TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class dataset_GetOrthesisProsthesisByProcedureAndDate2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TCKIMLIKNO.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.UniqueRefNo) : "");
                    HASTAADI.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.Name) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.HospitalProtocolNo) : "");
                    ISLEMADI.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.Description) : "");
                    KOD.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.ExternalCode) : "");
                    TARIH.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.TransactionDate) : "");
                    ADET.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.Amount) : "");
                    FIYAT.CalcValue = (dataset_GetOrthesisProsthesisByProcedureAndDate2 != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisByProcedureAndDate2.Totalprice) : "");
                    return new TTReportObject[] { SIRANO,TCKIMLIKNO,HASTAADI,PROTOCOLNO,ISLEMADI,KOD,TARIH,ADET,FIYAT};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    if(((OrthesisProsthesisProcedureReport)ParentReport).RuntimeParameters.STATE != AccountTrnsMedulaDontSendAndInvoicedState.MedulaDontSend)
                this.Visible = EvetHayirEnum.ehEvet;
            else 
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OrthesisProsthesisProcedureReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            PARTE = new PARTEGroup(PARTA,"PARTE");
            PARTD = new PARTDGroup(PARTE,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PROCEDURE", "", "Hizmet", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9ae2f694-85c0-42b0-a1cf-8f98ec2944f5");
            reportParameter = Parameters.Add("PROCEDUREFLAG", "", "Hizmet Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("STATE", "", "Durum", @"", false, true, false, new Guid("018b2eef-b190-4c4a-bb19-2bd1f0df1bd7"));
            reportParameter = Parameters.Add("STATEID", "", "", @"", false, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PROCEDURE"))
                _runtimeParameters.PROCEDURE = (List<string>)parameters["PROCEDURE"];
            if (parameters.ContainsKey("PROCEDUREFLAG"))
                _runtimeParameters.PROCEDUREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PROCEDUREFLAG"]);
            if (parameters.ContainsKey("STATE"))
                _runtimeParameters.STATE = (AccountTrnsMedulaDontSendAndInvoicedState?)(int?)TTObjectDefManager.Instance.DataTypes["AccountTrnsMedulaDontSendAndInvoicedState"].ConvertValue(parameters["STATE"]);
            if (parameters.ContainsKey("STATEID"))
                _runtimeParameters.STATEID = (List<string>)parameters["STATEID"];
            Name = "ORTHESISPROSTHESISPROCEDUREREPORT";
            Caption = "Ortez-Protez İşlemlerine Göre Hasta Bilgileri Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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