using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController()
        {
            _taskRepository = new TaskRepository();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, AppTask taskUpdate)
        {
            try
            {
                _taskRepository.Update(id, taskUpdate);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("create")]
        public IActionResult Create(int listId, AppTask task)
        {
            try
            {
                var newTask = new AppTask
                {
                    Name = task.Name,
                    Description = task.Description,
                    CreatedAt = DateTime.Now,
                    DueDate = task.DueDate,
                    FrequencyId = task.FrequencyId,
                    ListId = listId,
                    IsConcluded = false,
                    PriorityId = task.PriorityId,

                };

                _taskRepository.Create(newTask);

                return StatusCode(201, task);



            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException);
            }
        }

        [HttpPatch("conclude/{id}")]
        public IActionResult Conclude (int id)
        {
            try
            {
                _taskRepository.AlterStatus(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPatch("myday/{id}")]
        public IActionResult MoveToMyDay(int id)
        {
            try
            {
                _taskRepository.MoveToMyDay(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
