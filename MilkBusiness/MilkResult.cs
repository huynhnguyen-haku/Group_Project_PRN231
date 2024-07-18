using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public interface IMilkResult
{
    int Status { get; set; }
    string Message { get; set; }
    object? Data { get; set; }
}

public class MilkResult : IMilkResult
{
    public int Status { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public MilkResult()
    {
        Status = -1;
        Message = "Action Fail";
    }

    public MilkResult(object? data)
    {
        Status = 1;
        Message = "Action Success";
        Data = data;
    }

    public MilkResult(int staus, string message)
    {
        Status = staus;
        Message = message;
    }

    public MilkResult(int status, string message, object? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }
}
