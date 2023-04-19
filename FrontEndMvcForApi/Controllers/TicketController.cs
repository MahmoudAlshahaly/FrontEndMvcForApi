using FrontEndMvcForApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndMvcForApi.Controllers
{
    public class TicketController : Controller
    {
        HttpClient httpClient;
        public TicketController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress =new Uri("https://localhost:44397/") ;
        }
        public async Task< IActionResult> Index()
        {
            var response=await  httpClient.GetAsync("/api/ticket/");
            var content = await response.Content.ReadAsStringAsync();
            var convertToObjects = JsonConvert.DeserializeObject<List<Ticket>>(content);
            return View(convertToObjects);
        }
        public async Task<IActionResult> GetByid(int id)
        {
            var response = await httpClient.GetAsync("/api/ticket/"+id+"");
            var content = await response.Content.ReadAsStringAsync();
            var convertToObject = JsonConvert.DeserializeObject<Ticket>(content);
            return View(convertToObject);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = await httpClient.GetAsync("/api/department/");
            var content = await response.Content.ReadAsStringAsync();
            var convertToObjects = JsonConvert.DeserializeObject<List<Department>>(content);
            Ticket t = new Ticket();
            t.Departments= convertToObjects;
             
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            var content = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,"Application/json");
            var response = await httpClient.PostAsync("/api/ticket/",content);
            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await httpClient.GetAsync("/api/ticket/" + id + "");
            var content = await response.Content.ReadAsStringAsync();

            //convert from json to object
            var convertToObject = JsonConvert.DeserializeObject<Ticket>(content);
            var responsedepart = await httpClient.GetAsync("/api/department/");
            var contentdepart = await responsedepart.Content.ReadAsStringAsync();
            var convertToObjectsdepart = JsonConvert.DeserializeObject<List<Department>>(contentdepart);
            convertToObject.Departments = convertToObjectsdepart;
            return View(convertToObject);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            //convert from object to json
            var content = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "Application/json");
            var response = await httpClient.PutAsync("/api/ticket/"+ticket.id+"", content);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await httpClient.DeleteAsync("/api/ticket/"+id+"");
            return RedirectToAction("index");
        }
    }
}
