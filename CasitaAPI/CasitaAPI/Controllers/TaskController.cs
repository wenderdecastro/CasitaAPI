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
        [HttpGet("myday")]
        public ActionResult GetMyDay(Guid userId)
        {

            return Ok(_taskRepository.GetMyDay(userId));
        }

        [HttpDelete("{id}")]
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

        [HttpGet]
        public IActionResult GetAll(Guid userId) {
            return Ok(_taskRepository.GetAll(userId));
        }

        [HttpPatch("{id}")]
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

        [HttpPost]
        public IActionResult Create(Guid userId, AppTask task, int listType)
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
                    IsConcluded = false,
                    PriorityId = task.PriorityId,
                    DueTime = task.DueTime,
                    ConcludedDate = task.ConcludedDate,
                    ResetDate = task.ResetDate,
                };

                _taskRepository.Create(userId, newTask, listType);

                return StatusCode(201, task);

            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("custom")]
        public IActionResult CreateToCustom(Guid userId, AppTask task, int listId)
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
                    IsConcluded = false,
                    PriorityId = task.PriorityId,
                    DueTime = task.DueTime,
                    ConcludedDate = task.ConcludedDate,
                    ResetDate = task.ResetDate,
                };

                _taskRepository.CreateToCustomList(userId, newTask, listId);

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
                _taskRepository.MoveToMyDay(id, 2);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
