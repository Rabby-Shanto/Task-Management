using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Handlers;
using Todo.Application.Handlers.Contracts;
using Todo.Domain.RequestModel.Task;
using Todo.Presentation.Controllers.Base;

namespace Todo.Presentation.Controllers
{
    //[Authorize]
    public class TaskManagementController(ITaskHandler taskHandler) : BaseApiController
    {
        private readonly ITaskHandler _taskHandler = taskHandler;

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskRequest request)
        {
            var response = await _taskHandler.AddTask(request);
            return Ok(response);
        }

        [HttpPost("BulkDelete")]
        public async Task<IActionResult> BulkDeleteData(BulkDeleteRequest request)
        {
            var response = await _taskHandler.BulkDeleteData(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(DeleteTaskRequest request)
        {
            var response = await _taskHandler.DeleteTask(request);
            return Ok(response);
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks([FromQuery] GetAllTaskRequest request)
        {
            var response = await _taskHandler.GetAllTasks(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetTask([FromQuery] GetTaskRequest request)
        {
            var response = await _taskHandler.GetTask(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequest request)
        {
            var response = await _taskHandler.UpdateTask(request);
            return Ok(response);
        }


    }
}