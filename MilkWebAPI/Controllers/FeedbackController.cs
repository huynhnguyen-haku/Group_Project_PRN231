using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Feedback;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackBusiness _feedbackBusiness;

        public FeedbackController()
        {
            _feedbackBusiness = new FeedbackBusiness();
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        [SwaggerOperation(Summary = "Get all Feedbacks")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var response = await _feedbackBusiness.GetAllFeedback();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        [SwaggerOperation(Summary = "Get Feedback by its id")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var response = await _feedbackBusiness.GetFeedbackById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbackOfProductEndPoint)]
        [SwaggerOperation(Summary = "Get Feedback by productId")]
        public async Task<IActionResult> GetFeedbackOfProduct(int productId)
        {
            var response = await _feedbackBusiness.GetFeedbackOfProduct(productId);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        [SwaggerOperation(Summary = "Create a new Feedback")]
        public async Task<IActionResult> CreateFeedback(FeedbackDTO createFeedback)
        {
            var response = await _feedbackBusiness.CreateFeedback(createFeedback);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        [SwaggerOperation(Summary = "Update Feedback Info")]
        public async Task<IActionResult> UpdateFeedback(int id, FeedbackDTO feedback)
        {
            var response = await _feedbackBusiness.UpdateFeedBack(id, feedback);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        [SwaggerOperation(Summary = "Delete Feedback")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var response = await _feedbackBusiness.DeleteFeedback(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
