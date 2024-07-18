using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Voucher;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly VoucherBusiness _voucherBusiness;
        public VoucherController()
        {
            _voucherBusiness = new VoucherBusiness();
        }

        [HttpGet(ApiEndPointConstant.Voucher.VouchersEndpoint)]
        [SwaggerOperation(Summary = "Get all Vouchers")]
        public async Task<IActionResult> GetAllVouchers()
        {
            var response = await _voucherBusiness.GetAllVoucher();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Voucher.VoucherEndpoint)]
        [SwaggerOperation(Summary = "Get Voucher by its id")]
        public async Task<IActionResult> GetVoucherInfo(Guid id)
        {
            var response = await _voucherBusiness.GetVoucherInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Voucher.VoucherEndpointByType)]
        [SwaggerOperation(Summary = "Get Voucher by its type")]
        public async Task<IActionResult> GetVoucherByType(string type)
        {
            var response = await _voucherBusiness.GetVoucherByType(type);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Voucher.VouchersEndpoint)]
        [SwaggerOperation(Summary = "Create a new Voucher")]
        public async Task<IActionResult> CreateVoucher(VoucherDTO voucher)
        {
            var response = await _voucherBusiness.CreateVoucher(voucher);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Voucher.VoucherEndpoint)]
        [SwaggerOperation(Summary = "Update Voucher Info")]
        public async Task<IActionResult> UpdateVoucherInfo(Guid id, VoucherDTO voucher)
        {
            var response = await _voucherBusiness.UpdateVoucherInfo(id, voucher);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Voucher.VoucherEndpoint)]
        [SwaggerOperation(Summary = "Delete Voucher")]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            var response = await _voucherBusiness.DeleteVoucher(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

    }
}
