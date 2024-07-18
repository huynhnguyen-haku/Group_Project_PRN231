using MilkData.DTOs.Gift;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class GiftBusiness
    {
        private UnitOfWork _unitOfWork;
        public GiftBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        // Get all gift
        public async Task<IMilkResult> GetAllGift()
        {
            var giftList = await _unitOfWork.GetRepository<Gift>()
                .GetListAsync(selector: x => new GetGiftDTO
                {
                    GiftId = x.GiftId,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Point = x.Point,
                    Status = x.Status,
                    UpdateDate = x.UpdateDate,
                    CreateDate = x.CreateDate,
                    Type = x.Type
                });
            return new MilkResult(giftList);
        }

        // Get gift by gift id
        public async Task<IMilkResult> GetGiftInfo(int giftId)
        {
            var gift = await _unitOfWork.GetRepository<Gift>()
                .SingleOrDefaultAsync(predicate: p => p.GiftId == giftId,
                                    selector: x => new GetGiftDTO
                                    {
                                        GiftId = x.GiftId,
                                        Name = x.Name,
                                        Quantity = x.Quantity,
                                        Description = x.Description,
                                        ImageUrl = x.ImageUrl,
                                        Point = x.Point,
                                        Status = x.Status,
                                        UpdateDate = x.UpdateDate,
                                        CreateDate = x.CreateDate,
                                        Type = x.Type
                                    });
            return new MilkResult(gift);
        }


        // Create new gift
        public async Task<IMilkResult> CreateGift(GiftDTO gift)
        {
            MilkResult result = new MilkResult();

            // Validate point (ensure non-negative)
            if (gift.Point < 0)
            {
                return new MilkResult(-2, "Point cannot be negative");
            }

            // Validate quantity (ensure non-negative)
            if (gift.Quantity < 0)
            {
                return new MilkResult(-3, "Quantity cannot be negative");
            }

            // Update status to "Gifted" if quantity is zero
            if (gift.Quantity == 0)
            {
                gift.Status = "Gifted";
            }

            Gift newGift = new Gift()
            {
                Name = gift.Name,
                Quantity = gift.Quantity,
                Description = gift.Description,
                ImageUrl = gift.ImageUrl,
                Point = gift.Point,
                Status = gift.Status,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Type = gift.Type
            };

            await _unitOfWork.GetRepository<Gift>().InsertAsync(newGift);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (isSuccessful)
            {
                result = new MilkResult(1, "Create successfully");
            }
            else
            {
                result.Status = -1;
                result.Message = "Create gift failed";
            }

            return result;
        }

        // Update gift info
        public async Task<IMilkResult> UpdateGiftInfo(int id, GiftDTO giftInfo)
        {
            Gift currentGift = await _unitOfWork.GetRepository<Gift>()
                .SingleOrDefaultAsync(predicate: p => p.GiftId == id);

            if (currentGift == null)
            {
                return new MilkResult(-1, "Gift not found");
            }
            else
            {
                // Validate point (ensure non-negative)
                if (giftInfo.Point < 0)
                {
                    return new MilkResult(-2, "Point cannot be negative");
                }

                // Validate quantity (ensure non-negative)
                if (giftInfo.Quantity < 0)
                {
                    return new MilkResult(-3, "Quantity cannot be negative");
                }

                // Update status to "Gifted" if quantity is zero
                if (giftInfo.Quantity == 0)
                {
                    giftInfo.Status = "Gifted";
                }

                currentGift.Name = String.IsNullOrEmpty(giftInfo.Name) ? currentGift.Name : giftInfo.Name;
                currentGift.Quantity = giftInfo.Quantity;
                currentGift.Description = String.IsNullOrEmpty(giftInfo.Description) ? currentGift.Description : giftInfo.Description;
                currentGift.ImageUrl = String.IsNullOrEmpty(giftInfo.ImageUrl) ? currentGift.ImageUrl : giftInfo.ImageUrl;
                currentGift.Point = giftInfo.Point;
                currentGift.Status = giftInfo.Status;
                currentGift.UpdateDate = DateTime.Now;
                currentGift.Type = giftInfo.Type;

                _unitOfWork.GetRepository<Gift>().UpdateAsync(currentGift);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(giftInfo);
        }

        // Delete gift
        public async Task<IMilkResult> DeleteGift(int giftId)
        {
            Gift gift = await _unitOfWork.GetRepository<Gift>()
                .SingleOrDefaultAsync(predicate: p => p.GiftId == giftId);
            if (gift == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Gift>().DeleteAsync(gift);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(1, "Delete successfully");
        }

        // Change gift status
        public async Task<IMilkResult> ChangeGiftStatus(int giftId, string newStatus)
        {
            if (newStatus.ToLower() != "Inactive" && newStatus.ToLower() != "Active")
            {
                return new MilkResult(-4, "Invalid status. Status must be 'inactive' or 'active'");
            }

            Gift currentGift = await _unitOfWork.GetRepository<Gift>()
              .SingleOrDefaultAsync(predicate: p => p.GiftId == giftId);

            if (currentGift == null)
            {
                return new MilkResult(-1, "Gift not found");
            }
            else
            {
                currentGift.Status = newStatus;
                currentGift.UpdateDate = DateTime.Now;

                _unitOfWork.GetRepository<Gift>().UpdateAsync(currentGift);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(1, "Status changed successfully");
        }
    }
}

