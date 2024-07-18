using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.FeedbackMedia;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class FeedbackMediaController : ControllerBase
    {
        private readonly FeedbackMediaBusiness _feedbackMediaBusiness;
        public FeedbackMediaController()
        {
            _feedbackMediaBusiness = new FeedbackMediaBusiness();
        }

        [HttpGet(ApiEndPointConstant.FeedbackMedia.FeedbackMediaEndPoint)]
        [SwaggerOperation(Summary = "Get all Feedback Media")]
        public async Task<IActionResult> GetAllFeedbackMedia()
        {
            var response = await _feedbackMediaBusiness.GetAllFeMedia();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response.Message);
        }

        [HttpGet(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        [SwaggerOperation(Summary = "Get Feedback Media by its id")]
        public async Task<IActionResult> GetAllFeedbackMedia(int id)
        {
            var response = await _feedbackMediaBusiness.GetFeMedaiInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.FeedbackMedia.FeedbackMediaEndPoint)]
        [SwaggerOperation(Summary = "Create a new Feedback Media")]
        public async Task<IActionResult> CreateFeedbackMedia(FeedbackMediaDTO feedbackMedia)
        {
            var response = await _feedbackMediaBusiness.CreateFeMedia(feedbackMedia);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        [SwaggerOperation(Summary = "Update Feedback Media Info")]
        public async Task<IActionResult> UpdateFeedbackMedia(int id, FeedbackMediaDTO feedbackMedia)
        {
            var response = await _feedbackMediaBusiness.UpdateFeMediaInfo(id, feedbackMedia);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        [SwaggerOperation(Summary = "Delete Feedback Media")]
        public async Task<IActionResult> DeleteFeedbackMedia(int id)
        {
            var response = await _feedbackMediaBusiness.DeleteFeedbackMedia(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
