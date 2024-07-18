using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Gift;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    public class GiftController : ControllerBase
    {
        private readonly GiftBusiness _giftBusiness;
        public GiftController()
        {
            _giftBusiness = new GiftBusiness();
        }

        [HttpGet(ApiEndPointConstant.Gift.GiftsEndpoint)]
        [SwaggerOperation(Summary = "Get all Gifts")]
        public async Task<IActionResult> GetAllGifts()
        {
            var response = await _giftBusiness.GetAllGift();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Gift.GiftEndpoint)]
        [SwaggerOperation(Summary = "Get Gift by its id")]
        public async Task<IActionResult> GetGiftInfo(int id)
        {
            var response = await _giftBusiness.GetGiftInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Gift.GiftsEndpoint)]
        [SwaggerOperation(Summary = "Create a new Gift")]
        public async Task<IActionResult> CreateGift(GiftDTO gift)
        {
            var response = await _giftBusiness.CreateGift(gift);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Gift.GiftEndpoint)]
        [SwaggerOperation(Summary = "Update Gift Info")]
        public async Task<IActionResult> UpdateGiftInfo(int id, GiftDTO gift)
        {
            var response = await _giftBusiness.UpdateGiftInfo(id, gift);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Gift.GiftEndpoint)]
        [SwaggerOperation(Summary = "Delete Gift")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            var response = await _giftBusiness.DeleteGift(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
