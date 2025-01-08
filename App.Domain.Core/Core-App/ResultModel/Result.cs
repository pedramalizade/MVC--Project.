namespace App.EndPoints.MVC.Core_App.Models
{
    public class Result
    {
        public bool IsDone { get; set; }
        public string Message { get; set; }
        public Result(bool isdone, string message = null)
        {
            IsDone = isdone;
            Message = message;
        }
    }
}
