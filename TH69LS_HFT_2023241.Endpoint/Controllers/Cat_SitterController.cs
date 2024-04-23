using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TH69LS_HFT_2023241.Endpoint.Services;
using TH69LS_HFT_2023241.Logic;
using TH69LS_HFT_2023241.Models;


namespace TH69LS_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Cat_SitterController : ControllerBase
    {
        ICat_SitterLogic logic;
        IHubContext<SignalRHub> hub;

        public Cat_SitterController(ICat_SitterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cat_Sitter> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Cat_Sitter Read(int ID)
        {
            return this.logic.Read(ID);
        }

        [HttpPost]
        public void Create([FromBody] Cat_Sitter v)
        {
            this.logic.Create(v);
            this.hub.Clients.All.SendAsync("Cat_SitterCreated", v);
        }

        [HttpPut]
        public void Update([FromBody] Cat_Sitter v)
        {
            this.logic.Update(v);
            this.hub.Clients.All.SendAsync("Cat_SitterUpdated", v);
        }

        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            var companyToDelete = this.logic.Read(ID);
            this.logic.Delete(ID);
            this.hub.Clients.All.SendAsync("Cat_SitterDeleted", companyToDelete);
        }
    }
}
