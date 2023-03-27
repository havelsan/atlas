using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class SendToENabizTestServiceController : Controller
    {
        [HttpPost]
        public void Send250()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend250("27de2867-6a46-4af6-8aff-018365b6fc11");
        }

        [HttpPost]
        public void Send101()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend101("49ab1c87-4dea-4d01-b948-62a3df5c24c1");
        }

        [HttpPost]
        public void Send102()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend102("54fbd213-c7db-4837-9476-7834abe8fa29");

        }

        [HttpPost]
        public void Send103()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend103("02444a55-526a-4871-8d08-53b21c04d3d6");
        }

        [HttpPost]
        public void Send104()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend104("14666af3-a302-4187-9f5a-bc0016d63f42");
        }

        [HttpPost]
        public void Send226()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend226("8ec5558d-471b-46dc-adf0-eff4f2e2cc5c");
        }

        [HttpPost]
        public void Send105()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend105("13779489-fde2-41fe-98ec-79b566adca5f");
        }

        [HttpPost]
        public void Send407()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend407(null,null);
        }

        [HttpPost]
        public void Send219()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend219("2400a67c-15f3-45d0-ba93-45372f15fb86");
        }

        [HttpPost]
        public void Send106()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend106("3e2a6f67-9326-4321-bf6e-032730f5482e");
        }

        [HttpPost]
        public void Send215()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend215("69ba7676-470b-481d-b71d-b12da4ceb5df");
        }

        [HttpPost]
        public void Send235()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend235("a20c2c60-b660-4159-8908-6e7641db94ce");
        }
        [HttpPost]
        public void Send302()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend302("cace65b9-4cbc-4c0f-ad86-bddf61f28001");
        }

        [HttpPost]
        public void Send301()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend301("66e8f82a-dbcf-490b-8e70-12d035b37660");
        }

        [HttpGet]
        public void Send901(DateTime Date)
        {
         
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend901();
        }

        [HttpPost]
        public void Send201()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend201("8d0e6159-63b6-481b-b73e-63910bb5a308");
        }

        [HttpPost]
        public void Send214()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend214("c685b243-32ed-4273-aed1-68ac974aea77");
        }

        [HttpPost]
        public void Send200()
        {
           
        }

        [HttpPost]
        public void Send409()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend409("d8777fc0-0446-4d9a-a9fd-14fee03f1f53");
        }

        [HttpPost]
        public void Send203()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend203("db509ac4-d89e-4396-a1f8-b8f95f47d1a4");
        }
    }
}
