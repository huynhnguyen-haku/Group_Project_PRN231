using MilkData.DTOs.Voucher;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class VoucherBusiness
    {
        private UnitOfWork _unitOfWork;
        public VoucherBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<IMilkResult> GetAllVoucher()
        {
            var voucherList = await _unitOfWork.GetRepository<Voucher>()
                .GetListAsync(selector: x => new GetVoucherDTO
                {
                    VoucherId = x.VoucherId,
                    Value = x.Value,
                    Type = x.Type,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status,
                });
            return new MilkResult(voucherList);
        }

        // Get voucher by voucher id
        public async Task<IMilkResult> GetVoucherInfo(Guid voucherId)
        {
            var voucher = await _unitOfWork.GetRepository<Voucher>()
                .SingleOrDefaultAsync(predicate: p => p.VoucherId == voucherId,
                                    selector: x => new GetVoucherDTO
                                    {
                                        VoucherId = x.VoucherId,
                                        Value = x.Value,
                                        Type = x.Type,
                                        Description = x.Description,
                                        StartDate = x.StartDate,
                                        EndDate = x.EndDate,
                                        Status = x.Status,
                                    });
            return new MilkResult(voucher);
        }

        // Get voucher by type
        public async Task<IMilkResult> GetVoucherByType(string type)
        {
            var voucherList = await _unitOfWork.GetRepository<Voucher>()
                .GetListAsync(predicate: p => p.Type == type,
                            selector: x => new GetVoucherDTO
                            {
                                VoucherId = x.VoucherId,
                                Value = x.Value,
                                Type = x.Type,
                                Description = x.Description,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                Status = x.Status,
                            });
            return new MilkResult(voucherList);
        }

        // Create new voucher
        public async Task<IMilkResult> CreateVoucher(VoucherDTO voucher)
        {
            MilkResult result = new MilkResult();
            Voucher newVoucher = new Voucher
            {
                Value = voucher.Value,
                Type = voucher.Type,
                Description = SetVoucherDescription(voucher.Type, voucher.Value),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Status = voucher.Status,
            };

            await _unitOfWork.GetRepository<Voucher>().InsertAsync(newVoucher);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (isSuccessful)
            {
                result = new MilkResult(1, "Create successfully");
            }
            else
            {
                result.Status = -1;
                result.Message = "Create voucher failed";
            }

            return result;
        }

        public async Task<IMilkResult> UpdateVoucherInfo(Guid voucherId, VoucherDTO voucher)
        {
            MilkResult result = new MilkResult();

            // Validate voucher id
            if (voucherId == null)
            {
                return new MilkResult(-6, "Invalid voucher ID. ID must be a positive integer.");
            }

            // Retrieve existing voucher
            Voucher existingVoucher = await _unitOfWork.GetRepository<Voucher>()
              .SingleOrDefaultAsync(predicate: p => p.VoucherId == voucherId);

            if (existingVoucher == null)
            {
                return new MilkResult(-7, "Voucher not found");
            }

            existingVoucher.Value = voucher.Value;
            existingVoucher.Type = voucher.Type;
            existingVoucher.Description = SetVoucherDescription(voucher.Type, voucher.Value);
            existingVoucher.EndDate = voucher.EndDate;
            existingVoucher.Status = voucher.Status;

            _unitOfWork.GetRepository<Voucher>().UpdateAsync(existingVoucher);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (isSuccessful)
            {
                result = new MilkResult(1, "Update successfully");
            }
            else
            {
                result.Status = -1;
                result.Message = "Update voucher failed";
            }

            return result;
        }

        public async Task<IMilkResult> DeleteVoucher(Guid voucherId)
        {
            Voucher voucher = await _unitOfWork.GetRepository<Voucher>()
                              .SingleOrDefaultAsync(predicate: p => p.VoucherId == voucherId);
            if (voucher == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Voucher>().DeleteAsync(voucher);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult();
        }

        #region Utils Function
        private string SetVoucherDescription(string type, decimal value)
        {
            switch (type.ToLower())
            {
                case "discount":
                    return $"Giảm giá {(value)}% cho toàn bộ đơn hàng";
                case "freeship":
                    return $"Giảm giá {(value)}% phí vận chuyển cho đơn hàng";
                case "value":
                    return $"Giảm giá {(value)} VND cho toàn bộ đơn hàng";
                default:
                    return "Loại voucher không hợp lệ";
            }
        }
        #endregion
    }
}
