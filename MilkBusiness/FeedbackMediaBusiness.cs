using MilkData.DTOs.FeedbackMedia;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public class FeedbackMediaBusiness
{
    private UnitOfWork _unitOfWork;

    public FeedbackMediaBusiness()
    {
        _unitOfWork = new UnitOfWork();
    }

    public async Task<IMilkResult> GetAllFeMedia()
    {
        var feMediaList = await _unitOfWork.GetRepository<FeedbackMedia>()
            .GetListAsync(selector: fm => new GetFeedbackMediaDTO
            {
                FeedbackId = fm.FeedbackId,
                UpdateDate = fm.UpdateDate,
                CreateDate = fm.CreateDate,
                FeedbackMediaId = fm.FeedbackMediaId,
                MediaType = fm.MediaType,
                MediaUrl = fm.MediaUrl
            });
        return new MilkResult(feMediaList);
    }

    public async Task<IMilkResult> GetFeMedaiInfo(int feMediaId)
    {
        var feMedia = await _unitOfWork.GetRepository<FeedbackMedia>()
            .SingleOrDefaultAsync(predicate: fm => fm.FeedbackMediaId == feMediaId,
                                  selector: fm => new GetFeedbackMediaDTO
                                  {
                                      FeedbackId = fm.FeedbackId,
                                      UpdateDate = fm.UpdateDate,
                                      CreateDate = fm.CreateDate,
                                      FeedbackMediaId = fm.FeedbackMediaId,
                                      MediaType = fm.MediaType,
                                      MediaUrl = fm.MediaUrl
                                  });
        return new MilkResult(feMedia);
    }

    public async Task<IMilkResult> CreateFeMedia(FeedbackMediaDTO feMedia)
    {
        MilkResult result = new MilkResult();

        FeedbackMedia feedbackMedia = new FeedbackMedia()
        {
            MediaType = feMedia.MediaType,
            FeedbackId = feMedia.FeedbackId,
            MediaUrl = feMedia.MediaUrl,
            CreateDate = feMedia.CreateDate,
            UpdateDate = feMedia.UpdateDate
        };

        await _unitOfWork.GetRepository<FeedbackMedia>().InsertAsync(feedbackMedia);
        bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

        if (!isSuccessful)
        {
            result.Status = -1;
            result.Message = "Create unsuccessfully";
        }
        else
        {
            result = new MilkResult(1, "Create Susscessfull");
        }

        return result;
    }

    public async Task<IMilkResult> UpdateFeMediaInfo(int id, FeedbackMediaDTO feedbackMedia)
    {
        FeedbackMedia currentFeMedia = await _unitOfWork.GetRepository<FeedbackMedia>()
            .SingleOrDefaultAsync(predicate: fm => fm.FeedbackMediaId == id);
        if (currentFeMedia == null) return new MilkResult(-1, "Feedback media cannot be found");
        else
        {
            currentFeMedia.MediaUrl = String.IsNullOrEmpty(feedbackMedia.MediaUrl) ? currentFeMedia.MediaUrl : feedbackMedia.MediaUrl;
            currentFeMedia.MediaType = String.IsNullOrEmpty(feedbackMedia.MediaType) ? currentFeMedia.MediaType : feedbackMedia.MediaType;
            currentFeMedia.FeedbackId = feedbackMedia.FeedbackId;
            currentFeMedia.CreateDate = feedbackMedia.CreateDate;
            currentFeMedia.UpdateDate = feedbackMedia.UpdateDate;

            _unitOfWork.GetRepository<FeedbackMedia>().UpdateAsync(currentFeMedia);
            await _unitOfWork.CommitAsync();
        }

        return new MilkResult(currentFeMedia);
    }

    public async Task<IMilkResult> DeleteFeedbackMedia(int id)
    {
        FeedbackMedia currentFeMedia = await _unitOfWork.GetRepository<FeedbackMedia>()
           .SingleOrDefaultAsync(predicate: fm => fm.FeedbackMediaId == id);
        if (currentFeMedia == null) return new MilkResult(-1, "Feedback cannot be found");
        else
        {
            _unitOfWork.GetRepository<FeedbackMedia>().DeleteAsync(currentFeMedia);
            await _unitOfWork.CommitAsync();
        }

        return new MilkResult("Delete Successfull");
    }
}
